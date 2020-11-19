using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu (fileName = "Card", menuName = "Cards/Card", order = 1)]
public class Card : ScriptableObject
{
    public UnityEvent valueChanged = new UnityEvent();
    private Card parentCard;
    public Card(Card card)
    {
        SetValueByCard(card);
        parentCard = card;
        parentCard.valueChanged.AddListener(ValueChangedOnParent);
    }

    [SerializeField] private int _attack;
    public int attack 
    { 
        get => _attack; 
        set { _attack = value; valueChanged.Invoke(); 
        } 
    }


    [SerializeField] private int _health;
    public int health 
    { 
        get => _health; 
        set 
        { _health = value; 
            valueChanged.Invoke(); 
        } 
    }


    [SerializeField] private int _mana;
    public int mana 
    { 
        get => _mana; 
        set 
        { _mana = value; valueChanged.Invoke(); 
        } 
    }

    [SerializeField] private string _description;
    public string description 
    { 
        get => _description; 
        set 
        { 
            _description = value; valueChanged.Invoke(); 
        } 
    }


    [SerializeField] private Sprite _cardImage;
    public Sprite cardImage  
    {   
        get => _cardImage; 
        set 
        { _cardImage = value; valueChanged.Invoke(); 
        } 
    }

    [SerializeField] private string _cardCaption;
    public string cardCaption 
    { 
        get => _cardCaption; 
        set 
        { _cardCaption = value; valueChanged.Invoke(); 
        } 
    }

    [SerializeField] private string _cardName;
    public string cardName 
    { 
        get => _cardName; 
        set 
        { _cardCaption = value; valueChanged.Invoke(); 
        } 
    }

    private void ValueChangedOnParent()
    {
        SetValueByCard(parentCard);
    }

    private void SetValueByCard(Card card)
    {
        description = card.description;
        cardName = card.cardName;
        cardCaption = card.cardCaption;
        attack = card.attack;
        health = card.health;
        mana = card.mana;
        cardImage = card.cardImage;
    }
} 
