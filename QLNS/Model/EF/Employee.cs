namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public long ID { get; set; }

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
        public string Email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Bạn không được để trống trường này!")]
        public string Phone { get; set; }

        public DateTime? Birthday { get; set; }

        public int Gender { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(250)]
        public string GraduateShool { get; set; }

        public int? Degree { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        public int? Status { get; set; }

        public long? DepartmentID { get; set; }

        [StringLength(250)]
        public string Avatar { get; set; }

        public decimal? Salary { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Bạn không được để trống trường này!")]
        public string IdCard { get; set; }
    }
}
