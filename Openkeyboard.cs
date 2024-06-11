using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Openkeyboard : MonoBehaviour
{
    private InputField inputField;
    private TouchScreenKeyboard keyboard;

    private void Start()
    {
        // Get reference to the InputField component
        inputField = GetComponent<InputField>();
    }

    private void Update()
    {
        // Check if the input field is clicked and the mobile keyboard is not currently active
        if (inputField.isFocused && (keyboard == null || !keyboard.active))
        {
            //Debug.Log("ok");
            // Show the mobile keyboard
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
    }
}
