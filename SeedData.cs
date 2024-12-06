using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace YourNamespace.Data
{
    public static class SeedData
    {
        public static void Generate(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            
            if (context.TodoLists.Any())
            {
                return;
            }

            
            var user = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                EmailConfirmed = true
            };

            userManager.CreateAsync(user, "Password123!").Wait();

            
            var list = new TodoList
            {
                Title = "Default List"
            };

            list.Items.Add(new TodoItem { Title = "Task 1" });
            list.Items.Add(new TodoItem { Title = "Task 2" });

            context.TodoLists.Add(list);

            
            for (int i = 2; i <= 10; i++)
            {
                context.TodoLists.Add(new TodoList
                {
                    Title = $"List {i}",
                    Items = { new TodoItem { Title = $"Task {i}.1" } }
                });
            }

            context.SaveChanges();
        }
    }
}
