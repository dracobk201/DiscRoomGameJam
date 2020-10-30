﻿using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private BoolReference DebugMode = null;
    [SerializeField] private Animator gunAnimator = null;
    [SerializeField] private BoolReference havingDisc = null;
    [SerializeField] private IntReference remainingDiscs = null;
    [SerializeField] private DiscsRuntimeSet discs = null;
    [SerializeField] private GameEvent playerShot = null;
    [SerializeField] private Transform discInitialPosition = null;

    private void Awake()
    {
        Cursor.visible = false;
        remainingDiscs.Value = 1;
        havingDisc.Value = true;
        gunAnimator.SetBool("havingDisc", true);
    }

    public void ShootDisc()
    {
        if (remainingDiscs.Value <= 0 && !DebugMode.Value) return;
        gunAnimator.SetTrigger("shoot");
        Invoke(nameof(ReleaseDisc), 0.6f);
    }

    private void ReleaseDisc()
    {
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
                if (remainingDiscs.Value <= 0)
                {
                    gunAnimator.SetBool("havingDisc", false);
                    havingDisc.Value = false;
                }
                playerShot.Raise();
                break;
            }
        }
    }

    public void DiscRetrieved()
    {
        remainingDiscs.Value++;
        gunAnimator.SetBool("havingDisc", true);
        havingDisc.Value = true;
    }
}
