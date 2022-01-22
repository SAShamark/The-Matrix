using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public void Start()
    {

    }

    public void LoadScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
}
