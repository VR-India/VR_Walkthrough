using UnityEngine;
public class ClockTime : MonoBehaviour
{
    public TMPro.TMP_Text timeText;
    void Update()
    {
        timeText.text = System.DateTime.Now.ToString("h:mm:ss tt  dd/MMM/yyyy");
    }

}