# New website launch!

Welcome to my new site! I decided it was time to ditch my old Wordpress site, buckle down and learn web development so I could make my own site and customize it exactly how I want. I've always been interested in web development, but I always quit early on because I found it so gross and confusing.

After making my first "real" website, I still find web development pretty gross (*cough cough* CSS), but at least bearable since I didn't have to use Javascript. Instead, I used a framework called [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor), which lets you write front-end code in C#.

I quite enjoy Blazor, since I enjoy C# and .NET. Though HTML and CSS are no less of a pain. Learning Bootstrap helped a lot because I could worry less about CSS, but even Bootstrap has a lot of things that trip me up, like layout.

There are two hosting models in Blazor: Blazor WebAssembly and Blazor Server. I decided to go with WebAssembly, which is a static site model where the entire site is downloaded to the client on first load. So the first time accessing the site has a longer load time, but navigating the site after that is quick.

I also wanted to host my website in the cloud, and chose Azure mostly because Microsoft owns both Azure and Blazor, so there are more tutorials about hosting Blazor apps in Azure than other cloud providers. Also I used to work for Microsoft, so it still has a soft spot in my heart, what can I say. Azure will host my static site for free, which is amazing.