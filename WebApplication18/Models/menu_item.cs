using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication18.Models
{
    public class menu_item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("categorie")]
        public int categorieid { get; set; }
        public string item_name { get; set; }
        public List<itemoptions> itemoptions { get; set; }=new List<itemoptions>();

    }
}
    