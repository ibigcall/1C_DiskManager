using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Win32.TaskScheduler;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConfigurationManagerLibrary.Data;
using ConfigurationManagerLibrary.Services;

namespace ConfigurationManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Configuration> Configurations { get; set; }
        public ObservableCollection<Configuration> LocalConfigurations { get; set; }
        
        public string LocalPath = Properties.Settings.Default.PathSetting;

        Menu_Actions install = new Menu_Actions();

        public MainWindow()
        {

            if(!Directory.Exists(LocalPath))
            {
                Directory.CreateDirectory(LocalPath);
 
            }

            
            Configurations = new ObservableCollection<Configuration>();
            LocalConfigurations = new ObservableCollection<Configuration>();
            DataContext = this;
            InitializeComponent();
            LocalFolderPath.Text = LocalPath;


            IConfigurationProvider localprovider = new LocalConfiguratorProvider();
            IConfigurationProvider provider = new FileSystemConfigurationProvider();

            var localconfigs = localprovider.GetConfigurations();
            var configurations = provider.GetConfigurations();
            foreach (var conf in localconfigs) LocalConfigurations.Add(conf);
            foreach (var conf2 in configurations) Configurations.Add(conf2);
         
          

        }

        public void openclick(object sender, RoutedEventArgs e)
        {
            LocalPath = LocalFolderPath.Text;
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            var opening = dialog.ShowDialog();
            if (dialog.SelectedPath != null)
            {
                LocalFolderPath.Text = dialog.SelectedPath.ToString();
                Properties.Settings.Default.PathSetting = LocalFolderPath.Text;
                Properties.Settings.Default.Save();
            }
            

        }
        public void install_click(object sender, RoutedEventArgs e)
        {
           
            install.install(ConfigurationsListBox, Configurations);

        }
        public void install_local_click(object sender, RoutedEventArgs e)
        {
            
            install.install(ConfigurationsListBox3, LocalConfigurations);

        }
        public void delete_click(object sender, RoutedEventArgs e)
        {
            int a = ConfigurationsListBox3.SelectedIndex;
            string filename = System.IO.Path.Combine(LocalConfigurations[a].VersionInfoPath + "\\..\\");
            DirectoryInfo DeleteDir = new DirectoryInfo(filename);
            DeleteDir.Delete(true);

            try
            {
                filename += "\\..\\";
                DirectoryInfo DeleteDir2 = new DirectoryInfo(filename);
                DeleteDir2.Delete();
            }
            catch
            {
            };
            
            LocalConfigurations.RemoveAt(a);

        }

        public void copy(object sender, RoutedEventArgs e)
        {
            int a = ConfigurationsListBox.SelectedIndex;
            install.copy(LocalPath , Configurations, a);
        }
        public void copy_all(object sender, RoutedEventArgs e)
        {
            for(int i=0; i<Configurations.Count; i++)
            {
                install.copy(LocalPath, Configurations, i);
            }
        }
    }
}

