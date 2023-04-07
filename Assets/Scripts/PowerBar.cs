using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    private float value;

    public float Value
    {
        get => value;
        set
        {
            this.value = Mathf.Clamp(value, minValue, maxValue);
            bar.transform.localScale = new Vector3(1, this.value, 1);
            //Color the bar based on the value
            //use a gradient
            bar.color = Color.Lerp(Color.red, Color.green, this.value);
        }
    }
    private float maxValue = 1;
    private float minValue = 0;
    
    [SerializeField] private Image bar;
}
