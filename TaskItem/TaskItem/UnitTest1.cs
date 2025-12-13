using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;

public class UnitTest1
{
    //  DOMAIN 
    public record TaskItem
    {
        public string Id { get; init; } = default!;
        public string Title { get; init; } = default!;
        public DateTime CreatedUtc { get; init; }
    }

    // REQUEST
    public record CreateTaskRequest(string Title);

    //VALIDATION
    public class CreateTaskValidator
    {
        public void Validate(CreateTaskRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Title))
                throw new ArgumentException("Title is required");
        }
    }

    // DATA SERVICE 
    public interface IFileDataService
    {
        Task SaveAsync(string key, TaskItem item);
        Task<TaskItem?> GetAsync(string key);
    }

    //HANDLER 
    public class CreateTaskHandler
    {
        private readonly IFileDataService _fileDataService;
        private readonly CreateTaskValidator _validator;

        public CreateTaskHandler(
            IFileDataService fileDataService,
            CreateTaskValidator validator)
        {
            _fileDataService = fileDataService;
            _validator = validator;
        }

        public async Task<TaskItem> HandleAsync(CreateTaskRequest request)
        {
            _validator.Validate(request);

            var task = new TaskItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                CreatedUtc = DateTime.UtcNow
            };

            await _fileDataService.SaveAsync(task.Id, task);

            return task;
        }
    }

    //  UNIT TEST 
    [Fact]
    public async Task CreateTask_ValidRequest_SavesAndCanBeRetrieved()
    {
        // Arrange
        var storage = new Dictionary<string, TaskItem>();

        var fileServiceMock = new Mock<IFileDataService>();

        fileServiceMock
            .Setup(x => x.SaveAsync(It.IsAny<string>(), It.IsAny<TaskItem>()))
            .Returns<string, TaskItem>((key, item) =>
            {
                storage[key] = item;
                return Task.CompletedTask;
            });

        fileServiceMock
            .Setup(x => x.GetAsync(It.IsAny<string>()))
            .Returns<string>(key =>
            {
                storage.TryGetValue(key, out var item);
                return Task.FromResult(item);
            });

        var handler = new CreateTaskHandler(
            fileServiceMock.Object,
            new CreateTaskValidator());

        var request = new CreateTaskRequest("Quick task");

        // Act
        var createdTask = await handler.HandleAsync(request);
        var retrievedTask = await fileServiceMock.Object.GetAsync(createdTask.Id);

        // Assert
        Assert.NotNull(retrievedTask);
        Assert.Equal(createdTask.Id, retrievedTask!.Id);
        Assert.Equal("Quick task", retrievedTask.Title);

        fileServiceMock.Verify(
            x => x.SaveAsync(createdTask.Id, It.IsAny<TaskItem>()),
            Times.Once);
    }
}
