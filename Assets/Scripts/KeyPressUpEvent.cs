using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyPressUpEvent : MonoBehaviour
{
    public KeyCode key;
    [SerializeField] private UnityEvent onPressUp;

    private void Update()
    {
        if (Input.GetKeyUp(key))
        {
            onPressUp.Invoke();
        }
    }
}
