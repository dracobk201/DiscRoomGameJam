using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimatorBool : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string boolPropertyName;

    public void Execute(bool value)
    {
        animator.SetBool(boolPropertyName, value);
    }

}
