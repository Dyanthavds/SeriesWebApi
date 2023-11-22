using Microsoft.EntityFrameworkCore;
using Moq;
using XprtzSerieApp.Database;
using XprtzSerieApp.Database.Entities;

namespace Unittests
{
    public class ShowUnitTests
    {
        [Fact]
        public async Task TestGetShowAsync()
        {
            // Arrange
            var dbContextMock = new Mock<ShowContext>();
            var repository = new ShowRepository(dbContextMock.Object);

            var id = 1;
            var entityModel = new ShowEntity { Id = id, Name = "EntityName" };
            var shows = new List<ShowEntity>() { entityModel };
            var dbSetMock = new Mock<DbSet<ShowEntity>>();

            dbSetMock.As<IQueryable<ShowEntity>>().Setup(m => m.Provider).Returns(shows.AsQueryable().Provider);
            dbSetMock.As<IQueryable<ShowEntity>>().Setup(m => m.Expression).Returns(shows.AsQueryable().Expression);
            dbSetMock.As<IQueryable<ShowEntity>>().Setup(m => m.ElementType).Returns(shows.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<ShowEntity>>().Setup(m => m.GetEnumerator()).Returns(() => shows.GetEnumerator());

            dbContextMock.Setup(db => db.Shows)
                        .Returns(dbSetMock.Object);

            // Act
            var result = await repository.GetShowAsync("EntityName");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("EntityName", result.Name);
        }
    }
}