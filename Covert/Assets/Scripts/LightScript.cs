using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    GameObject scarlett;
    GameObject lightSwitch;
    GameObject wallLight;
    Light light;
    //bool state = true;
    // Start is called before the first frame update
    void Start()
    {
        scarlett = GameObject.Find("Scarlett");
        lightSwitch = GameObject.Find("Switch1");
        wallLight = GameObject.Find("WallLight1");
        light = wallLight.GetComponent<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool button = Input.GetKeyUp(KeyCode.E);
        if(scarlettWithinRange())
        {
            Debug.Log("Within range.");
            if(button)
            {
                if(light.intensity == 5)
                {
                    light.intensity = 0;
                }
                else
                {
                    light.intensity = 5;
                }
            }
        }
    }

    bool scarlettWithinRange()
    {
        float scarlettPosX = scarlett.transform.position.x;
        float scarlettPosY = scarlett.transform.position.z;
        float switchPosX = lightSwitch.transform.position.x;
        float switchPosY = lightSwitch.transform.position.z;

        return (scarlettPosX < switchPosX + 1.5) && (scarlettPosX > switchPosX - 1.5)
        && (scarlettPosY < switchPosY + 2) && (scarlettPosY > switchPosY - 2);
    }
}
