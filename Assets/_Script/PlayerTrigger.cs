using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private Buff _buff;
    [SerializeField] private PlayerControllerSize _playerControllerSize;
    // [SerializeField] private PlayerController _playerController;
    void Start()
    {
        //  _playerController = gameObject.GetComponent<PlayerController>();
    }


    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Hp":
                PlayerController._numberHp++;
                _playerControllerSize.CreateSize();
                Destroy(other.gameObject);
                break;

            case "UpEat":
                PlayerController._numberHp += 30;
                _playerControllerSize.CreateSize();
                Destroy(other.gameObject);
                break;

            case "Speed":
                if (!_buff.speed)
                {
                    _buff.speed = true;
                    StartCoroutine(_buff.timerBaff(20f, 0));//15 seconds, 0 - baff this speed
                }
                Destroy(other.gameObject);
                break;

            case "Protect":
                _buff.protect = true;
                Destroy(other.gameObject);
                break;

            case "xHp":
                if (!_buff.xHp)
                {
                    _buff.xHp = true;
                    StartCoroutine(_buff.timerBaff(15f, 1));//15 seconds, 1 - baff this xHp
                }
                Destroy(other.gameObject);
                break;

            default:
                break;
        }

        _buff.CheckEffect();
    }
}