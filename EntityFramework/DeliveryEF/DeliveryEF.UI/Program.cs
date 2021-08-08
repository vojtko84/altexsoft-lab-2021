using DeliveryEF.Data;

namespace DeliveryEF.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var context = new DataContext();
            context.Database.EnsureCreated();
        }
    }
}