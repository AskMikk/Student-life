using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Recordss : MonoBehaviour
{
    public TMP_Text top1;
    public TMP_Text top2;
    public TMP_Text top3;
    public TMP_Text top4;
    public TMP_Text top5;
    // Start is called before the first frame update
    void Start()
    {
        top1.text = PlayerPrefs.GetInt("top1").ToString();
        top2.text = PlayerPrefs.GetInt("top2").ToString();
        top3.text = PlayerPrefs.GetInt("top3").ToString();
        top4.text = PlayerPrefs.GetInt("top4").ToString();
        top5.text = PlayerPrefs.GetInt("top5").ToString();
    }
}
