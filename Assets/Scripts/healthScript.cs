using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Player;
using System.Linq;

public class healthScript : MonoBehaviour
{
    public static Text health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Text>();
        health.text = string.Concat(Enumerable.Repeat("*", Player.health));
;

    }

    // Update is called once per frame
    void Update()
    {
        int healthAmount = Player.health;
        if(health.text.Length > healthAmount){
            health.text = string.Concat(Enumerable.Repeat("*", healthAmount));
        }
    }
}
