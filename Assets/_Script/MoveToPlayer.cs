using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform Player;
    private void FixedUpdate()
    {
        transform.position += (Player.position - transform.position) * Time.fixedDeltaTime;
    }
}
