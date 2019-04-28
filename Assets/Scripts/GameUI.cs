using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Player player;
    [SerializeField] private Text thuneText;

    void Start()
    {
        pauseMenu.SetActive(false);

        UpdateThune();
    }

    void Update()
    {
        UpdateThune();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeInHierarchy)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        } 
    }

    void UpdateThune()
    {
        this.thuneText.text =  this.player.getThune().ToString() + "€$";
    }

    private void PauseGame()
    {
        print("PauseGame");
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    } 

    private void ContinueGame()
    {
        print("ContinueGame");
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
