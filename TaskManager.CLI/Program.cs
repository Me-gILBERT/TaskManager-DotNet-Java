using Microsoft.Extensions.DependencyInjection;
using TaskManager.CLI.Data;
using TaskManager.CLI.Exceptions;
using TaskManager.CLI.Interfaces;
using TaskManager.CLI.Models;
using TaskManager.CLI.Persistence;
using TaskManager.CLI.Services;

// --- 1. SET UP THE SERVICE CONTAINER ---
var serviceCollection = new ServiceCollection();

// A. Register the Database Context (EF Core)
serviceCollection.AddDbContext<AppDbContext>();

// B. Register the SQL Repository 
// We use 'AddScoped' for databases to ensure connections are closed after use.
serviceCollection.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));

// C. Register the Service Layer (The "Chef")
// This was missing in your last run! 
serviceCollection.AddTransient<TaskService>();

// --- 2. BUILD THE PROVIDER ---
var serviceProvider = serviceCollection.BuildServiceProvider();

// --- 3. RESOLVE THE SERVICE ---
// We ask for the TaskService; the container automatically injects the SqlRepository into it.
var taskService = serviceProvider.GetRequiredService<TaskService>();

// 4. "Order" the service
var taskRepo = serviceProvider.GetRequiredService<IRepository<ProjectTask>>();
bool running = true;

while (running)
{
    try
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("    JAKARTA TASK MANAGER (VER 1.1)     ");
        Console.WriteLine("========================================");

        // Load and display current tasks
        var tasks = await taskRepo.GetAllAsync();
        if (!tasks.Any())
        {
            Console.WriteLine("\n [ No tasks found. Start by adding one! ]");
        }
        else
        {
            foreach (var t in tasks)
            {
                // We'll use a simple colored output for completion status
                var status = t.IsCompleted ? "[DONE]" : "[PENDING]";
                Console.WriteLine($"{t.Id}. {status} {t.Title}");
            }
        }

        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("[A] Add Task | [C] Complete | [D] Delete | [Q] Quit");
        Console.Write("Choose an option: ");

        var input = Console.ReadKey(true).Key;

        switch (input)
        {
            case ConsoleKey.A:
                Console.Write("\n\nEnter Task Title: ");
                var title = Console.ReadLine();

                // --- INPUT VALIDATION ---
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new ArgumentException("Task title cannot be empty or just spaces.");
                }

                await taskRepo.AddAsync(new ProjectTask { Title = title, IsCompleted = false });
                break;

            case ConsoleKey.C:
                Console.Write("\n\nEnter Task ID to mark as Completed: ");
                if (int.TryParse(Console.ReadLine(), out int cId))
                {
                    var taskToComplete = await taskRepo.GetByIdAsync(cId);

                    // The Repository will throw EntityNotFoundException if we tried 
                    // to call an update on a null, but we check here for better UI flow.
                    if (taskToComplete == null) throw new EntityNotFoundException("Task", cId);

                    taskToComplete.IsCompleted = true;
                    await taskRepo.UpdateAsync(taskToComplete);
                }
                break;

            case ConsoleKey.D:
                Console.Write("\n\nEnter Task ID to Delete: ");
                if (int.TryParse(Console.ReadLine(), out int dId))
                {
                    await taskRepo.DeleteAsync(dId);
                    Console.WriteLine("\nTask deleted successfully!");
                }
                break;

            case ConsoleKey.Q:
                running = false;
                break;
        }
    }
    // --- ERROR HANDLING LAYER ---
    catch (EntityNotFoundException ex)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n\n[NOT FOUND] {ex.Message}");
        Console.ResetColor();
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
    }
    catch (ArgumentException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n\n[VALIDATION ERROR] {ex.Message}");
        Console.ResetColor();
        Console.WriteLine("Press any key to try again...");
        Console.ReadKey();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n\n[CRITICAL ERROR] Something went wrong: {ex.Message}");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        running = false;
    }
}

Console.WriteLine("\nTerima Kasih! Closing Task Manager...");