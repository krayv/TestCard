using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardLoader : MonoBehaviour
{
    [SerializeField]  string cardResourcesPath = "Cards";
    public List<Card> LoadCards()
    {
        List<Card> cards = Resources.LoadAll<Card>(cardResourcesPath).OfType<Card>().ToList();
        cards.ForEach(c => StartCoroutine(LoadImageFromSite.LoadImageForCard(c)));
        return cards;
    }
}
