using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private ChangerCamera _changer;
    [SerializeField] private string _triggerTag;
    private float speed = 5.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_triggerTag))
        {
            _changer.SelectTargetCamera(other);
        }
    }


    void Update()
    {
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");

        Vector3 forward = Vector3.forward * Time.deltaTime * speed * vInput;
        Vector3 side = Vector3.right * Time.deltaTime * speed * hInput;

        transform.Translate(forward + side);
    }
}
