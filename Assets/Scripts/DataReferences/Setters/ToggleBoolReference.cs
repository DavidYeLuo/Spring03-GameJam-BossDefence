using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBoolReference : MonoBehaviour
{
    public BoolReference boolReference;
    public void Toggle()
    {
        boolReference.SetData(!boolReference.GetData());
    }
}
