using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float force = 1;
    public float kick = 100;
    public Vector3 direction = Vector3.zero;

    private Rigidbody rb;
    private Rigidbody parentRb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        parentRb = gameObject.GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire()
    {
        rb.AddRelativeForce(direction * force * Time.deltaTime);
    }

    public void Kick()
    {
        parentRb.angularVelocity = Vector3.zero;
        rb.AddRelativeForce(direction * force * kick * Time.deltaTime);
    }
}
