using OnlineMuhasebeServer.Domain.Abstraction;

namespace OnlineMuhasebeServer.Domain.CompanyEntities;

public sealed class Report : Entity
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public string FileUrl { get; set; }
}
