using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Music : MonoBehaviour
{
    [SerializeField]
    private AudioSource Click_Sound;
    [SerializeField]
    private AudioSource Block_Sound;
    public void Click()
    {
        Click_Sound.Play();
    }
    public void Block()
    {
        Block_Sound.Play();
    }

}
