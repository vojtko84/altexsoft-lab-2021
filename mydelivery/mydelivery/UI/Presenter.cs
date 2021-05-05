using MyDelivery.Interfaces;
using MyDelivery.Models;
using MyDelivery.Validators;
using System;

namespace MyDelivery.Controllers
{
    public class Presenter
    {
        private readonly IContext context;
        private readonly IUserController userController;
        private readonly IProductController productController;
        private readonly IOrderController orderController;
        private readonly ICategoryController categoryController;
        private readonly IDeliveryAddressController deliveryAddressController;

        public Presenter(IContext context, IUserController userController, IProductController productController, IOrderController orderController, ICategoryController categoryController, IDeliveryAddressController deliveryAddressController)
        {
            this.context = context;
            this.userController = userController;
            this.productController = productController;
            this.categoryController = categoryController;
            this.deliveryAddressController = deliveryAddressController;
            this.orderController = orderController;
        }

        public void Run()
        {
            ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Hello, select user\n1. Buyer\n2. Seller\n3. Admin");
            var selectedUser = Console.ReadLine();
            userController.User = userController.SelectUserType(selectedUser);
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
            Console.WriteLine("Specify the delivery address or enter 'Q' to exit to the main menu");
            string address;
            do
            {                
                address = Console.ReadLine();
                if (address.ToUpper() == "Q")
                {
                    ShowMainMenu();
                }
                if (!Validator.IsValidDeliveryAddres(address))
                {
                    Console.WriteLine("Incorect input");
                    Console.Write("Re-enter the address or enter 'Q' to exit to the main menu: ");
                }
            } while (!Validator.IsValidDeliveryAddres(address));            
            var buyerId = userController.User.Id;            
            var deliveryAddress = deliveryAddressController.AddDeliveryAddress(address, buyerId);
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

            var sellerId = userController.User.Id;
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