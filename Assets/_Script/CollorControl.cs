using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorControl : MonoBehaviour
{
    [SerializeField] private MeshRenderer renderer;
    private void ChangeColor()
    {
        var prop = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(prop);
        prop.SetColor("_Color", new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1));
        renderer.SetPropertyBlock(prop);
    }
    private void Start()
    {
        ChangeColor();
    }
}
