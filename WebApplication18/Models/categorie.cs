using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication18.Models
{
    public class categorie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        [ForeignKey("resturants")]
        public int resturantsid { get; set; }
        public List<menu_item> items { get; set; }=new List<menu_item>();  
    }
}
