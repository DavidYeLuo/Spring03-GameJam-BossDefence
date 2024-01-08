using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // shown
    [Tooltip("movement speed in m/s")]
    [SerializeField] private float speed = 10f;
    [Tooltip("the type (tag) of entity which this enemy will target-- Player by default, but healers should have it set to Enemy.")]
    [SerializeField] private string targetTag = "Player";
    [Tooltip("the range at which the enemy will attack the target")]
    [SerializeField] private float range = 2f;
    [Tooltip("the delay between shots")]
    [SerializeField] private float fireDelay = 0.5f;
    [Tooltip("the bullet prefab generated on each shot")]
    [SerializeField] private GameObject bulletPatternPrefab;
    [SerializeField] private float maxHealth;

    // internal (hidden)
    private Transform current_target;
    private Vector3 moveDirection;
    private string behaviorState = "chasing";
    private const float levelSize = 20f; //needed to check for out-of-bounds move target
    private float health;
    private float nextShotTimer = 0f;
    private bool inactive = false; // to be used for spawning in, destroying self, etc..
    // the same smoke effect can be used for spawning and disappearing the bodies.

    void Start()
    {
        moveDirection = Vector3.zero;
        health = maxHealth;
    }

    void Update()
    {
        if(inactive)
        {
            return;
        }
        nextShotTimer -= Time.deltaTime;
        behaviorTree();
        switch(behaviorState)
        {
            case "chasing":
                moveDirection = new Vector3(current_target.position.x - transform.position.x, 0f, current_target.position.z - transform.position.z);
                transform.Translate(moveDirection.normalized*Time.deltaTime*speed);
                break;
            case "fleeing":
                // it's the same as chasing state, but reverse direction. healers can't flee.
                moveDirection = new Vector3(current_target.position.x - transform.position.x, 0f, current_target.position.z - transform.position.z);
                transform.Translate(moveDirection.normalized*Time.deltaTime*speed*(-1f));
                break;
            case "attacking":
                if(nextShotTimer <= 0f)
                {
                    Instantiate(bulletPatternPrefab, transform.position, Quaternion.LookRotation(current_target.position - transform.position, Vector3.up));
                    nextShotTimer = fireDelay;
                }
                break;
            case "none":
                break;
            default:
                print("error: no state given");
                break;
        }
    }

    private void behaviorTree() //placeholder! basic movement and attacking
    {
        if(health/maxHealth < 0.5f && targetTag == "Player")
        {
            behaviorState = "fleeing";
        }
        else
        {
            current_target = GetClosestWithTag(targetTag).transform;
            if(!current_target)
            {
                behaviorState = "none"; // there are no valid targets!
            }
            // ^ the vertical component of moveDirection is removed
            if(Vector3.Distance(current_target.position, transform.position) <= range)
            {
                behaviorState = "attacking";
            }
            else
            {
                behaviorState = "chasing";
            }
        }
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