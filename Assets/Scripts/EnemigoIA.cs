using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    enum EstadoEnemigo
    {
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
        Ray rayo = new Ray(
            transform.position + new Vector3(0, 1, 0) + transform.forward,
            transform.forward
        );

        RaycastHit hit;
        bool colisionPared = Physics.SphereCast(
            rayo,
            0.2f,
            out hit,
            LayerMask.GetMask("Enemy"));

        if (!colisionPared){
            Vector3 reflexionPared = Vector3.Reflect(transform.forward,hit.normal); 
            
            Debug.DrawLine(transform.position, hit.point, Color.red);
            Debug.DrawLine(hit.point, hit.normal, Color.blue);
            Debug.DrawLine(hit.point, reflexionPared, Color.white);
        }

        // --------------------------------------------
        switch (estado)
        {
            case EstadoEnemigo.Andando:
                Debug.Log("Se mueve");
                characterController.Move(transform.forward * speed * Time.deltaTime);
                IniciarAnimacion();
                break;
            case EstadoEnemigo.Parado:
                characterController.Move(Vector3.zero);
                PararAnimacion();
                break;
        }

    }

    private void IniciarAnimacion()
    {
        estado = EstadoEnemigo.Andando;
        foreach (RotadorExtremidades rotador in rotadores)
        {
            rotador.IniciarAnimacion();
        }
    }

    private void PararAnimacion()
    {
        estado = EstadoEnemigo.Parado;
        foreach (RotadorExtremidades rotador in rotadores)
        {
            rotador.PararAnimacion();
        }
    }
}
