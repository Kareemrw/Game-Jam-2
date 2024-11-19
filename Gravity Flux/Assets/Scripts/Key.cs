using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Key Picked Up");
            door.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has acquired key!");
            gameObject.SetActive(false);
        }
    }
}
