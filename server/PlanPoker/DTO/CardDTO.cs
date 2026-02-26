using System;

namespace PlanPoker.Models
{
    /// <summary>
    /// Класс CardDTO.
    /// </summary>
    public class CardDTO
    {
        /// <summary>
        /// Id карты.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя сущности Card.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Значение сущности Card.
        /// </summary>
        public string Value { get; set; }
    }
}
