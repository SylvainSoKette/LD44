using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    Player player;
    Text thuneText;

    // Start is called before the first frame update
    void Start()
    {
        this.thuneText = this.GetComponentInChildren<Text>();
        this.player = GameObject.Find("Player").GetComponent<Player>();
        UpdateThune();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateThune();
    }

    void UpdateThune()
    {
        this.thuneText.text =  this.player.getThune().ToString() + "$$";
    }
}
