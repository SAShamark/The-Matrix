using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private VariableJoystick _varJoystic;
    [SerializeField] public float speed;
    [SerializeField] private VariableJoystick _varJoysticCam;
    [SerializeField] private float speedCam = 60;
    [SerializeField] private GameObject[] rayTest;
    private Vector3 direction = Vector3.zero;
    private bool directMain = true;

    //Const
    private const float sizeStartMove = 0.3f;
    private const float sizeRaycast = 0.6f;

    //
    public static string[] tagUse = { "Hp", "Protect", "Speed", "xHp", "Enemy", "EnemyFire", "EnemyJump", "Bullet", "Barier", "Portal", "PointBot", "UpEat", "PortalBack" };


    void Update()
    {
        MobileImput();
    }

    //
    private void MobileImput()
    {
        if (_varJoysticCam.Horizontal > sizeStartMove || _varJoysticCam.Horizontal < -sizeStartMove) gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up * _varJoysticCam.Horizontal, speedCam * Time.deltaTime);

        if (_varJoystic.Vertical > sizeStartMove)
        {
            direction = gameObject.transform.forward;
            directMain = true;
        }
        else if (_varJoystic.Vertical < -sizeStartMove)
        {
            direction = -gameObject.transform.forward;
            directMain = true;
        }
        else if (_varJoystic.Horizontal > sizeStartMove)
        {
            direction = gameObject.transform.right;
            directMain = false;
        }
        else if (_varJoystic.Horizontal < -sizeStartMove)
        {
            direction = -gameObject.transform.right;
            directMain = false;
        }
        else direction = Vector3.zero;
    }

    //Move
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (directMain)
        {
            bool workRay = false;
            for (int i = 0; i < 3; i++)
            {
                if (Physics.Raycast(new Ray(rayTest[i].transform.position, direction), out hit, sizeRaycast))
                {
                    TestCollider(hit);
                    workRay = true;
                }
            }
            if (!workRay) gameObject.transform.position += direction * Time.deltaTime * speed;
        }
        else
        {
            bool workRay = false;
            for (int i = 0; i < 5; i++)
            {
                if (i == 1 || i == 2) continue;
                if (Physics.Raycast(new Ray(rayTest[i].transform.position, direction), out hit, sizeRaycast))
                {
                    TestCollider(hit);
                    workRay = true;
                }
            }
            if (!workRay) gameObject.transform.position += direction * Time.deltaTime * speed;
        }
    }

    private void TestCollider(RaycastHit hit)
    {
        for (int i = 0; i < tagUse.Length; i++)
        {
            if (hit.collider.tag == tagUse[i])
            {
                gameObject.transform.position += direction * Time.deltaTime * speed;
                break;
            }
        }
    }
    //Speed time move
}
