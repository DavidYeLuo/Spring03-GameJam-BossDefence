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
    [SerializeField] private float standTimeMax = 1f;

    // internal (hidden)
    private Transform current_target;
    private const float levelSize = 20f; //needed to check for out-of-bounds move target

    private Vector3 targetPosition = Vector3.zero;
    private bool isMoving = false;
    private Vector3 velocity = Vector3.zero;
    private float standAndBurstTimer = 0f;
    private float shotTimer = 0f;
    private float shotTimerMax = 0.3f;

    void Start()
    {
        targetPosition = Vector3.zero;
        // standAndBurstTimer = Random.Range(0f,standTimeMax);
    }

    void Update()
    {
        if(isMoving)
        {
            move();
        }
        else
        {
            standAndBurst();
        }
    }

    private void move()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.5f);
        if(Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isMoving = false;
        }
    }

    private void setMoveTarget(Vector3 newPos)
    {
        targetPosition = newPos;
        isMoving = true;
    }


    private void standAndBurst()
    {
        if(!current_target)
        {
            current_target = GetClosestWithTag("Player").transform;
            if(!current_target)
            {
                return;
            }
        }
        shotTimer -= Time.deltaTime;
        if(shotTimer <= 0f)
        {
            Instantiate(bulletPatternPrefab, transform.position, Quaternion.LookRotation(current_target.position - transform.position));
            shotTimer = shotTimerMax;
        }
        standAndBurstTimer -= Time.deltaTime;
        if(standAndBurstTimer <= 0f)
        {
            standAndBurstTimer = standTimeMax;
            // setMoveTarget(current_target.position);
            float rand_x = Mathf.Clamp(current_target.position.x + Random.Range(-5f, 5f), -levelSize, levelSize);
            float rand_z = Mathf.Clamp(current_target.position.z + Random.Range(-5f, 5f), -levelSize, levelSize);
            setMoveTarget(new Vector3(rand_x, 0f, rand_z));
            shotTimer = 0f;
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