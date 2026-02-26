using DataService;
using PlanPoker.Models;
using System;

namespace PlanPoker.Services
{
    /// <summary>
    /// Класс RoomService.
    /// </summary>
    public class RoomService
    {
        /// <summary>
        /// Экземпляр InMemoryRoomRepository.
        /// </summary>
        private readonly IRepository<Room> roomRepository;

        /// <summary>
        /// Экземпляр InMemoryUserRepository.
        /// </summary>
        private readonly IRepository<User> userRepository;

        /// <summary>
        /// Экземпляр UserService.
        /// </summary>
        private readonly UserService userService;

        /// <summary>
        /// Экземпляр DiscussionService.
        /// </summary>
        private readonly DiscussionService discussionService;

        /// <summary>
        /// Конструктор класса RoomService.
        /// </summary>
        /// <param name="roomRepository">Экземпляр InMemoryRoomRepository.</param>
        /// <param name="userRepository">Экземпляр InMemoryUserRepository.</param>
        /// <param name="userService">Экземпляр UserService.</param>
        /// <param name="discussionService">Экземпляр DiscussionService.</param>
        public RoomService(
            IRepository<Room> roomRepository,
            IRepository<User> userRepository,
            UserService userService,
            DiscussionService discussionService)
        {

            this.roomRepository = roomRepository;
            this.userRepository = userRepository;
            this.userService = userService;
            this.discussionService = discussionService;
        }

        /// <summary>
        /// Создает новую комнату.
        /// </summary>
        /// <param name="name">Имя комнаты.</param>
        /// <param name="ownerId">Id создателя.</param>
        /// <param name="ownerToken">Token создателя.</param>
        /// <returns>Возвращает экземпляр Room.</returns>
        public Room Create(string name, Guid ownerId, string ownerToken)
        {
            var newRoom = this.roomRepository.Create();

            var owner = this.userRepository.Get(ownerId) ?? throw new UnauthorizedAccessException("User not found");
            if (name is null || name == string.Empty)
            {
                throw new UnauthorizedAccessException("Room name is not valid");
            }

            if (ownerToken is null || !owner.Token.Equals(ownerToken))
            {
                throw new UnauthorizedAccessException("Token is not valid");
            }

            newRoom.Name = name;
            newRoom.OwnerId = owner.Id;
            newRoom.HostId = owner.Id;
            if (!newRoom.Members.Contains(owner))
            {
                newRoom.Members.Add(owner);
            }

            newRoom.HashCode = Convert.ToBase64String(newRoom.Id.ToByteArray());

            this.roomRepository.Save(newRoom);
            return newRoom;
        }

        /// <summary>
        /// Добавляет пользователя в комнату.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="newUserId">Id пользователя, которого нужно добавить в комнату.</param>
        /// <returns>Возвращает экземпляр Room.</returns>
        public Room AddMember(Guid roomId, Guid newUserId)
        {
            var newUser = this.userRepository.Get(newUserId) ?? throw new UnauthorizedAccessException("User not found");
            var room = this.roomRepository.Get(roomId) ?? throw new UnauthorizedAccessException("Room not found");

            if (!room.Members.Contains(newUser))
            {
                room.Members.Add(newUser);
                this.roomRepository.Save(room);
            }

            return room;
        }

        /// <summary>
        /// Позволяет сменить ведущего.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="newHostId">Id пользователя, который будет новым ведущим.</param>
        /// <param name="ownerId">Id пользователя, который является владельцем комнаты.</param>
        /// <returns>Возвращает экземпляр Room.</returns>
        public Room ChangeHost(Guid roomId, Guid newHostId, Guid ownerId)
        {
            var updatingRoom = this.roomRepository.Get(roomId) ?? throw new UnauthorizedAccessException("Room not found");
            var newHost = this.userRepository.Get(newHostId) ?? throw new UnauthorizedAccessException("User not found");
            var owner = this.userRepository.Get(ownerId) ?? throw new UnauthorizedAccessException("User not found");

            if (!updatingRoom.OwnerId.Equals(owner.Id))
            {
                throw new UnauthorizedAccessException("Owner is not valid");
            }

            updatingRoom.HostId = newHost.Id;
            if (!updatingRoom.Members.Contains(newHost))
            {
                updatingRoom.Members.Add(newHost);
            }

            this.roomRepository.Save(updatingRoom);
            return updatingRoom;
        }

        /// <summary>
        /// Возвращает информацию о комнате.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="userId">Id пользователя.</param>
        /// <returns>Возвращает экземпляр Room.</returns>
        public Room GetRoomInfo(Guid roomId, Guid userId)
        {
            var room = this.roomRepository.Get(roomId) ?? throw new UnauthorizedAccessException("Room not found");
            var user = this.userRepository.Get(userId) ?? throw new UnauthorizedAccessException("User not found");
            if (!room.Members.Contains(user))
            {
                throw new UnauthorizedAccessException("User does not belong to this room");
            }

            return room;
        }

        /// <summary>
        /// Позволяет создать пользователя, комнату и обсуждение.
        /// </summary>
        /// <param name="userName">Имя создателя комнаты.</param>
        /// <param name="roomName">Имя комнаты.</param>
        /// <param name="discussionName">Название обсуждения.</param>
        /// <returns>Возвращает экземпляр Room.</returns>
        public Room CreateUserAndRoomWithDiscussion(string userName, string roomName, string discussionName)
        {
            if (userName is null || userName == string.Empty)
            {
                throw new ArgumentException("Wrong username");
            }
            if (roomName is null || roomName == string.Empty)
            {
                throw new UnauthorizedAccessException("Room name is not valid");
            }
            if (discussionName is null || discussionName == string.Empty)
            {
                throw new UnauthorizedAccessException("Discussion topic name is not valid");
            }

            var user = this.userService.Create(userName);
            var room = Create(roomName, user.Id, user.Token);
            this.discussionService.Create(room.Id, discussionName, user.Id, user.Token);

            return room;
        }
    }
}
