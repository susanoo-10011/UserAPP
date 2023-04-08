using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace UserAPP
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Использовать только программный рендеринг для предотвращения размытости текста при запуске приложения
            // RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
            
        }
    }
}
