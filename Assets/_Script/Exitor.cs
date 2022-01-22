using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exitor : MonoBehaviour
{
    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }
}
