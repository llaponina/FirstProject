using Domain.Contracts;

namespace Domain.Models
{
    public class SupplierIdentityModel : ISupplierIdentity
    {
        public int Id { get; }

        public SupplierIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}