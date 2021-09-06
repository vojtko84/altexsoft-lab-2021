using System.ComponentModel.DataAnnotations;

namespace AspMyDelivery.API.ViewModels
{
    public class ProductForCreateViewModel
    {
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter categoryId")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter providerId")]
        public int ProviderId { get; set; }
    }
}