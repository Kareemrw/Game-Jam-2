using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{   public GameObject door;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Key Picked Up");
            door.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.SetActive(false)
        }
    }

}
