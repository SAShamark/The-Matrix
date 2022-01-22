using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyWithFire : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _point;
    [SerializeField] private TMP_Text _hp;
    public float Distance = 5;
    public float timeForShoting=4;
    private float lastShoting = 4;
    public float _numberHP;

    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        _hp.text = _numberHP.ToString();
        StartCoroutine(Shoting());
    }
    public void SetHp(int hp)
    {
        _numberHP = hp;
    }
    IEnumerator Shoting()
    {
        
        while(true)
        {
            yield return null;
            if (lastShoting < Time.time - timeForShoting)
            {
                if (Vector3.Distance(_player.position, transform.position) < Distance)
                {

                    var bulletGO = Instantiate(bullet, _point);
                    bulletGO.transform.position = _point.position;
                    if(bulletGO.TryGetComponent(out MoveToPlayer bulletScript))
                    {
                        bulletScript.Player = _player;
                    }
                    lastShoting = Time.time;
                }
            }

            
        }
    }

}
