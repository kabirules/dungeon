using UnityEngine;
using System.Collections;

public class CameraPlayerController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        offset = transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = player.transform.position + offset;

    }
}