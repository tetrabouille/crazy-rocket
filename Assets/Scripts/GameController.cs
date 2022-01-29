using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioClip successAC;
    private bool _gameOver = false;
    public bool gameOver { get { return _gameOver; } }
    private static float restartDelay = 1.5f;
    private static float nextLevelDelay = 2.8f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    void OnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnSucess()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings <= nextIndex) nextIndex = 0;
        SceneManager.LoadScene(nextIndex);
    }

    public void InvokeDeath()
    {
        if (_gameOver) return;
        _gameOver = true;
        Invoke("OnDeath", restartDelay);
    }

    public void InvokeFinish()
    {
        if (_gameOver) return;
        audioSource.PlayOneShot(successAC, 0.7f);
        _gameOver = true;
        Invoke("OnSucess", nextLevelDelay);
    }
}
