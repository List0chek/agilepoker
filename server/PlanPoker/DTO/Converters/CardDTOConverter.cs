using PlanPoker.Models;

namespace PlanPoker.DTO.Converters
{
    /// <summary>
    /// Класс CardDTOConverter.
    /// </summary>
    public class CardDTOConverter
    {
        /// <summary>
        /// Метод конвертации Card в CardDTO.
        /// </summary>
        /// <param name="card">Экземпляр Card.</param>
        /// <returns>Экземпляр CardDTO.</returns>
        public CardDTO Convert(Card card)
        {
            return new CardDTO()
            {
                Id = card.Id,
                Name = card.Name,
                Value = card.Value
            };
        }
    }
}
