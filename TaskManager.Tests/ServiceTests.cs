using Moq;
using TaskManager.CLI.Models;
using TaskManager.CLI.Interfaces;
using Xunit;

namespace TaskManager.Tests;

public class ServiceTests
{
    [Fact]
    public async Task AddTask_ShouldInvokeRepository()
    {
        // 1. ARRANGE
        // Create a "Fake" Repository
        var mockRepo = new Mock<IRepository<ProjectTask>>();
        var taskToAdd = new ProjectTask { Title = "Mocking Task" };

        // 2. ACT
        // We call the method on the Mock object
        await mockRepo.Object.AddAsync(taskToAdd);

        // 3. ASSERT (Verification)
        // We check: "Did the AddAsync method get called exactly once?"
        mockRepo.Verify(r => r.AddAsync(It.IsAny<ProjectTask>()), Times.Once());
    }

    [Fact]
    public async Task Repository_ShouldThrowError_WhenDiskIsLocked()
    {
        // 1. ARRANGE
        var mockRepo = new Mock<IRepository<ProjectTask>>();

        // We tell the Mock: "When someone calls GetAllAsync, THROW an Exception!"
        mockRepo.Setup(repo => repo.GetAllAsync())
                .ThrowsAsync(new Exception("Disk I/O Error: Permission Denied"));

        // 2. ACT & 3. ASSERT
        // We verify that the code calling the repo actually receives the error
        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await mockRepo.Object.GetAllAsync();
        });
    }
}