using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextTutor3 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
