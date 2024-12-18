namespace Infrastructure.Base.Model;

public abstract class BaseModel
{
    protected BaseModel()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }
}