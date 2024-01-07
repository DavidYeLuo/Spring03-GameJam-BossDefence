using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("horizontal speed of the player in m/s")]
    [SerializeField] private float speed = 2f;

    // private statuses
    private bool status_frozen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDelta = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.Translate(movementDelta*Time.deltaTime*speed);
    }
}