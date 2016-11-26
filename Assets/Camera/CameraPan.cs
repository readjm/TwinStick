using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {

    private  GameObject target;

    // Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        //target = GameObject.FindObjectOfType<Player>().transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void LateUpdate()
    {
        transform.LookAt(target.transform);
    }
}
