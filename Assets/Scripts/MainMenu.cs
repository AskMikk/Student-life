using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial1");
    }

    public void Story()
    {
        SceneManager.LoadScene("Story");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToTutorial2()
    {
        SceneManager.LoadScene("Tutorial2");
    }

    public void ToTutorial3()
    {
        SceneManager.LoadScene("Tutorial3");
    }

}
