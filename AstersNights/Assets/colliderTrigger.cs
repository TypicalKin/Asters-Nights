using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODTrigger : MonoBehaviour
{
    [EventRef]
    public string fmodEventPath;  // Set this in the Inspector, e.g. "event:/Aster/vox/Aster_joy"

    private EventInstance fmodEventInstance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Create the event instance
            fmodEventInstance = RuntimeManager.CreateInstance(fmodEventPath);
            fmodEventInstance.start();
            fmodEventInstance.release(); // Optional: release if you don’t need to stop it manually
        }
    }
}

