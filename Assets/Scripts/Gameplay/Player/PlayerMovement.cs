using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2Reference movementAxis = null;
    [SerializeField] private FloatReference moveSpeed = null;
    [SerializeField] private GameEvent playerStepSound = null;
    private float timeForWait;

    private void Start()
    {
        timeForWait = 0.5f;
    }

    public void Move()
    {
        var dualDirectionMultiplier = (movementAxis.Value.x != 0 && movementAxis.Value.y != 0) ? 0.4f : 1;
        float newstraffe = movementAxis.Value.x * moveSpeed.Value * dualDirectionMultiplier * Time.deltaTime;
        float newtranslation = movementAxis.Value.y * moveSpeed.Value * dualDirectionMultiplier * Time.deltaTime;
        transform.Translate(newstraffe, 0, newtranslation);
        timeForWait -= Time.deltaTime;
        if (timeForWait <= 0)
        {
            timeForWait = 0.5f;
            playerStepSound.Raise();
        }
    }
}
