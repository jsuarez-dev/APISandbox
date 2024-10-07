

namespace BlogAPI.Services;

public interface IDemoService
{
    string Hello();
}


public class DemoService : IDemoService
{

    private readonly DateTime _createAt;
    private readonly Guid _serviceId;
    public DemoService()
    {
        _createAt = DateTime.Now;
        _serviceId = Guid.NewGuid();
    }

    public string Hello()
    {
        return $"""
            Hello From Service {_serviceId.ToString()}
            At => {_createAt.ToString()}

            """;
    }
}

