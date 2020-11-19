using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupController : MonoBehaviour
{
    [SerializeField] private Deck playerDeck;
    [SerializeField] private CardLoader cardLoader;
    [SerializeField] private PlayerHand playerHand;
    private void Start()
    {
        Cards.cards = cardLoader.LoadCards();
        playerDeck.FullfillDeck();
        playerHand.ShowHand();
    }
}
