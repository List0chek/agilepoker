using DataService;
using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO.Converters;
using PlanPoker.Models;
using PlanPoker.Services;
using System;

namespace PlanPoker.Controllers
{
    /// <summary>
    /// Класс DiscussionController.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscussionController : ControllerBase
    {
        /// <summary>
        /// Экземпляр InMemoryVoteRepository.
        /// </summary>
        private readonly IRepository<Vote> voteRepository;

        /// <summary>
        /// Экземпляр DiscussionService.
        /// </summary>
        private readonly DiscussionService discussionService;

        /// <summary>
        /// Экземпляр RoomService.
        /// </summary>
        private readonly RoomService roomService;

        /// <summary>
        /// Экземпляр InMemoryUserRepository.
        /// </summary>
        private readonly IRepository<User> userRepository;

        /// <summary>
        /// Экземпляр InMemoryDiscussionRepository.
        /// </summary>
        private readonly IRepository<Discussion> discussionRepository;

        /// <summary>
        /// Экземпляр InMemoryDeckRepository.
        /// </summary>
        private readonly IRepository<Deck> deckRepository;

        /// <summary>
        /// Экземпляр InMemoryCardRepository.
        /// </summary>
        private readonly IRepository<Card> cardRepository;

        /// <summary>
        /// Конструктор класса DiscussionController.
        /// </summary>
        /// <param name="discussionService">Экземпляр DiscussionService.</param>
        /// <param name="roomService">Экземпляр RoomService.</param>
        /// <param name="voteRepository">Экземпляр InMemoryVoteRepository.</param>
        /// <param name="userRepository">Экземпляр InMemoryUserRepository.</param>
        /// <param name="discussionRepository">Экземпляр InMemoryDiscussionRepository.</param>
        /// <param name="deckRepository">Экземпляр InMemoryDeckRepository.</param>
        /// <param name="cardRepository">Экземпляр InMemoryCardRepository.</param>
        public DiscussionController(
            DiscussionService discussionService,
            RoomService roomService,
            IRepository<Vote> voteRepository,
            IRepository<User> userRepository,
            IRepository<Discussion> discussionRepository,
            IRepository<Deck> deckRepository,
            IRepository<Card> cardRepository)
        {
            this.discussionService = discussionService;
            this.roomService = roomService;
            this.voteRepository = voteRepository;
            this.userRepository = userRepository;
            this.discussionRepository = discussionRepository;
            this.deckRepository = deckRepository;
            this.cardRepository = cardRepository;
        }

        /// <summary>
        /// Создает новое обсуждение. 
        /// </summary>
        /// <param name="roomId">Id комнаты, в которой создается новое обсуждение.</param>
        /// <param name="topic">Название темы обсуждения.</param>
        /// <param name="hostId">Id ведущего.</param>
        /// <param name="token">Token ведущего.</param>
        /// <returns>Возвращает экземпляр RoomDTO.</returns>
        [HttpPost]
        public RoomDTO Create(Guid roomId, string topic, Guid hostId, [FromHeader]string token)
        {
            var discussion = this.discussionService.Create(roomId, topic, hostId, token);
            var room = this.roomService.GetRoomInfo(discussion.RoomId, hostId);
            return new RoomDTOConverter(
                this.voteRepository,
                this.discussionRepository,
                this.deckRepository,
                this.cardRepository,
                this.userRepository)
                .Convert(room);
        }

        /// <summary>
        /// Создает оценку пользователя обсуждению.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="userId">Id пользователя.</param>
        /// <param name="cardId">Id карты.</param>
        /// <returns>Возвращает экземпляр RoomDTO.</returns>
        [HttpPost]
        public RoomDTO SetVote(Guid discussionId, Guid userId, Guid cardId)
        {
            var discussion = this.discussionService.SetVote(discussionId, userId, cardId);
            var room = this.roomService.GetRoomInfo(discussion.RoomId, userId);
            return new RoomDTOConverter(
                this.voteRepository,
                this.discussionRepository,
                this.deckRepository,
                this.cardRepository,
                this.userRepository)
                .Convert(room);
        }

        /// <summary>
        /// Закрывает обсуждение.
        /// </summary>
        /// <param name="roomId">Id комнаты, в которой нужно закрыть обсуждение.</param>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="hostId">Id пользователя.</param>
        /// <returns>Возвращает экземпляр RoomDTO.</returns>
        [HttpPost]
        public RoomDTO Close(Guid roomId, Guid discussionId, Guid hostId)
        {
            var discussion = this.discussionService.Close(roomId, discussionId, hostId);
            var room = this.roomService.GetRoomInfo(discussion.RoomId, hostId);
            return new RoomDTOConverter(
                this.voteRepository,
                this.discussionRepository,
                this.deckRepository,
                this.cardRepository,
                this.userRepository)
                .Convert(room);
        }

        /// <summary>
        /// Удаляет обсуждение.
        /// </summary>
        /// <param name="roomId">Id комнаты, в которой нужно закрыть обсуждение.</param>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="hostId">Id пользователя.</param>
        /// <returns>Возвращает экземпляр RoomDTO.</returns>
        [HttpPost]
        public RoomDTO Delete(Guid roomId, Guid discussionId, Guid hostId)
        {
            var discussion = this.discussionService.GetResults(discussionId, hostId);
            this.discussionService.Delete(roomId, discussionId, hostId);
            var room = this.roomService.GetRoomInfo(discussion.RoomId, hostId);
            return new RoomDTOConverter(
                this.voteRepository,
                this.discussionRepository,
                this.deckRepository,
                this.cardRepository,
                this.userRepository)
                .Convert(room);
        }

        /// <summary>
        /// Возвращает оценки участников обсуждения и итоговую среднюю оценку.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="userId">Id пользователя.</param>
        /// <returns>Возвращает экземпляр RoomDTO.</returns>
        [HttpGet]
        public DiscussionDTO GetResults(Guid discussionId, Guid userId)
        {
            var discussion = this.discussionService.GetResults(discussionId, userId);
            return new DiscussionDTOConverter(this.voteRepository, this.userRepository).Convert(discussion);
        }
    }
}
