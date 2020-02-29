using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WpfAppFileManager
{
    [TestFixture]
    class FilemanagerTest
    {
        [Test]
        public void CreateDirectoryTest()
        {
            var sfm = new SubFileManager();
            string expected = @"D:\DirectoryTest\Test4";
            var actual = sfm.CreateDirectory(expected);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DeleteDirectoryTest()
        {
            var sfm = new SubFileManager();
            string path = @"D:\DirectoryTest\Test4";
            string expected = @"D:\DirectoryTest";
            var actual = sfm.DeleteDirectory(path);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CreateFileTest()
        {
            var sfm = new SubFileManager();
            string expected = @"D:\DirectoryTest\testfile2.txt";
            var actual = sfm.CreateFile(expected);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DeleteFileTest()
        {
            var sfm = new SubFileManager();
            string path = @"D:\DirectoryTest\testfile2.txt";
            string expected = @"D:\DirectoryTest";
            var actual = sfm.DeleteFile(path);
            Assert.AreEqual(expected, actual);
        }
    }
}
