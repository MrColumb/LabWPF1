using CodingSeb.Localization;
using CodingSeb.Localization.Loaders;
using System;
using System.Windows;

namespace WPF_MVVM_Demo
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LocalizationLoader.Instance.FileLanguageLoaders.Add(new JsonFileLoader());
            LocalizationLoader.Instance.AddDirectory(System.IO.Path.Combine(AppContext.BaseDirectory, "Localization"));

            Loc.Instance.CurrentLanguage = "ru";
        }
    }
}
