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

        if (currentPopUpWindow == null)
        {
            this.currentPopUpWindow = Instantiate(
                popUpWindow,
                PlaceMeUpScotty(),
                Quaternion.identity
            );
        }
        else
        {
            this.currentPopUpWindow.transform.position = PlaceMeUpScotty();
            this.currentPopUpWindow.SetActive(true);
        }
    }

    Vector3 PlaceMeUpScotty()
    {
        float randomX = Random.Range(-1.0f, 1.0f);
        float randomY = Random.Range(-1.0f, 1.0f);
        return new Vector3(
            player.transform.position.x + randomX,
            player.transform.position.y + randomY,
            -2
        );
    }

    void ClickPopUpWindow(bool accept)
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

    public void OnClickButton(string name)
    {
        switch(name)
        {
            case "AcceptButton":
                ClickPopUpWindow(true);
                break;
            case "RefuseButton":
                ClickPopUpWindow(false);
                break;
        }

        // Player is free to move again !
        playerScript.SetAllowToMove(true);
    }
}
