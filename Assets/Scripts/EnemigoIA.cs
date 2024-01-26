
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    enum EstadoEnemigo{
        Parado = 0,
        Andando = 1
    }

    EstadoEnemigo estado;
    private RotadorExtremidades[] rotadores;
    private CharacterController characterController;
    public float speed = 2;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotadores = GetComponentsInChildren<RotadorExtremidades>();
        IniciarAnimacion();
    }

    void Update()
    {
        switch (estado){
            case EstadoEnemigo.Andando:
                Debug.Log("Se mueve");
                characterController.Move(Vector3.forward*speed*Time.deltaTime);
                IniciarAnimacion();
                break;
            case EstadoEnemigo.Parado:
                characterController.Move(Vector3.zero);
                PararAnimacion();
                break;
        }
    }

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
