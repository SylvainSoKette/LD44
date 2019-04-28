using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Color hoverColor;

    Color initColor;
    PopUpWindowManager popUpWindowManager;

    enum mouseButton : int {
        PRIMARY=0,
        SECONDARY=1,
        MIDDLE=2
    }

    void Start()
    {
        this.initColor = this.GetComponent<MeshRenderer>().material.color;
        this.popUpWindowManager = GameObject.Find("Map").GetComponent<PopUpWindowManager>();
    }

    void OnMouseOver()
    {
        this.GetComponent<MeshRenderer>().material.color = hoverColor;
        if (Input.GetMouseButtonDown((int)mouseButton.PRIMARY))
        {
            this.popUpWindowManager.OnClickButton(this.name);
        }
    }

    void OnMouseExit()
    {
        this.GetComponent<MeshRenderer>().material.color = initColor;
    }
}
