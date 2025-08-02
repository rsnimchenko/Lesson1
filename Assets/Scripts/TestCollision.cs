using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Enter collision with {collision.gameObject.name}");
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log($"Exit collision with {collision.gameObject.name}");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Enter trigger with {other.gameObject.name}");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log($"Exit trigger with {other.gameObject.name}");
    }
}
