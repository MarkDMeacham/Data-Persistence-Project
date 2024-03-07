using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameInput : MonoBehaviour
{
    private TMP_InputField inputField; 

    // Start is called before the first frame update
    void Start()
    {
        inputField = this.GetComponent<TMP_InputField>();
        inputField.text = MenuUIHandler.Instance.userName;
    }

    public void OnUpdate()
    {
        MenuUIHandler.Instance.UpdateUserName(inputField.text);
    }
}
