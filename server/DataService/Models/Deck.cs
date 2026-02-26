using System;
using System.Collections.Generic;

namespace DataService.Models
{
    /// <summary>
    /// Класс колоды.
    /// </summary>
    public class Deck : Entity
    {
        /// <summary>
        /// Имя сущности Deck.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Лист ID карт, которые есть в колоде.
        /// </summary>
        public ICollection<Guid> CardsIds { get; } = new List<Guid>();

        /// <summary>
        /// Конструктор класса Deck.
        /// </summary>
        /// <param name="id">Id сущности Deck.</param>
        public Deck(Guid id) : base(id)
        {
        }
    }
}
