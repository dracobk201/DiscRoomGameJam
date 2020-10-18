using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private DiscsRuntimeSet discs = null;
    [SerializeField] private IntReference remainingDiscs = null;
    [SerializeField] private GameEvent playerShot = null;
    [SerializeField] private Transform discInitialPosition = null;

    public void ShootDisc()
    {
        if (remainingDiscs.Value > 0) return;

        var initialPosition = discInitialPosition.position;
        var initialRotation = discInitialPosition.rotation;

        for (int i = 0; i < discs.Items.Count; i++)
        {
            if (!discs.Items[i].activeInHierarchy)
            {
                discs.Items[i].transform.localPosition = initialPosition;
                discs.Items[i].transform.localRotation = initialRotation;
                discs.Items[i].SetActive(true);
                remainingDiscs.Value--;
                playerShot.Raise();
                break;
            }
        }
    }
}
