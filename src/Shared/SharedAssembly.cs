using System.Reflection;

namespace AWC.Shared;

public static class SharedAssembly
{
    public static readonly Assembly Instance = typeof(SharedAssembly).Assembly;
}