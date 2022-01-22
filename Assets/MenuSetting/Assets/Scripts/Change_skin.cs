using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_skin : MonoBehaviour
{
    [SerializeField]
    private Sprite spr1;
    [SerializeField]
    private Sprite spr2;
    [SerializeField]
    private Sprite spr3;
    [SerializeField]
    private AudioSource Clothes_Sound;

    public void Style_1()
    {
        gameObject.GetComponent<Image>().sprite = spr1;
        Clothes_Sound.Play();
    }
    public void Style_2()
    {
        gameObject.GetComponent<Image>().sprite = spr2;
        Clothes_Sound.Play();
    }
    public void Style_3()
    {
        gameObject.GetComponent<Image>().sprite = spr3;
        Clothes_Sound.Play();
    }

}
