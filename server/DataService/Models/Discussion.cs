using System;
using DataService.Models;

namespace PlanPoker.Models
{
  /// <summary>
  /// Класс обсуждения.
  /// </summary>
  public class Discussion : Entity
  {
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
    /// Среднее значение всех оценок.
    /// </summary>
    public double? AverageResult { get; set; }

    /// <summary>
    /// Конструктор класса Discussion.
    /// </summary>
    /// <param name="id">Id сущности Discussion.</param>
    public Discussion(Guid id) : base(id)
    {
    }
  }
}
