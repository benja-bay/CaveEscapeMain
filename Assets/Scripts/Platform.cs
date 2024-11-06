using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private PlatformEffector2D   effector;
    public float startWaiTime;
    private float waitedTime;


    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitedTime = startWaiTime;
        }

        if (Input.GetKey("s"))
        {
            if (waitedTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitedTime = startWaiTime;
            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }
        if (Input.GetKey("space"))
        {
            effector.rotationalOffset = 0;
        }
    }
}
