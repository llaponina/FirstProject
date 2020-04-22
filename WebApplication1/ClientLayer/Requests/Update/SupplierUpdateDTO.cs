using Client.Requests.Create;

namespace Client.Requests.Update
{
    public class SupplierUpdateDTO : SupplierCreateDTO
    {
        public int Id { get; set; }
    }
}