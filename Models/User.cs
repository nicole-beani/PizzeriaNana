namespace PizzeriaNana.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Inserisci l'username")]
        public string Username { get; set; }

        [StringLength(50)]
        [Display(Name = "Inserisci password")]
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = "Ruolo")]
        public string Role { get; set; }
    }
}
