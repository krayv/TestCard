using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRandomValueFromCardInHand : MonoBehaviour
{
    [SerializeField] PlayerHand playerHand;
    [SerializeField] int minChangeValue;
    [SerializeField] int maxChangeValue;

    public void ChangeValue()
    {
        playerHand.SelectNextCard();
        GameObjectCard gameObjectCard = playerHand.GetSelectedCard();
        int value = Random.Range(minChangeValue, maxChangeValue);
        switch(Random.Range(0,3))
        {
            case 0: gameObjectCard.card.attack = value; break;
            case 1: gameObjectCard.card.health = value; break;
            case 2: gameObjectCard.card.mana = value; break;
        }
    }

}
