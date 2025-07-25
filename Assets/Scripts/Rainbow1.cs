using UnityEngine;

public class Rainbow1 : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private float _speed = 0.2f;
    private Texture2D _rainbowTex;

    void Start()
    {

        _rainbowTex = new Texture2D(256, 1, TextureFormat.RGBA32, false);
        _rainbowTex.wrapMode = TextureWrapMode.Repeat;

        for (int x = 0; x < 256; x++)
        {
            float h = x / 256f;
            Color col = Color.HSVToRGB(h, 1f, 1f);
            _rainbowTex.SetPixel(x, 0, col);
        }
        _rainbowTex.Apply();

        _meshRenderer.material.mainTexture = _rainbowTex;

    }

    void Update()
    {
        float offsetU = Time.time * _speed % 1f;

        _meshRenderer.material.mainTextureOffset = new Vector2(offsetU, 0f);
    }
}
