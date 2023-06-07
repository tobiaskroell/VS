using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RefreshBlackbox : MonoBehaviour
{
    public GameObject prompt;
    public TextMeshProUGUI promptMessage;

    public void Refresh()
    {
        prompt.SetActive(true);
        promptMessage.text = "Als nächstes benötigt der Patient einen Strahlenschutz.";
    }

}
