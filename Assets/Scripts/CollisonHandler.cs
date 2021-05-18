
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You collided with RESPAWN");
                break;

            case "Fuel":
                Debug.Log("You collieded with FUEL");
                break;
            
            case "Finish":
                Debug.Log("You collieded with FINISH");
                break;

            default:
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
