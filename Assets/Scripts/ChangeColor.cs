using System.Collections;
using TMPro;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private float _duration;
    [SerializeField] private ChangeColorKind _kind;

    void Start()
    {
        Coroutine coroutine = _kind switch
        {
            ChangeColorKind.Manual => StartCoroutine(ChangeColorManual(_meshRenderer, _startColor, _endColor, _duration)),
            ChangeColorKind.Cos => StartCoroutine(ChangeColorCos(_meshRenderer, _startColor, _endColor, _duration)),
            ChangeColorKind.Pong => StartCoroutine(ChangeColorPong(_meshRenderer, _startColor, _endColor, _duration))
        };
    }

    private IEnumerator ChangeColorManual(MeshRenderer meshRenderer, Color startColorParam, Color endColorParam, float duration)
    {
        float currentTime = 0f;

        Color startColor = startColorParam;
        Color endColor = endColorParam;

        while (true)
        {
            float interpolation = currentTime / duration;
            Color currentColor = Color.Lerp(startColor, endColor, interpolation);
            meshRenderer.material.color = currentColor;
            currentTime += Time.deltaTime;
            if (currentTime >= duration)
            {
                currentTime = 0f;
                meshRenderer.material.color = endColor;
                (startColor, endColor) = (endColor, startColor);
            }

            yield return null;
        }
    }

    private IEnumerator ChangeColorCos(MeshRenderer meshRenderer, Color startColor, Color endColor, float duration)
    {
        while (true)
        {
            float raw = Mathf.Cos(Time.time * (Mathf.PI * 2 / (duration * 2)));
            float interpolation = raw * 0.5f + 0.5f;
            Color currentColor = Color.Lerp(endColor, startColor, interpolation);
            meshRenderer.material.color = currentColor;

            yield return null;
        }
    }

    private IEnumerator ChangeColorPong(MeshRenderer meshRenderer, Color startColor, Color endColor, float duration)
    {
        while (true)
        {
            float interpolation = Mathf.PingPong(Time.time, duration) / duration;
            Color currentColor = Color.Lerp(startColor, endColor, interpolation);
            meshRenderer.material.color = currentColor;

            yield return null;
        }
    }
}
