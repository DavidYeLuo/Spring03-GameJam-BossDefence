using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolReference : MonoBehaviour
{
    public BoolReference boolReference;
    public void Set(bool data)
    {
        boolReference.SetData(data);
    }
}
