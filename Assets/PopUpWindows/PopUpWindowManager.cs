using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpWindowManager : MonoBehaviour
{
    public GameObject popUpWindow;

    GameObject currentPopUpWindow;
    
    GameObject player;
    Player playerScript;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        // DEBUG STUFF
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnPopUpWindow();
        }

        // REAL GAME STUFF
        
    }

    void SpawnPopUpWindow()
    {
        // No, player can't move ! :D
        playerScript.SetAllowToMove(false);

        float randomX = Random.Range(-1.0f, 1.0f);
        float randomY = Random.Range(-1.0f, 1.0f);
        if (currentPopUpWindow == null)
        {
            this.currentPopUpWindow = Instantiate(
                popUpWindow,
                new Vector3(randomX, randomY, -1),
                Quaternion.identity
            );
        }
        else
        {
            this.currentPopUpWindow.transform.position = new Vector3(randomX, randomY, -1);
            this.currentPopUpWindow.SetActive(true);
        }
    }

    void OnClickPopUpWindow(bool accept)
    {
        this.currentPopUpWindow.SetActive(false);
        if (accept)
        {
            print("Hhinhinhinhnihnihnihin");
        }
        else
        {
            print("sad :(");
        }
    }

    public void ClickButton(string name)
    {
        switch(name)
        {
            case "AcceptButton":
                OnClickPopUpWindow(true);
                break;
            case "RefuseButton":
                OnClickPopUpWindow(false);
                break;
        }

        // Player is free to move again !
        playerScript.SetAllowToMove(true);
    }
}
