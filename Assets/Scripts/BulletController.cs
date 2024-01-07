using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private string affectedTag = "Player";
    [SerializeField] private float damage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // REMEMBER: exclude cosmetic objects, e.g. character models, from DefaultRaycastLayers layermask! (giving it the "ignore raycast" tag should do the trick)
        if(Physics.Raycast(transform.position, transform.forward, out hit, speed * Time.deltaTime))
        {
            if(hit.collider.gameObject.tag == affectedTag)
            {
                float score = hit.collider.gameObject.GetComponent<HealthManager>().scoreFromDamage(damage);
                if(score > 0f && affectedTag == "Enemy")
                {
                    // Insert code to update score in the UI here!!
                }
                Destroy(gameObject);
                return;
            }
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // oncollisionenter-- do ~~~
}
