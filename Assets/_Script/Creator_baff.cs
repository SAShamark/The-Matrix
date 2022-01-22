using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator_baff : MonoBehaviour
{
    [SerializeField] private GameObject _barier, _speed,XP,Protect;
    private void Start()
    {
        if (_barier)
        {
            StartCoroutine(CreatorBarier());

        }
        if (_speed)
        {
            StartCoroutine(CreatorSpeed());

        }
        if (XP)
        {
            StartCoroutine(CreatorXP());

        }
        if (Protect)
        {
            StartCoroutine(CreatorProtect());

        }


    }
    IEnumerator CreatorBarier()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            Instantiate(_barier, new Vector3(Random.Range(-22, 22), 1, Random.Range(22, -22)), Quaternion.identity);
        }
    }
    IEnumerator CreatorSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            Instantiate(_speed, new Vector3(Random.Range(-22, 22), 1, Random.Range(22, -22)), Quaternion.identity);
        }
    }
    IEnumerator CreatorXP()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);
            Instantiate(XP, new Vector3(Random.Range(-22, 22), 1, Random.Range(22, -22)), Quaternion.identity);
        }
    }
    IEnumerator CreatorProtect()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);
            Instantiate(Protect, new Vector3(Random.Range(-22, 22), 1, Random.Range(22, -22)), Quaternion.identity);
        }
    }
}
