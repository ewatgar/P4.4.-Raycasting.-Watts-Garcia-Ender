using System;
using UnityEngine;

public class RotadorExtremidades : MonoBehaviour
{
    [SerializeField] public float angMinimo = -30;
    [SerializeField] public float angMaximo = 30;
    [SerializeField] public float vAngular = 150;
    [SerializeField] public float direccion = 1;

    private float anguloTotal = 0;
    private Boolean isWalking = false;



    void Start()
    {
        
    }


    void Update()
    {
        isWalking = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        WalkAnimation(isWalking);
    }

    private void WalkAnimation(bool isWalking)
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
}
