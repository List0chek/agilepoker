using System.Linq;
using DataService.Repositories;
using NUnit.Framework;
using PlanPoker.Models;
using PlanPoker.Services;

namespace Tests
{
  public class DiscussionServiceTests
  {
    private InMemoryUserRepository userRepository;
    private InMemoryRoomRepository roomRepository;
    private InMemoryDiscussionRepository discussionRepository;
    private InMemoryVoteRepository voteRepository;
    private InMemoryCardRepository cardRepository;


    private DiscussionService discussionService;
    private VoteService voteService;

    private User host;
    private Room room;
    private Card card1;
    private Card card2;
    private string topicName;

    [SetUp]
    public void SetUp()
    {
      this.userRepository = new InMemoryUserRepository();
      this.roomRepository = new InMemoryRoomRepository();
      this.discussionRepository = new InMemoryDiscussionRepository();
      this.cardRepository = new InMemoryCardRepository();
      this.voteRepository = new InMemoryVoteRepository();

      this.voteService = new VoteService(
          this.voteRepository,
          this.cardRepository,
          this.discussionRepository,
          this.userRepository);

      this.discussionService = new DiscussionService(
          this.discussionRepository,
          this.roomRepository,
          this.voteRepository,
          this.userRepository,
          this.voteService,
          this.cardRepository);

      this.host = this.userRepository.Create();
      this.host.Token = "token";
      this.host.Name = "hostName";
      this.userRepository.Save(this.host);

      this.room = this.roomRepository.Create();
      this.room.Name = "roomName";
      this.room.OwnerId = this.host.Id;
      this.room.HostId = this.host.Id;
      this.room.Members.Add(this.host);
      this.roomRepository.Save(this.room);

      this.topicName = "topicName 1";

      this.card1 = this.cardRepository.Create();
      this.card1.Name = "8";
      this.card1.Value = "8";
      this.cardRepository.Save(this.card1);

      this.card2 = this.cardRepository.Create();
      this.card2.Name = "?";
      this.card2.Value = "?";
      this.cardRepository.Save(this.card2);
    }

    [Test]
    public void CreateDiscussionTest()
    {
      var discussion = this.discussionService.Create(this.room.Id, this.topicName, this.room.HostId, this.host.Token);
      Assert.IsNotNull(discussion);
      Assert.IsNotNull(discussion.Id);
      Assert.AreEqual(this.topicName, discussion.Topic);
      Assert.AreEqual(this.room.Id, discussion.RoomId);
      Assert.AreEqual(null, discussion.AverageResult);
      Assert.IsNotNull(discussion.DateStart);
      Assert.IsNull(discussion.DateEnd);
    }

    [Test]
    public void SetVoteInDiscussionTest()
    {
      var discussion = this.discussionService.Create(this.room.Id, this.topicName, this.room.HostId, this.host.Token);
      this.discussionService.SetVote(discussion.Id, this.room.HostId, this.card1.Id);
      var votes = this.voteRepository.GetAll().Where(item => item.DiscussionId == discussion.Id).ToList();
      var vote = votes.Find(item => item.UserId == this.room.HostId);

      Assert.IsNotNull(votes);
      Assert.AreEqual(1, votes.Count());
      Assert.AreEqual(this.card1, vote.Card);
      Assert.AreEqual(this.card1.Id, vote.CardId);
      Assert.AreEqual(this.room.Id, vote.RoomId);
      Assert.AreEqual(this.host.Id, vote.UserId);
    }

    [Test]
    public void CloseDiscussionTest()
    {
      var discussion = this.discussionService.Create(this.room.Id, this.topicName, this.room.HostId, this.host.Token);
      this.discussionService.SetVote(discussion.Id, this.room.HostId, this.card1.Id);

      this.discussionService.Close(this.room.Id, discussion.Id, this.room.HostId);

      Assert.IsNotNull(discussion.DateEnd);
    }

    [Test]
    public void DeleteDiscussionTest()
    {
      var discussion = this.discussionService.Create(this.room.Id, this.topicName, this.room.HostId, this.host.Token);
      this.discussionService.Delete(this.room.Id, discussion.Id, this.room.HostId);
      var isDiscussionDeleted = this.discussionRepository.Get(discussion.Id) == null;
      Assert.IsTrue(isDiscussionDeleted);
    }

    [Test]
    public void GetDiscussionResultsTest()
    {
      var discussion = this.discussionService.Create(this.room.Id, this.topicName, this.room.HostId, this.host.Token);
      var recivedDiscussion = this.discussionService.GetResults(discussion.Id, this.room.HostId);

      Assert.IsNotNull(recivedDiscussion);
      Assert.AreEqual(discussion, recivedDiscussion);
    }
  }
}
