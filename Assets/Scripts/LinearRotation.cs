using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeedRadiansPerSecond;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeedRadiansPerSecond * Time.deltaTime);
    }
}
