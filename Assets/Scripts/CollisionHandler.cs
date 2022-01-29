using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private GameController gameController;
    private LifeController lifeController;
    private AudioSource audioSource;

    private void Start()
    {
        lifeController = gameObject.GetComponent<LifeController>();
        audioSource = gameObject.GetComponent<AudioSource>();

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
                audioSource.Stop();
                break;
            default:
                lifeController.Hit();
                break;
        }
    }
}
