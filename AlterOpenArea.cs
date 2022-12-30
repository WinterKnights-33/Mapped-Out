using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterOpenArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Open")
        Destroy(other.gameObject);
    }
}