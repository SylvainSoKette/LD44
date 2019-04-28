using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpWindowManager : MonoBehaviour
{
    public GameObject popUpWindow;
    public float popUpWindowJutter = 4.0f;

    GameObject currentPopUpWindow;
    
    GameObject player;
    Player playerScript;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();

        StartCoroutine(SpawnPopUpWindow());
    }

    void Update()
    {

    }

    IEnumerator SpawnPopUpWindow()
    {
        float spawnRate = Random.Range(5f, 15f);

        while (true) {
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
            yield return new WaitForSeconds(spawnRate);
        }
    }

    Vector3 PlaceMeUpScotty()
    {
        float randomX = Random.Range(-popUpWindowJutter, popUpWindowJutter);
        float randomY = Random.Range(-popUpWindowJutter, popUpWindowJutter);
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
