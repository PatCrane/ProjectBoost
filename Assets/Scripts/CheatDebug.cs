using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatDebug : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AutoLoadNextLevel();

    }

    public void AutoLoadNextLevel()
    {
        if (Input.GetKey(KeyCode.L))
        {
            SceneHelper.LoadNextLevel();
        }
    }
    
}
