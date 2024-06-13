﻿using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.LogFeatures.Queries.GetLogsByTableName;

public sealed record GetLogsByTableNameQuery(
    string TableName,
    string CompanyId,
    int PageNumber = 1,
    int PageSize = 10) : IQuery<GetLogsByTableNameQueryResponse>;

