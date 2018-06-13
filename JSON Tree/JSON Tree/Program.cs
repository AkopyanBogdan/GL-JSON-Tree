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
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

