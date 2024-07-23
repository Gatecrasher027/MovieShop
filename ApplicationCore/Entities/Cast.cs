using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ApplicationCore.Entities;

public class Cast
{
    public int Id { get; set; }

    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [StringLength(2084)]
    public string ProfilePath { get; set; }
    
    [Required]
    public string TmdbUrl { get; set; }

    public ICollection<MovieCast> MovieCasts { get; set; }
}