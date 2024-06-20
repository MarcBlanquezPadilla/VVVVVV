using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [Header("PROPERTIES")]
    [SerializeField] private float defaultSpeed;
    [SerializeField] private float defaultJumpSpeed;

    [Header("INFORMATION")]
    [SerializeField] private float alpha;
    [SerializeField] private float currentSpeed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        SetDefaultVelocity();
    }

    public void Move(Vector3 direction)
    {
        transform.position = transform.position + direction * currentSpeed * Time.deltaTime;
    }

    public void MoveRB(Vector3 direction)
    {
        _rb.MovePosition(transform.position + direction * currentSpeed * Time.fixedDeltaTime);
    }

    public void MoveVelocity(Vector3 direction)
    {
        direction = new Vector3 (direction.x * currentSpeed, direction.y, direction.z);
        _rb.velocity = direction;
    }

    public void RotatePoints(float a, float b)
    {
        alpha = Mathf.Atan2(b, a) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, alpha);
    }

    public void RotateAngle(float alpha)
    {
        float degrees = alpha * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degrees);
    }
    public void RotateVector(Vector3 vector)
    {
        float angle = Mathf.Atan2(vector.y, vector.x);
        angle *= Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void Freeze()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void FreezeRotation()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void FreezePosition()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void SetVelocity(float s)
    {
        currentSpeed = s;
    }

    public void SetDefaultVelocity()
    {
        currentSpeed = defaultSpeed;
    }
}
