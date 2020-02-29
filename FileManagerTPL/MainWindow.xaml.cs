using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace FileManagerTPL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileManager fm = new FileManager();
        string s;
        TextBlock temp2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DelDirectory_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            string path = pathTxtBox.Text + @"\" + nameTxtBox.Text;
            Task.Run(() => fm.DeleteDirectory(path));
            ShowTree();
        }

        private void CreateDirectory_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            string path = pathTxtBox.Text + @"\" + nameTxtBox.Text;
            Task.Run(() => fm.CreateDirectory(path));
            ShowTree();
        }

        private void DelFile_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            string path = pathTxtBox.Text + @"\" + nameTxtBox.Text;
            Task.Run(() => fm.DeleteFile(path));
            ShowTree();
        }


        private void CreateFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((TreeViewItem)treeView.SelectedItem).IsSelected = false;
            }
            catch { }
            treeView.Items.Clear();
            string path = pathTxtBox.Text + @"\" + nameTxtBox.Text;
            Task.Run(() => fm.CreateFile(path));
            pathTxtBox.Text = path;
            ShowTree();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            ShowTree();
        }

        private void CliarBtn_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            pathTxtBox.Text = "";
            nameTxtBox.Text = "";
            readTextBox.Text = "";
            writeTextBox.Text = "";
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                temp2 = ((TreeViewItem)e.NewValue).Header as TextBlock;
            }
            catch { }
            pathTxtBox.Text = temp2.Text;
            s = System.IO.Path.GetExtension(pathTxtBox.Text);
            if (s == ".txt")
            {
                string path = pathTxtBox.Text;
                Task<string> task = Task<string>.Factory.StartNew(fm.ReadFileTxt, path);
                readTextBox.Text = task.Result;
            }
            else
            {
                readTextBox.Text = "";
            }
        }


        private void WriteFile_Click(object sender, RoutedEventArgs e)
        {
            string path = pathTxtBox.Text;
            string value = writeTextBox.Text;
            Task.Run(() => fm.WriteFileTxt(path, value));
        }

        private void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            Task<string> task = Task<string>.Factory.StartNew(fm.ReadFileTxt, pathTxtBox.Text);
            readTextBox.Text = task.Result;
        }

        private void ReadTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((TreeViewItem)treeView.SelectedItem).IsSelected = false;
        }

        private void WriteTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((TreeViewItem)treeView.SelectedItem).IsSelected = false;
        }

        private void ShowTree()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                try
                {
                    if (drive.Name == @"D:\")
                    {
                        TextBlock textBlock = new TextBlock() { Text = drive.Name };
                        TreeViewItem driveGo = new TreeViewItem() { Header = textBlock };
                        treeView.Items.Add(driveGo);
                        fm.ShowTreeView(drive.Name, driveGo);
                    }
                }
                catch { }
            }
        }
    }
}
