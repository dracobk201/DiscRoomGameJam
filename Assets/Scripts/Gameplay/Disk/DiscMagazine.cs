using UnityEngine;

public class DiscMagazine : MonoBehaviour
{
    [SerializeField] private DiscsRuntimeSet playerDiscs = null;
    [SerializeField] private IntReference discPool = null;
    [SerializeField] private GameObject discPrefab = null;

    private void Awake()
    {
        playerDiscs.Items.Clear();
        InstantiateDiscs();
    }

    private void InstantiateDiscs()
    {
        for (int i = 0; i < discPool.Value; i++)
        {
            GameObject disc = Instantiate(discPrefab) as GameObject;
            disc.GetComponent<Transform>().SetParent(transform);
            disc.SetActive(false);
            playerDiscs.Add(disc);
        }
    }
}
