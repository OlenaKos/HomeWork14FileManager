using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppFileManager
{
    public class SubFileManager
    {
        public string CreateDirectory(string path)
        {
            string s = @"D:\DirectoryTest\Test4";
            if (path == s)
            {
                return s;
            }
            return null;
        }

        public string DeleteDirectory(string path)
        {
            string s = path;
            int pos = s.LastIndexOf('\\');
            s = s.Substring(0, pos);
            if (s == @"D:\DirectoryTest")
            {
                return s;
            }
            return null;
        }

        public string CreateFile(string path)
        {
            string s = @"D:\DirectoryTest\testfile2.txt";
            if (path == s)
            {
                return s;
            }
            return null;
        }

        public string DeleteFile(string path)
        {
            string s = path;
            int pos = s.LastIndexOf('\\');
            s = s.Substring(0, pos);
            if (s == @"D:\DirectoryTest")
            {
                return s;
            }
            return null;
        }
    }
}
