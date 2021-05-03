using System.Text.RegularExpressions;

namespace MyDelivery.Validators
{
    public static class Validator
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            var pattern = @"^([+]38)?0[(]?\d{2}[)]?\s?\d{3}\s?\d{2}\s?\d{2}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }

        public static bool IsValidDeliveryAddres(string deliveryAddres)
        {
            var pattern = @"^(ул\.|улица\s)[А-я)]+(\.|,)\s?(д\.|дом)\s?\d+(,\s?(кв\.|квартира)\s?\d+)?$";
            var regex = new Regex(pattern);
            return regex.IsMatch(deliveryAddres);
        }
    }
}