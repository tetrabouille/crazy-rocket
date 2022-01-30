using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioClip successAC;
    public bool gameOver { get { return _gameOver; } }
    public bool disableCollisions { get { return _disableCollisions; } }

    private bool _gameOver = false;
    private bool _disableCollisions = false;
    private static float restartDelay = 1.5f;
    private static float nextLevelDelay = 2.8f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessKey();
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void NextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings <= nextIndex) nextIndex = 0;
        SceneManager.LoadScene(nextIndex);
    }

    void ToggleCollisions()
    {
        _disableCollisions = !disableCollisions;
    }

    void ProcessKey()
    {
        if (Input.GetKeyDown(KeyCode.L)) NextLevel();
        if (Input.GetKeyDown(KeyCode.R)) RestartLevel();
        if (Input.GetKeyDown(KeyCode.C)) ToggleCollisions();
    }

    public void InvokeDeath()
    {
        if (_gameOver) return;
        _gameOver = true;
        Invoke("RestartLevel", restartDelay);
    }

    public void InvokeFinish()
    {
        if (_gameOver) return;
        audioSource.PlayOneShot(successAC, 0.7f);
        _gameOver = true;
        Invoke("NextLevel", nextLevelDelay);
    }
}
