﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("experience")]
[Index("UserId", Name = "FK_experience_user")]
public partial class Experience
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
    [Column("company")]
    [StringLength(255)]
    public string Company { get; set; }

    [Required]
    [Column("period")]
    [StringLength(255)]
    public string Period { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Experience")]
    public virtual ICollection<ExperienceTag> ExperienceTags { get; set; } = new List<ExperienceTag>();

    [ForeignKey("UserId")]
    [InverseProperty("Experiences")]
    public virtual User User { get; set; }
}