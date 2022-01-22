using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit_button : MonoBehaviour
{
    [SerializeField]
    private GameObject sprite;
    [SerializeField]
    private AudioSource Click_Sound;

    public void ExitGame()
    {
        sprite.SetActive(true);
        Click_Sound.Play();
    }

    public void Yes()
    {
        Click_Sound.Play();

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void No()
    {
        Click_Sound.Play();
    }


}

