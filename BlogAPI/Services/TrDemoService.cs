
namespace BlogAPI.Services;

public interface IService
{
    string Name { get; }
    string SayHello();
}

public interface ITranService : IService { }

public class TranService : ITranService
{

    private readonly DateTime _createAt;
    private readonly Guid _serviceId;
    public TranService()
    {
        _createAt = DateTime.Now;
        _serviceId = Guid.NewGuid();
    }

    public string Name => nameof(TranService);

    public string SayHello()
    {
        return $"""
            Hello From Service {Name}
            Id => {_serviceId.ToString()}
            At => {_createAt.ToString()}

            """;
    }
}

public interface ISingService : IService { }

public class SingService : ISingService
{

    private readonly DateTime _createAt;
    private readonly Guid _serviceId;
    public SingService()
    {
        _createAt = DateTime.Now;
        _serviceId = Guid.NewGuid();
    }

    public string Name => nameof(SingService);

    public string SayHello()
    {
        return $"""
            Hello From Service {Name}
            Id => {_serviceId.ToString()}
            At => {_createAt.ToString()}

            """;
    }
}

public interface IScopeService : IService
{
}


public class ScopedService : IScopeService
{

    private readonly DateTime _createAt;
    private readonly Guid _serviceId;
    private readonly ITranService _tranService;
    private readonly ISingService _singService;
    public ScopedService(ISingService singService, ITranService tranService)
    {
        _createAt = DateTime.Now;
        _serviceId = Guid.NewGuid();
        _singService = singService;
        _tranService = tranService;
    }

    public string Name => nameof(ScopedService);

    public string SayHello()
    {
        string ScopeMsg = $"""
            Hello From Service {Name}
            Id => {_serviceId.ToString()}
            At => {_createAt.ToString()}
            ___________________________
            """;

        string TranMsg = $"""
            I am From {Name}
            {_tranService.SayHello()};
            ___________________________
            """;

        string SingMsg = $"""
            I am From {Name}
            {_singService.SayHello()};
            ___________________________
            """;

        return $"""
            {ScopeMsg}
            ___________________________
            {TranMsg}
            ___________________________
            {SingMsg}
            """;
    }
}
