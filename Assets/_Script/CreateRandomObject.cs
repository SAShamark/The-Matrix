using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomObject : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [Range(0, 100)]
    [SerializeField] private float RandomIndex = 50;

    [Header("Size Arena")]
    [SerializeField] private Vector3 StartPos;
    [SerializeField] private Vector3 sizeArena;
    void Start()
    {
        for(float x = StartPos.x; x < sizeArena.x; x++) {
            gameObject.transform.position = new Vector3(x, sizeArena.y, StartPos.z);
            for (float z = StartPos.z; z < sizeArena.z; z++)
            {
                gameObject.transform.position = new Vector3(x, sizeArena.y, z);
                RaycastHit hit;
                if (Physics.Raycast(new Ray(gameObject.transform.position, Vector3.down), out hit, 25f)) {
                    if(hit.collider.tag == "Graynd")
                    {
                        int randomRange = Random.Range(0, 101);
                        if(randomRange < RandomIndex)
                        {
                            Instantiate(prefab, new Vector3(x, StartPos.y, z), Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}
