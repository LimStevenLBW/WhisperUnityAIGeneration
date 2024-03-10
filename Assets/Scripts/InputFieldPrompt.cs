using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
public class InputFieldPrompt : MonoBehaviour
{
    public TMP_InputField textField;

    public bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated == true) return;
        if (Input.GetKeyDown("t"))
        {
            textField.Select();
            activated = true;
            textField.ActivateInputField();
        }
    }
}
