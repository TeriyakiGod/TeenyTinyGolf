using UnityEngine;

[System.Serializable]
public class Player
{
    public Rigidbody ball;
    [SerializeField] private Transform camera;
    [SerializeField] private float powerMultiplier = 1;
    public Vector3 Direction => Vector3.ProjectOnPlane(ball.transform.forward.normalized, Vector3.up).normalized;

    public void Fire(float power)
    {
        var force = Direction * power * powerMultiplier;
        ball.AddForce(force, ForceMode.Impulse);
    }

    public void Rotate(float amount)
    {
        ball.transform.Rotate(Vector3.up, amount);
    }
}
