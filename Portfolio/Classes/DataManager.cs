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
        private static string languageFolder;

        public static async Task FetchPostsAsync(HttpClient httpClient)
        {
            languageFolder = CultureInfo.CurrentCulture.ToString();
            DataManager.httpClient = httpClient;
            PostFiles = await GetPostFilesAsync();
            BlogPosts = await GetPostsAsync(httpClient);
        }

        private static async Task<List<BlogPost>> GetPostsAsync(HttpClient httpClient)
        {
            List<BlogPost> blogPosts = new List<BlogPost>();

            foreach (string item in PostFiles)
            {
                string markdown = string.Empty;

                try
                {
                    markdown = await httpClient.GetStringAsync($"blog-posts/{languageFolder}/{item}");
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                    continue;
                }
                
                StringReader stringReader = new StringReader(markdown);
                StringBuilder stringBuilder = new StringBuilder();
                BlogPost blogPost = new BlogPost();
                bool firstPara = true;
                bool readTitle = false;

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

                    if (s == "---")
                    {
                        while (true)
                        {
                            s = stringReader.ReadLine();
                            Console.WriteLine(s);

                            if (s.StartsWith("date"))
                            {
                                blogPost.LastUpdated = DateTime.Parse(s.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                                Console.WriteLine(blogPost.LastUpdated.ToShortDateString());
                                continue;
                            }

                            if (s == "---" || s == null)
                            {
                                break;
                            }
                        }
                    }

                    if (s.StartsWith('#') && !readTitle)
                    {
                        blogPost.Title = s.Split('#')[1].Trim();
                        readTitle = true;
                        continue;
                    }

                    if (s.StartsWith('!'))
                    {
                        string[] tokens = s.Split(new char[] { '!', '[', ']', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        string centeredImage = $"<div class=\"text-center\"><img src=\"{tokens[1]}\" alt=\"{tokens[0]}\" /></div>";
                        stringBuilder.AppendLine(centeredImage);
                        continue;
                    }

                    stringBuilder.AppendLine(s.Trim());

                    if (firstPara)
                    {
                        blogPost.FirstPara = stringBuilder.ToString();
                        firstPara = false;
                    }
                }

                blogPost.Markdown = markdown;
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
            string data = await httpClient.GetStringAsync($"blog-posts/{languageFolder}/blog-post-data.txt");
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
