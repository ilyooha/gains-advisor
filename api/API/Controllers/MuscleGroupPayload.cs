namespace API.Controllers;

public record MuscleGroupPayload(string Name, Guid? ParentId = null);