using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Buyer
    {
        public Buyer()
        {
            this.Tightss = new HashSet<Tights>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //идентификатор
        public int Id { get; set; }
        
        //Имя 
        public string Name { get; set; }

       
        public virtual ICollection<Tights> Tightss { get; set; }
    }
}