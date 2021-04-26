using Mydelivery.Data;
using Mydelivery.Models;
using System;

namespace Mydelivery.Controllers
{
    public class Presenter
    {
        private readonly Context context;
        private readonly UserController userController;
        private readonly ProductController productController;
        private readonly OrderController orderController;
        private readonly CategoryController categoryController;
        private readonly DeliveryAddressController deliveryAddressController;

        public Presenter(Context context)
        {
            this.context = context;
            userController = new UserController();
            productController = new ProductController(context);
            categoryController = new CategoryController(context);
            deliveryAddressController = new DeliveryAddressController(context);
            orderController = new OrderController(context);
        }

        public void Run()
        {
            ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("Hello, select user\n1. Buyer\n2. Seller\n3. Admin");
            var selectedUser = Console.ReadLine();
            userController.User = userController.SelectUser(selectedUser);
            switch (userController.User)
            {
                case Buyer:
                    RunBuyersScript();
                    break;

                case Seller:
                    RunSellersScript();
                    break;

                case Admin:
                    RunAdminScript();
                    break;

                default:
                    Console.WriteLine("Incorect input");
                    break;
            }
        }

        private void RunBuyersScript()
        {
            Console.Clear();
            Console.WriteLine("1. View product list\n2. Create order.");
            var userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                ShowProducts();
            }

            if (userChoice == "2")
            {
                CreateOrder();
            }
        }

        private void CreateOrder()
        {
            Console.Clear();
            Console.WriteLine("Choose a product");
            ShowProducts();
            int userChoise;
            while (!int.TryParse(Console.ReadLine(), out userChoise))
            {
                Console.Write("Incorrect input, enter number: ");
            }
            var selectedProduct = productController.GetProduct(userChoise);
            Console.WriteLine("Please provide the shipping address");
            Console.WriteLine("Enter house number");
            var houseNumber = Console.ReadLine();
            Console.WriteLine("Enter street name");
            var streetName = Console.ReadLine();
            Console.WriteLine("Enter apartment number");
            var apartmentNumber = Console.ReadLine();
            Console.WriteLine("Enter city name");
            var cityName = Console.ReadLine();
            Console.WriteLine("Enter area name");
            var areaName = Console.ReadLine();
            Console.WriteLine("Enter PostCode");
            var postCode = Console.ReadLine();
            var buyerId = ((Buyer)userController.User).Id;
            var deliveryAddress = deliveryAddressController.AddDeliveryAddress(houseNumber, streetName, apartmentNumber, cityName, areaName, postCode, buyerId);
            orderController.AddOrder(buyerId, selectedProduct, deliveryAddress);
            Console.WriteLine("Order created");
        }

        private void ShowProducts()
        {            
            foreach (var item in productController.GetProducts())
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }

        private void PostProduct()
        {
            Console.WriteLine("Enter product name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter descriptionb");
            var description = Console.ReadLine();
            Console.WriteLine("Select a product category.");
            foreach (var item in context.Categories)
            {
                Console.WriteLine($"{item.Id} {item.Name}.");
            }
            int categoryId;
            while (!int.TryParse(Console.ReadLine(), out categoryId))
            {
                Console.Write("Incorrect input, enter number: ");
            }
            decimal price;
            Console.WriteLine("Enter price");
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("Incorrect input, enter number: ");
            }

            var sellerId = ((Seller)userController.User).Id;
            productController.AddProduct(name, description, categoryId, price, sellerId);
            Console.WriteLine("Product added");
        }

        private void RunSellersScript()
        {
            Console.Clear();
            Console.WriteLine("1. View product list.\n2. Add your product.");
            var userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                ShowProducts();
            }
            if (userChoice == "2")
            {
                PostProduct();
            }
        }

        private void RunAdminScript()
        {
            Console.Clear();
            Console.WriteLine("1. View categories\n2. Create category");
            var userChoise = Console.ReadLine();
            switch (userChoise)
            {
                case "1":
                    ShowCategories();
                    break;

                case "2":
                    CreateCategory();
                    break;

                default:
                    break;
            }
        }

        private void ShowCategories()
        {
            foreach (var item in categoryController.GetCategories())
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }

        private void CreateCategory()
        {
            Console.Clear();
            Console.Write("Enter category name: ");
            var name = Console.ReadLine();
            categoryController.AddCategory(name);
        }
    }
}