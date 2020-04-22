using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
        public partial class Supplier
    {
        public Supplier()
        {
            this.Tights = new HashSet<Tights>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual ICollection<Tights> Tights { get; set; }

        //Идентификатор
        public int Id { get; set; }
        
        //Название фирмы
        public string Name { get; set; }

        //Адрес
        public string Address { get; set; }
        
    }
}