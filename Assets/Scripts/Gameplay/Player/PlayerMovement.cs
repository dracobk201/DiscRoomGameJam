using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2Reference movementAxis = null;
    [SerializeField] private FloatReference moveSpeed = null;
    [SerializeField] private GameEvent playerStepSound = null;
    [SerializeField] private Rigidbody playerRigigbody = null;
    private float _timeForWait;

    private void Start()
    {
        _timeForWait = 0.5f;
    }

    public void Move()
    {
        var dualDirectionMultiplier = (movementAxis.Value.x != 0 && movementAxis.Value.y != 0) ? 0.4f : 1;
        float newstraffe = movementAxis.Value.x * moveSpeed.Value * dualDirectionMultiplier * Time.deltaTime;
        float newtranslation = movementAxis.Value.y * moveSpeed.Value * dualDirectionMultiplier * Time.deltaTime;
        var moveDirection = transform.TransformDirection(new Vector3(newstraffe, 0, newtranslation));
        playerRigigbody.MovePosition(moveDirection + transform.position);
        _timeForWait -= Time.deltaTime;
        if (_timeForWait <= 0)
        {
            _timeForWait = 0.5f;
            playerStepSound.Raise();
        }
    }
}
