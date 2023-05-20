using FakeItEasy;
using System.Threading;
using UpSchool.Domain.Data;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Services;

namespace UpSchool.Domain.Tests.Data
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task AddAsync_ShouldThrowException_WhenEmailIsEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = userId,
                FirstName = "ayfer",
                LastName = "y",
                Age = 5,
                Email = null
            };

            //Act
            
            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.AddAsync(expectedUser.FirstName, expectedUser.LastName, expectedUser.Age, expectedUser.Email, cancellationSource.Token);
            
            //Assert
            Assert.Throws<ArgumentException>(() => user);

        }

        [Fact]
        public async void DeleteAsync_ShouldReturnTrue_WhenUserExists()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = userId
            };

            //A.CallTo(() => userRepositoryMock.DeleteAsync(ex, cancellationSource.Token))
            //    .Returns(Task.FromResult(expectedUser));

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.AddAsync("Ayfer", "Y", 20, "ayfer@gmail.com", cancellationSource.Token);


            var DeletedUser = await userService.DeleteAsync(userId, cancellationSource.Token);

            Assert.True(DeletedUser);
        }

        [Fact]
        public async void DeleteAsync_ShouldThrowException_WhenUserDoesntExists()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            var cancellationSource = new CancellationTokenSource();


            IUserService userService = new UserManager(userRepositoryMock);

            await Assert.ThrowsAsync<ArgumentException>(() => userService.DeleteAsync(Guid.NewGuid(), cancellationSource.Token));
        }

        [Fact]
        public async void UpdateAsync_ShouldThrowException_WhenUserIdIsEmpty()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = Guid.Empty,
                FirstName = "Ayfer",
                LastName = "Yıldırım",
                Age = 3,
                Email = "ajsfkja"
            };

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.UpdateAsync(expectedUser, cancellationSource.Token);

            Assert.Throws<ArgumentException>(() => user);
        }

        [Fact]
        public async void UpdateAsync_ShouldThrowException_WhenUserEmailEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            var cancellationSource = new CancellationTokenSource();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var expectedUser = new User()
            {
                Id = userId,
                FirstName = "Ayfer",
                LastName = "Yıldırım",
                Age = 26,
                Email = String.Empty
            };

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.UpdateAsync(expectedUser, cancellationSource.Token);

            Assert.Throws<ArgumentException>(() => user);

        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn_UserListWithAtLeastTwoRecords()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            var cancellationSource = new CancellationTokenSource();
            List<User> userList = new List<User>();

            userList.Add(new User() { Id = Guid.NewGuid() });
            userList.Add(new User() { Id = Guid.NewGuid() });
            userList.Add(new User() { Id = Guid.NewGuid() });

            A.CallTo(() => userRepositoryMock.GetAllAsync(cancellationSource.Token))
                .Returns(Task.FromResult(userList));

            IUserService userService = new UserManager(userRepositoryMock);

            var allUsers = await userService.GetAllAsync(cancellationSource.Token);

            Assert.True(allUsers.Count >= 2);
        }
    }
}


