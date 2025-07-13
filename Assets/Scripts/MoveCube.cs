using Unity.VisualScripting;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float offset = 4.0f;
    public float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -offset)
            transform.position = new(-offset, transform.position.y, transform.position.z);

        if (transform.position.x > offset)
            transform.position = new(offset, transform.position.y, transform.position.z);

        if (transform.position.z < -offset)
            transform.position = new(transform.position.x, transform.position.y, -offset);

        if (transform.position.z > offset)
            transform.position = new(transform.position.x, transform.position.y, offset);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0)
            transform.Translate(speed * Time.deltaTime * horizontalInput * Vector3.right);

        if (verticalInput != 0)
            transform.Translate(speed * Time.deltaTime * verticalInput * Vector3.forward);
    }
}
