using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2Reference movementAxis = null;
    [SerializeField] private FloatReference moveSpeed = null;

    public void Move()
    {
        var dualDirectionMultiplier = (movementAxis.Value.x != 0 && movementAxis.Value.y != 0) ? 0.4f : 1;
        float newstraffe = movementAxis.Value.x * moveSpeed.Value * dualDirectionMultiplier * Time.deltaTime;
        float newtranslation = movementAxis.Value.y * moveSpeed.Value * dualDirectionMultiplier * Time.deltaTime;
        transform.Translate(newstraffe, 0, newtranslation);
    }
}
