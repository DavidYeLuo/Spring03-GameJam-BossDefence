using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("horizontal speed of the player in m/s")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float dashCooldown = 5f;
    [SerializeField] private float dashDuration = 0.5f;
    private bool isDashing = false;
    private float currDashCooldown = 0f;
    private float currDashDuration = 0f;
    private Vector3 movementDelta;
    // private statuses
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currDashCooldown > 0f)
        {
            currDashCooldown = Mathf.Clamp(currDashCooldown - Time.deltaTime, 0f, dashCooldown);
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            isDashing = true;
            currDashDuration = dashDuration;
            currDashCooldown = dashCooldown;
        }
        if(isDashing)
        {
            transform.Translate(movementDelta*Time.deltaTime*speed*5f);
            currDashDuration = Mathf.Clamp(currDashDuration - Time.deltaTime, 0f, dashDuration);
            if(currDashDuration == 0f)
            {
                isDashing = false;
            }
        }
        else
        {
            movementDelta = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            movementDelta = movementDelta.normalized;
            transform.Translate(movementDelta*Time.deltaTime*speed);
        }
    }
}