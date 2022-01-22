using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;

    void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position + offset, Time.deltaTime * 2f);
    }
}
