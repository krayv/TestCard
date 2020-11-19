using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardRenderer : MonoBehaviour
{
    [SerializeField] private Text manaText;
    [SerializeField] private Text healthText;
    [SerializeField] private Text attackText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Image cardImage;
    [SerializeField] private Text captionText;

    private Card currentCard; 

    public void RenderCardInfo(Card card)
    {
        currentCard = card;
        card.valueChanged.AddListener(RefreshCardInfo);
        RefreshCardInfo();
    }
    public void RefreshCardInfo()
    {
        manaText.text = currentCard.mana.ToString();
        healthText.text = currentCard.health.ToString();
        attackText.text = currentCard.attack.ToString();
        descriptionText.text = currentCard.description;
        cardImage.sprite = currentCard.cardImage;
        captionText.text = currentCard.cardCaption;
    }
}
