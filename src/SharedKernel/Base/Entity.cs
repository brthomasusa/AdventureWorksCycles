#pragma warning disable CS8618

namespace AWC.SharedKernel.Base
{
    public abstract class Entity<T>
    {
        public T Id { get; protected set; }

        public DateTime? ModifiedDate { get; private set; }

        public void UpdateModifiedDate()
        {
            ModifiedDate = DateTime.UtcNow;
        }

        protected virtual void CheckValidity()
        {
            // Validation involving multiple properties go here.
        }
    }
}