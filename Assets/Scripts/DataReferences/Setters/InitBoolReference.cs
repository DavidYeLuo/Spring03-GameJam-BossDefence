using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBool : MonoBehaviour
{
    public BoolReference boolReference;
    public bool initValue;

    private void Start()
    {
        boolReference.SetData(initValue);
    }
}
