using System;
using Unity.VisualScripting;
using UnityEngine;

public class Rainbow2 : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private float _duration;
    private Gradient _gradient;

    void Start()
    {
        _gradient = new Gradient();
        _gradient.colorKeys = new GradientColorKey[] {
            new GradientColorKey(Color.red, 0f),
            new GradientColorKey(Color.yellow, 0.17f),
            new GradientColorKey(Color.green, 0.33f),
            new GradientColorKey(Color.cyan, 0.5f),
            new GradientColorKey(Color.blue, 0.67f),
            new GradientColorKey(new Color(0.5f,0f,1f), 0.84f),
            new GradientColorKey(Color.red, 1f)
        };
    }

    void Update()
    {
        float t = Mathf.Repeat(Time.time / _duration, 1f);
        _meshRenderer.material.color = _gradient.Evaluate(t);
    }
}
