using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication18.Models
{
    public class option
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        [ForeignKey("itemoptions")]
        public int itemoptionsid { get; set; }
        public int price { get; set; }
        public bool isSelected { get; set; }
    }
}