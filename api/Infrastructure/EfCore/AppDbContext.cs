using Infrastructure.EfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EfCore;

public class AppDbContext : DbContext
{
    public DbSet<EfMove> Moves { get; set; } = null!;
    public DbSet<EfMuscleGroup> MuscleGroups { get; set; } = null!;
    public DbSet<EfMuscleGroupConnection> MuscleGroupConnections { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EfMoveConfiguration());
        modelBuilder.ApplyConfiguration(new EfMuscleGroupConfiguration());
        modelBuilder.ApplyConfiguration(new EfMuscleGroupConnectionConfiguration());
        modelBuilder.ApplyConfiguration(new EfMuscleGroupActivationDataConfiguration());

        

        modelBuilder.Entity<EfMuscleGroup>()
            .HasData(
                new EfMuscleGroup
                {
                    Id = new Guid("028cdbc7-ced6-41bc-a044-50dcdc7e82fc"),
                    Name = "Back"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("b3b2ea3a-a7df-477b-ad56-13a736da9a69"),
                    Name = "Lats"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("d3949e3f-a54d-44ff-b27d-b9e14d3f377b"),
                    Name = "Rhomboids"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("a2661688-d504-4149-8965-4dd28e53781a"),
                    Name = "Traps"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("d589505d-8cbe-4a5a-986a-f6713b460d99"),
                    Name = "Spinal Erectors"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("c9cb2feb-ddfd-4921-9a65-50ac70dffe4e"),
                    Name = "Chest"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("ae188fb5-8115-4184-bce9-82802ba9c6c8"),
                    Name = "Upper Chest"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("d0e96626-b353-4881-aafa-851020c2fe9a"),
                    Name = "Mid Chest"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("86e5a5c5-8782-48f4-8506-015670f38a1d"),
                    Name = "Lower Chest"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("f18a77b0-3adb-4679-b9a5-e622445f404a"),
                    Name = "Shoulders"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("ecad75a2-1d16-4cbe-9a9c-9864a4cd80aa"),
                    Name = "Front Delts"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("bdd9fee2-1dc3-48d5-b4f7-dc22d2b505d6"),
                    Name = "Mid Delts"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("6615486e-50b7-409b-96f4-1fbf0e8bc416"),
                    Name = "Rear Delts"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("e0ac13e0-4bf9-4af9-a873-b22f66ee9e89"),
                    Name = "Legs"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("0ddec529-033d-4435-9813-7ca63950ff2d"),
                    Name = "Quads"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("5ec7b81b-e3af-4520-9798-b774ccc1758e"),
                    Name = "Glutes"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("60724155-2cbe-4506-9f44-fe93a903a295"),
                    Name = "Hamstrings"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("c2d52c36-b845-4043-8fbe-d44356f1437b"),
                    Name = "Calves"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("3440453f-e4e9-48d9-827d-5ca02e3f0568"),
                    Name = "Core"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("0df3ec9b-031f-4bf9-8ae5-5df48af8b66d"),
                    Name = "Abs"
                },
                new EfMuscleGroup
                {
                    Id = new Guid("e0a5e4bb-987e-438e-a894-9c1a62f1c07f"),
                    Name = "Obliques"
                });

        modelBuilder.Entity<EfMuscleGroupConnection>()
            .HasData(
                // back - back : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("028cdbc7-ced6-41bc-a044-50dcdc7e82fc"),
                    DescendantId = new Guid("028cdbc7-ced6-41bc-a044-50dcdc7e82fc"),
                    Depth = 0
                },
                // back - lats : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("028cdbc7-ced6-41bc-a044-50dcdc7e82fc"),
                    DescendantId = new Guid("b3b2ea3a-a7df-477b-ad56-13a736da9a69"),
                    Depth = 1
                },
                // back - traps : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("028cdbc7-ced6-41bc-a044-50dcdc7e82fc"),
                    DescendantId = new Guid("a2661688-d504-4149-8965-4dd28e53781a"),
                    Depth = 1
                },
                // back - rhomboids : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("028cdbc7-ced6-41bc-a044-50dcdc7e82fc"),
                    DescendantId = new Guid("d3949e3f-a54d-44ff-b27d-b9e14d3f377b"),
                    Depth = 1
                },
                // back - spinal erectors : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("028cdbc7-ced6-41bc-a044-50dcdc7e82fc"),
                    DescendantId = new Guid("d589505d-8cbe-4a5a-986a-f6713b460d99"),
                    Depth = 1
                },
                // lats - lats : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("b3b2ea3a-a7df-477b-ad56-13a736da9a69"),
                    DescendantId = new Guid("b3b2ea3a-a7df-477b-ad56-13a736da9a69"),
                    Depth = 0
                },
                // traps - traps : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("a2661688-d504-4149-8965-4dd28e53781a"),
                    DescendantId = new Guid("a2661688-d504-4149-8965-4dd28e53781a"),
                    Depth = 0
                },
                // rhomboids - rhomboids : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("d3949e3f-a54d-44ff-b27d-b9e14d3f377b"),
                    DescendantId = new Guid("d3949e3f-a54d-44ff-b27d-b9e14d3f377b"),
                    Depth = 0
                },
                // spinal erectors - spinal erectors : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("d589505d-8cbe-4a5a-986a-f6713b460d99"),
                    DescendantId = new Guid("d589505d-8cbe-4a5a-986a-f6713b460d99"),
                    Depth = 0
                },
                // chest - chest : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("c9cb2feb-ddfd-4921-9a65-50ac70dffe4e"),
                    DescendantId = new Guid("c9cb2feb-ddfd-4921-9a65-50ac70dffe4e"),
                    Depth = 0
                },
                // chest - upper chest : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("c9cb2feb-ddfd-4921-9a65-50ac70dffe4e"),
                    DescendantId = new Guid("ae188fb5-8115-4184-bce9-82802ba9c6c8"),
                    Depth = 1
                },
                // chest - mid chest : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("c9cb2feb-ddfd-4921-9a65-50ac70dffe4e"),
                    DescendantId = new Guid("d0e96626-b353-4881-aafa-851020c2fe9a"),
                    Depth = 1
                },
                // chest - lower chest : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("c9cb2feb-ddfd-4921-9a65-50ac70dffe4e"),
                    DescendantId = new Guid("86e5a5c5-8782-48f4-8506-015670f38a1d"),
                    Depth = 1
                },
                // upper chest - upper chest : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("ae188fb5-8115-4184-bce9-82802ba9c6c8"),
                    DescendantId = new Guid("ae188fb5-8115-4184-bce9-82802ba9c6c8"),
                    Depth = 0
                },
                // mid chest - mid chest : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("d0e96626-b353-4881-aafa-851020c2fe9a"),
                    DescendantId = new Guid("d0e96626-b353-4881-aafa-851020c2fe9a"),
                    Depth = 0
                },
                // lower chest - lower chest : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("86e5a5c5-8782-48f4-8506-015670f38a1d"),
                    DescendantId = new Guid("86e5a5c5-8782-48f4-8506-015670f38a1d"),
                    Depth = 0
                },
                // 
                // shoulders - shoulders : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("f18a77b0-3adb-4679-b9a5-e622445f404a"),
                    DescendantId = new Guid("f18a77b0-3adb-4679-b9a5-e622445f404a"),
                    Depth = 0
                },
                // shoulders - front delts : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("f18a77b0-3adb-4679-b9a5-e622445f404a"),
                    DescendantId = new Guid("ecad75a2-1d16-4cbe-9a9c-9864a4cd80aa"),
                    Depth = 1
                },
                // shoulders - mid delts : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("f18a77b0-3adb-4679-b9a5-e622445f404a"),
                    DescendantId = new Guid("bdd9fee2-1dc3-48d5-b4f7-dc22d2b505d6"),
                    Depth = 1
                },
                // shoulders - rear delts : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("f18a77b0-3adb-4679-b9a5-e622445f404a"),
                    DescendantId = new Guid("6615486e-50b7-409b-96f4-1fbf0e8bc416"),
                    Depth = 1
                },
                // front delts - front delts : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("ecad75a2-1d16-4cbe-9a9c-9864a4cd80aa"),
                    DescendantId = new Guid("ecad75a2-1d16-4cbe-9a9c-9864a4cd80aa"),
                    Depth = 0
                },
                // mid delts - mid delts : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("bdd9fee2-1dc3-48d5-b4f7-dc22d2b505d6"),
                    DescendantId = new Guid("bdd9fee2-1dc3-48d5-b4f7-dc22d2b505d6"),
                    Depth = 0
                },
                // rear delts - rear delts : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("6615486e-50b7-409b-96f4-1fbf0e8bc416"),
                    DescendantId = new Guid("6615486e-50b7-409b-96f4-1fbf0e8bc416"),
                    Depth = 0
                },
                //
                // legs - legs : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("e0ac13e0-4bf9-4af9-a873-b22f66ee9e89"),
                    DescendantId = new Guid("e0ac13e0-4bf9-4af9-a873-b22f66ee9e89"),
                    Depth = 0
                },
                // legs - quads : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("e0ac13e0-4bf9-4af9-a873-b22f66ee9e89"),
                    DescendantId = new Guid("0ddec529-033d-4435-9813-7ca63950ff2d"),
                    Depth = 1
                },
                // legs - glutes : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("e0ac13e0-4bf9-4af9-a873-b22f66ee9e89"),
                    DescendantId = new Guid("5ec7b81b-e3af-4520-9798-b774ccc1758e"),
                    Depth = 1
                },
                // legs - hamstrings : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("e0ac13e0-4bf9-4af9-a873-b22f66ee9e89"),
                    DescendantId = new Guid("60724155-2cbe-4506-9f44-fe93a903a295"),
                    Depth = 1
                },
                // legs - calves : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("e0ac13e0-4bf9-4af9-a873-b22f66ee9e89"),
                    DescendantId = new Guid("c2d52c36-b845-4043-8fbe-d44356f1437b"),
                    Depth = 1
                },
                // quads - quads : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("0ddec529-033d-4435-9813-7ca63950ff2d"),
                    DescendantId = new Guid("0ddec529-033d-4435-9813-7ca63950ff2d"),
                    Depth = 0
                },
                // glutes - glutes : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("5ec7b81b-e3af-4520-9798-b774ccc1758e"),
                    DescendantId = new Guid("5ec7b81b-e3af-4520-9798-b774ccc1758e"),
                    Depth = 0
                },
                // hamstrings - hamstrings : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("60724155-2cbe-4506-9f44-fe93a903a295"),
                    DescendantId = new Guid("60724155-2cbe-4506-9f44-fe93a903a295"),
                    Depth = 0
                },
                // calves - calves : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("c2d52c36-b845-4043-8fbe-d44356f1437b"),
                    DescendantId = new Guid("c2d52c36-b845-4043-8fbe-d44356f1437b"),
                    Depth = 0
                },
                //
                // core - core : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("3440453f-e4e9-48d9-827d-5ca02e3f0568"),
                    DescendantId = new Guid("3440453f-e4e9-48d9-827d-5ca02e3f0568"),
                    Depth = 0
                },
                // core - abs : 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("3440453f-e4e9-48d9-827d-5ca02e3f0568"),
                    DescendantId = new Guid("0df3ec9b-031f-4bf9-8ae5-5df48af8b66d"),
                    Depth = 1
                },
                // core - obliques: 1
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("3440453f-e4e9-48d9-827d-5ca02e3f0568"),
                    DescendantId = new Guid("e0a5e4bb-987e-438e-a894-9c1a62f1c07f"),
                    Depth = 1
                },
                // abs - abs : 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("0df3ec9b-031f-4bf9-8ae5-5df48af8b66d"),
                    DescendantId = new Guid("0df3ec9b-031f-4bf9-8ae5-5df48af8b66d"),
                    Depth = 0
                },
                // obliques - obliques: 0
                new EfMuscleGroupConnection
                {
                    AncestorId = new Guid("e0a5e4bb-987e-438e-a894-9c1a62f1c07f"),
                    DescendantId = new Guid("e0a5e4bb-987e-438e-a894-9c1a62f1c07f")
                }
            );

        modelBuilder.Entity<EfMove>()
            .HasData(
                new EfMove
                {
                    Id = new Guid("1fcb07da-930f-4804-b3e8-367507824ee0"),
                    Name = "Lying Leg Curl"
                },
                new EfMove
                {
                    Id = new Guid("a113d887-f9fe-4f61-b1ed-12aa9ce95256"),
                    Name = "Back Squats"
                },
                new EfMove
                {
                    Id = new Guid("685fe3ea-ba26-4348-8b9a-f4f649003af4"),
                    Name = "Romanian Deadlift"
                },
                new EfMove
                {
                    Id = new Guid("3a68cf1f-996c-4a47-a986-81d261662b0a"),
                    Name = "Walking Lunges"
                },
                new EfMove
                {
                    Id = new Guid("86de43c4-2303-4e46-805f-a377f6df3e06"),
                    Name = "Leg Extension"
                },
                new EfMove
                {
                    Id = new Guid("4279bc52-14c7-435f-a87a-93a8c7c747de"),
                    Name = "Leg Press, 45 deg"
                },
                new EfMove
                {
                    Id = new Guid("9e159dc7-62ee-4e8c-82ed-6213a82672d2"),
                    Name = "Seating Calf Raises"
                },
                new EfMove
                {
                    Id = new Guid("38ec82fb-c503-4908-9e51-2c174160167c"),
                    Name = "Standing Calf Raises"
                });

        modelBuilder.Entity<EfMuscleGroupActivationData>()
            .HasData(
                // Lying leg curl: hamstring
                new EfMuscleGroupActivationData
                {
                    MoveId = new Guid("1fcb07da-930f-4804-b3e8-367507824ee0"),
                    MuscleGroupId = new Guid("60724155-2cbe-4506-9f44-fe93a903a295")
                },
                // Back squats: quads + glutes
                new EfMuscleGroupActivationData
                {
                    MoveId = new Guid("a113d887-f9fe-4f61-b1ed-12aa9ce95256"),
                    MuscleGroupId = new Guid("0ddec529-033d-4435-9813-7ca63950ff2d")
                },
                new EfMuscleGroupActivationData
                {
                    MoveId = new Guid("a113d887-f9fe-4f61-b1ed-12aa9ce95256"),
                    MuscleGroupId = new Guid("5ec7b81b-e3af-4520-9798-b774ccc1758e")
                },
                // RDL: glutes + hamstrings
                new EfMuscleGroupActivationData
                {
                    MoveId = new Guid("685fe3ea-ba26-4348-8b9a-f4f649003af4"),
                    MuscleGroupId = new Guid("5ec7b81b-e3af-4520-9798-b774ccc1758e")
                },
                new EfMuscleGroupActivationData
                {
                    MoveId = new Guid("685fe3ea-ba26-4348-8b9a-f4f649003af4"),
                    MuscleGroupId = new Guid("60724155-2cbe-4506-9f44-fe93a903a295")
                },
                // walking lunge: quads
                new EfMuscleGroupActivationData
                {
                    MoveId = new Guid("3a68cf1f-996c-4a47-a986-81d261662b0a"),
                    MuscleGroupId = new Guid("0ddec529-033d-4435-9813-7ca63950ff2d")
                },
                // leg extension: quads
                new EfMuscleGroupActivationData
                {
                    MoveId = new Guid("86de43c4-2303-4e46-805f-a377f6df3e06"),
                    MuscleGroupId = new Guid("0ddec529-033d-4435-9813-7ca63950ff2d")
                },
                // Leg Press, 45 deg: glutes + quads
                new EfMuscleGroupActivationData
                {
                    MoveId = new Guid("4279bc52-14c7-435f-a87a-93a8c7c747de"),
                    MuscleGroupId = new Guid("5ec7b81b-e3af-4520-9798-b774ccc1758e")
                },
                new EfMuscleGroupActivationData
                {
                    MoveId = new Guid("4279bc52-14c7-435f-a87a-93a8c7c747de"),
                    MuscleGroupId = new Guid("0ddec529-033d-4435-9813-7ca63950ff2d")
                },
                // Seating calf raises: calves
                new EfMuscleGroupActivationData
                {
                    MoveId = new Guid("9e159dc7-62ee-4e8c-82ed-6213a82672d2"),
                    MuscleGroupId = new Guid("c2d52c36-b845-4043-8fbe-d44356f1437b")
                },
                // Standing calf raises: calves
                new EfMuscleGroupActivationData
                {
                    MoveId = new Guid("38ec82fb-c503-4908-9e51-2c174160167c"),
                    MuscleGroupId = new Guid("c2d52c36-b845-4043-8fbe-d44356f1437b")
                });
    }
}