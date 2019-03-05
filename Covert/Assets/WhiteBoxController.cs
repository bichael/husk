using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoxController : MonoBehaviour
{
    GameObject Scarlett;
    GameObject WhiteBox;
    bool boxLocked = false;
    // Start is called before the first frame update
    void Start()
    {
        Scarlett = GameObject.Find("Scarlett");
        WhiteBox = GameObject.Find("WhiteBox");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool lockBoxToScarlett = Input.GetKeyUp(KeyCode.E);
        bool moveRight = Input.GetKey(KeyCode.D);
        bool moveLeft = Input.GetKey(KeyCode.A);
        bool moveUp = Input.GetKey(KeyCode.W);
        bool moveDown = Input.GetKey(KeyCode.S);
        if (!boxLocked)
        {
            if (lockBoxToScarlett)
            {
                if (scarlettWithinRange())
                    boxLocked = true;
                Debug.Log("Locking!");
            }
        }
        else
        {
            Debug.Log("Locked.");
            if (lockBoxToScarlett)
            {
                boxLocked = false;
                Debug.Log("Unlocking.");
            }


            if(boxLocked)
            {
                if(moveRight)
                    WhiteBox.transform.position = 
                    new Vector3(WhiteBox.transform.position.x + 0.02F, WhiteBox.transform.position.y, -0.28F);
                if (moveLeft)
                    WhiteBox.transform.position =
                    new Vector3(WhiteBox.transform.position.x - 0.02F, WhiteBox.transform.position.y, -0.28F);
                if (moveUp)
                    WhiteBox.transform.position =
                    new Vector3(WhiteBox.transform.position.x, WhiteBox.transform.position.y + 0.02F, -0.28F);
                if (moveDown)
                    WhiteBox.transform.position =
                    new Vector3(WhiteBox.transform.position.x, WhiteBox.transform.position.y - 0.02F, -0.28F);
            }
        }

    }

    bool scarlettWithinRange()
    {
        float scarlettPosX = Scarlett.transform.position.x;
        float scarlettPosY = Scarlett.transform.position.y;
        float boxPosX = WhiteBox.transform.position.x;
        float boxPosY = WhiteBox.transform.position.y;

        return (scarlettPosX < boxPosX + 1.5) && (scarlettPosX > boxPosX - 1.5) 
        && (scarlettPosY < boxPosY + 2) && (scarlettPosY > boxPosY - 2);
    }

}
