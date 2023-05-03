using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication18.Models
{
    public class homecat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
       
    }
}
