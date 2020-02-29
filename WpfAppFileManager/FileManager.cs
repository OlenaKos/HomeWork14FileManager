using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;

namespace WpfAppFileManager
{
    public class FileManager
    {
        public FileManager() { }

        public void ShowTreeView(string d, TreeViewItem driveGo)
        {
            TreeViewItem folderGo;
            TreeViewItem fileGo;
            try
            {
                string[] directories = Directory.GetDirectories(d);
                foreach (string directory in directories)
                {
                    //StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
                    TextBlock textBlock1 = new TextBlock() { Text = directory };
                    //sp.Children.Add(textBlock1);
                    //folderGo = new TreeViewItem() { Header = sp };
                    folderGo = new TreeViewItem() { Header = textBlock1 };
                    driveGo.Items.Add(folderGo);
                    ShowTreeView2(directory, folderGo);
                }
                foreach (string i in Directory.GetFiles(d))
                {
                    //StackPanel sp2 = new StackPanel() { Orientation = Orientation.Horizontal };
                    TextBlock textBlock2 = new TextBlock() { Text = i };
                    //sp2.Children.Add(textBlock2);
                    //fileGo = new TreeViewItem() { Header = sp2 };
                    fileGo = new TreeViewItem() { Header = textBlock2 };
                    driveGo.Items.Add(fileGo);
                }             
            }
            catch { }
        }

        public void ShowTreeView2(string d, TreeViewItem dirGo)
        {
            TreeViewItem folderGo;
            TreeViewItem fileGo;
            try
            {
                string[] directories = Directory.GetDirectories(d);
                foreach (string directory in directories)
                {
                    //StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
                    TextBlock textBlock1 = new TextBlock() { Text = directory };
                    //sp.Children.Add(textBlock1);
                    //folderGo = new TreeViewItem() { Header = sp };
                    folderGo = new TreeViewItem() { Header = textBlock1 };
                    dirGo.Items.Add(folderGo);
                    ShowTreeView(directory, folderGo);
                }
                foreach (string i in Directory.GetFiles(d))
                {
                    //StackPanel sp2 = new StackPanel() { Orientation = Orientation.Horizontal };
                    TextBlock textBlock2 = new TextBlock() { Text = i };
                    //sp2.Children.Add(textBlock2);
                    //fileGo = new TreeViewItem() { Header = sp2 };
                    fileGo = new TreeViewItem() { Header = textBlock2 };
                    dirGo.Items.Add(fileGo);
                }
            }
            catch { }
        }


        public string CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    return path;
                }
            }
            catch { }
            return null;
        }

        public string DeleteDirectory(string path)
        {
            try
            {
                Directory.Delete(path);
                if (Directory.Exists(path))
                {
                    return path;
                }
            }
            catch { }
            return null;
        }

        public string CreateFile(string path)
        {
            try
            {
                File.Create(path);
                if (File.Exists(path))
                {
                    return path;
                }
            }
            catch { }
            return null;
        }

        public string DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
                if (File.Exists(path))
                {
                    return path;
                }
            }
            catch { }
            return null;
        }

        public string FindFile(string path, string partialName)
        {
            try
            {
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(path);
                FileSystemInfo[] filesAndDirs = hdDirectoryInWhichToSearch.GetFileSystemInfos("*" + partialName + "*");

                foreach (FileSystemInfo foundFile in filesAndDirs)
                {
                    string fullName = foundFile.FullName;
                    return fullName;
                }          
            }
            catch { }
            return "Такого файла нет";
        }

        public string FindDirectory(string path, string partialName)
        {
            try
            {
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(path);
                FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");
                DirectoryInfo[] dirsInDir = hdDirectoryInWhichToSearch.GetDirectories("*" + partialName + "*.*");
                foreach (DirectoryInfo foundDir in dirsInDir)
                {
                    string fullName = foundDir.FullName;
                    return fullName;
                }
            }
            catch { }
            return "Такой папки нет";
        }
    }
}
