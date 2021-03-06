using GameBlogSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameBlogSite.Models
{
    public class ArticleComments
    {
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Article> Article { get; set; }
        public IEnumerable<Comment> Comment { get; set; }
        public IEnumerable<Images> Images { get; set; }
        public IEnumerable<Reply> Reply { get; set; }
        public IEnumerable<Tag> Tag { get; set; }
        public IEnumerable<Slider> Slider { get; set; }

        public Comment comment { get; set; }
        public Reply reply { get; set; }

    }
}