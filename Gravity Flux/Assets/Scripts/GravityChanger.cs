using UnityEngine;

public class RandomGravityChanger : MonoBehaviour
{
    [SerializeField] private float minGravityScale = -2f;
    [SerializeField] private float maxGravityScale = 2f;
    public float changeInterval = 3f;
    

    private float originalGravityScale;
    private Rigidbody2D[] allRigidbodies;
    private bool gravityReset = true;

    public float changeTimer;

    private void Start()
    {
        //finding all RigidBodies in scene
        allRigidbodies = FindObjectsOfType<Rigidbody2D>();

        if (allRigidbodies.Length > 0)
        {
            originalGravityScale = allRigidbodies[0].gravityScale;
        }

        changeTimer = changeInterval;
    }

    private void Update()
    {
        changeTimer -= Time.deltaTime;

        if (changeTimer <= 0f && gravityReset)
        {
            ChangeGravityScale();
            changeTimer = changeInterval;
        }
        if (changeTimer <= 0f && !gravityReset)
        {
            ResetGravityScale();
            changeTimer = changeInterval;
        }
    }
    
    // Randomly Change Gravity Scale
    private void ChangeGravityScale()
    {
        if (gravityReset)
        {
            float newGravityScale = Random.Range(minGravityScale, maxGravityScale);
            foreach (Rigidbody2D rb in allRigidbodies)
            {
                rb.gravityScale = newGravityScale;
            }
            Debug.Log($"Gravity scale changed to: {newGravityScale}");

            //Invoke(nameof(ResetGravityScale), changeInterval);
            gravityReset = false;
        }
    }

    // Reset Gravity To Original Value
    private void ResetGravityScale()
    {
        foreach (Rigidbody2D rb in allRigidbodies)
        {
            rb.gravityScale = originalGravityScale;
        }
        Debug.Log($"Gravity scale reset to original: {originalGravityScale}");
        gravityReset = true;
    }
}
