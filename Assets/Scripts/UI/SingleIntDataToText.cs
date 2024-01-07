using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingleIntDataToText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] IntReference data;

    private void OnEnable()
    {
        data.broadcast += OnDataUpdate;
    }

    private void OnDisable()
    {
        data.broadcast -= OnDataUpdate;
    }

    private void OnDataUpdate()
    {
        textMeshPro.text = data.GetData().ToString();
    }
}
