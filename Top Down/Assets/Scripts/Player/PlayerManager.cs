using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerLocomotionManager playerLocomotionManager;
    public PlayerCamera playerCamera;
    public PlayerInputManager playerInputManager;
    public Rigidbody2D rb;

    private void Awake()
    {
        playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInputManager = GetComponent<PlayerInputManager>();
        playerCamera = GameObject.Find("CameraHolder").GetComponent<PlayerCamera>();
    }
}
