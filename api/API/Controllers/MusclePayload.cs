namespace API.Controllers;

public record MusclePayload(string Name, Guid? ParentId = null);