using DataService.Repositories;
using NUnit.Framework;
using PlanPoker.Models;
using PlanPoker.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class DeckServiceTests
    {
        private InMemoryDeckRepository deckRepository;
        private InMemoryCardRepository cardRepository;
        private DeckService deckService;
        private string deckName;
        private List<Guid> cardIdsList;
        private Card card1;
        private Card card2;
        private Card card3;

        [SetUp]
        public void SetUp()
        {
            this.cardRepository = new InMemoryCardRepository();
            this.deckRepository = new InMemoryDeckRepository(this.cardRepository);
            this.deckService = new DeckService(this.deckRepository, this.cardRepository);
            this.deckName = "deckName";
            this.card1 = this.cardRepository.Create();
            this.cardRepository.Save(this.card1);
            this.card2 = this.cardRepository.Create();
            this.cardRepository.Save(this.card2);
            this.card3 = this.cardRepository.Create();
            this.cardRepository.Save(this.card3);
            this.cardIdsList = new List<Guid>() { this.card1.Id, this.card2.Id, this.card3.Id };
        }

        [Test]
        public void CreateNewDeckTest()
        {
            var newDeck = this.deckService.Create(this.deckName, this.cardIdsList);
            Assert.AreEqual(this.deckName, newDeck.Name);
            Assert.AreEqual(this.cardIdsList, newDeck.CardsIds);
            Assert.IsNotNull(newDeck.Id);
        }

        [Test]
        public void GetDefaultDeckTest()
        {
            var defaultDeck = this.deckService.GetDefaultDeck();
            Assert.AreEqual("defaultDeck", defaultDeck.Name);
            Assert.IsNotNull(defaultDeck.CardsIds);
            Assert.IsNotNull(defaultDeck.Id);
        }

        [Test]
        public void IsThrowExceptionOnInvalidValueTest()
        {
            var exampleCardIdsListWithInvalidCardId = new List<Guid>() { this.card1.Id, this.card2.Id, Guid.NewGuid() };
            Assert.Throws<ArgumentException>(() => this.deckService.Create(null, this.cardIdsList), "Wrong deck name");
            Assert.Throws<ArgumentException>(() => this.deckService.Create(string.Empty, this.cardIdsList), "Wrong deck name");
            Assert.Throws<ArgumentException>(() => this.deckService.Create("defaultDeck", this.cardIdsList), "Wrong deck name");
            Assert.Throws<ArgumentException>(() => this.deckService.Create(this.deckName, null), "Wrong cardIds");
            Assert.Throws<ArgumentException>(
                () => this.deckService.Create(this.deckName, exampleCardIdsListWithInvalidCardId),
                "Card by this Id is not found",
                exampleCardIdsListWithInvalidCardId.Select(item => item).ToString());
        }
    }
}
