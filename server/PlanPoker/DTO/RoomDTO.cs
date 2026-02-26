using PlanPoker.DTO;
using System;
using System.Collections.Generic;

namespace PlanPoker.Models
{
    /// <summary>
    /// Класс RoomDTO.
    /// </summary>
    public class RoomDTO
    {
        /// <summary>
        /// Id комнаты.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя комнаты.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id сущности Owner.
        /// </summary>
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Id сущности Host.
        /// </summary>
        public Guid HostId { get; set; }

        /// <summary>
        /// Список членов комнаты.
        /// </summary>
        public IEnumerable<UserDTO> Members { get; set; }


        /// <summary>
        /// Список всех обсуждений комнаты.
        /// </summary>
        public IEnumerable<DiscussionDTO> Discussions { get; set; }


        /// <summary>
        /// Хеш код для URL.
        /// </summary>
        public string HashCode { get; set; }

        /// <summary>
        /// Колода в комнате.
        /// </summary>
        public DeckDTO Deck { get; set; }
    }
}
