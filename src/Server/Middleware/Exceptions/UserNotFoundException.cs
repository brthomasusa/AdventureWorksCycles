#pragma warning disable RCS1194

namespace AWC.Server.Middleware.Exceptions
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(int userId)
            : base($"The user with the identifier {userId} was not found.")
        {
        }
    }
}