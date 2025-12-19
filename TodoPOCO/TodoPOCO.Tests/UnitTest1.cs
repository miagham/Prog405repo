using Microsoft.VisualBasic;
using TodoPOCO;
using Xunit;

public class TodoRepositoryTests
{
    [Fact]
    public void Create_Returns_New_TodoItem()
    {
        // Arrange
        ICreate creator = new TodoRepository();

        // Act
        var item = creator.Create("Test", "Testing create");

        // Assert
        Assert.Equal("Test", item.Title);
        Assert.False(item.IsComplete);
    }

    [Fact]
    public void MarkComplete_Sets_IsComplete_To_True()
    {
        // Arrange
        IUpdate updater = new TodoRepository();
        var item = new TodoItem("Test", "Testing update");

        // Act
        updater.MarkComplete(item);

        // Assert
        Assert.True(item.IsComplete);
    }
}


