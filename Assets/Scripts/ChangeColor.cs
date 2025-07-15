using Unity.VisualScripting;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    private float redOffset = 1f;
    private float signRedOffset = -1;

    void Start()
    {
        meshRenderer.material.SetColor("_BaseColor", new(redOffset, 0f, 0f));
    }

    void Update()
    {
        redOffset += signRedOffset * Time.deltaTime;
        meshRenderer.material.SetColor("_BaseColor", new(redOffset, 0f, 1f - redOffset));

        if (redOffset <= 0f || redOffset >= 1f) signRedOffset = -signRedOffset;
    }
}