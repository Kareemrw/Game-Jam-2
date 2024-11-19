using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet; 
    public Transform bulletPos; 
    public float shootInterval = 2f; 
    public float bulletSpeed = 5f; 

    private float shootTimer;

    void Update()
    {
        shootTimer += Time.deltaTime; 
        if (shootTimer >= shootInterval) 
        {
            shootTimer = 0; 
            Shoot(); 
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);

        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.left * bulletSpeed; 
        }
    }
}
