using Mydelivery.Controllers;
using Mydelivery.Models;
using System;

namespace Mydelivery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var navigationController = new NavigationController();

            navigationController.RunMenu();
        }
    }
}