using System.ComponentModel.DataAnnotations;

namespace Client.Requests.Create
{
    public class BuyerCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
              
    }
}