using System;

namespace DataService.Models
{
  /// <summary>
  /// Интерфейс сущности.
  /// </summary>
  public interface IEntity
  {
    /// <summary>
    /// Id сущности.
    /// </summary>
    Guid Id { get; }
  }
}
