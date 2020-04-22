using Domain.Contracts;

namespace Domain.Models
{
    public class SupplierUpdateModel : ISupplierIdentity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }
    }
}