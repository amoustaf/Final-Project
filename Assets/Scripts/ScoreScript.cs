using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static int ValueOfScore;
    Text Score;
    public static int multiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        Score.text = "Score: " + (ValueOfScore*multiplier).ToString();

    }
}
