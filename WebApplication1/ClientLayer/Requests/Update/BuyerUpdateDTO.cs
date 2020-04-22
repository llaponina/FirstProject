using Client.Requests.Create;

namespace Client.Requests.Update
{
    public class BuyerUpdateDTO : BuyerCreateDTO
    {
        public int Id { get; set; }
    }
}