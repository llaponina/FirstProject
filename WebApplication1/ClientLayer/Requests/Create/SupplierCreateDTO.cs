using System.ComponentModel.DataAnnotations;

namespace Client.Requests.Create
{
    public class SupplierCreateDTO
    {

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}