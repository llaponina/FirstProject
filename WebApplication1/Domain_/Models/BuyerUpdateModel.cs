using Domain.Contracts;

namespace Domain.Models
{
    public class BuyerUpdateModel : IBuyerIdentity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        
    }
}