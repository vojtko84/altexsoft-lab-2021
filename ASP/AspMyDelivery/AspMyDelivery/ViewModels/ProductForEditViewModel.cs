using System.ComponentModel.DataAnnotations;

namespace AspMyDelivery.API.ViewModels
{
    public class ProductForEditViewModel
    {
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        public decimal Price { get; set; }
    }
}