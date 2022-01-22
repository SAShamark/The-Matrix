using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTheGame : MonoBehaviour
{
    [SerializeField] private int _indexWin;
    [SerializeField] private GameObject Portals;
    public int CountKill = 0;
    private void Start()
    {
        CountKill = 0;

    }
    private void FixedUpdate()
    {
       
    }
    public void CillPlupPlus()
    {
       
            CountKill++;
            if (CountKill >= _indexWin)
            {
            
                Portals.SetActive(true);
            }
        

    }
}
