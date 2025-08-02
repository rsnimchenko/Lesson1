using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private Rigidbody _rb;
    private bool _startMoving = false;
    private float _jumpForce = 50.0f;
    private float _jumpSpeed = 5.0f;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _startMoving = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _startMoving = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
    }

    void FixedUpdate()
    {
        if (_rb != null && _startMoving)
        {
            Debug.Log("Jump");
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Force);
        }
    }

    private void MoveUp()
    {
        if (_rb != null) return;
        if (_startMoving)
        {
            transform.Translate(Vector3.up * Time.deltaTime * _jumpSpeed);
        }
        else if (transform.position.y > 0.5)
        {
            transform.Translate(Vector3.down * Time.deltaTime * _jumpSpeed);
        }
    }
}
