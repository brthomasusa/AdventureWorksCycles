using MediatR;

namespace AWC.SharedKernel.Base
{
    public abstract record DomainEvent : INotification;
}
