using Microsoft.Win32;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string rawImageFolderPath;
        private string directoryImageFolderPath;

        public MainWindow()
        {
            InitializeComponent();
            rawImageFolderPath = Properties.Settings.Default.RawPhotoFolderPath;
            directoryImageFolderPath = Properties.Settings.Default.FinalPhotoFolderPath;
            txtRawImageFolder.Text = rawImageFolderPath;
            txtDirectoryImageFolder.Text = directoryImageFolderPath;

        }

  
        private string pickImageDirectory()
        {
            FolderBrowserDialog fbdDirectory = new FolderBrowserDialog();


            fbdDirectory.SelectedPath = txtRawImageFolder.Text;
            fbdDirectory.ShowDialog();
            return fbdDirectory.SelectedPath;
        }


        private void getRawImageFolder_Click(object sender, RoutedEventArgs e)
        {
            txtRawImageFolder.Text = pickImageDirectory();
            rawImageFolderPath = txtRawImageFolder.Text;
            Properties.Settings.Default.RawPhotoFolderPath = rawImageFolderPath;
            Properties.Settings.Default.Save();
        }

        private void getDirectoryImageFolder_Click(object sender, RoutedEventArgs e)
        {
            txtDirectoryImageFolder.Text = pickImageDirectory();
            directoryImageFolderPath = txtDirectoryImageFolder.Text;
            Properties.Settings.Default.FinalPhotoFolderPath = directoryImageFolderPath;
            Properties.Settings.Default.Save();
        }

        private void copy_and_rename_images_Click(object sender, RoutedEventArgs e)
        {
            string id = 10471.ToString();
            string directoryImageFileName = directoryImageFolderPath + @"\" + id + @".png" ;
            string rawImageFileName = rawImageFolderPath + @"\" + getRawImageFileName(id);


            if (File.Exists(rawImageFileName))
            {
                List<String> files = new List<String>();
                files.Add(rawImageFileName);
                lbFileList.ItemsSource = files;
                File.Copy(rawImageFileName, directoryImageFileName, true);
            }
        }

        private string getRawImageFileName(string id)
        {
            string finalFileName = "0000000000";
            //int periodIndex = id.IndexOf(".");

            //finalFileName = finalFileName + id.Substring(0, periodIndex);
            finalFileName = finalFileName + id;
            finalFileName = finalFileName.Insert(finalFileName.Length - 1, ".");
            finalFileName = finalFileName.Substring(finalFileName.Length - 10);
            return finalFileName;
        }
    }
}
