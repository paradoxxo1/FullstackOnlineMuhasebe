﻿using OnlineMuhasebeServer.Domain.Abstraction;

namespace OnlineMuhasebeServer.Domain.CompanyEntities;

public sealed class Log : Entity
{
    public string UserId { get; set; }
    public string TableName { get; set; }
    public string Data { get; set; }
    public string Progresss { get; set; }
}
