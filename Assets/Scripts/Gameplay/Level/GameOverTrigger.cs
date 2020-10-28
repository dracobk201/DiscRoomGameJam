using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent onGameOver;
    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Asteroid")) {
            Debug.Log("Murio Toh");
            onGameOver.Raise();
            //TODO GAMEOVER
        }
    }
    
}
