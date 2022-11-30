using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu1 : MonoBehaviour
{
    public TMP_Text mainMenuCounter;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuCounter.text = PlayerPrefs.GetInt("TotalDays").ToString();
    }
}
