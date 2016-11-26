using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool isRecording = true;

    private bool isPaused = false;
    private float fixedDeltaTime;

    void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

	// Update is called once per frame
	void Update ()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            isRecording = false;
        }
        else
        {
            isRecording = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            PauseGame();
        }
	}

    void PauseGame()
    {
        if (isPaused == true)
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        }
        else
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = fixedDeltaTime;
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
        PauseGame();
        
    }
}
