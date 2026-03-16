using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace People4DRepositiryClassLibrary.Models;

[Table("addresses")]
public partial class Address
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [StringLength(150)]
    public string Street { get; set; } = null!;

    [StringLength(100)]
    public string City { get; set; } = null!;

    [InverseProperty("Address")]
    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
