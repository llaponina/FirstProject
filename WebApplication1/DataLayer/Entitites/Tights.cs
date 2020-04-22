using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Tights
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //идентификатор
        public int Id { get; set; }
        
        //Размер
        public string Size { get; set; }

        //Время продажи
        public string Date { get; set; }
        
        public int? SupplierId { get; set; }

        public int? BuyerId { get; set; }

        public virtual Buyer Buyer { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}