using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    [SerializeField] float distance = 20f;

    private void Awake()
    {
        cam = gameObject.GetComponentInChildren<Camera>();
        cam.orthographicSize = distance;
    }

    private void Start()
    {
        
        CameraShake.instance.mCam.m_Lens.OrthographicSize = distance;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        transform.position = player.transform.position;
    }

}
