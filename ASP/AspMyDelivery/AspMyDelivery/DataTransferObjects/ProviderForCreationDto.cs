using System.ComponentModel.DataAnnotations;

namespace AspMyDelivery.API.DataTransferObjects
{
    public class ProviderForCreationDto
    {
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
    }
}