using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication18.Models
{
    public class resturants
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        public string name{ get; set; }
        public string adress { get; set; }
        public int reviews { get; set; }
        public int deliverytimeminutes { get; set; }
        public List<categorie> categorie { get; set; }=new List<categorie>();
        [ForeignKey("images")]
        public int imageid { get; set; }
       
    }
}
