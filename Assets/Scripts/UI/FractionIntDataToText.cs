using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FractionIntDataToText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] IntReference current;
    [SerializeField] IntReference max;

    private void OnEnable()
    {
        current.broadcast += OnDataUpdate;
        max.broadcast += OnDataUpdate;
    }

    private void OnDisable()
    {
        current.broadcast -= OnDataUpdate;
        max.broadcast -= OnDataUpdate;
    }

    private void OnDataUpdate()
    {
        // Edit text to fraction. EX: 34/100
        string text = string.Format("{0}/{1}\n", current.GetData()
                , max.GetData());
        textMeshPro.text = text;
    }
}
