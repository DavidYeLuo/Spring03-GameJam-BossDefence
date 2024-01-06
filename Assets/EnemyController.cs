using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform current_target;
    private Vector3 destination;
    private string targetTag = "Player";
    private bool enabled_moving = true;

    void Start()
    {
        destination = Vector3.zero;
    }

    void Update()
    {
        if(enabled_moving)
        {
            Vector3 moveDirection = new Vector3(destination.x - transform.position.x, 0f, destination.z - transform.position.z);
            // ^ the vertical component of moveDirection is removed
            transform.Translate(moveDirection.normalized*Time.deltaTime*speed);
        }
    }

    private void AI() //placeholder! basic movement and attacking
    {
        //
    }

    private GameObject GetClosestWithTag(string input_tag)
    {
        float minDist = Mathf.Infinity;
        GameObject ret = null;
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag(input_tag))
        {
            float currDist = Vector3.Distance(obj.transform.position, transform.position);
            if(currDist < minDist)
            {
                ret = obj;
                minDist = currDist;
            }
        }
        return ret;
    }
}
