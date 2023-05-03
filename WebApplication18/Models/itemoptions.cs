using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication18.Models
{
    public class itemoptions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("menu_item")]
        public int menu_itemid { get; set; }
       public string name { get; set; }
       public List<option> options { get; set; }=new List<option>();
    }
}
