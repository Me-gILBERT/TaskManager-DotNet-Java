using TaskManager.CLI.Models;
using TaskManager.CLI.Interfaces;
using TaskManager.CLI.Data;

// 1. Initialize the Engine
// We program to the Interface (IRepository) but use the Implementation (InMemoryRepository)
IRepository<ProjectTask> taskRepo = new InMemoryRepository<ProjectTask>();

Console.WriteLine("--- Jakarta Dev Task Manager ---");

// 2. Add a Task
var task1 = new ProjectTask { Title = "Complete .NET Module 1" };
await taskRepo.AddAsync(task1);

var task2 = new ProjectTask { Title = "Review Java Bridge (Streams vs LINQ)" };
await taskRepo.AddAsync(task2);

// 3. Update a Task (Simulate completing the first one)
task1.IsCompleted = true;
await taskRepo.UpdateAsync(task1);

// 4. Display the results
var allTasks = await taskRepo.GetAllAsync();

Console.WriteLine("\nCurrent Tasks in Memory:");
foreach (var task in allTasks)
{
    // This calls the custom ToString() override you wrote!
    Console.WriteLine(task.ToString());
    Console.WriteLine($"Priority: {task.Priority}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();