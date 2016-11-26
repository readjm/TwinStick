using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour
{
    private const int BUFFER_SIZE = 600;

    private MyKeyFrame[] keyFrames;
    private Rigidbody rigidBody;
    private GameManager gameManager;

	// Use this for initialization
	void Start ()
    {
        keyFrames = new MyKeyFrame[BUFFER_SIZE];
        //for (int i = 0; i < keyFrames.Length; i++)
        //{
        //    keyFrames[i] = new MyKeyFrame(0f, Vector3.zero, Quaternion.identity);
        //}

        rigidBody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameManager.isRecording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
	}

    void PlayBack()
    {
        rigidBody.isKinematic = true;
        transform.position = keyFrames[Time.frameCount % BUFFER_SIZE].position;
        transform.rotation = keyFrames[Time.frameCount % BUFFER_SIZE].rotation;
    }

    void Record()
    {
        rigidBody.isKinematic = false;
        keyFrames[Time.frameCount % BUFFER_SIZE] = new MyKeyFrame(Time.time, rigidBody.transform.position, rigidBody.transform.rotation);
    }
}

public struct MyKeyFrame
{
    public float time;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float t, Vector3 pos, Quaternion rot)
    {
        time = t;
        position = pos;
        rotation = rot;
    }

    public void Set(float t, Vector3 pos, Quaternion rot)
    {
        time = t;
        position = pos;
        rotation = rot;
    }
}
