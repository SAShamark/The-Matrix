using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPacBrain : MonoBehaviour
{
    [SerializeField] private Vector3[] rayTransform;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;
    [SerializeField] private float speed;

    private bool move = false;

    void Start()
    {
        startPos = gameObject.transform.position;
        endPos = startPos;
        CreateRay();
    }


    private void CreateRay()
    {
        startPos = gameObject.transform.position;
        RaycastHit hit;
        for(int i = 0; i < 20; i++)
        {
            int k = Random.Range(0, rayTransform.Length);
            if(Physics.Raycast(new Ray(gameObject.transform.position, rayTransform[k]), out hit,  30f))
            {
                if (hit.collider.tag == "PointBot")
                {
                    endPos = hit.collider.transform.position;
                    StartCoroutine(MovePlayerCoroutine(rayTransform[k]));
                    break;
                }
            }
        }
    }

    private IEnumerator MovePlayerCoroutine(Vector3 direct)
    {
        float timer = Random.Range(3, 11);
        Vector3 offset = endPos - gameObject.transform.position;

        timer /= speed;
        for(float t = 0; t  < 1; t += Time.deltaTime/ timer)
        {
            gameObject.transform.position = startPos + (offset * t);
            yield return null;
        }

        gameObject.transform.position = startPos + offset;

        CreateRay();
    }
}
