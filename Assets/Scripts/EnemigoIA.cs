using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    enum EstadoEnemigo{
        Parado = 0,
        Andando = 1
    }

    EstadoEnemigo estado = EstadoEnemigo.Parado;
    private RotadorExtremidades[] rotadores;
    private CharacterController characterController;
    public float speed = 5;

    void Start()
    {
        rotadores = GetComponentsInChildren<RotadorExtremidades>();
        IniciarAnimacion();
    }

    void Update()
    {
        switch (estado){
            case EstadoEnemigo.Andando:
                transform.Translate(Vector3.forward*speed*Time.deltaTime);
                break;
            case EstadoEnemigo.Parado:
                transform.Translate(Vector3.zero);
                break;
        }
    }

    /*
    private void Andando(){
        characterController.Move(transform.TransformDirection(new Vector3(
            0,
            0,
            1
        ) * 1 * Time.deltaTime));
    }

    private void Parado(){
        characterController.Move(Vector3.zero);
    }*/

    private void IniciarAnimacion(){
        estado = EstadoEnemigo.Andando;
        foreach (RotadorExtremidades rotador in rotadores){
            rotador.IniciarAnimacion();
        }
    }

    private void PararAnimacion(){
        estado = EstadoEnemigo.Parado;
        foreach (RotadorExtremidades rotador in rotadores){
            rotador.PararAnimacion();
        }
    }
}
