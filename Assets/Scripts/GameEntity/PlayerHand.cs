using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private GameObject cardTemplate;
    [SerializeField] private int cardNumbersInHand;
    [SerializeField] private float maxArcRotation;
    [SerializeField] private float maxYOffset;
    [SerializeField] private float rangeBetweenCards;
    [SerializeField] private Transform parentTransform;
    public List<Card> cardsInHand = new List<Card>();
    public List<GameObjectCard> gameObjectCards = new List<GameObjectCard>();

    private GameObjectCard selectedCard;

    public void ShowHand()
    {
        cardsInHand.AddRange(deck.GetCardsFromDeck(cardNumbersInHand));
        RenderCards();
    }

    public GameObjectCard GetSelectedCard()
    {
        if(selectedCard == null)
        {
            selectedCard = gameObjectCards.First();
        }
        gameObjectCards.ForEach(c => c.ReturnCard());
        selectedCard.PullCard();
        return selectedCard;
    }

    public void SelectNextCard()
    {
        if(selectedCard == null)
        {
            GetSelectedCard();
            return;
        }
        int currentIndex = gameObjectCards.IndexOf(selectedCard);
        if(gameObjectCards.Count - 1 > currentIndex)
        {
            selectedCard = gameObjectCards[currentIndex + 1];
        }
        else
        {
            selectedCard = gameObjectCards.First();
        }
    }

    private void RenderCards()
    {
        float currentArcRotation = maxArcRotation;
        float arcRotationStep = (maxArcRotation / ((cardsInHand.Count - 1) / 2f));

        float yOffsetStep = (maxYOffset / ((cardsInHand.Count - 1) / 2f));
        float currentYPostionOffset = maxYOffset;

        float currentXPositionOffset = -rangeBetweenCards * cardsInHand.Count;
        foreach (Card card in cardsInHand)
        {
            GameObject renderedCard = Instantiate(cardTemplate);
            GameObjectCard gameObjectCard = renderedCard.GetComponent<GameObjectCard>();
            gameObjectCards.Add(gameObjectCard);
            gameObjectCard.card = card;

            renderedCard.transform.position = parentTransform.position;
            renderedCard.transform.position += new Vector3(currentXPositionOffset, currentYPostionOffset < 0 ? currentYPostionOffset : -currentYPostionOffset, 0f);

            renderedCard.transform.SetParent(parentTransform);
            renderedCard.transform.Rotate(0, 0, currentArcRotation);

            currentArcRotation -= arcRotationStep;
            currentYPostionOffset = currentYPostionOffset - yOffsetStep;
            currentXPositionOffset += rangeBetweenCards;
        }
    }
}
