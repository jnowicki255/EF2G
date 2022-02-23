using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF2G.Repository.Entities
{
    [Index(nameof(Username), Name = "UQ_Users_Username", IsUnique = true)]
    public partial class DbUser
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        //[Column(TypeName = "datetime2(3)")]
        public DateTime InsertDate { get; set; }

        [Required]
        //[Column(TypeName = "datetime2(3)")]
        public DateTime ModifyDate { get; set; }

        //[Column(TypeName = "datetime2(3)")]
        public DateTime? ExpirationDate { get; set; }

        //[Column(TypeName = "datetime2(3)")]
        public DateTime? LastLoginDate { get; set; }

        [Required]
        [StringLength(150)]
        public string Username { get; set; }

        [Required]
        [StringLength(250)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        
        [StringLength(200)]
        public string Email { get; set; }
        
        [StringLength(50)]
        public string Telephone { get; set; }
    }
}
