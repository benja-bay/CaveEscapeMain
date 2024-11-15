using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatText : MonoBehaviour
{
    public float timeAlive = 2;

    private void Update() {
        timeAlive -= Time.deltaTime;
        if (timeAlive <= 0)
        {
            Destroy(this.gameObject);    
        }
    }
}
