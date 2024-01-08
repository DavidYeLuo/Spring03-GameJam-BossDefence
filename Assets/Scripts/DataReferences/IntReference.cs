using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataReference/IntReference", fileName = "IntReference")]
public class IntReference : ScriptableObject
{
    [SerializeField] private int data;

    public delegate void notify();

    public event notify broadcast;

    public int GetData() { return data; }
    public void SetData(int data)
    {
        this.data = data;

        // In case when there isn't subscribers
        if (broadcast == null) return;
        broadcast.Invoke();
    }
}
