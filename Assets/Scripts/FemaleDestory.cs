using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FemaleDestory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public Player Players2;

    // Update is called once per frame
    void Update()
    {
        if (Players2.transform.position.x > transform.position.x)
        {
            Destroy(gameObject);

        }
        if (((transform.position.x - Players2.transform.position.x) <= 0.5) && ((transform.position.y - Players2.transform.position.y) >= -1.6))
        {
            Destroy(Players2);
            SceneManager.LoadScene(2);
        }


    }






}