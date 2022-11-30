using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ResourceManager;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text mainMenuCounter;
    public TMP_Text counter;
    public static int crown = 50;
    public static int health = 50;
    public static int knowledge = 50;
    public static int money = 50;
    public static int maxValue = 100;
    public static int minValue = 0;
    public GameObject cardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    public ResourceManager resourceManager;
    public float fMovingSpeed;
    public float fSideTrigger;
    float alphaText;
    public Color textColor;
    public Color dialogueBGColor;
    public Vector3 pos;
    public SpriteRenderer dialogueBG;
    public TMP_Text dialogue;
    public TMP_Text characterDialogue;
    public TMP_Text characterName;
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card testCard;
    public float divideValue;
    public bool isSubstituting = false;
    public Vector3 cardRotation;
    public Vector3 currentRotation;
    public Vector3 initRotation;

    void Start()
    {
        NewCard();
    }


    void UpdateDialogue()
    {
        dialogue.color = textColor;
        dialogueBG.color = dialogueBGColor;
        if (cardGameObject.transform.position.x > 0)
        {
            dialogue.text = leftQuote;
        }
        else
        {
            dialogue.text = rightQuote;
        }
    }
    void Update()
    {
        textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x)) / divideValue, 1);
        dialogueBGColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x)) / divideValue, 0.6f);
        if (cardGameObject.transform.position.x > fSideTrigger)
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Left();
                if (crown >= maxValue || health >= maxValue || knowledge >= maxValue || money >= maxValue || crown < minValue || health < minValue || knowledge < minValue || money < minValue)
                {
                    GameOver();
                }
                else
                {
                    NewCard();
                }
                counter.text = (int.Parse(counter.text) + 1).ToString();
            }
        }
        else if (cardGameObject.transform.position.x < -fSideTrigger)
        {
            if (Input.GetMouseButtonUp(0)) 
            {
                currentCard.Right();
                if (crown >= maxValue || health >= maxValue || knowledge >= maxValue || money >= maxValue || crown < minValue || health < minValue || knowledge < minValue || money < minValue)
                {
                    GameOver();
                }
                else 
                {
                    NewCard();
                }
                counter.text = (int.Parse(counter.text) + 1).ToString();
            }
        }
        UpdateDialogue();
        // Movement
        if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardGameObject.transform.position = pos;
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, cardGameObject.transform.position.x * -1.5f);
        }
        else if (!isSubstituting)
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, new Vector3(0, 0.78f, -0.01f), fMovingSpeed);
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (isSubstituting)
        {
            cardGameObject.transform.eulerAngles = Vector3.MoveTowards(cardGameObject.transform.eulerAngles, cardRotation, 2.5f);
        }
        if (cardGameObject.transform.eulerAngles == cardRotation)
        {
            isSubstituting = false;
        }
    }

    public void LoadCard(Card card) 
    {
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        currentCard = card;
        characterDialogue.text = card.dialogue;
        characterName.text = resourceManager.sprites[(int)card.sprite].name;
        cardGameObject.transform.position = new Vector2(0, 0.78f);
        cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        isSubstituting = true;
        cardGameObject.transform.eulerAngles = initRotation;
    }
    public void NewCard()
    {
        int rollDice = Random.Range(1, resourceManager.cards.Length);
        LoadCard(resourceManager.cards[rollDice]);
    }
    public void GameOver()
    {
        LoadCard(resourceManager.cards[0]);
        crown = 50;
        health = 50;
        knowledge = 50;
        money = 50;

        // mainMenuCounter.text = (int.Parse(mainMenuCounter.text) + int.Parse(counter.text)).ToString();
        // SceneManager.LoadScene("Menu");
    }
    public void Substitute()
    {

    }

}