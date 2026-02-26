using TaskManager.CLI.Models;
using TaskManager.CLI.Interfaces;
using TaskManager.CLI.Data;

// Initialize the persistent repository
IRepository<ProjectTask> taskRepo = new JsonRepository<ProjectTask>("tasks.json");

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("=== JAKARTA DEV TASK MANAGER ===");

    // 1. Display current tasks from JSON
    var tasks = await taskRepo.GetAllAsync();
    foreach (var t in tasks)
    {
        Console.WriteLine(t.ToString());
    }

    Console.WriteLine("\n[A] Add Task | [C] Mark Completed | [D] Delete | [Q] Quit");
    var input = Console.ReadKey(true).Key;

    switch (input)
    {
        case ConsoleKey.A:
            Console.Write("\nEnter Task Title: ");
            var title = Console.ReadLine();
            if (!string.IsNullOrEmpty(title))
                await taskRepo.AddAsync(new ProjectTask { Title = title });
            break;

        case ConsoleKey.C:
            Console.Write("\nEnter ID to Complete: ");
            if (int.TryParse(Console.ReadLine(), out int cId))
            {
                var task = await taskRepo.GetByIdAsync(cId);
                if (task != null)
                {
                    task.IsCompleted = true;
                    await taskRepo.UpdateAsync(task);
                }
            }
            break;

        case ConsoleKey.D:
            Console.Write("\nEnter ID to Delete: ");
            if (int.TryParse(Console.ReadLine(), out int dId))
                await taskRepo.DeleteAsync(dId);
            break;

        case ConsoleKey.Q:
            running = false;
            break;
    }
}