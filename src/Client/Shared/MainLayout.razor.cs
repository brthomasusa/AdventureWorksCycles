using System.Reflection;

namespace AWC.Client.Shared
{
    public partial class MainLayout
    {
        string currentVersion = string.Empty;

        protected override void OnInitialized()
        {

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            currentVersion = $"AdventureWorksCycles v{currentAssembly.GetName().Version}";

            base.OnInitialized();
        }
    }
}