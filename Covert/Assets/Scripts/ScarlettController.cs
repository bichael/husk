using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScarlettController : MonoBehaviour
{

    GameObject Scarlett;
    GameObject zone;
    private float posx = 0;
    private float posy = 1.5F;
    private float posz = 0;


    // Start is called before the first frame update
    void Start()
    {
        Scarlett = GameObject.Find("Scarlett");
        zone = GameObject.Find("Square");
        Scarlett.transform.position = new Vector3(posx, posy, posz);
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
            posz += 0.05F;
        }
        if (moveDown)
        {
            posz -= 0.05F;
        } 

        Scarlett.transform.position = new Vector3(posx, posy, posz);
        Camera.main.gameObject.transform.position = new Vector3(posx, 25, posz);

    }

}
