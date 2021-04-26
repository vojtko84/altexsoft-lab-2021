using Mydelivery.Controllers;
using Mydelivery.Data;

namespace Mydelivery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var context = new Context();

            var presenter = new Presenter(context);

            presenter.Run();
        }
    }
}