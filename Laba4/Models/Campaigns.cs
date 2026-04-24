using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba4.Models
{
    [Table("Campaigns")]
    public class Campaign
    {
        [Key]
        [Column("id_кампании")]
        public int CampaignID { get; set; }

        [Column("название")]
        public string CampaignName { get; set; }

        [Column("id_клиента")]
        public int ClientID { get; set; }

        [Column("бюджет")]
        public decimal? Budget { get; set; }

        [Column("дата_начала")]
        public DateTime? StartDate { get; set; }

        [Column("дата_окончания")]
        public DateTime? EndDate { get; set; }

        [Column("статус")]
        public string Status { get; set; }

        public virtual Client Client { get; set; }
    }
}
