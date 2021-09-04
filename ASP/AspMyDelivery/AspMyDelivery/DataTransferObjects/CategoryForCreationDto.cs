using System.ComponentModel.DataAnnotations;

namespace AspMyDelivery.API.DataTransferObjects
{
    public class CategoryForCreationDto
    {
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
    }
}