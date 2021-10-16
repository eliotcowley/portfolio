using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Classes
{
    public class BlogPost
    {
        public string Markdown { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        // blog/{file.md}
        public string Url { get; set; }
        public string FirstPara { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
