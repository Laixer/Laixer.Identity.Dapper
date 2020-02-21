using Laixer.Identity.Dapper.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Laixer.Identity.Dapper.Tests
{
    public class UserStoreTest
    {
        private readonly Mock<ILoggerFactory> _mockLoggerFactory;
        private readonly Mock<IDatabaseDriver> _mockDatabase;

        public UserStoreTest()
        {
            _mockLoggerFactory = new Mock<ILoggerFactory>();
            _mockDatabase = new Mock<IDatabaseDriver>();
        }

        [Fact(Skip = "not working")]
        public async Task CreateTest()
        {
            // Arrange
            var user = new IdentityUser();

            // Act
            var store = new Store.UserStore<IdentityUser>(Options.Create(DapperOptions()), _mockLoggerFactory.Object);

            // Assert
            var result = await store.CreateAsync(user, default);
            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task GetUserIdTest()
        {
            // Arrange
            var user = new IdentityUser();

            // Act
            var store = new Store.UserStore<IdentityUser>(Options.Create(DapperOptions()), _mockLoggerFactory.Object);

            // Assert
            var result = await store.GetUserIdAsync(user, default);
            Assert.Equal(user.Id, result);
        }

        [Fact]
        public async Task GetNormalizedUserNameTest()
        {
            // Arrange
            var user = new IdentityUser
            {
                NormalizedUserName = "SOMENAME"
            };

            // Act
            var store = new Store.UserStore<IdentityUser>(Options.Create(DapperOptions()), _mockLoggerFactory.Object);

            // Assert
            var result = await store.GetNormalizedUserNameAsync(user, default);
            Assert.Equal(user.NormalizedUserName, result);
        }

        private static IdentityDapperOptions DapperOptions()
        {
            return new IdentityDapperOptions
            {
                ConnectionString = "connectionString",
                Schema = "schema",
                UserTable = "userTable",
                RoleTable = "roleTable",
                Database = new MockDb(new Mock<System.Data.IDbConnection>().Object),
            };
        }
    }
}
