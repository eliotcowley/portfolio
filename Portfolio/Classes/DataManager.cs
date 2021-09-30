using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Classes
{
    public static class DataManager
    {
        public static List<string> PostFiles { get; set; }
        public static List<BlogPost> BlogPosts { get; set; }

        private static HttpClient httpClient;

        public static async Task FetchPostsAsync(HttpClient httpClient)
        {
            DataManager.httpClient = httpClient;
            PostFiles = await GetPostFilesAsync();
            BlogPosts = await GetPostsAsync(httpClient);
        }

        private static async Task<List<BlogPost>> GetPostsAsync(HttpClient httpClient)
        {
            List<BlogPost> blogPosts = new List<BlogPost>();
            string languageFolder = CultureInfo.CurrentCulture.ToString();
            Console.WriteLine(languageFolder);

            foreach (string item in PostFiles)
            {
                string markdown = await httpClient.GetStringAsync($"blog-posts/{languageFolder}/{item}");
                StringReader stringReader = new StringReader(markdown);
                StringBuilder stringBuilder = new StringBuilder();
                BlogPost blogPost = new BlogPost();
                bool firstPara = true;

                while (true)
                {
                    string s = stringReader.ReadLine();

                    if (s == null)
                    {
                        break;
                    }

                    if (s == string.Empty)
                    {
                        continue;
                    }

                    if (s.StartsWith('#'))
                    {
                        blogPost.Title = s.Split('#')[1].Trim();
                        continue;
                    }

                    stringBuilder.AppendLine(s.Trim());

                    if (firstPara)
                    {
                        blogPost.FirstPara = stringBuilder.ToString();
                        firstPara = false;
                    }
                }

                blogPost.Body = stringBuilder.ToString().Trim();
                string url = item.Split('.')[0];
                blogPost.Url = $"blog/{url}";
                blogPosts.Add(blogPost);
            }

            return blogPosts;
        }

        private static async Task<List<string>> GetPostFilesAsync()
        {
            List<string> postData = new List<string>();
            string data = await httpClient.GetStringAsync("blog-posts/blog-post-data.txt");
            StringReader stringReader = new StringReader(data);

            while (true)
            {
                string filename = stringReader.ReadLine();

                if (filename != null)
                {
                    postData.Add(filename);
                }
                else
                {
                    break;
                }
            }

            return postData;
        }
    }
}
