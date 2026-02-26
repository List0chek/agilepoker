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
      Assert.That(discussion, Is.Not.Null);
      Assert.That(discussion.Id, Is.Not.Null);
      Assert.That(discussion.Topic, Is.EqualTo(this.topicName));
      Assert.That(discussion.RoomId, Is.EqualTo(this.room.Id));
      Assert.That(discussion.AverageResult, Is.Null);
      Assert.That(discussion.DateStart, Is.Not.Null);
      Assert.That(discussion.DateEnd, Is.Null);
    }

    [Test]
    public void SetVoteInDiscussionTest()
    {
      var discussion = this.discussionService.Create(this.room.Id, this.topicName, this.room.HostId, this.host.Token);
      this.discussionService.SetVote(discussion.Id, this.room.HostId, this.card1.Id);
      var votes = this.voteRepository.GetAll().Where(item => item.DiscussionId == discussion.Id).ToList();
      var vote = votes.Find(item => item.UserId == this.room.HostId);

      Assert.That(votes, Is.Not.Null);
      Assert.That(votes.Count(), Is.EqualTo(1));
      Assert.That(vote.Card, Is.EqualTo(this.card1));
      Assert.That(vote.CardId, Is.EqualTo(this.card1.Id));
      Assert.That(vote.RoomId, Is.EqualTo(this.room.Id));
      Assert.That(vote.UserId, Is.EqualTo(this.host.Id));
    }

    [Test]
    public void CloseDiscussionTest()
    {
      var discussion = this.discussionService.Create(this.room.Id, this.topicName, this.room.HostId, this.host.Token);
      this.discussionService.SetVote(discussion.Id, this.room.HostId, this.card1.Id);

      this.discussionService.Close(this.room.Id, discussion.Id, this.room.HostId);

      Assert.That(discussion.DateEnd, Is.Not.Null);
    }

    [Test]
    public void DeleteDiscussionTest()
    {
      var discussion = this.discussionService.Create(this.room.Id, this.topicName, this.room.HostId, this.host.Token);
      this.discussionService.Delete(this.room.Id, discussion.Id, this.room.HostId);
      var isDiscussionDeleted = this.discussionRepository.Get(discussion.Id) == null;
      Assert.That(isDiscussionDeleted, Is.True);
    }

    [Test]
    public void GetDiscussionResultsTest()
    {
      var discussion = this.discussionService.Create(this.room.Id, this.topicName, this.room.HostId, this.host.Token);
      var recivedDiscussion = this.discussionService.GetResults(discussion.Id, this.room.HostId);

      Assert.That(recivedDiscussion, Is.Not.Null);
      Assert.That(recivedDiscussion, Is.EqualTo(discussion));
    }
  }
}
