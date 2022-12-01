using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public Card card;
    BoxCollider2D thisCard;
    public bool isMouseOver;
    private void Start()
    {
        thisCard = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnMouseOver()
    {
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }
}

public enum CardSprite
{
    DeathMinMoney,
    DeathMaxMoney,
    DeathMinRep,
    DeathMaxRep,
    DeathMinMaxHealth,
    DeathMinStudy,
    DeathMaxStudy,
    Loop,
    Joe,
    Sarah,
    Rasta,
    
}