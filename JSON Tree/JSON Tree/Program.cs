using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JSON_Tree
{
    class TreeItem
    {
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public string Path { get; set; }
        public string Size { get; set; }
        public List<TreeItem> Files;


        public TreeItem(FileSystemInfo fileSystemInfo)
        {
            Files = new List<TreeItem>();


            Name = fileSystemInfo.Name;
            DateCreated = fileSystemInfo.CreationTime.ToString("d-MMM-yy h:mm tt");
            Path = fileSystemInfo.FullName;

            if (fileSystemInfo.Attributes == FileAttributes.Directory)
            {
                Size = GetDirectorySize(fileSystemInfo.FullName).ToString() + " B";

                foreach (FileSystemInfo file in (fileSystemInfo as DirectoryInfo).GetFileSystemInfos())
                {
                    Files.Add(new TreeItem(file));
                }
            }
            else
            {
                Size = new FileInfo(fileSystemInfo.FullName).Length.ToString() + " B";
            }
        }

        private long GetDirectorySize(string path)
        {
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            long size = 0;
            foreach (string name in files)
            {
                FileInfo info = new FileInfo(name);
                size += info.Length;
            }
            return size;
        }

        public string JsonToTree()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

