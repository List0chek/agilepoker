using DataService.Models;
using System;

namespace PlanPoker.Models
{
    /// <summary>
    /// Класс оценка.
    /// </summary>
    public class Vote : Entity
    {
        /// <summary>
        /// Id сущности Card.
        /// </summary>
        public Guid CardId { get; set; }

        /// <summary>
        /// Id сущности Room.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Id сущности Discussion.
        /// </summary>
        public Guid DiscussionId { get; set; }

        /// <summary>
        /// Id сущности User.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Карта.
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// Конструктор класса Vote.
        /// </summary>
        /// <param name="id">Id сущности Vote.</param>
        public Vote(Guid id) : base(id)
        {
        }
    }
}
