using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication18.Models
{
    public class clientorder
    {
        
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            [ForeignKey("Client")]
            public int Clientid { get; set; }
            [ForeignKey("resturants")]
            public string Resturantid { get; set; }
            public List<menu_item> orderitems { get; set; } = new List<menu_item>();

        
    }
}
