using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public FloatVariable asteroidSpeed;
    public FloatVariable levelChangeOffset;
    public Rigidbody asteroidRigidbody;
    private Vector3 currentPosition;
    private float currentSpeed;
    [SerializeField] private FloatVariable distance;

    void Start()
    {
        currentPosition = transform.position;
        asteroidRigidbody.velocity = Vector3.down * asteroidSpeed.value;
        currentSpeed = asteroidSpeed.value;
    }

    private void Update() {
        distance.value = transform.position.y;
    }

    public void OffsetChange() {
        currentPosition.y += levelChangeOffset.value;
        transform.position = currentPosition;
        currentSpeed += asteroidSpeed.value;
        asteroidRigidbody.velocity = Vector3.down * currentSpeed;
    }
}
