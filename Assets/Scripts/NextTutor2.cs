using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextTutor2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Next()
    {
        SceneManager.LoadScene("Tutorial3");
    }
}
