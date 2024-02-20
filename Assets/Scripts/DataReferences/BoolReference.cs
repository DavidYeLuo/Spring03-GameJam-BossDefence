using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataReference/BoolReference", fileName = "BoolReference")]
public class BoolReference : ScriptableObject
{
    [SerializeField] private bool data;

    public delegate void notify();

    public event notify broadcast;

    public bool GetData() { return data; }
    public void SetData(bool data)
    {
        this.data = data;

        // In case when there isn't subscribers
        if (broadcast == null) return;
        broadcast.Invoke();
    }
}
