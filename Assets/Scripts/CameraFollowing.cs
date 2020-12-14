using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{




    public Transform playerposition;
    public Transform boundsright;
    public Transform boundsleft;
    private float cameraHeight;
    private float cameraWidth;
    private float minxlevel;
    private float maxXlevel;
    public float timetotarget = 0.15f;
    private Vector3 smoothDampVelocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        cameraWidth = cameraHeight * Camera.main.aspect;
        cameraHeight = Camera.main.orthographicSize * 2;


        float widthleftbound = boundsleft.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;

        float widthrightbound = boundsright.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;

        minxlevel = boundsleft.position.x + widthleftbound + (cameraWidth/2);
        
        maxXlevel = boundsright.position.x - widthrightbound - (cameraWidth / 2);




    }

    // Update is called once per frame
    void Update()
    
    
    {

        if (playerposition)
        {
            float Xtarget = Mathf.Max(minxlevel, Mathf.Min(maxXlevel, playerposition.position.x));

            float x = Mathf.SmoothDamp(transform.position.x, Xtarget, ref smoothDampVelocity.x, timetotarget);

            transform.position = new Vector3(x, transform.position.y, transform.position.z);

        }



    }




}
