using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Deck: MonoBehaviour
{
    public List<Card> cardsInDeck;

    public void FullfillDeck()
    {
        cardsInDeck = Cards.cards;
    }

    public List<Card> GetCardsFromDeck(int count)
    {
        List<Card> cards = new List<Card>();
        while(count > 0 && cardsInDeck.Count > 0)
        {
            cards.Add(cardsInDeck.First());
            cardsInDeck.Remove(cardsInDeck.First());
            count--;
        }
        return cards;
    }
}
