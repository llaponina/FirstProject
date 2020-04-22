using Domain.Contracts;

namespace Domain.Models
{
    public class TightsUpdateModel : ITightsIdentity, IBuyerContainer, ISupplierContainer
    {
        public int Id { get; set; }
        
        //Время сеанса
        public string Size { get; set; }
        
        //Дата сеанса
        public string Date { get; set; }
        
        public int? BuyerId { get; set; }
        public int? SupplierId { get; set; }
    }
}