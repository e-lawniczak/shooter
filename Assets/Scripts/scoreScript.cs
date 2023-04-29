using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{

    public static Text score;
    public static Text health;
    public static int scoreNumber;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
