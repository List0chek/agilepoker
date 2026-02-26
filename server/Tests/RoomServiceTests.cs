using DataService.Repositories;
using NUnit.Framework;
using PlanPoker.Models;
using PlanPoker.Services;
using System.Linq;

namespace Tests
{
    public class RoomServiceTests
    {
        private InMemoryRoomRepository roomRepository;
        private InMemoryUserRepository userRepository;
        private InMemoryDiscussionRepository discussionRepository;
        private InMemoryVoteRepository voteRepository;
        private InMemoryCardRepository cardRepository;

        private RoomService roomService;
        private DiscussionService discussionService;
        private UserService userService;
        private VoteService voteService;
        private User owner;
        private string ownerName;
        private string roomName;

        [SetUp]
        public void SetUp()
        {
            this.roomRepository = new InMemoryRoomRepository();
            this.userRepository = new InMemoryUserRepository();
            this.discussionRepository = new InMemoryDiscussionRepository();
            this.voteRepository = new InMemoryVoteRepository();
            this.cardRepository = new InMemoryCardRepository();
            this.voteService = new VoteService(this.voteRepository, this.cardRepository, this.discussionRepository, this.userRepository);
            this.discussionService = new DiscussionService(this.discussionRepository, this.roomRepository, this.voteRepository, this.userRepository, this.voteService, this.cardRepository);
            this.userService = new UserService(this.userRepository, this.roomRepository);
            this.ownerName = "ownerName";
            this.owner = this.userService.Create(this.ownerName);


            this.roomService = new RoomService(this.roomRepository, this.userRepository, this.userService, this.discussionService);
            this.roomName = "roomName";
        }

        [Test]
        public void CreateRoomTest()
        {
            var room = this.roomService.Create(this.roomName, this.owner.Id, this.owner.Token);
            Assert.IsNotNull(room);
            Assert.AreEqual(this.roomName, room.Name);
            Assert.AreEqual(this.owner.Id, room.OwnerId);
            Assert.AreEqual(this.owner.Id, room.HostId);
            Assert.IsTrue(room.Members.Count(item => item == this.owner) == 1);
        }

        [Test]
        public void AddMemberToTheRoomTest()
        {
            var room = this.roomService.Create(this.roomName, this.owner.Id, this.owner.Token);
            var newUser = this.userService.Create("newUserName");
            this.roomService.AddMember(room.Id, newUser.Id);

            Assert.IsTrue(room.Members.Contains(this.owner));
            Assert.IsTrue(room.Members.Contains(newUser));
            Assert.IsTrue(room.Members.Count(item => item == newUser) == 1);
        }

        [Test]
        public void ChangeRoomHostTest()
        {
            var room = this.roomService.Create(this.roomName, this.owner.Id, this.owner.Token);
            var newUser = this.userService.Create("newUserName");
            this.roomService.ChangeHost(room.Id, newUser.Id, this.owner.Id);

            Assert.AreEqual(this.owner.Id, room.OwnerId);
            Assert.AreEqual(newUser.Id, room.HostId);
            Assert.IsTrue(room.Members.Contains(this.owner));
            Assert.IsTrue(room.Members.Contains(newUser));
            Assert.IsTrue(room.Members.Count(item => item == this.owner) == 1);
            Assert.IsTrue(room.Members.Count(item => item == newUser) == 1);
        }

        [Test]
        public void GetRoomInfoTest()
        {
            var room = this.roomService.Create(this.roomName, this.owner.Id, this.owner.Token);
            var receivedRoom = this.roomService.GetRoomInfo(room.Id, this.owner.Id);

            Assert.IsNotNull(room);
            Assert.IsNotNull(receivedRoom);
            Assert.AreEqual(receivedRoom, receivedRoom);
        }
    }
}
