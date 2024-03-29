﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLPlayground.Models;

[Table("platforms")]
public class Platform
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("license-key")]
    public string? LicenseKey { get; set; }

    public ICollection<Command> Commands { get; set; } = new List<Command>();
}
