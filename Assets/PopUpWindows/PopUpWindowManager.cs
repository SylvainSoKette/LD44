﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpWindowManager : MonoBehaviour
{
    public GameObject popUpWindow;

    GameObject currentPopUpWindow;
    Color initialButtonColor;
    Ray mouseRay;
    RaycastHit mouseHit;

    enum mouseButton : int {
        PRIMARY=0,
        SECONDARY=1,
        MIDDLE=2
    }

    void Update()
    {
        // DEBUG STUFF
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetPopUpWindow();
        }

        // REAL GAME STUFF
        // mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // if(Physics.Raycast(mouseRay, out mouseHit))
        // {
        //     onHoverButton(mouseHit.collider.gameObject);
        //     if (this.currentPopUpWindow != null && Input.GetMouseButtonDown((int)mouseButton.PRIMARY))
        //     {
        //         onClickButton(mouseHit.collider.gameObject);
        //     }
        // }
        // else
        // {
        //     onNotHoverButton(mouseHit.collider.gameObject);
        // }
    }

    void ResetPopUpWindow()
    {
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

    // void onHoverButton(GameObject button)
    // {
    //     Material buttonMaterial = button.GetComponent<MeshRenderer>().material;
    //     initialButtonColor = buttonMaterial.color;
    //     buttonMaterial.color = Color.gray;
    // }

    // void onNotHoverButton(GameObject button)
    // {
    //     button.GetComponent<MeshRenderer>().material.color = initialButtonColor;
    // }

    void onClickButton(GameObject button)
    {
        switch(button.name)
        {
            case "AcceptButton":
                ClickPopUpWindow(true);
                break;
            case "RefuseButton":
                ClickPopUpWindow(false);
                break;
        }
    }

    void ClickPopUpWindow(bool accept)
    {
        this.currentPopUpWindow.SetActive(false);
    }
}
