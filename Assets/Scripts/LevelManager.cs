using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Tooltip("insert the prefabs of waves that you want to deploy here!")]
    [SerializeField] private GameObject[] wave_objects;
    [Tooltip("Write the time you want the wave prefabs to be spawned here (in same order) (must be in order from lowest to highest time)!")]
    [SerializeField] private float[] wave_times;
    private int curr_index = 0;
    private bool isSpawning = true;

    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpawning)
        {
            return;
        }
        if(wave_times[curr_index]>Time.time)
        {
            curr_index += 1;
            if(curr_index>=wave_times.Length)
            {
                isSpawning = false;
            }
        }
    }   
}