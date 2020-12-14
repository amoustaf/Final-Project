using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{


    private float TimerClock;

    // Start is called before the first frame update
    void Start()
    {
        TimerClock = 0;
    }

    // Update is called once per frame
    void Update()
    {

        TimerClock += Time.deltaTime;
 

    }






}
