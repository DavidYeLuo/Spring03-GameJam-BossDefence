using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public void LoadScene(string str)
    {
        SceneManager.LoadScene(str);
    }
}
