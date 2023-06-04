using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateActionmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ActivateMenu()
    {
        PlayerPrefs.SetInt("activateActionmenu", 1);
        PlayerPrefs.Save();
    }
}
