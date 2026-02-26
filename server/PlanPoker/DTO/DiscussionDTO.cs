using System;
using System.Collections.Generic;

namespace PlanPoker.Models
{
    /// <summary>
    /// Класс DiscussionDTO.
    /// </summary>
    public class DiscussionDTO
    {
        /// <summary>
        /// Id обсуждения.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id сущности Room.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Тема обсуждения.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// Дата начала.
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата начала.
        /// </summary>
        public DateTime? DateEnd { get; set; } = null;

        /// <summary>
        /// Лист оценок.
        /// </summary>
        public IEnumerable<VoteDTO> Votes { get; set; }

        /// <summary>
        /// Среднее значение всех оценок.
        /// </summary>
        public double? AverageResult { get; set; }

        /// <summary>
        /// Длительность обсуждения.
        /// </summary>
        public double? Duration { get; set; }
    }
}
