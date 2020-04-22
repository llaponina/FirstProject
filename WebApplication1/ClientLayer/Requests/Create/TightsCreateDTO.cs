using System.ComponentModel.DataAnnotations;

namespace Client.Requests.Create
{
    public class TightsCreateDTO
    {
        
        public int? BuyerId{ get; set; }

        [Required(ErrorMessage = "Size is required")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public string Date { get; set; }

        public int? SupplierId { get; set; }
    }
}