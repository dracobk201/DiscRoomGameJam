using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPlayer : MonoBehaviour
{
    private bool repelActive = false;
    private float cooldownTime = 0f;
    [SerializeField] private FloatVariable currentSpeed = null;
    [SerializeField] private Vector3 currentDirection;
    [SerializeField] private Vector3 randomNess;
    [SerializeField] private Transform objectToAvoid = null;
    [SerializeField] private Rigidbody enemyRigidbody = null;
    [SerializeField] private FloatVariable cooldownTimeVariable = null;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = (TryGetComponent(out Rigidbody rigidbodyResult)) ? rigidbodyResult : gameObject.AddComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cooldownTime > 0)
        {
            currentDirection = (transform.position - objectToAvoid.position).normalized;
            currentDirection.y = 0;
            //TODO configmar si vamso a querer este comportamiento
            //currentDirection.x *= randomNess.x;
            //currentDirection.y *= randomNess.y;
            cooldownTime -= Time.deltaTime;
        }
        else
        {
            currentDirection = Vector3.zero;
        }

        enemyRigidbody.velocity = currentDirection * currentSpeed.value;

    }

    public void alert(Transform objectToAvoid)
    {
        cooldownTime = cooldownTimeVariable.value;
        if (!this.objectToAvoid.Equals(objectToAvoid))
        { 
            AddRandomNess();
        }
        this.objectToAvoid = objectToAvoid;
        this.repelActive = true;
    }

    private void AddRandomNess()
    {
        //TODO transformar estos numeros magicos para que sea comprensible (le dan la aletoriedad al movimiento)
        randomNess.Random(-Vector3.one, Vector3.one);
        randomNess.y = 0;
        randomNess *= Random.Range(1, 3);
    }
}
