using System;
using DataService.Repositories;
using NUnit.Framework;
using PlanPoker.Models;
using PlanPoker.Services;

namespace Tests
{
  public class VoteServiceTests
  {
    private InMemoryVoteRepository voteRepository;
    private InMemoryUserRepository userRepository;
    private InMemoryCardRepository cardRepository;
    private InMemoryDiscussionRepository discussionRepository;

    private VoteService voteService;
    private Card card;
    private User user;
    private Discussion discussion;

    [SetUp]
    public void SetUp()
    {
      this.voteRepository = new InMemoryVoteRepository();
      this.userRepository = new InMemoryUserRepository();
      this.cardRepository = new InMemoryCardRepository();
      this.discussionRepository = new InMemoryDiscussionRepository();
      this.voteService = new VoteService(this.voteRepository, this.cardRepository, this.discussionRepository, this.userRepository);
      this.card = this.cardRepository.Create();
      this.cardRepository.Save(this.card);
      this.user = this.userRepository.Create();
      this.userRepository.Save(this.user);
      this.discussion = this.discussionRepository.Create();
      this.discussionRepository.Save(this.discussion);
    }

    [Test]
    public void CreateVoteTest()
    {
      var vote = this.voteService.SetVote(this.card.Id, this.discussion.Id, this.user.Id);
      Assert.IsNotNull(vote);
      Assert.AreEqual(this.card.Id, vote.Card.Id);
      Assert.AreEqual(this.card.Id, vote.CardId);
      Assert.AreEqual(this.discussion.Id, vote.DiscussionId);
      Assert.AreEqual(this.user.Id, vote.UserId);
    }

    [Test]
    public void ChangeVoteTest()
    {
      var vote = this.voteService.SetVote(this.card.Id, this.discussion.Id, this.user.Id);
      var newCard = this.cardRepository.Create();
      this.cardRepository.Save(newCard);
      var changedVote = this.voteService.SetVote(newCard.Id, this.discussion.Id, this.user.Id);
      Assert.IsNotNull(changedVote);
      Assert.AreEqual(vote.Id, changedVote.Id);
      Assert.AreEqual(newCard.Id, changedVote.Card.Id);
      Assert.AreEqual(newCard.Id, changedVote.CardId);
      Assert.AreEqual(this.user.Id, changedVote.UserId);
    }

    [Test]
    public void IsThrowExceptionOnInvalidValueTest()
    {
      var vote = this.voteService.SetVote(this.card.Id, this.discussion.Id, this.user.Id);
      var newCard = this.cardRepository.Create();
      this.cardRepository.Save(newCard);
      Assert.Throws<ArgumentException>(() => this.voteService.SetVote(Guid.NewGuid(), this.discussion.Id, this.user.Id), "Card not found");
      Assert.Throws<ArgumentException>(() => this.voteService.SetVote(this.card.Id, Guid.NewGuid(), this.user.Id), "Discussion not found");
      Assert.Throws<ArgumentException>(() => this.voteService.SetVote(this.card.Id, this.discussion.Id, Guid.NewGuid()), "User not found");
      Assert.Throws<ArgumentException>(() => this.voteService.SetVote(Guid.NewGuid(), newCard.Id, this.user.Id), "Vote not found");
    }
  }
}
