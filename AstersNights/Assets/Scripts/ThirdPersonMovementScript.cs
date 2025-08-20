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

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);

            if (!isPlaying)
            {
                SendMessage("Play");
                isPlaying = true;
            }
        }
        else
        {
            if (isPlaying)
            {
                SendMessage("Stop");
                isPlaying = false;
            }
        }
    }
}