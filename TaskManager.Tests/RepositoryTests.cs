using TaskManager.CLI.Data;
using TaskManager.CLI.Exceptions;
using TaskManager.CLI.Models;
using Xunit;

namespace TaskManager.Tests;

public class RepositoryTests
{
    [Fact]
    public async Task AddAsync_ShouldIncreaseCount()
    {
        // Arrange
        // We use a specific test file so we don't mess up your real tasks.json
        var repo = new JsonRepository<ProjectTask>("test_tasks.json");
        var newTask = new ProjectTask { Title = "Unit Test Task" };

        // Act
        await repo.AddAsync(newTask);
        var allTasks = await repo.GetAllAsync();

        // Assert
        Assert.Contains(allTasks, t => t.Title == "Unit Test Task");

        // Clean up: Delete the test file after testing
        if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test_tasks.json")))
        {
            File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test_tasks.json"));
        }
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrowException_WhenIdDoesNotExist()
    {
        // Arrange
        var repo = new JsonRepository<ProjectTask>("test_error.json");

        // Act & Assert
        // We expect this specific exception to be thrown
        await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
        {
            await repo.DeleteAsync(999); // ID 999 definitely doesn't exist
        });
    }
}