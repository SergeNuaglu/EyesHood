using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    protected void OnValueChanged(int value, int maxValue)
    {
        _slider.value = (float)value / maxValue;
    }
}
