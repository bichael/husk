using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note1Script : MonoBehaviour
{
    GameObject Scarlett;
    GameObject StoryNote;
    bool noteShown = false;
    public Transform _noteTransform;
    // Start is called before the first frame update
    void Start()
    {
        Scarlett = GameObject.Find("Scarlett");
        StoryNote = GameObject.Find("Note");
        if(_noteTransform == null)
        {
            _noteTransform = gameObject.GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool lockBoxToScarlett = Input.GetKeyUp(KeyCode.Space);
        if (!noteShown)
        {
            if (lockBoxToScarlett)
            {
                if (scarlettWithinRange())
                    noteShown = true;
                Debug.Log("Moving Note...");
                StoryNote.transform.position = new Vector3(-100, -100, -100);
            }
        }
        else
        {
            Debug.Log("Note Moved.");
            if (lockBoxToScarlett)
            {
                noteShown = false;
                Debug.Log("Moving Note back...");
                StoryNote.transform.position = new Vector3(-20, -10, 0);
            }

        }

    }

    bool scarlettWithinRange()
    {
        float scarlettPosX = Scarlett.transform.position.x;
        float scarlettPosY = Scarlett.transform.position.y;
        float boxPosX = _noteTransform.position.x;
        float boxPosY = _noteTransform.position.y;

        return (scarlettPosX < boxPosX + 1.5) && (scarlettPosX > boxPosX - 1.5)
        && (scarlettPosY < boxPosY + 2) && (scarlettPosY > boxPosY - 2);
    }

}
