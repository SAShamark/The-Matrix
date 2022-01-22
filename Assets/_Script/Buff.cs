using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    [Header("Protect")]
    [SerializeField] public bool protect = false;
    [SerializeField] public GameObject protectObject;


    //Use moment
    [Header("Speed")]
    [SerializeField] public bool speed = false;
    [SerializeField] public GameObject speedObject;
    [SerializeField] private MovePlayer _movePl;
    [SerializeField] private Slider _speedSlider;

    [Header("xHp")]
    [SerializeField] public bool xHp = false;
    [SerializeField] public GameObject xHpObject;
    [SerializeField] private Slider _xHpSlider;

    void Start()
    {
        CheckEffect();
    }

    public void CheckEffect()
    {
        if (protect) protectObject.SetActive(true);
        else protectObject.SetActive(false);

        if (speed) speedObject.SetActive(true);
        else {
            _speedSlider.value = 0;
            speedObject.SetActive(false);
        }


        if (xHp) xHpObject.SetActive(true);
        else {
            _xHpSlider.value = 0;
            xHpObject.SetActive(false);
        }
    }

    public IEnumerator timerBaff(float timer, int indexBaff)
    {
        switch (indexBaff)
        {
            case 0:
                _movePl.speed *= 2;
                break;

            case 1:
                PlayerController._numberHp *= 2; 
                break;
        }
        
        //Timer
        for(float t = timer; t > 0; t -= 0.1f)
        {
            switch (indexBaff)
            {
                case 0:
                    _speedSlider.value = t;
                    break;

                case 1:
                    _xHpSlider.value = t;
                    break;
            }

            yield return new WaitForSeconds(0.1f);
            Debug.Log(t);
        }

        switch (indexBaff)
        {
            case 0:
                _movePl.speed /= 2;
                speed = false;
                break;

            case 1:
                PlayerController._numberHp /= 2;
                PlayerController._numberHp = Mathf.Round(PlayerController._numberHp);
                xHp = false;
                break;
        }

        CheckEffect();
    }
}