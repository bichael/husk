using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note1Script : MonoBehaviour
{
    GameObject Scarlett;
    GameObject Note;
    GameObject StoryNote;
    bool boxLocked = false;
    // Start is called before the first frame update
    void Start()
    {
        Scarlett = GameObject.Find("Scarlett");
        Note = GameObject.Find("Note 1");
        StoryNote = GameObject.Find("StoryNote1");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool lockBoxToScarlett = Input.GetKeyUp(KeyCode.Space);
        if (!boxLocked)
        {
            if (lockBoxToScarlett)
            {
                if (scarlettWithinRange())
                    boxLocked = true;
                Debug.Log("Moving Note...");
                StoryNote.transform.position = new Vector3(-100, -100, -100);
            }
        }
        else
        {
            Debug.Log("Note Moved.");
            if (lockBoxToScarlett)
            {
                boxLocked = false;
                Debug.Log("Moving Note back...");
                StoryNote.transform.position = new Vector3(11.5F, -30, 0);
            }

        }

    }

    bool scarlettWithinRange()
    {
        float scarlettPosX = Scarlett.transform.position.x;
        float scarlettPosY = Scarlett.transform.position.y;
        float boxPosX = Note.transform.position.x;
        float boxPosY = Note.transform.position.y;

        return (scarlettPosX < boxPosX + 1.5) && (scarlettPosX > boxPosX - 1.5)
        && (scarlettPosY < boxPosY + 2) && (scarlettPosY > boxPosY - 2);
    }

}
