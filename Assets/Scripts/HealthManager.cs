using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float scoreWhenKilled = 100f;
    [SerializeField] private GameObject deathPrefab; // sound + particle system + smoke (to hide disappearance of model)
    // it may be benificial to have a grace period to obscure the model before it is destroyed. deactivate movement components, destroy ~0.2f later.
    [SerializeField] private GameObject deathPrefab;

    [Space]
    [Header("Data References")]
    [SerializeField] private bool useDataReference;
    [SerializeField] private IntReference healthReference;
    [SerializeField] private IntReference maxHealthReference;

    private float health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        if (useDataReference)
        {
            healthReference.SetData((int)health);
            maxHealthReference.SetData((int)maxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public float scoreFromDamage(float damageAmount) // if damage results in death, will return the score for killing this enemy
    {
        health -= damageAmount;
        if (health <= 0f)
        {
            if (useDataReference) { healthReference.SetData(0); }
            if (deathPrefab)
            {
                Instantiate(deathPrefab);
            }
            Destroy(gameObject);
            return scoreWhenKilled;

        }
        else if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (useDataReference) { healthReference.SetData((int)health); }
        return 0f;
    }
}
