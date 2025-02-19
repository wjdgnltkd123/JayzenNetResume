﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("project")]
[Index("UserId", Name = "FK_project_user")]
public partial class Project
{
    [Key]
    [Column("id", TypeName = "bigint(20)")]
    public long Id { get; set; }

    [Column("user_id", TypeName = "bigint(20)")]
    public long UserId { get; set; }

    [Required]
    [Column("title")]
    [StringLength(255)]
    public string Title { get; set; }

    [Required]
    [Column("description", TypeName = "text")]
    public string Description { get; set; }

    [Required]
    [Column("demo_url")]
    [StringLength(255)]
    public string DemoUrl { get; set; }

    [Required]
    [Column("github_url")]
    [StringLength(255)]
    public string GithubUrl { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Project")]
    public virtual ICollection<ProjectTag> ProjectTags { get; set; } = new List<ProjectTag>();

    [ForeignKey("UserId")]
    [InverseProperty("Projects")]
    public virtual User User { get; set; }
}