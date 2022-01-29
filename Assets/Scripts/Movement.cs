using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float gravityForce = 4;

    private Boost[] rightBoosters;
    private Boost[] leftBoosters;
    private Boost propulser;
    private CoreController coreController;
    private AudioSource audioSource;
    private GameController gameController;

    void Start()
    {
        List<Boost> boosters = gameObject.GetComponentsInChildren<Boost>().ToList();
        audioSource = gameObject.GetComponent<AudioSource>();
        gameController = GameObject.FindObjectOfType<GameController>();
        coreController = gameObject.GetComponentInChildren<CoreController>();

        propulser = boosters.Single(x => x.tag == "Propulser");
        leftBoosters = boosters.Where(x => x.tag == "BoosterLeft").ToArray();
        rightBoosters = boosters.Where(x => x.tag == "BoosterRight").ToArray();

        Physics.gravity = Vector3.down * gravityForce;
    }

    void Update()
    {
        if (gameController.gameOver) return;

        ProcessBoost();
        ProcessRotation();
    }

    void ProcessBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            propulser.Fire();
            if (!audioSource.isPlaying) audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }

    }

    void ProcessRotation()
    {
        Boost[] boosters = null;

        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.D)) coreController.ResetRotation();

        if (Input.GetKey(KeyCode.Q)) boosters = leftBoosters;
        else if (Input.GetKey(KeyCode.D)) boosters = rightBoosters;

        if (boosters == null) return;
        foreach (Boost booster in boosters)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D)) booster.Kick();
            else booster.Fire();
        }
    }
}
