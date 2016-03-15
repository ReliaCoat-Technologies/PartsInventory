using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Core;

namespace ReliacoatInventory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnAppStartup_UpdateThemeName(object sender, StartupEventArgs e)
        {
            var theme = new Theme("MetropolisDarkBlue", "DevExpress.Xpf.Themes.MetropolisDarkBlue.v15.2")
            {
                AssemblyName = "DevExpress.Xpf.Themes.MetropolisDarkBlue.v15.2"
            };
            Theme.RegisterTheme(theme);

            ApplicationThemeHelper.UpdateApplicationThemeName();
        }
    }
}
