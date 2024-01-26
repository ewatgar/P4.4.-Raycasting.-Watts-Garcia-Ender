using UnityEngine;

public class RotacionX : MonoBehaviour
{

    [SerializeField] private float _velocidad = 30;
    private float _anguloTotal = 0;

    void Start()
    {
        
    }

    void Update()
    {
        _anguloTotal += _velocidad * Time.deltaTime;
        _velocidad = _anguloTotal >= 50 || _anguloTotal <= -50 ? -_velocidad : _velocidad;
        transform.Rotate(_velocidad * Time.deltaTime, 0, 0, Space.Self);
        
    }
}
