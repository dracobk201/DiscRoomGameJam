using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyRuntimeSet enemies = null;
    [SerializeField] private Animator animator;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        enemies.Add(gameObject);
    }

    private void OnDisable()
    {
        enemies.Remove(gameObject);
    }

    private void Update()
    {
        float yClamped = Global.Clamp0360(_camera.transform.eulerAngles.y);
        animator.SetFloat("currentAngle", Global.Clamp0360(yClamped - transform.eulerAngles.y) / 360);
    }
}
