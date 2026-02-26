using DataService.Models;
using System;

namespace PlanPoker.Models
{
    /// <summary>
    /// Класс карты.
    /// </summary>
    public class Card : Entity
    {
        /// <summary>
        /// Имя сущности Card.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Значение сущности Card.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Коснтруктор класса Card.
        /// </summary>
        /// <param name="id">Id сущности Card.</param>
        public Card(Guid id) : base(id)
        {
        }
    }
}
