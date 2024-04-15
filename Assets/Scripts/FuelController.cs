using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{ 
    public static FuelController instanceFC;

    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 2f;
    [SerializeField] private float _maxFuelAmount = 100f;
    [SerializeField] private Gradient _fuelGradient;

    private float _currentFuelAmount;

    private void Awake()
    {
        if (instanceFC == null)
        {
            instanceFC = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUi();    
    }

    // Update is called once per frame
    void Update()
    {
        _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
        UpdateUi();

        if (_currentFuelAmount <= 0f)
        {
            GameManager.instanceGM.GameOver();
        }
    }

    private void UpdateUi()
    {
        _fuelImage.fillAmount = (_currentFuelAmount / _maxFuelAmount);
        _fuelImage.color = _fuelGradient.Evaluate(_fuelImage.fillAmount);
    }

    public void FillFuel()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUi();
    }
}
