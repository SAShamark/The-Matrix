using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControll : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 offSet;

    void FixedUpdate()
    {
        transform.position = _player.transform.position + offSet;
    }
}
