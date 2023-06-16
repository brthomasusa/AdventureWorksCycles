﻿using AWC.SharedKernel.Utilities;
using MediatR;

namespace AWC.Application.Interfaces.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}