using TodoPOCO;
using Xunit;

namespace TodoPOCO.Tests
{
    public class TodoRepositoryTests
    {
        [Fact]
        public void Add_ShouldAddItem()
        {
            // Arrange
            var repo = new TodoRepository();
            var item = new TodoItem("Test", "Testing add");

            // Act
            repo.Add(item);

            // Assert
            Assert.Single(repo.GetAll());
            Assert.Equal("Test", repo.GetAll()[0].Title);
        }

        [Fact]
        public void Get_ShouldReturnCorrectItem()
        {
            // Arrange
            var repo = new TodoRepository();
            repo.Add(new TodoItem("A", "First"));
            repo.Add(new TodoItem("B", "Second"));

            // Act
            var result = repo.Get(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("B", result!.Title);
        }

        [Fact]
        public void Delete_ShouldRemoveItem()
        {
            // Arrange
            var repo = new TodoRepository();
            repo.Add(new TodoItem("A", "First"));
            repo.Add(new TodoItem("B", "Second"));

            // Act
            repo.Delete(0);

            // Assert
            Assert.Single(repo.GetAll());
            Assert.Equal("B", repo.GetAll()[0].Title);
        }

        [Fact]
        public void Update_ShouldReplaceExistingItem()
        {
            // Arrange
            var repo = new TodoRepository();
            var oldItem = new TodoItem("Old", "Old desc");
            repo.Add(oldItem);

            var update = new TodoItem("New", "New desc");

            // Act
            repo.Update(update);

            // Assert
            Assert.Equal("New", repo.GetAll()[0].Title);
        }
    }
}
