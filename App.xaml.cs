using System.Configuration;
using System.Data;
using System.Windows;

using trpo7_voroshilov_pr.Class;

namespace trpo7_voroshilov_pr
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ThemeHelper.ApplySaved();
        }
    }

}
