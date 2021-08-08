using System.IO;
using Microsoft.Extensions.Configuration;

namespace Delivery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }

        private static IConfigurationRoot Initialize()
        {
            var builder = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}