using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ResourceManager;
using static StatsManager;
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
    public static int loop = 0;
    public GameObject cardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    public ResourceManager resourceManager;
    public StatsManager statsManager;
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
    	crown = 50;
        health = 50;
        knowledge = 50;
        money = 50;
		loop = 0;
        NewCard(0);
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
                if (crown == 0 || health == 0 || knowledge == 0 || money == 0 || loop == 1)
                {
                    RouteToMainMenu();
                }
                currentCard.Left();
     			if (int.Parse(counter.text) >= 30)
                {
                    LoopCard();
                } 
				else if (crown >= maxValue || health >= maxValue || knowledge >= maxValue || money >= maxValue || crown < minValue || health < minValue || knowledge < minValue || money < minValue)
                {
                    GameOver();
                }
                else
                {
                    NewCard(int.Parse(counter.text));
                }
                counter.text = (int.Parse(counter.text) + 1).ToString();
                PlayerPrefs.SetInt("TotalDays", PlayerPrefs.GetInt("TotalDays") + 1);

            }
        }
        else if (cardGameObject.transform.position.x < -fSideTrigger)
        {
            if (Input.GetMouseButtonUp(0)) 
            {
                if (crown == 0 || health == 0 || knowledge == 0 || money == 0 || loop == 1)
                {
                    RouteToMainMenu();
                }
                currentCard.Right();
                if (int.Parse(counter.text) >= 30)
                {
                    LoopCard();
                } 
				else if (crown >= maxValue || health >= maxValue || knowledge >= maxValue || money >= maxValue || crown < minValue || health < minValue || knowledge < minValue || money < minValue)
                {
                    GameOver();
                }
                else 
                {
                    
                    NewCard(int.Parse(counter.text));
                }
                counter.text = (int.Parse(counter.text) + 1).ToString();
                PlayerPrefs.SetInt("TotalDays", PlayerPrefs.GetInt("TotalDays") +1);
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

    public void NewCard(int count)
    {
  		if (0 <= count && count <= 5) {
			int rollDice = Random.Range(2, 5);
        	LoadCard(resourceManager.cards[rollDice]);
		} else if (2 <= count && count <= 10) {
			int rollDice = Random.Range(2, 10);
        	LoadCard(resourceManager.cards[rollDice]);
		}
    }

    public void LoopCard()
    {
		loop = 1;
        LoadCard(resourceManager.cards[0]);
    }

    public void GameOver()
    {
        crown = 0;
        health = 0;
        knowledge = 0;
        money = 0;
        LoadCard(resourceManager.cards[1]);
    }

    public void RouteToMainMenu()
    {
        crown = 50;
        health = 50;
        knowledge = 50;
        money = 50;
		loop = 0;
        SceneManager.LoadScene("Menu");
    }
}