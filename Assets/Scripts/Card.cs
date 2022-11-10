using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Card : ScriptableObject

{
    public int cardID;
    public CardSprite sprite;
    public string cardName;
    public string dialogue;
    public string leftQuote;
    public string rightQuote;

    public int RiCrown;
    public int RiHealth;
    public int RiKnowledge;
    public int RiMoney;

    public int LiCrown;
    public int LiHealth;
    public int LiKnowledge;
    public int LiMoney;

    public void Left()
    {
        GameManager.crown += LiCrown;
        GameManager.health += LiHealth;
        GameManager.knowledge += LiKnowledge;
        GameManager.money += LiMoney;
    }

    public void Right()
    {
        GameManager.crown += RiCrown;
        GameManager.health += RiHealth;
        GameManager.knowledge += RiKnowledge;
        GameManager.money += RiMoney;
    }
}