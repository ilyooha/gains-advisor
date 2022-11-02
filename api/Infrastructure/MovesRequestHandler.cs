using MediatR;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Infrastructure;

public class MovesRequestHandler : IRequestHandler<CreateMoveRequest, Guid>,
    IRequestHandler<UpdateMoveRequest>, IRequestHandler<DeleteMoveRequest>,
    IRequestHandler<GetMoveByIdRequest, IMove?>, IRequestHandler<GetMovesRequest, IMove[]>
{
    private readonly AppDbContext _dbContext;

    public MovesRequestHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateMoveRequest request, CancellationToken cancellationToken)
    {
        var name = NormalizeName(request.Name);

        var existingMovement = await _dbContext.Moves
            .FirstOrDefaultAsync(MoveSpecs.ByName(name), cancellationToken);

        if (existingMovement is not null)
            return existingMovement.Id;

        var newMovement = new EfMove
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        await _dbContext.Moves.AddAsync(newMovement, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return newMovement.Id;
    }

    public async Task<Unit> Handle(UpdateMoveRequest request, CancellationToken cancellationToken)
    {
        var existingMovement = await _dbContext.Moves
            .FirstOrDefaultAsync(MoveSpecs.ById(request.Id), cancellationToken);

        if (existingMovement is null)
            throw new ArgumentException("Movement doesn't exist", nameof(request));

        var name = NormalizeName(request.Name);
        if (existingMovement.Name.Equals(name))
            return Unit.Value;

        existingMovement.Name = name;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> Handle(DeleteMoveRequest request, CancellationToken cancellationToken)
    {
        var existingMovement = await _dbContext.Moves
            .FirstOrDefaultAsync(MoveSpecs.ById(request.Id), cancellationToken);

        if (existingMovement is null)
            return Unit.Value;

        _dbContext.Moves.Remove(existingMovement);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    private static string NormalizeName(string input)
    {
        return input
            .Trim()
            .RemoveLineBreaks()
            .RemoveDoubleSpaces();
    }

    public async Task<IMove?> Handle(GetMoveByIdRequest request, CancellationToken cancellationToken)
    {
        var move = await _dbContext.Moves
            .AsNoTracking()
            .FirstOrDefaultAsync(MoveSpecs.ById(request.Id), cancellationToken);

        return move is null
            ? null
            : Map(move);
    }

    public async Task<IMove[]> Handle(GetMovesRequest request, CancellationToken cancellationToken)
    {
        var moves = await _dbContext.Moves
            .AsNoTracking()
            .Where(MoveSpecs.ByQuery(request.Query))
            .ToArrayAsync(cancellationToken);

        return moves.Select(Map).ToArray();
    }

    private static IMove Map(EfMove source)
    {
        return new Move(source.Id, source.Name);
    }
}