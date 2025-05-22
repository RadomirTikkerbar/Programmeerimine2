using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace KooliProjekt.Data
{
    public static class SeedData
    {
        [ExcludeFromCodeCoverage]
        public static void Generate(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            if (context.ProductCategory.Any())
            {
                return;
            }

            //var list = new TodoList();
            //list.Title = "List 1";
            //list.Items.Add(new TodoItem
            //{
            //    Title = "Item 1.1"
            //});

            //context.TodoLists.Add(list);

            var user = new IdentityUser
            {
                UserName = "admin",
                Email = "admin",
                EmailConfirmed = true
            };

            // Add new user and their role

            userManager.CreateAsync(user, "Password123!").Wait();


            var category1 = new ProductCategory();
            category1.Name = "Category 1";
            context.ProductCategory.Add(category1);

            var category2 = new ProductCategory();
            category2.Name = "Category 2";
            context.ProductCategory.Add(category2);

            var category3 = new ProductCategory();
            category3.Name = "Category 3";
            context.ProductCategory.Add(category3);

            var category4 = new ProductCategory();
            category4.Name = "Category 4";
            context.ProductCategory.Add(category4);

            var category5 = new ProductCategory();
            category5.Name = "Category 5";
            context.ProductCategory.Add(category5);

            var category6 = new ProductCategory();
            category6.Name = "Category 6";
            context.ProductCategory.Add(category6);

            var category7 = new ProductCategory();
            category7.Name = "Category 7";
            context.ProductCategory.Add(category7);

            var category8 = new ProductCategory();
            category8.Name = "Category 8";
            context.ProductCategory.Add(category8);

            var category9 = new ProductCategory();
            category9.Name = "Category 9";
            context.ProductCategory.Add(category9);

            var category10 = new ProductCategory();
            category10.Name = "Category 10";
            context.ProductCategory.Add(category10);


            var product1 = new Product();
            product1.Name = "Product 1";
            product1.ProductCategory = category1;
            product1.Price = 12;
            product1.Description = "Description 1";
            context.Product.Add(product1);

            var product2 = new Product();
            product2.Name = "Product 2";
            product2.ProductCategory = category2;
            product2.Price = 12;
            product1.Description = "Description 2";
            context.Product.Add(product2);

            var product3 = new Product();
            product3.Name = "Product 3";
            product3.ProductCategory = category3;
            product3.Price = 12;
            product1.Description = "Description 3";
            context.Product.Add(product3);

            var product4 = new Product();
            product4.Name = "Product 4";
            product4.ProductCategory = category4;
            product4.Price = 12;
            product1.Description = "Description 4";
            context.Product.Add(product4);

            var product5 = new Product();
            product5.Name = "Product 5";
            product5.ProductCategory = category5;
            product5.Price = 12;
            product1.Description = "Description 5";
            context.Product.Add(product5);

            var product6 = new Product();
            product6.Name = "Product 6";
            product6.ProductCategory = category6;
            product6.Price = 12;
            product1.Description = "Description 6";
            context.Product.Add(product6);

            var product7 = new Product();
            product7.Name = "Product 7";
            product7.ProductCategory = category7;
            product7.Price = 12;
            product1.Description = "Description 7";
            context.Product.Add(product7);

            var product8 = new Product();
            product8.Name = "Product 8";
            product8.ProductCategory = category8;
            product8.Price = 12;
            product1.Description = "Description 8";
            context.Product.Add(product8);

            var product9 = new Product();
            product9.Name = "Product 9";
            product9.ProductCategory = category9;
            product9.Price = 12;
            product1.Description = "Description 9";
            context.Product.Add(product9);

            var product10 = new Product();
            product10.Name = "Product 10";
            product10.ProductCategory = category10;
            product10.Price = 12;
            product1.Description = "Description 10";
            context.Product.Add(product10);


            var order1 = new Order();
            order1.Date = DateTime.Now;
            order1.User = user;
            context.Order.Add(order1);

            var order2 = new Order();
            order2.Date = DateTime.Now;
            order2.User = user;
            context.Order.Add(order2);

            var order3 = new Order();
            order3.Date = DateTime.Now;
            order3.User = user;
            context.Order.Add(order3);

            var order4 = new Order();
            order4.Date = DateTime.Now;
            order4.User = user;
            context.Order.Add(order4);

            var order5 = new Order();
            order5.Date = DateTime.Now;
            order5.User = user;
            context.Order.Add(order5);

            var order6 = new Order();
            order6.Date = DateTime.Now;
            order6.User = user;
            context.Order.Add(order6);

            var order7 = new Order();
            order7.Date = DateTime.Now;
            order7.User = user;
            context.Order.Add(order7);

            var order8 = new Order();
            order8.Date = DateTime.Now;
            order8.User = user;
            context.Order.Add(order8);

            var order9 = new Order();
            order9.Date = DateTime.Now;
            order9.User = user;
            context.Order.Add(order9);

            var order10 = new Order();
            order10.Date = DateTime.Now;
            order10.User = user;
            context.Order.Add(order10);



            var orderline1 = new OrderLine();
            orderline1.Order = order1;
            orderline1.Product = product1;
            orderline1.Amount = 3;
            orderline1.Price = 12;
            context.OrderLine.Add(orderline1);

            var orderline2 = new OrderLine();
            orderline2.Order = order2;
            orderline2.Product = product2;
            orderline2.Amount = 3;
            orderline2.Price = 12;
            context.OrderLine.Add(orderline1);

            var orderline3 = new OrderLine();
            orderline3.Order = order3;
            orderline3.Product = product3;
            orderline3.Amount = 3;
            orderline3.Price = 12;
            context.OrderLine.Add(orderline1);

            var orderline4 = new OrderLine();
            orderline4.Order = order4;
            orderline4.Product = product4;
            orderline4.Amount = 3;
            orderline4.Price = 12;
            context.OrderLine.Add(orderline1);

            var orderline5 = new OrderLine();
            orderline5.Order = order5;
            orderline5.Product = product5;
            orderline5.Amount = 3;
            orderline5.Price = 12;
            context.OrderLine.Add(orderline1);

            var orderline6 = new OrderLine();
            orderline6.Order = order6;
            orderline6.Product = product6;
            orderline6.Amount = 3;
            orderline6.Price = 12;
            context.OrderLine.Add(orderline1);

            var orderline7 = new OrderLine();
            orderline7.Order = order7;
            orderline7.Product = product7;
            orderline7.Amount = 3;
            orderline7.Price = 12;
            context.OrderLine.Add(orderline1);

            var orderline8 = new OrderLine();
            orderline8.Order = order8;
            orderline8.Product = product8;
            orderline8.Amount = 3;
            orderline8.Price = 12;
            context.OrderLine.Add(orderline1);

            var orderline9 = new OrderLine();
            orderline9.Order = order9;
            orderline9.Product = product9;
            orderline9.Amount = 3;
            orderline9.Price = 12;
            context.OrderLine.Add(orderline1);

            var orderline10 = new OrderLine();
            orderline10.Order = order10;
            orderline10.Product = product10;
            orderline10.Amount = 3;
            orderline10.Price = 12;
            context.OrderLine.Add(orderline1);



            // Veel andmeid

            context.SaveChanges();
        }
    }
}
