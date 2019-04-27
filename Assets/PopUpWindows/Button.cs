using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Color hoverColor;

    Color initColor;
    
    void Start()
    {
        this.initColor = this.GetComponent<MeshRenderer>().material.color;
    }

    void OnMouseOver()
    {
        this.GetComponent<MeshRenderer>().material.color = hoverColor;
    }

    void OnMouseExit()
    {
        this.GetComponent<MeshRenderer>().material.color = initColor;
    }
}
