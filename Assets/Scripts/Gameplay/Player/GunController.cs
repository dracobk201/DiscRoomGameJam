﻿using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private BoolReference DebugMode = null;
    [SerializeField] private BoolReference gunCollected = null;
    [SerializeField] private Animator gunAnimator = null;
    [SerializeField] private BoolReference havingDisc = null;
    [SerializeField] private IntReference remainingDiscs = null;
    [SerializeField] private DiscsRuntimeSet discs = null;
    [SerializeField] private GameEvent playerShot = null;
    [SerializeField] private GameObject gunGameObject = null;
    [SerializeField] private Transform discInitialPosition = null;
    private bool _waitingForLastCall = false;

    private void Awake()
    {
        Cursor.visible = false;
        remainingDiscs.Value = 1;
        havingDisc.Value = true;
        gunAnimator.SetBool("havingDisc", true);
        gunCollected.Value = false;
    }

    private void Update()
    {
        if (DebugMode.Value) return;
        if (gunCollected.Value)
            gunGameObject.SetActive(true);
        else
            gunGameObject.SetActive(false);
    }

    public void ShootDisc()
    {
        if (remainingDiscs.Value <= 0 || !gunCollected.Value || _waitingForLastCall) return;
        gunAnimator.SetTrigger("shoot");
        havingDisc.Value = false;
        _waitingForLastCall = true;
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
                _waitingForLastCall = false;
                if (remainingDiscs.Value <= 0)
                {
                    gunAnimator.SetBool("havingDisc", false);
                }
                playerShot.Raise();
                break;
            }
        }
    }

    public void DiscRetrieved()
    {
        if (remainingDiscs.Value <= 0)
            remainingDiscs.Value++;
        gunAnimator.SetBool("havingDisc", true);
        havingDisc.Value = true;
    }
}
