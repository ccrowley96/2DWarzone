using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun.Demo.PunBasics;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]

    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;

    void Start(){
        CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();
        cam = Camera.main;

        if (_cameraWork != null)
        {
            if (photonView.IsMine)
            {
                _cameraWork.OnStartFollowing();
            }
        }
        else
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Break out of controller if not accessing local movement
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        
        Vector2 lookDir = mousePos - rb.position; // Using this to find the angle to shoot at.
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
