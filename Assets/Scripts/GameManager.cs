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
    public bool isFirstPlaythrough = true;

    void Start()
    {
    	crown = 50;
        health = 50;
        knowledge = 50;
        money = 50;
		loop = 0;
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
                if (crown == 0 || health == 0 || knowledge == 0 || money == 0 || loop == 1)
                {
                    RouteToMainMenu();
                }
                currentCard.Left();
     			if (int.Parse(counter.text) >= 30)
                {
                    LoopCard();
                }
                else if (money < minValue)
                {
                    GameOver(1);
                }
                else if (money >= maxValue)
                {
                    GameOver(2);
                }
                else if (crown < minValue)
                {
                    GameOver(3);
                }
                else if (crown >= maxValue)
                {
                    GameOver(4);
                }
                else if (health < minValue)
                {
                    GameOver(5);
                }
                else if (health >= maxValue)
                {
                    GameOver(6);
                }
                else if (knowledge < minValue)
                {
                    GameOver(7);
                }
                else if (knowledge >= maxValue)
                {
                    GameOver(8);
                }

                else
                {
                    NewCard();
                }
                counter.text = (int.Parse(counter.text) + 1).ToString();
                PlayerPrefs.SetInt("TotalDays", PlayerPrefs.GetInt("TotalDays") + 1);

            }
        }
        else if (cardGameObject.transform.position.x < -fSideTrigger)
        {
            if (Input.GetMouseButtonUp(0)) 
            {
                if (crown == -100 || health == -100 || knowledge == -100 || money == -100 || loop == 1)
                {
                    RouteToMainMenu();
                }
                currentCard.Right();
                if (int.Parse(counter.text) >= 30)
                {
                    LoopCard();
                }
                else if (money < minValue)
                {
                    GameOver(1);
                }
                else if (money >= maxValue)
                {
                    GameOver(2);
                }
                else if (crown < minValue)
                {
                    GameOver(3);
                }
                else if (crown >= maxValue)
                {
                    GameOver(4);
                }
                else if (health < minValue)
                {
                    GameOver(5);
                }
                else if (health >= maxValue)
                {
                    GameOver(6);
                }
                else if (knowledge < minValue)
                {
                    GameOver(7);
                }
                else if (knowledge >= maxValue)
                {
                    GameOver(8);
                }
                else 
                {
                    NewCard();
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

    public void LoadPlotText() 
    {
        cardSpriteRenderer.sprite = null;
        characterDialogue.text = "If you believe the calendar, today is September 1, 1980, this is the fourth time in my life that I have experienced this date... Everything is like groundhog Day, except that I have not 1 day of time, but a whole month. The first time I 'woke up' in a new reality for myself, I thought that I had something wrong with my head, for a long time I could not believe that all this was real, eventually I made a couple of fatal mistakes and died... I stopped paying any attention to everything that was happening around me, I didn't really eat or sleep. At some point, I had a strong pain in my chest, it was unbearably painful, and a second later I woke up in my bed, and the date was on the calendar again - September 1, 1980. The second time it was a little different, I noticed that the university has changed a little, new teachers and students have appeared, the atmosphere has changed. The world seemed to be invisibly different from what it was last time. I thought that I would deal with this later, and this time I will just try to use all the useful information from the past two lives for my own good and make as many new useful acquaintances as possible this month, perhaps by getting new information through them I will be able to understand what happened and how to get out of the loop. I really succeeded in this, I had a lot of new acquaintances! It seems even too much, because on September 14 I was trampled by a crowd of my own new friends... As I understood, this 'world' into which I got does not want me to stand out in something, it exaggerates all the results from my decisions several times, and if I start to stand out in something, it solves this problem in the most cardinal way... I'm still scared, I've died 2 times already... it shouldn't be like this. I have not yet figured out what to do and how to get out of this loop, so I will try to live a few 'months' without incident and see what it will lead to...Well, it's time to relive September 1, 1980 for the fourth time..";
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
        int count = PlayerPrefs.GetInt("TotalDays", 0);
        if (isFirstPlaythrough) {
            LoadPlotText();
            isFirstPlaythrough = false;
            return;
        }
        if (0 <= count && count <= 15) {
			int rollDice = Random.Range(9, 20);
        	LoadCard(resourceManager.cards[rollDice]);
		} 
        else if (15 <= count && count <= 30) {
			int rollDice = Random.Range(9, 29);
        	LoadCard(resourceManager.cards[rollDice]);
		}
        else if (30 <= count && count <= 45)
        {
            int rollDice = Random.Range(9, 40);
            LoadCard(resourceManager.cards[rollDice]);
        }
        else  if (45 <= count) {
            int rollDice = Random.Range(9, resourceManager.cards.Length);
            LoadCard(resourceManager.cards[rollDice]);
        }
    }
    public void LoopCard()
    {
		loop = 1;
        LoadCard(resourceManager.cards[0]);
    }

    public void GameOver(int death)
    {
        crown = -100;
        health = -100;
        knowledge = -100;
        money = -100;
        LoadCard(resourceManager.cards[death]);
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