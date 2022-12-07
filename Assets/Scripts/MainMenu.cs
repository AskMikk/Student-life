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

    public void ToTutorial4()
    {
        SceneManager.LoadScene("Tutorial4");
    }

    public void ToChar()
    {
        SceneManager.LoadScene("Char");
    }
    public void ToChar1()
    {
        SceneManager.LoadScene("Char1");
    }

    public void ToChar2()
    {
        SceneManager.LoadScene("Char2");
    }
    public void ToChar3()
    {
        SceneManager.LoadScene("Char3");
    }
    public void ToChar4()
    {
        SceneManager.LoadScene("Char4");
    }
    public void ToChar5()
    {
        SceneManager.LoadScene("Char5");
    }

}
