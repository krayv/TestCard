using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameObjectCard : MonoBehaviour
{
    public UnityEvent valueChanged;

    [SerializeField] CardRenderer cardRenderer;
    [SerializeField] Card _card;

    private int siblingIndex;

    public void PullCard()
    {
        transform.SetAsLastSibling();
    }

    public void ReturnCard()
    {
        transform.SetSiblingIndex(siblingIndex);
    }

    public Card card 
    { 
        get => _card;
        set 
        {
            _card = new Card(value);
            cardRenderer.RenderCardInfo(_card);
        }
    }

    private void Start()
    {
        siblingIndex = transform.GetSiblingIndex();
    }
}
