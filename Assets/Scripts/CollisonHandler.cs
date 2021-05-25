
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisonHandler : MonoBehaviour

{
    [SerializeField] float reloadLevelDelay = 1f;
    [SerializeField] float loadNextLevelDelay = 6f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {



        switch (collision.gameObject.tag)
        {
            case "Friendly":
                
                
                break;
            
            case "Finish":
                StartNextLevelSequence();
                Debug.Log("LANDING PAD");
                break;

            default:
                StartCrashSequence();
                Debug.Log("CRASH");
                break;
        }
    }

    
    void StartCrashSequence()
    {
        audioSource.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", reloadLevelDelay);
    }

    void StartNextLevelSequence()
    {
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", loadNextLevelDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

        Debug.Log("You hit the finish area.");
        
    }
}
