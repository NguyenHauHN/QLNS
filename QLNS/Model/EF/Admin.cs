namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        public long ID { get; set; }

        [Required(ErrorMessage ="Bạn không được để trống trường này!")]
        [StringLength(250)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống trường này!")]
        [StringLength(250)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống trường này!")]
        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public int Gender { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống trường này!")]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Status { get; set; }

        [StringLength(250)]
        public string Avatar { get; set; }
    }
}
