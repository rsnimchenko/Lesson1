using UnityEngine;

public class Rainbow3 : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private float _duration;

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.Repeat(Time.time / _duration, 1f);
        _meshRenderer.material.color = Color.HSVToRGB(t, 1f, 1f);
    }
}
