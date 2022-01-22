using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class EnemyForJump : MonoBehaviour
{
    NavMeshAgent our;
    [SerializeField] private Transform _player;
    [SerializeField] private TMP_Text _hp;
    public float _numberHP;
    public float DistanceForMove = 3;
    public float DistanceForJump = 1;
    private bool canUpdate=true;
    private float timeForJump = 1f;
    void Start()
    {
        _hp.text = _numberHP.ToString();
        our = GetComponent<NavMeshAgent>();
        our.speed = 2f;

    }
    public void SetHp(int hp)
    {
        _numberHP = hp;
    }
    // Update is called once per frame
    void Update()
    {
        if (!canUpdate)
        {
            return;
        }
        if (Vector3.Distance(_player.position, transform.position) < DistanceForJump)
        {
            StartCoroutine(Jump());
        }
        else if (Vector3.Distance(_player.position, transform.position) < DistanceForMove)
        {
            our.destination = _player.position;
        }
        


    }
    IEnumerator Jump()
    {
        canUpdate = false;

        yield return new WaitForSeconds (0.5f);

        var time = 0f;
        var middlePoint = ((transform.position - _player.position) * 0.5f) + transform.position +transform.up * 3f;
        var startPoint = transform.position;
        var endPoint = _player.position;

        while(time < timeForJump)
        {
            var lerp1 = Vector3.Lerp(startPoint, middlePoint, time / timeForJump);
            var lerp2 = Vector3.Lerp(middlePoint, endPoint, time / timeForJump);
            transform.position = Vector3.Lerp(lerp1, lerp2, time / timeForJump);
            yield return null;
            time += Time.deltaTime;
        }
        
        yield return new WaitForSeconds(3f);

        canUpdate = true;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}
