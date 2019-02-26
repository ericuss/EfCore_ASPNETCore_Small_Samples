using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Creating.From.Context.Contexts;
using Creating.From.Context.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace Creating.From.Api.UnitTests.AuthorsV3Controller
{
    public class AuthorsV3ControllerGetTests
    {
        [Fact]
        public async Task Call_To_Get_And_Get_Authors()
        {
            // Arrange 
            var authors = new List<Author>()
            {
                new Author(){ Id = Guid.NewGuid(), Name ="Test author" }
            };

            var options = new DbContextOptions<LibraryContext>();
            var mockEF = new Mock<LibraryContext>(options);
            mockEF.Setup(x => x.Authors).ReturnsDbSet(authors);

            var authorsController = new Controllers.AuthorsV3Controller(mockEF.Object);
            // Act
            var response = await authorsController.Get();
            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(response);
            Assert.NotNull(objectResult.Value);
        }


        [Fact]
        public async Task Call_To_Get_And_Get_Authors_And_Verify_Authors()
        {
            // Arrange 
            var authors = new List<Author>()
            {
                new Author(){ Id = Guid.NewGuid(), Name ="Test author" }
            };

            var options = new DbContextOptions<LibraryContext>();
            var mockEF = new Mock<LibraryContext>(options);
            mockEF.Setup(x => x.Authors).ReturnsDbSet(authors);

            var authorsController = new Controllers.AuthorsV3Controller(mockEF.Object);
            // Act
            var response = await authorsController.Get();
            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(response);
            Assert.NotNull(objectResult.Value);

            var authorsResult = objectResult.Value as IEnumerable<Author>;
            Assert.NotNull(authorsResult);
            Assert.True(authorsResult.Any());
            Assert.Equal(authors.First().Name, authorsResult.First().Name);

        }
    }
}
