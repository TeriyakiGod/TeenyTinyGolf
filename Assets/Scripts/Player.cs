using UnityEngine;

[System.Serializable]
public class Player
{
    [SerializeField] private Rigidbody ball;
    [SerializeField] private Transform camera;
    [SerializeField] private float powerMultiplier = 1;

    public void Fire(float power)
    {
        var force = camera.forward * power * powerMultiplier;
        ball.AddForce(force, ForceMode.Impulse);
    }
}
