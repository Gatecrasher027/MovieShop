using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ApplicationCore.Entities;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(128)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(128)]
    public string LastName { get; set; }

    [Required]
    [StringLength(256)]
    public string Email { get; set; }

    [Required]
    [StringLength(1024)]
    public string HashedPassword { get; set; }

    [StringLength(1024)]
    public string Salt { get; set; }

    [StringLength(16)]
    public string PhoneNumber { get; set; }

    public bool IsLocked { get; set; }
    public DateTime DateOfBirth { get; set; }

    public ICollection<MovieCast> MovieCasts { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
    public ICollection<Review> Reviews { get; set; }
}