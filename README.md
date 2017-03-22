# Link Scraper
## Introduction
When you add a link to some sites like Facebook, you will find notice the facebook is displaying some images for you to add it with your post. This usually know as <a href="https://en.wikipedia.org/wiki/Web_scraping">Web scraping</a> which allow you to parse a content then extract data from content .This data could be an images, link or anything else like images below.
 <img src="http://i.imgur.com/TGRkktw.png" alt="http://i.imgur.com/TGRkktw.png">
  <img src="http://i.imgur.com/EGA6h42.png" alt="http://i.imgur.com/EGA6h42.png">
### How it Works
**LinkScaper** In general depending on <a href="http://ogp.me/"> Open Graph Protocol</a>, So it first check if the page contain the **og** Metadata or not. If yes it will bring all the **og:image** then display to you otherwise it will bring all html images **<img..>**
## What next
- [ ] Creating a Nuget Pacakge so you can use it in your MVC or WebForms project.
- [ ] Creating a Tag Helper for ASP.NET Core. 
