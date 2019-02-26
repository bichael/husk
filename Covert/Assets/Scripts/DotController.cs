using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotController : MonoBehaviour
{

    GameObject dot;
    GameObject zone;
    private float posx = 0;
    private float posy = 0;
    private float posz = 0;


    // Start is called before the first frame update
    void Start()
    {
        dot = GameObject.Find("dot");
        zone = GameObject.Find("Square");
        dot.transform.position = new Vector3(posx, posy, posz);
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        bool moveRight = Input.GetKey(KeyCode.D);
        bool moveLeft = Input.GetKey(KeyCode.A);
        bool moveUp = Input.GetKey(KeyCode.W);
        bool moveDown = Input.GetKey(KeyCode.S);

        bool within = posx >= -1 && posx <= 1 && posy >= 2 && posy <= 4;

        if (within)
        {
            zone.transform.Rotate(0, 0, 0.1F);
        }
        else
        {
            zone.transform.Rotate(0, 0, 0);
        }

        if (moveRight)
        {
            posx += 0.05F;
        }
        if (moveLeft)
        {
            posx -= 0.05F;
        }
        if (moveUp)
        {
            posy += 0.05F;
        }
        if (moveDown)
        {
            posy -= 0.05F;
        } 

        dot.transform.position = new Vector3(posx, posy, posz);
        Camera.main.gameObject.transform.position = new Vector3(posx, posy, -10);

    }

}
