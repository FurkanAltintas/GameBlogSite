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
    
    public partial class Skill
    {
        public int Id { get; set; }
        public Nullable<int> WriterId { get; set; }
        public string Name { get; set; }
        public Nullable<int> SLevel { get; set; }
    
        public virtual Writer Writer { get; set; }
    }
}
