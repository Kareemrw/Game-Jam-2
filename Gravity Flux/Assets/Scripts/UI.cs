using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI gravTimer;
    public RandomGravityChanger gravChanger;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        gravTimer.text = "Gravity Change in " + (gravChanger.changeTimer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gravTimer.text = "Gravity Change in " + (gravChanger.changeTimer);
    }
}
