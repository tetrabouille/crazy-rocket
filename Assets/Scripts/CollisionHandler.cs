using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private GameController gameController;
    private LifeController lifeController;
    private AudioSource audioSource;

    private void Start()
    {
        lifeController = gameObject.GetComponent<LifeController>();
        gameController = GameObject.FindObjectOfType<GameController>();
        audioSource = gameController.GetComponent<AudioSource>();
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
                audioSource.Stop();
                gameController.InvokeFinish();
                break;
            default:
                lifeController.Hit();
                break;
        }
    }
}
