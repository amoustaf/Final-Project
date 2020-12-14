using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{




    public Vector2 velocityspeed;

    public LayerMask wall;

    public float space_jumpvelocityspeed;
    public float grav;
    public LayerMask floor;
    private bool movement, left_movements, right_movements, space_jump;
    public GameObject gameovertext;

    public enum PlayerState
    {
        space_jumping,idle,walking
    }
    private PlayerState playerState = PlayerState.idle;
    void Start()
    {

        gameovertext.SetActive(false);
        Fall();


    }

    void Update()
    {
        PlayerInputCheck();

        PlayerPositionUpdated();

        Scene currentScene = SceneManager.GetActiveScene();
        int buildIndex = currentScene.buildIndex;

        if (transform.position.x > 22 && buildIndex == 1)
        {
            SceneManager.LoadScene(3);
        }

        if (transform.position.x > 22 && buildIndex == 3  )
        {
            StartCoroutine(updateyouwin());
        }
    }

    IEnumerator updateyouwin()
    {
        gameovertext.SetActive(true);

        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene(1);

    }




    void PlayerPositionUpdated()
    {

        Vector3 scaling = transform.localScale;

        Vector3 position = transform.localPosition;



        if (movement)
        {
            if (left_movements)
            {
                position.x -= velocityspeed.x * Time.deltaTime;
                scaling.x = -1;
            }

            if (right_movements)
            {
                position.x += velocityspeed.x * Time.deltaTime;
                scaling.x = 1;
            }
            position = wallraycast(position, scaling.x);

        }


        if(space_jump && playerState != PlayerState.space_jumping)
        {
            playerState = PlayerState.space_jumping;

            velocityspeed = new Vector2(velocityspeed.x, space_jumpvelocityspeed);
        }

        if(playerState == PlayerState.space_jumping)
        {
            position.y += velocityspeed.y * Time.deltaTime;

            velocityspeed.y -= grav*2f * Time.deltaTime;
        }






        if(velocityspeed.y <= 0)
        {
            position = floorraycast(position);

        }

        transform.localPosition = position;


        transform.localScale = scaling;


    }

    void PlayerInputCheck()

    {
        bool left_input = Input.GetKey(KeyCode.LeftArrow);

        bool right_input = Input.GetKey(KeyCode.RightArrow);

        bool input_space = Input.GetKey(KeyCode.Space);


        movement = left_input || right_input;


        left_movements = left_input && !right_input;

        right_movements = !left_input && right_input;

        space_jump = input_space;

    }

    Vector3 wallraycast(Vector3 pos, float direction)
    {
        Vector2 originTop = new Vector2(pos.x + direction * 0.5f, pos.y + 1f - 0.2f);
        
        Vector2 originmiddle = new Vector2(pos.x + direction * 0.5f, pos.y);
        
        RaycastHit2D wallTop = Physics2D.Raycast(originTop, new Vector2(direction, 0), velocityspeed.x * Time.deltaTime, wall);
        
        RaycastHit2D wallMiddle = Physics2D.Raycast(originmiddle, new Vector2(direction, 0), velocityspeed.x * Time.deltaTime, wall);
        
        RaycastHit2D wallBottom = Physics2D.Raycast(originTop, new Vector2(direction, 0), velocityspeed.x * Time.deltaTime, wall);


        
        if (wallBottom.collider != null || wallMiddle.collider != null || wallTop.collider != null)
        
        {
        
            pos.x -= velocityspeed.x * Time.deltaTime * direction;
        }


        return pos;

    }

    Vector3 floorraycast(Vector3 pos)
    {
        Vector2 originleft = new Vector2(pos.x - 0.5f + 0.2f, pos.y -1f);

        Vector2 originmiddle = new Vector2(pos.x, pos.y - 1f);

        Vector2 originright = new Vector2(pos.x + 0.5f - 0.2f, pos.y - 1f);

     
        RaycastHit2D floorleft = Physics2D.Raycast(originleft, Vector2.down, velocityspeed.y *Time.deltaTime, floor);

        RaycastHit2D floormiddle = Physics2D.Raycast(originmiddle, Vector2.down, velocityspeed.y * Time.deltaTime, floor);

        RaycastHit2D floorright = Physics2D.Raycast(originright, Vector2.down, velocityspeed.y * Time.deltaTime, floor);


        if (floorleft.collider != null || floormiddle.collider != null || floorright.collider != null)
        {
            RaycastHit2D hitray = floorright;
            
            if (floorleft)

            {


                hitray = floorleft;

            }
            else if(floormiddle)

            {

                hitray = floormiddle;


            }

            else if (floorright)
            {

                hitray = floorright;

            }

            playerState = PlayerState.idle;

            velocityspeed.y = 0;

            pos.y = (hitray.collider.bounds.center.y + hitray.collider.bounds.size.y / 2) + 1;
        }
        else
        {
            if(playerState != PlayerState.space_jumping)
            {
                Fall();
            }
        }

        return pos;

    }
    void Fall()
    {

        velocityspeed.y = 0;

        playerState = PlayerState.space_jumping;

    }



}
