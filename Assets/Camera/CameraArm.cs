using UnityEngine;
using System.Collections;

public class CameraArm : MonoBehaviour {

    public float panSpeed = 10f;

    private GameObject target;
    private Vector3 armRotation;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
        //target = GameObject.FindObjectOfType<Player>().transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        armRotation.y += Input.GetAxis("RHoriz") * panSpeed * Time.deltaTime;
        armRotation.z += Input.GetAxis("RVert") * panSpeed * Time.deltaTime;
        transform.position = target.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);

        Debug.Log("RVert: " + Input.GetAxis("RVert"));
	}

}
