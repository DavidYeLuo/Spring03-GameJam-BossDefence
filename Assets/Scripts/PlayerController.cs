using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("horizontal speed of the player in m/s")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float dashCooldown = 0.2f;
    [SerializeField] private float dashReload = 1f;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private TrailRenderer myTr;
    [SerializeField] private int maxStoredDashes = 1;
    private bool isDashing = false;
    private float currDashCooldown = 0f;
    private float currDashReload = 0f;
    private float currDashDuration = 0f;
    private int currStoredDashes = 1;
    private Vector3 movementDelta;
    // private statuses
    

    // Start is called before the first frame update
    void Start()
    {
        currStoredDashes = maxStoredDashes;
    }

    // Update is called once per frame
    void Update()
    {
        if(currStoredDashes<maxStoredDashes)
        {
            currDashReload -= Time.deltaTime;
            if(currDashReload <= 0f)
            {
                currDashReload = dashReload;
                currStoredDashes++;
            }
        }

        if(currDashCooldown > 0f)
        {
            currDashCooldown = Mathf.Clamp(currDashCooldown - Time.deltaTime, 0f, dashCooldown);
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && currStoredDashes > 0f)
        {
            isDashing = true;
            currDashDuration = dashDuration;
            currDashCooldown = dashCooldown;
            currStoredDashes--;
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
        myTr.emitting = isDashing;
    }
}