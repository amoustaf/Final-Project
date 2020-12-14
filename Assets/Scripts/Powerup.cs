using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public Player Players;

    // Update is called once per frame
    void Update()
    {
        if (((transform.position.x - Players.transform.position.x) <= 0.5) && ((transform.position.y - Players.transform.position.y) >= -1.6))
        {
            Destroy(gameObject);
            ScoreScript.multiplier += 1;
        }


    }






}