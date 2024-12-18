using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCollision : MonoBehaviour
{
    public GameObject key;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !key.activeSelf)
        {
            Debug.Log("Level Complete!");
            player.SetActive(false);
            SceneManager.LoadScene(2);

        }

        else
        {
            Debug.Log("Door is locked!");
        }
    }
}
