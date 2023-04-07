using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGolf : MonoBehaviour
{
    private Input input;
    [SerializeField] private InputSettings inputSettings = new();
    
    private Vector2 MouseDelta => input.Player.Look.ReadValue<Vector2>() * inputSettings.mouseSensitivity;
    [SerializeField] private Player player = new Player();

    private bool isReady = false;

    private Task charge;
    [SerializeField] private PowerBar powerBar;
    public void Start()
    {
        input = new Input();
        input.Enable();
        input.Player.Fire.started += Ready;
        input.Player.Fire.canceled += Fire;
        LockCursor();
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Ready(InputAction.CallbackContext context)
    {
        powerBar.Value = 0;
        isReady = true;
        charge = Charge();
    }
    
    public void Fire(InputAction.CallbackContext context)
    {
        isReady = false;
        player.Fire(powerBar.Value);
    }
    
    private async Task Charge()
    {
        var t = 0f;
        while (isReady)
        {
            powerBar.Value = (Mathf.Sin(Mathf.PI*t-Mathf.PI/2)+1)/2;
            t += .01f;
            await Task.Delay(1);
        }
    }
}