using UnityEngine;

[System.Serializable]
public class Player
{
    public Rigidbody ball;
    [SerializeField] private Transform camera;
    [SerializeField] private float powerMultiplier = 1;
    public Vector3 direction => Vector3.ProjectOnPlane(camera.forward, Vector3.up);

    public void Fire(float power)
    {
        var force = direction * power * powerMultiplier;
        ball.AddForce(force, ForceMode.Impulse);
    }
}
