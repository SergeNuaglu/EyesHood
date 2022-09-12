using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponSwinger : MonoBehaviour
{
    [SerializeField] private float _swingDuration = 2;
    [SerializeField] private float _swingThreshhold = 0.2f;
    [SerializeField] private Slider _swingPowerSlider;

    private float _swingTime;
    private bool _isSwing;

    public float SwingThreshhold => _swingThreshhold;
    public float SwingPower { get; private set; }

    public event UnityAction<float> StoppedSwinging;

    public void Swing()
    {
        _isSwing = true;
    }

    public void ResetSwing()
    {
        float startValue = 0;

        SwingPower = startValue;
        _swingTime = startValue;
        _swingPowerSlider.value = SwingPower;
        _swingPowerSlider.gameObject.SetActive(false);
        _isSwing = false;
    }

    public void StopSwinging()
    {
        StoppedSwinging?.Invoke(SwingPower);
    }

    private void Awake()
    {
        _swingPowerSlider.value = SwingPower;
        _swingPowerSlider.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_isSwing)
        {
            if (SwingPower <= _swingDuration)
            {
                if (SwingPower >= _swingThreshhold)
                    _swingPowerSlider.gameObject.SetActive(true);

                _swingTime += Time.deltaTime;
                SwingPower = _swingTime / _swingDuration;
                _swingPowerSlider.value = SwingPower;
            }
        }
    }
}
