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
    public  int cardbefore = 10;
    public  int rollDice;
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
                if (crown == -100 || health == -100 || knowledge == -100 || money == -100 || loop == 1)
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
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (money >= maxValue)
                {
                    GameOver(2);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (crown < minValue)
                {
                    GameOver(3);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (crown >= maxValue)
                {
                    GameOver(4);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (health < minValue)
                {
                    GameOver(5);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (health >= maxValue)
                {
                    GameOver(6);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (knowledge < minValue)
                {
                    GameOver(7);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (knowledge >= maxValue)
                {
                    GameOver(8);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
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
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (money >= maxValue)
                {
                    GameOver(2);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (crown < minValue)
                {
                    GameOver(3);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (crown >= maxValue)
                {
                    GameOver(4);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (health < minValue)
                {
                    GameOver(5);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (health >= maxValue)
                {
                    GameOver(6);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (knowledge < minValue)
                {
                    GameOver(7);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
                }
                else if (knowledge >= maxValue)
                {
                    GameOver(8);
                    if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top1", 0)) { PlayerPrefs.SetInt("top1", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top2", 0)) { PlayerPrefs.SetInt("top2", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top3", 0)) { PlayerPrefs.SetInt("top3", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top4", 0)) { PlayerPrefs.SetInt("top4", PlayerPrefs.GetInt("TotalDays")); }
                    else if (PlayerPrefs.GetInt("TotalDays", 0) > PlayerPrefs.GetInt("top5", 0)) { PlayerPrefs.SetInt("top5", PlayerPrefs.GetInt("TotalDays")); }
                    PlayerPrefs.SetInt("TotalDays", -2);
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
        if (0 <= count && count <= 5) {
            if (8 < cardbefore && cardbefore < 16) { rollDice = Random.Range(16, 20); }
            if (15 < cardbefore && cardbefore < 21) { rollDice = Random.Range(9, 15); }
            cardbefore = rollDice;
            LoadCard(resourceManager.cards[rollDice]);
		}
        else if (5 <= count && count <= 20)
        {
            if (8 < cardbefore && cardbefore < 16) { rollDice = Random.Range(16, 29); }
            if (15 < cardbefore && cardbefore < 21) { rollDice = Random.Range(21, 29); }
            if (20 < cardbefore && cardbefore < 26) { rollDice = Random.Range(9, 20); }
            if (25 < cardbefore && cardbefore < 30) { rollDice = Random.Range(9, 25); }
            cardbefore = rollDice;
            LoadCard(resourceManager.cards[rollDice]);
        }
        else if(20 <= count && count <= 35)
        {
            if (8 < cardbefore && cardbefore < 16) { rollDice = Random.Range(16, 40); }
            if (15 < cardbefore && cardbefore < 21) { rollDice = Random.Range(21, 40); }
            if (20 < cardbefore && cardbefore < 26) { rollDice = Random.Range(26, 40); }
            if (25 < cardbefore && cardbefore < 30) { rollDice = Random.Range(9, 25); }
            if (29 < cardbefore && cardbefore < 33) { rollDice = Random.Range(9, 29); }
            if (32 < cardbefore && cardbefore < 37) { rollDice = Random.Range(9, 32); }
            if (36 < cardbefore && cardbefore < 41) { rollDice = Random.Range(9, 36); }
            cardbefore = rollDice;
            LoadCard(resourceManager.cards[rollDice]);
        }
        else  if (45 <= count)
        {
            if (8 < cardbefore && cardbefore < 16) { rollDice = Random.Range(16, 48); }
            if (15 < cardbefore && cardbefore < 21) { rollDice = Random.Range(21, 48); }
            if (20 < cardbefore && cardbefore < 26) { rollDice = Random.Range(26, 48); }
            if (25 < cardbefore && cardbefore < 30) { rollDice = Random.Range(30, 48); }
            if (29 < cardbefore && cardbefore < 33) { rollDice = Random.Range(9, 29); }
            if (32 < cardbefore && cardbefore < 37) { rollDice = Random.Range(9, 32); }
            if (36 < cardbefore && cardbefore < 41) { rollDice = Random.Range(9, 36); }
            if (40 < cardbefore && cardbefore < 45) { rollDice = Random.Range(9, 40); }
            if (44 < cardbefore && cardbefore < 49) { rollDice = Random.Range(9, 44); }
            cardbefore = rollDice;
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