using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSize : MonoBehaviour
{

    [SerializeField] private Vector3[] numSize;
    [SerializeField] private float[] ifSize;
    
    public void CreateSize()
    {
        for(int i = 0; i < ifSize.Length; i++)
        {
            if(PlayerController._numberHp < ifSize[i])
            {
                gameObject.transform.localScale = numSize[i];
                break;
            }
        }
    }
}
