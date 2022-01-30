using System.Linq;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private GameController gameController;
    private LifeController lifeController;
    private AudioSource audioSource;
    private ParticleSystem successParticle;

    void Start()
    {
        lifeController = gameObject.GetComponent<LifeController>();
        audioSource = gameObject.GetComponent<AudioSource>();
        successParticle = gameObject
            .GetComponentsInChildren<ParticleSystem>()
            .Single(x => x.tag == "Success");

        gameController = GameObject.FindObjectOfType<GameController>();
    }

    void OnCollisionEnter(Collision other)
    {
        HandleCollision(other);
    }

    public void HandleCollision(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
            case "Propulser":
            case "BoosterRight":
            case "BoosterLeft":
                break;
            case "Finish":
                if (gameController.gameOver) return;
                gameController.InvokeFinish();
                lifeController.StopAllBoosters();
                successParticle.Play();
                audioSource.Stop();
                break;
            default:
                lifeController.Hit();
                break;
        }
    }
}
