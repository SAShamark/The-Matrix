using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_button : MonoBehaviour
{
    [SerializeField]
    private AudioSource Click_Sound;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Click_Sound.Play();
    }
  
}
