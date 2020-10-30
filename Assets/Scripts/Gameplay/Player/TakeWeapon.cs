using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapon : MonoBehaviour
{
    [SerializeField] private GameEvent onWeaponTaken;
    private void OnTriggerEnter(Collider other) {
        gameObject.SetActive(false);
        onWeaponTaken.Raise();
    }
}
