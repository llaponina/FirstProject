using Domain.Contracts;

namespace Domain.Models
{
    public class TightsIdentityModel : ITightsIdentity
    {
        public int Id { get; }

        public TightsIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}