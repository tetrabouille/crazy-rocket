using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public AudioClip explosionAC;
    private int life = 1;
    private FixedJoint[] joints;
    private GameController gameController;
    private AudioSource audioSource;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        audioSource = gameObject.GetComponent<AudioSource>();
        joints = gameObject.GetComponentsInChildren<FixedJoint>();
    }

    void Update()
    {

    }

    public void Kill()
    {
        foreach (FixedJoint joint in joints) Destroy(joint);
        if (gameController.gameOver) return;
        gameController.InvokeDeath();
        audioSource.Stop();
        audioSource.PlayOneShot(explosionAC, 0.7f);
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
}
