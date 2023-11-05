using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelectScreen;
    public GameObject startTransition;

    public Button select1Button;
    public Button levelSelectButton;
    public void Quit()
    {
        Application.Quit();
    }

    public void OpenLevelSelect()
    {
        startTransition.SetActive(false);
        mainMenu.SetActive(false);
        levelSelectScreen.SetActive(true);
        select1Button.Select();
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        levelSelectScreen.SetActive(false);
        levelSelectButton.Select();
    }

    public void StartLevel()
    {
        //SceneManager.LoadScene();
    }

    public void Race1Load()
    {
        SceneManager.LoadScene("Race1");
    }

    public void Race2Load()
    {
        SceneManager.LoadScene("Race2");
    }
}
