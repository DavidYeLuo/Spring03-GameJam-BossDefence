using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnBool : MonoBehaviour
{
    public BoolReference boolReference;
    [SerializeField] private bool negate;
    public List<GameObject> objectsToUpdate;

    private void OnEnable()
    {
        boolReference.broadcast += UpdateGameObjects;
    }

    private void OnDisable()
    {
        boolReference.broadcast -= UpdateGameObjects;
    }

    private void UpdateGameObjects()
    {
        foreach (GameObject obj in objectsToUpdate)
        {
            obj.SetActive(boolReference.GetData());
        }
    }
}
