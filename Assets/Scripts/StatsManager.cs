using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject card;
    public Image crown;
    public Image health;
    public Image knowledge;
    public Image money;
    public Image crownDot;
    public Image healthDot;
    public Image knowledgeDot;
    public Image moneyDot;
    
    IEnumerator ChangeColorToRed(Image element)
    { 
        element.GetComponent<Image>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(1);
        element.GetComponent<Image>().color = new Color(1, 1, 0);
    }
    IEnumerator ChangeColorToGreen(Image element)
    {
        element.GetComponent<Image>().color = new Color(0, 1, 0);
        yield return new WaitForSeconds(1);
        element.GetComponent<Image>().color = new Color(1, 1, 0);
    }

    void Update()
    {
        crown.fillAmount =  (float) GameManager.crown / GameManager.maxValue;
        health.fillAmount = (float) GameManager.health / GameManager.maxValue;
        knowledge.fillAmount = (float) GameManager.knowledge / GameManager.maxValue;
        money.fillAmount = (float) GameManager.money / GameManager.maxValue;


        if (card.transform.position.x < gameManager.fSideTrigger * -1)
        {
            if (gameManager.currentCard.RiCrown != 0) 
            {
                crownDot.transform.localScale = new Vector3(1, 1, 0);
                if (gameManager.currentCard.RiCrown < 0)
                {
                    StartCoroutine(ChangeColorToRed(crown));
                }
                if (gameManager.currentCard.RiCrown > 0)
                {
                    StartCoroutine(ChangeColorToGreen(crown));
                }
            }
            if (gameManager.currentCard.RiHealth != 0) 
            {
                healthDot.transform.localScale = new Vector3(1, 1, 0);
                if (gameManager.currentCard.RiHealth < 0)
                {
                    StartCoroutine(ChangeColorToRed(health));
                }
                if (gameManager.currentCard.RiCrown > 0)
                {
                    StartCoroutine(ChangeColorToGreen(health));
                }
            }
            if (gameManager.currentCard.RiKnowledge != 0) 
            {
                knowledgeDot.transform.localScale = new Vector3(1, 1, 0);
                if (gameManager.currentCard.RiKnowledge < 0)
                {
                    StartCoroutine(ChangeColorToRed(knowledge));
                }
                if (gameManager.currentCard.RiCrown > 0)
                {
                    StartCoroutine(ChangeColorToGreen(knowledge));
                }
            }
            if (gameManager.currentCard.RiMoney != 0) 
            {
                moneyDot.transform.localScale = new Vector3(1, 1, 0);
                if (gameManager.currentCard.RiMoney < 0)
                {
                    StartCoroutine(ChangeColorToRed(money));
                }
                if (gameManager.currentCard.RiCrown > 0)
                {
                    StartCoroutine(ChangeColorToGreen(money));
                }
            }
        }
        else if (card.transform.position.x > gameManager.fSideTrigger)
        {
            if (gameManager.currentCard.LiCrown != 0)
            {
                crownDot.transform.localScale = new Vector3(1, 1, 0);
                if (gameManager.currentCard.LiCrown < 0)
                {
                    StartCoroutine(ChangeColorToRed(crown));
                }
                if (gameManager.currentCard.LiCrown > 0)
                {
                    StartCoroutine(ChangeColorToGreen(crown));
                }
            }
            if (gameManager.currentCard.LiHealth != 0)
            {
                healthDot.transform.localScale = new Vector3(1, 1, 0);
                if (gameManager.currentCard.LiHealth < 0)
                {
                    StartCoroutine(ChangeColorToRed(health));
                }
                if (gameManager.currentCard.LiHealth > 0)
                {
                    StartCoroutine(ChangeColorToGreen(health));
                }
            }
            if (gameManager.currentCard.LiKnowledge != 0)
            {
                knowledgeDot.transform.localScale = new Vector3(1, 1, 0);
                if (gameManager.currentCard.LiKnowledge < 0)
                {
                    StartCoroutine(ChangeColorToRed(knowledge));
                }
                if (gameManager.currentCard.LiKnowledge > 0)
                {
                    StartCoroutine(ChangeColorToGreen(knowledge));
                }
            }
            if (gameManager.currentCard.LiMoney != 0)
            {
                moneyDot.transform.localScale = new Vector3(1, 1, 0);
                if (gameManager.currentCard.LiMoney < 0)
                {
                    StartCoroutine(ChangeColorToRed(money));
                }
                if (gameManager.currentCard.LiMoney > 0)
                {
                    StartCoroutine(ChangeColorToGreen(money));
                }
            }
        }
        else
        {
            crownDot.transform.localScale = new Vector3(0, 0, 0);
            healthDot.transform.localScale = new Vector3(0, 0, 0);
            knowledgeDot.transform.localScale = new Vector3(0, 0, 0);
            moneyDot.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
