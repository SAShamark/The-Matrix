using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSin : MonoBehaviour
{
    public float frequency = 1f;
    public Vector3 amplitudeVector = new Vector3(0f, 1f, 0f);
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float sin = Mathf.Sin(Time.time * frequency * 2f * Mathf.PI);

        Vector3 offsetm = amplitudeVector * sin;
        transform.position = startPosition + offsetm;
    }
}
