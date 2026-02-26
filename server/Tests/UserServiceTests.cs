using DataService.Repositories;
using NUnit.Framework;
using PlanPoker.Services;
using System;
using System.Linq;

namespace Tests
{
    public class UserServiceTests
    {
        private InMemoryUserRepository userRepository;
        private InMemoryRoomRepository roomRepository;
        private UserService userService;

        private string userName;
        private string token;

        [SetUp]
        public void SetUp()
        {
            this.roomRepository = new InMemoryRoomRepository();
            this.userRepository = new InMemoryUserRepository();
            this.userService = new UserService(this.userRepository, this.roomRepository);
            this.userName = "Name";
            this.token = "token";
        }

        [Test]
        public void CreateUserTest()
        {
            var newUser = this.userService.Create(this.userName);
            Assert.AreEqual(this.userName, newUser.Name);
        }

        [Test]
        public void ChangeUsernameTest()
        {
            var newName = "newName";
            var user = this.userService.Create(this.userName);
            this.userService.ChangeName(user.Id, user.Token, newName);
            Assert.AreEqual(newName, user.Name);
        }

        [Test]
        public void GetUserTest()
        {
            var newUser = this.userService.Create(this.userName);
            var receivedUser = this.userService.Get(newUser.Token);
            Assert.AreEqual(newUser, receivedUser);
            Assert.AreEqual(newUser.Id, receivedUser.Id);
            Assert.AreEqual(newUser.Name, receivedUser.Name);
            Assert.AreEqual(newUser.Id, receivedUser.Id);
        }

        [Test]
        public void DeleteUserTest()
        {
            var user = this.userService.Create(this.userName);
            this.userService.Delete(user.Token);
            var isUserDeleted = this.userRepository.Get(user.Id) == null;
            var isUserDeletedFromAllRooms = this.roomRepository.GetAll().Where(item => item.Members.Contains(user)).Count() == 0;
            Assert.IsFalse(isUserDeleted);
            Assert.IsTrue(isUserDeletedFromAllRooms);
        }

        [Test]
        public void IsThrowExceptionOnInvalidNameTest()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() => this.userService.Create(string.Empty), "Wrong username");
                Assert.Throws<UnauthorizedAccessException>(() => this.userService.ChangeName(Guid.NewGuid(), this.token, string.Empty), "User not found");
                Assert.Throws<ArgumentException>(() => this.userService.Create(null), "Wrong username");
                Assert.Throws<UnauthorizedAccessException>(() => this.userService.ChangeName(Guid.NewGuid(), this.token, null), "User not found");
                Assert.Throws<UnauthorizedAccessException>(() => this.userService.Get(null), "Wrong token");
                Assert.Throws<UnauthorizedAccessException>(() => this.userService.Get(string.Empty), "Wrong token");
            });
        }
    }
}
