﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactForm> ContactForm { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Writer> Writer { get; set; }
        public virtual DbSet<ArticleLike> ArticleLike { get; set; }
        public virtual DbSet<WriterChat> WriterChat { get; set; }
        public virtual DbSet<WriterChatReply> WriterChatReply { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CommentLike> CommentLike { get; set; }
        public virtual DbSet<Member> Member { get; set; }
    }
}
