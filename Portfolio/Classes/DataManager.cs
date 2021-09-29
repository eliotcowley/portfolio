using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Classes
{
    public static class DataManager
    {
        public static List<string> PostFiles { get; set; }
        public static List<BlogPost> BlogPosts { get; set; }
    }
}
