using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba4.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        [Column("Id_Клиента")]
        public int ClientID { get; set; }

        [Column("Фио")]
        public string FullName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("Телефон")]
        public string Phone { get; set; }

        [Column("адрес")]
        public string Address { get; set; }
    }
}
