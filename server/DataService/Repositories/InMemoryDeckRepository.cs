using DataService.Models;
using PlanPoker.Models;

namespace DataService.Repositories
{
    /// <summary>
    /// DeckRepository. 
    /// </summary>
    public class InMemoryDeckRepository : InMemoryRepository<Deck>
    {
        /// <summary>
        /// Конструктор InMemoryDeckRepository.
        /// </summary>
        /// <param name="cardRepository">Экземпляр InMemoryCardRepository.</param>
        public InMemoryDeckRepository(IRepository<Card> cardRepository)
        {
            var defaultDeck = this.Create();
            defaultDeck.Name = "defaultDeck";
            var card1 = cardRepository.Create();
            card1.Name = "0";
            card1.Value = "0";
            cardRepository.Save(card1);
            defaultDeck.CardsIds.Add(card1.Id);

            cardRepository.Create();
            var card2 = cardRepository.Create();
            card2.Name = "1";
            card2.Value = "1";
            cardRepository.Save(card2);
            defaultDeck.CardsIds.Add(card2.Id);

            cardRepository.Create();
            var card3 = cardRepository.Create();
            card3.Name = "2";
            card3.Value = "2";
            cardRepository.Save(card3);
            defaultDeck.CardsIds.Add(card3.Id);

            cardRepository.Create();
            var card4 = cardRepository.Create();
            card4.Name = "3";
            card4.Value = "3";
            cardRepository.Save(card4);
            defaultDeck.CardsIds.Add(card4.Id);

            cardRepository.Create();
            var card5 = cardRepository.Create();
            card5.Name = "5";
            card5.Value = "5";
            cardRepository.Save(card5);
            defaultDeck.CardsIds.Add(card5.Id);

            cardRepository.Create();
            var card6 = cardRepository.Create();
            card6.Name = "8";
            card6.Value = "8";
            cardRepository.Save(card6);
            defaultDeck.CardsIds.Add(card6.Id);

            cardRepository.Create();
            var card7 = cardRepository.Create();
            card7.Name = "13";
            card7.Value = "13";
            cardRepository.Save(card7);
            defaultDeck.CardsIds.Add(card7.Id);

            cardRepository.Create();
            var card8 = cardRepository.Create();
            card8.Name = "21";
            card8.Value = "21";
            cardRepository.Save(card8);
            defaultDeck.CardsIds.Add(card8.Id);

            cardRepository.Create();
            var card9 = cardRepository.Create();
            card9.Name = "34";
            card9.Value = "34";
            cardRepository.Save(card9);
            defaultDeck.CardsIds.Add(card9.Id);

            cardRepository.Create();
            var card10 = cardRepository.Create();
            card10.Name = "55";
            card10.Value = "55";
            cardRepository.Save(card10);
            defaultDeck.CardsIds.Add(card10.Id);

            cardRepository.Create();
            var card11 = cardRepository.Create();
            card11.Name = "89";
            card11.Value = "89";
            cardRepository.Save(card11);
            defaultDeck.CardsIds.Add(card11.Id);

            cardRepository.Create();
            var card12 = cardRepository.Create();
            card12.Name = "?";
            card12.Value = "?";
            cardRepository.Save(card12);
            defaultDeck.CardsIds.Add(card12.Id);

            cardRepository.Create();
            var card13 = cardRepository.Create();
            card13.Name = "infinity";
            card13.Value = "infinity";
            cardRepository.Save(card13);
            defaultDeck.CardsIds.Add(card13.Id);

            cardRepository.Create();
            var card14 = cardRepository.Create();
            card14.Name = "coffee";
            card14.Value = "coffee";
            cardRepository.Save(card14);
            defaultDeck.CardsIds.Add(card14.Id);
            this.Save(defaultDeck);
        }
    }
}
