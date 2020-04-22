using Domain.Contracts;

namespace Domain
{
    //Информация о колготках
    public class Tights : ISupplierContainer, IBuyerContainer
    {
        //идентификатор
        public int Id { get; set; }
        
        //Информация покупателе
        public Buyer Buyer{ get; set; }
        
        //Размер
        public string Size { get; set; }
        
        //дата продажи
        public string Date { get; set; }

        //Информация о поставщике 
        public Supplier Supplier { get; set; }
        
        public int? SupplierId => Supplier.Id;

        public int? BuyerId => Buyer.Id;
    }
}