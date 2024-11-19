using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI gravTimer; 
    public RandomGravityChanger gravChanger; 

    public Image[] heartIcons; 
    private int currentHearts;

    void Start()
    {
        currentHearts = heartIcons.Length; 
    }

    void Update()
    {
        gravTimer.text = "Gravity Change in " + Mathf.Ceil(gravChanger.changeTimer).ToString();
    }

    public void TakeDamage()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            heartIcons[currentHearts].enabled = false; 
        }
        if (currentHearts <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
