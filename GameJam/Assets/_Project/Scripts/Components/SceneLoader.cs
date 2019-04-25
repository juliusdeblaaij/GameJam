using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Fish").Length == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
