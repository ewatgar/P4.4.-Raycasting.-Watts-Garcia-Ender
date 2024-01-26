using UnityEngine;

public class RotadorCabeza : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 direccionPersonaje = transform.parent.forward;
        Vector3 direccionFirstPerson = (target.transform.position - transform.position).normalized;
        float prodEscalarCampoVision = Vector3.Dot(direccionPersonaje,direccionFirstPerson);
        if (prodEscalarCampoVision > 0.3f){
            transform.LookAt(target.transform);
        } else{
            transform.localEulerAngles = new Vector3(direccionPersonaje.x,0,0);
            /*
            Quaternion startRotation = Quaternion.LookRotation(direccionFirstPerson);
            Quaternion endRotation = Quaternion.LookRotation(direccionPersonaje);
            Quaternion smoothAnimation = Quaternion.Slerp(startRotation,endRotation,0.5f);
            transform.rotation = smoothAnimation;*/
        }

    }
}
