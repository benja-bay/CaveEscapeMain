using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickaxeCollect : MonoBehaviour
{
    private GameObject rockFall;
    void Start()
    {
        rockFall = GameObject.Find("rockfall");
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled=false;
            Destroy(gameObject, 0.5f);
            if (rockFall != null)
            {
                rockFall.SetActive(!rockFall.activeSelf);
                Debug.Log("rock fall disabled");
            }
        }
    }
}
