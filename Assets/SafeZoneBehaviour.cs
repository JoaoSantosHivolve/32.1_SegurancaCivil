using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SafeZoneBehaviour : MonoBehaviour
{
    public bool isSafe;

    public Color safe;
    public Color notSafe;

    public Image watchDisplay;
    public TextMeshProUGUI watchText;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "SafeZone")
        {
            isSafe = true;
            watchDisplay.color = safe;
            watchText.text = "Safe";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SafeZone")
        {
            isSafe = false;
            watchDisplay.color = notSafe;
            watchText.text = "Not Safe";
        }
    }
}
