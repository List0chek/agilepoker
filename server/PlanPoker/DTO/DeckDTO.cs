using System;
using System.Collections.Generic;
using PlanPoker.Models;

namespace PlanPoker.DTO
{
  /// <summary>
  /// Класс DeckDTO.
  /// </summary>
  public class DeckDTO
  {
    /// <summary>
    /// Id колоды.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя сущности Deck.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Набор карт.
    /// </summary>
    public IEnumerable<CardDTO> Cards { get; set; }
  }
}
