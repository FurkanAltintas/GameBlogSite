//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameBlogSite.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArticleLike
    {
        public int Id { get; set; }
        public Nullable<int> ArticleId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual Article Article { get; set; }
    }
}
