using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTeleport : MonoBehaviour
{
    [SerializeField] private GameObject placeToTeleport;

    public void Execute() {
        GameObject player =  GameObject.FindGameObjectWithTag("Player");
        player.transform.position = placeToTeleport.transform.position;
        //player.transform.Rotate(Vector3.up * 180);
    }
}
