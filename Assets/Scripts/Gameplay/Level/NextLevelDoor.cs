using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelDoor : MonoBehaviour
{
    public List<Light> lights;
    public Color openColor;
    public Color closedColor;
    public GameObject door;
    public AudioClip doorAudio;
    public AudioSource doorSource;

    [ContextMenu("OpenDoor")]
    public void OpenDoor()
    {
        lights.ForEach(light => light.color = openColor);
        door.SetActive(false);
        doorSource.PlayOneShot(doorAudio);
    }

    [ContextMenu("CloseDoor")]
    public void CloseDoor()
    {
        lights.ForEach(light => light.color = closedColor);
        door.SetActive(true);
    }
}
