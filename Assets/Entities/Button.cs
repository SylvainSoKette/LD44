using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Color hoverColor;

    Color initColor;
    GameObject popUpWindowManager;
    PopUpWindowManager popUpWindowManagerScript;

    enum mouseButton : int {
        PRIMARY=0,
        SECONDARY=1,
        MIDDLE=2
    }

    void Start()
    {
        this.initColor = this.GetComponent<MeshRenderer>().material.color;
        this.popUpWindowManager = GameObject.Find("PopUpWindowManager");
        this.popUpWindowManagerScript = this.popUpWindowManager.GetComponent<PopUpWindowManager>();
    }

    void OnMouseOver()
    {
        this.GetComponent<MeshRenderer>().material.color = hoverColor;
        if (Input.GetMouseButtonDown((int)mouseButton.PRIMARY))
        {
            this.popUpWindowManagerScript.OnClickButton(this.name);
        }
    }

    void OnMouseExit()
    {
        this.GetComponent<MeshRenderer>().material.color = initColor;
    }
}
