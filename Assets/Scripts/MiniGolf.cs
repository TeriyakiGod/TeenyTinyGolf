using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MiniGolf : MonoBehaviour
{
    
    private Input input;
    [SerializeField] private InputSettings inputSettings = new();

    [SerializeField] private AudioController audioController;
    
    [SerializeField] private Player player = new();
    [SerializeField] private Guide guide = new();
        
    private int[] score = new int[18];
    [SerializeField] private TextMeshProUGUI scoreDisplay;

    [SerializeField] private PowerBar powerBar;
    
    private Vector2 MouseDelta => input.Player.Look.ReadValue<Vector2>() * inputSettings.mouseSensitivity;
    
    private bool charging;
    private bool aiming;
    
    private int currentHole;
    
    public Vector3 startPosition;
    
    public Transform hole;
    public void Start()
    {
        input = new Input();
        input.Enable();
        input.Player.Fire.started += Ready;
        input.Player.Fire.canceled += Fire;
        input.Player.Aim.started += Aim;
        input.Player.Aim.canceled += StopAim;
        input.Player.Reset.performed += _ => Reset();
        LockCursor();
        startPosition = player.ball.position;
    }
    
    public void Reset()
    {
        player.ball.position = startPosition;
        player.ball.velocity = Vector3.zero;
        player.ball.angularVelocity = Vector3.zero;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Ready(InputAction.CallbackContext context)
    {
        if (player.ball.velocity.magnitude < .05f)
        {
            aiming = false;
            Charge();
        }
    }
    
    public void Fire(InputAction.CallbackContext context)
    {
        if (charging == false) return;
        charging = false;
        player.Fire(powerBar.Value);
        audioController.PlayPuttSound();
        score[currentHole]++;
        scoreDisplay.text = "Score: "+score[currentHole];
        powerBar.Value = 0;
        guide.Clear();
    }
    public void Aim(InputAction.CallbackContext context)
    {
        if (player.ball.velocity.magnitude < .05f)
        {
            DrawGuide();
        }
    }
    public void StopAim(InputAction.CallbackContext context)
    {
        aiming = false;
    }
    
    private async void Charge()
    {
        charging = true;
        var t = 0f;
        while (charging)
        {
            powerBar.Value = Mathf.Pow((Mathf.Sin(Mathf.PI*t-Mathf.PI/2f)+1f)/2f, 2);
            t += .003f;
            await Task.Yield();
        }
    }

    private async void DrawGuide()
    {
        aiming = true;
        while (aiming)
        {
            guide.Draw(player.ball.position, player.Direction);
            player.Rotate(MouseDelta.x);
            await Task.Yield();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene($"Hole ({++currentHole})");
    }
}