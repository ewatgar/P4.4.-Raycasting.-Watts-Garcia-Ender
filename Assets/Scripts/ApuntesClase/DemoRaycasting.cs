using UnityEngine;

public class DemoRaycasting : MonoBehaviour
{
    RaycastHit hit;
    //Vector3 hitPoint;

    void Start()
    {

    }

    void Update()
    {
        Ray r = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(r, out hit)){
            Debug.DrawLine(transform.position, hit.point);
            Debug.DrawRay(hit.point, transform.forward, Color.blue);

            Vector3 reflejo = Vector3.Reflect(transform.forward, hit.normal);
            Debug.DrawRay(hit.point, reflejo, Color.yellow);
        }





        /*
        if (Physics.Raycast(r, out hit))
        {
            hitPoint = hit.point;
        }
        else
        {
            hitPoint = hit.point;
        }

        if (hitPoint != null){
            Debug.DrawLine(transform.position, hit.point, Color.red);
        }*/

    }
}
