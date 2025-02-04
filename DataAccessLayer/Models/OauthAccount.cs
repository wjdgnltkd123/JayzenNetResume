﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("oauth_account")]
[Index("UserId", Name = "FK_oauth_account_member")]
public partial class OauthAccount
{
    [Key]
    [Column("id", TypeName = "bigint(20)")]
    public long Id { get; set; }

    [Column("user_id", TypeName = "bigint(20)")]
    public long UserId { get; set; }

    [Required]
    [Column("provider")]
    [StringLength(255)]
    public string Provider { get; set; }

    [Required]
    [Column("provider_user_id")]
    [StringLength(255)]
    public string ProviderUserId { get; set; }

    [Required]
    [Column("access_token")]
    [StringLength(255)]
    public string AccessToken { get; set; }

    [Required]
    [Column("refresh_token")]
    [StringLength(255)]
    public string RefreshToken { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("OauthAccounts")]
    public virtual User User { get; set; }
}