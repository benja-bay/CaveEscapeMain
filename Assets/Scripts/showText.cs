using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showText : MonoBehaviour
{
    public float padingInX = (-0.6f);
    public float padingIny = (0.15f);
    public GameObject textPrefab;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            showInfo();
        }
    }
    public void showInfo()
    {
        Debug.Log("Show Text");
        GameObject text = Instantiate(textPrefab);
        text.transform.position = new Vector3(this.gameObject.transform.position.x+padingInX,this.gameObject.transform.position.y+padingIny,this.gameObject.transform.position.z);
    }
}
