using System;
using UnityEngine;

public class RotadorExtremidades : MonoBehaviour
{
    public float angMinimo = -30;
    public float angMaximo = 30;
    public float vAngular = 150;
    public float direccion = 1;
    private float anguloTotal = 0;
    private Boolean isWalking = false;

    void Start()
    {
        
    }


    void Update()
    {
        isWalking = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        if (isWalking){
            IniciarAnimacion();
        } else{
            PararAnimacion();
        }
    }

    private void IniciarAnimacion()
    {
        if (isWalking){
            if (anguloTotal >= angMaximo || anguloTotal <= angMinimo){
                direccion *= -1;
                anguloTotal = Mathf.Clamp(anguloTotal,angMinimo,angMaximo);
            }

            float angulo = vAngular * Time.deltaTime;
            anguloTotal += direccion*angulo;
        } else{
            anguloTotal = 0;
        }

        transform.localEulerAngles = new Vector3(anguloTotal,0,0);
    }

    private void PararAnimacion(){
        transform.localEulerAngles = Vector3.zero;
    }
}
