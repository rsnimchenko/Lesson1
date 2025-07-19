using System.Collections;
using TMPro;
using UnityEngine;

public enum ChangeColorKind { Manual, Cos, Pong }

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float duration;
    [SerializeField] private ChangeColorKind kind;

    void Start()
    {
        switch (kind)
        {
            case ChangeColorKind.Manual:
                StartCoroutine(ChangeColorManual(meshRenderer, startColor, endColor, duration));
                break;
            case ChangeColorKind.Cos:
                StartCoroutine(ChangeColorCos(meshRenderer, startColor, endColor, duration));
                break;
            case ChangeColorKind.Pong:
                StartCoroutine(ChangeColorPong(meshRenderer, startColor, endColor, duration));
                break;
        }
    }

    private IEnumerator ChangeColorManual(MeshRenderer _meshRenderer, Color _startColor, Color _endColor, float _duration)
    {
        float currentTime = 0f;

        Color startColor = _startColor;
        Color endColor = _endColor;

        while (true)
        {
            float interpolation = currentTime / _duration;
            Color currentColor = Color.Lerp(startColor, endColor, interpolation);
            _meshRenderer.material.color = currentColor;
            currentTime += Time.deltaTime;
            if (currentTime >= _duration)
            {
                currentTime = 0f;
                meshRenderer.material.color = endColor;
                (startColor, endColor) = (endColor, startColor);
            }

            yield return null;
        }
    }

    private IEnumerator ChangeColorCos(MeshRenderer _meshRenderer, Color _startColor, Color _endColor, float _duration)
    {
        while (true)
        {
            float raw = Mathf.Cos(Time.time * (Mathf.PI * 2 / (_duration * 2)));
            float interpolation = raw * 0.5f + 0.5f;
            Color currentColor = Color.Lerp(_endColor, _startColor, interpolation);
            _meshRenderer.material.color = currentColor;

            yield return null;
        }
    }

    private IEnumerator ChangeColorPong(MeshRenderer _meshRenderer, Color _startColor, Color _endColor, float _duration)
    {
        while (true)
        {
            float interpolation = Mathf.PingPong(Time.time, _duration) / _duration;
            Color currentColor = Color.Lerp(_startColor, _endColor, interpolation);
            _meshRenderer.material.color = currentColor;

            yield return null;
        }
    }
}
