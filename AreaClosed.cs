using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//just copied and pasted here

public class AreaClosed : MonoBehaviour
{
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log("Next Area Closed!  Please Seek Out Alter To Open!");
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Please Seek Out Alter To Open!");
    }
}
