using DataService;
using DataService.Models;
using PlanPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanPoker.Services
{
    /// <summary>
    /// Класс DeckService.
    /// </summary>
    public class DeckService
    {
        /// <summary>
        /// Экземпляр InMemoryDeckRepository.
        /// </summary>
        private readonly IRepository<Deck> deckRepository;

        /// <summary>
        /// Экземпляр InMemoryCardRepository.
        /// </summary>
        private readonly IRepository<Card> cardRepository;

        /// <summary>
        /// Конструктор класса DeckService.
        /// </summary>
        /// <param name="deckRepository">Экземпляр InMemoryDeckRepository.</param>
        /// <param name="cardRepository">Экземпляр InMemoryCardRepository.</param>
        public DeckService(IRepository<Deck> deckRepository, IRepository<Card> cardRepository)
        {
            this.deckRepository = deckRepository;
            this.cardRepository = cardRepository;
        }

        /// <summary>
        /// Создает новую колоду.
        /// </summary>
        /// <param name="name">Название колоды.</param>
        /// <param name="cardIds">Id карт.</param>
        /// <returns>Возвращает экземпляр Deck.</returns>
        public Deck Create(string name, IEnumerable<Guid> cardIds)
        {
            var deck = this.deckRepository.Create();
            if (this.deckRepository.GetAll().Select(item => item.Name).Contains(name))
            {
                throw new ArgumentException("Wrong deck name");
            }

            if (name is null || name == string.Empty)
            {
                throw new ArgumentException("Wrong deck name");
            }

            var cardIDsList = cardIds ?? throw new ArgumentException("Wrong cardIds");
            foreach (var cardID in cardIDsList)
            {
                var card = this.cardRepository.Get(cardID) ?? throw new ArgumentException("Card by this Id is not found", cardID.ToString());
                deck.CardsIds.Add(card.Id);
            }

            deck.Name = name;
            this.deckRepository.Save(deck);
            return deck;
        }

        /// <summary>
        /// Возвращает стандартную колоду.
        /// </summary>
        /// <returns>Возвращает экземпляр Deck.</returns>
        public Deck GetDefaultDeck()
        {
            var deck = this.deckRepository
                .GetAll()
                .Where(item => item.Name.Contains("defaultDeck"))
                .FirstOrDefault() ?? throw new ArgumentException("Something went wrong, so we can't find the default deck"); 
            return deck;
        }
    }
}
