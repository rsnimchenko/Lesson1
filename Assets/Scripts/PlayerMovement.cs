using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;
    private float offset = 4.0f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -offset)
            transform.position = new(-offset, transform.position.y, transform.position.z);

        if (transform.position.x > offset)
            transform.position = new(offset, transform.position.y, transform.position.z);

        if (transform.position.z < -offset)
            transform.position = new(transform.position.x, transform.position.y, -offset);

        if (transform.position.z > offset)
            transform.position = new(transform.position.x, transform.position.y, offset);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 horizontalVector = movementSpeed * Time.deltaTime * horizontalInput * Vector3.right;
        Vector3 verticalVector = movementSpeed * Time.deltaTime * verticalInput * Vector3.forward;
        transform.Translate(horizontalVector + verticalVector);
    }
}
