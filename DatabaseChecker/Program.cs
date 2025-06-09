using Microsoft.EntityFrameworkCore;
using TodoListApp.Data;
using TodoListApp.Models;
using Task = TodoListApp.Models.Task;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite("Data Source=../TodoListApp/app.db")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            Console.WriteLine("Contenu de la base de données :");
            Console.WriteLine("\nTâches :");
            var tasks = await context.Tasks.ToListAsync();
            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine($"Titre: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Date d'échéance: {task.DueDate}");
                Console.WriteLine($"Utilisateur ID: {task.UserId}");
                Console.WriteLine("-------------------");
            }

            Console.WriteLine("\nUtilisateurs :");
            var users = await context.Users.ToListAsync();
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Nom d'utilisateur: {user.UserName}");
                Console.WriteLine("-------------------");
            }
        }
    }
}
