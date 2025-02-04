﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("comment")]
[Index("PostId", Name = "FK_comment_blog_post")]
[Index("UserId", Name = "FK_comment_member")]
public partial class Comment
{
    [Key]
    [Column("id", TypeName = "bigint(20)")]
    public long Id { get; set; }

    [Column("post_id", TypeName = "bigint(20)")]
    public long PostId { get; set; }

    [Column("user_id", TypeName = "bigint(20)")]
    public long UserId { get; set; }

    [Required]
    [Column("content", TypeName = "text")]
    public string Content { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("PostId")]
    [InverseProperty("Comments")]
    public virtual BlogPost Post { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Comments")]
    public virtual User User { get; set; }
}