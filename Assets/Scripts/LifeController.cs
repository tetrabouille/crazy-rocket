using System.Linq;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public AudioClip explosionAC;

    private int life = 1;
    private FixedJoint[] joints;
    private Boost[] boosters;
    private GameController gameController;
    private AudioSource audioSource;
    private ParticleSystem explostionParticle;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        joints = gameObject.GetComponentsInChildren<FixedJoint>();
        boosters = gameObject.GetComponentsInChildren<Boost>();
        explostionParticle = gameObject
            .GetComponentsInChildren<ParticleSystem>()
            .Single(x => x.tag == "Explosion");

        gameController = GameObject.FindObjectOfType<GameController>();
    }

    void Update()
    {

    }

    public void Kill()
    {
        foreach (FixedJoint joint in joints) Destroy(joint);
        if (gameController.gameOver) return;
        gameController.InvokeDeath();
        StopAllBoosters();
        audioSource.Stop();
        audioSource.PlayOneShot(explosionAC, 0.6f);
        explostionParticle.Play();
    }

    public void Hit(int power = 1)
    {
        if (life <= 0) return;
        life--;
        if (life <= 0) Kill();
    }

    public void Heal(int power = 1)
    {
        life++;
    }

    public void StopAllBoosters()
    {
        foreach (Boost booster in boosters) booster.Stop();
    }
}
