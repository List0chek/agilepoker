using DataService;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Converters;
using PlanPoker.Models;
using PlanPoker.Services;
using System;
using System.Collections.Generic;

namespace PlanPoker.Controllers
{
    /// <summary>
    /// Контроллер колоды.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        /// <summary>
        /// Экземпляр InMemoryCardRepository.
        /// </summary>
        private readonly IRepository<Card> cardRepository;

        /// <summary>
        /// Экземпляр DeckService.
        /// </summary>
        private readonly DeckService deckService;

        /// <summary>
        /// Конструктор класса DeckController.
        /// </summary>
        /// <param name="deckService">Экземпляр DeckService.</param>
        /// <param name="cardRepository">Экземпляр InMemoryCardRepository.</param>
        public DeckController(DeckService deckService, IRepository<Card> cardRepository)
        {
            this.deckService = deckService;
            this.cardRepository = cardRepository;
        }

        /// <summary>
        /// Создает экземпляр Deck.
        /// </summary>
        /// <param name="name">Имя колоды.</param>
        /// <param name="cardIds">Id карт.</param>
        /// <returns>Возвращает DeckDTO.</returns>
        [HttpPost]
        public DeckDTO Create(string name, IEnumerable<Guid> cardIds)
        {
            var deck = this.deckService.Create(name, cardIds);
            return new DeckDTOConverter(this.cardRepository).Convert(deck);
        }

        /// <summary>
        /// Получить стандартную колоду.
        /// </summary>
        /// <returns>Возвращает DeckDTO.</returns>
        [HttpGet]
        public DeckDTO GetDefaultDeck()
        {
            var deck = this.deckService.GetDefaultDeck();
            return new DeckDTOConverter(this.cardRepository).Convert(deck);
        }
    }
}
