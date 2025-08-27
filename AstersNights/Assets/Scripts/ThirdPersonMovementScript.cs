using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class ThirdPersonMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;

    private bool isPlaying = false;
    private Animator animator;

    private EventInstance footstepInstance;

    void Start()
    {
        animator = GetComponent<Animator>();
        footstepInstance = RuntimeManager.CreateInstance("event:/Aster/footsteps");
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
                footstepInstance.start();
                isPlaying = true;
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
            if (isPlaying)
            {
                footstepInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                isPlaying = false;
            }
        }
    }

    void OnDestroy()
    {
        // Release the FMOD instance when object is destroyed
        footstepInstance.release();
    }
}