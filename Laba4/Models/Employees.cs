using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba4.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Column("ID_сотрудника")]
        public int EmployeeID { get; set; }

        [Column("ФИО")]
        public string FullName { get; set; }

        [Column("Должность")]
        public string Position { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("Ставка_в_час")]
        public decimal? HourlyRate { get; set; }
    }
}
