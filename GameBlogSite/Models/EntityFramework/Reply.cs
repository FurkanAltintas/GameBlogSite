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
    
    public partial class Reply
    {
        public int Id { get; set; }
        public Nullable<int> CommentId { get; set; }
        public string NameSurName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual Comment Comment { get; set; }
    }
}
