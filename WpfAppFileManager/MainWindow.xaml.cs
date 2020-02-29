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

namespace WpfAppFileManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileManager fm;
        string s;
        public MainWindow()
        {
            InitializeComponent();
            fm = new FileManager();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            ShowTree();
        }

        private void DelDirectory_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            string path = pathTxtBox.Text + "\\" + nameTxtBox.Text;
            fm.DeleteDirectory(path);
            ShowTree();
        }

        private void CreateDirectory_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            string path = pathTxtBox.Text + "\\" + nameTxtBox.Text;
            fm.CreateDirectory(path);
            ShowTree();
        }

        private void DelFile_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            string path = pathTxtBox.Text + "\\" + nameTxtBox.Text;
            fm.DeleteFile(path);
            ShowTree();
        }

        private void CreateFile_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            string path = pathTxtBox.Text + "\\" + nameTxtBox.Text;
            fm.CreateFile(path);
            ShowTree();
        }

        private void CliarBtn_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            pathTxtBox.Text = "Path";
            nameTxtBox.Text = "Name";
        }

        private void FindFile_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            string path = pathTxtBox.Text;
            string name = nameTxtBox.Text;
            treeView.Items.Add(fm.FindFile(path, name));
        }

        private void FindDirectiry_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            string path = pathTxtBox.Text;
            string name = nameTxtBox.Text;
            treeView.Items.Add(fm.FindDirectory(path, name));
        }

        private void ShowTree()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                try
                {
                    if (drive.Name == "D:\\")
                    {
                        //StackPanel stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
                        TextBlock textBlock = new TextBlock() { Text = drive.Name };
                        //stackPanel.Children.Add(textBlock);
                        //TreeViewItem driveGo = new TreeViewItem() { Header = stackPanel };
                        TreeViewItem driveGo = new TreeViewItem() { Header = textBlock };
                        treeView.Items.Add(driveGo);
                        fm.ShowTreeView(drive.Name, driveGo);
                    }
                }
                catch { }
            }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //pathTxtBox.Text = ((e.NewValue as TreeView).Tag as TextBlock).Text;
            //pathTxtBox.Text = (((TreeView)sender).Tag as TextBlock).Text;
            //StackPanel temp = (StackPanel)((TreeViewItem)e.NewValue).Header;
            TextBlock temp2 = (TextBlock)((TreeViewItem)e.NewValue).Header; ;
            pathTxtBox.Text = temp2.Text;
        }
    }
}
