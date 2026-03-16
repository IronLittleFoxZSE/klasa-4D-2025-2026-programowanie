using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace People4DRepositiryClassLibrary.Models;

[Table("people")]
[Index("AddressId", Name = "FK_People_Addresses")]
public partial class Person
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Surname { get; set; } = null!;

    [Column(TypeName = "int(11)")]
    public int Age { get; set; }

    [Column(TypeName = "int(11)")]
    public int? AddressId { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("People")]
    public virtual Address? Address { get; set; }
}
