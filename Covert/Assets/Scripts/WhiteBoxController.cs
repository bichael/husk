﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoxController : MonoBehaviour
{
    GameObject Scarlett;
    public Transform _boxTransform;

    bool boxLocked = false;
    // Start is called before the first frame update
    void Start()
    {
        Scarlett = GameObject.Find("Scarlett");
        if (_boxTransform == null)
            _boxTransform = gameObject.GetComponent<Transform>();
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
                    _boxTransform.position = 
                    new Vector3(_boxTransform.position.x + 0.02F, _boxTransform.position.y, -0.28F);
                if (moveLeft)
                    _boxTransform.position =
                    new Vector3(_boxTransform.position.x - 0.02F, _boxTransform.position.y, -0.28F);
                if (moveUp)
                    _boxTransform.position =
                    new Vector3(_boxTransform.position.x, _boxTransform.position.y + 0.02F, -0.28F);
                if (moveDown)
                    _boxTransform.position =
                    new Vector3(_boxTransform.position.x, _boxTransform.position.y - 0.02F, -0.28F);
            }
        }

    }

    bool scarlettWithinRange()
    {
        float scarlettPosX = Scarlett.transform.position.x;
        float scarlettPosY = Scarlett.transform.position.y;
        float boxPosX = _boxTransform.position.x;
        float boxPosY = _boxTransform.position.y;

        return (scarlettPosX < boxPosX + 1.5) && (scarlettPosX > boxPosX - 1.5) 
        && (scarlettPosY < boxPosY + 2) && (scarlettPosY > boxPosY - 2);
    }

}
