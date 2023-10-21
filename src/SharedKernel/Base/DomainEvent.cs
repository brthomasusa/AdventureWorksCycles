#pragma warning disable S2094

using MediatR;

namespace AWC.SharedKernel.Base
{
    public abstract record DomainEvent : INotification;
}
