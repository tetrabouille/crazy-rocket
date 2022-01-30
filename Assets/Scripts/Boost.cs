using UnityEngine;

public class Boost : MonoBehaviour
{
    public float force = 1;
    public float kick = 100;
    public Vector3 direction = Vector3.zero;

    private Rigidbody rb;
    private ParticleSystem boostParticle;
    private Rigidbody parentRb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        boostParticle = gameObject.GetComponent<ParticleSystem>();
        parentRb = gameObject.GetComponentInParent<Rigidbody>();
    }

    void Update()
    {

    }

    public void Fire()
    {
        if (!boostParticle.isPlaying) boostParticle.Play();
        rb.AddRelativeForce(direction * force * Time.deltaTime);
    }

    public void Stop()
    {
        boostParticle.Stop();
    }

    public void Kick()
    {
        parentRb.angularVelocity = Vector3.zero;
        rb.AddRelativeForce(direction * force * kick * Time.deltaTime);
    }
}
