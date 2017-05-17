namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    public partial class Department
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống trường này!")]
        [StringLength(250)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống trường này!")]
        [StringLength(250)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống trường này!")]
        [StringLength(50)]
        public string Phone { get; set; }

        public int? Status { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
