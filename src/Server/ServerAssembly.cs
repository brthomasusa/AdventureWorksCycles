using System.Reflection;

namespace AWC.Server
{
    public static class ServerAssembly
    {
        public static readonly Assembly Instance = typeof(ServerAssembly).Assembly;
    }
}