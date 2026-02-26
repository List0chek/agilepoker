using System;

namespace PlanPoker.Models
{
  /// <summary>
  /// Класс VoteDTO.
  /// </summary>
  public class VoteDTO
  {
    /// <summary>
    /// Id оценки.
    /// </summary>
    public Guid Id { get; set; }

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
    public UserDTO User { get; set; }

    /// <summary>
    /// Карта.
    /// </summary>
    public CardDTO Card { get; set; }
  }
}
