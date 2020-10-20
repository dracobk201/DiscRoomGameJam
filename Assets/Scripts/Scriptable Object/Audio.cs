using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Audio")]
public class Audio : ScriptableObject
{
    public string audioName;
    public List<AudioClip> clips;
    public AudioType type;
    public bool canLoop;
}

public enum AudioType
{
    None, BGM, SFX
}