using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;

public class ThirdPersonMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;

    private bool isPlaying = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("IsMoving", true);
            controller.Move(direction * speed * Time.deltaTime);

            if (!isPlaying)
            {
                SendMessage("Play");
                isPlaying = true;
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
            if (isPlaying)
            {
                SendMessage("Stop");
                isPlaying = false;
            }
        }
    }
}