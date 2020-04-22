using Client.Requests.Create;

namespace Client.Requests.Update
{
    public class TightsUpdateDTO : TightsCreateDTO
    {
        public int Id { get; set; }
    }
}