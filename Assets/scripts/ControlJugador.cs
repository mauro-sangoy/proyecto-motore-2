using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlJugador : MonoBehaviour
{
    public Camera CamaraPrimeraPersona;
    public GameObject Proyectil; //noombre del objeto

    public float VelocidadDeMovimiento = 10.0f; //velocidad de movimiento
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // desaparece el cursor
    }

  
    void Update()
    {   // movimiento de los ejes x, y
        float MovimientoY = Input.GetAxis("Vertical") * VelocidadDeMovimiento;
        float MovimientoX = Input.GetAxis("Horizontal") * VelocidadDeMovimiento;

        MovimientoY *= Time.deltaTime;
        MovimientoX *= Time.deltaTime;

        transform.Translate(MovimientoX, 0 , MovimientoY);

        if (Input.GetKeyDown("escape")) 
        {
            Cursor.lockState = CursorLockMode.None; // reaparece el cursor
        }

        if (Input.GetMouseButtonDown(0)) //Raycasting
        {
            Ray ray = CamaraPrimeraPersona.ViewportPointToRay(new Vector3(0.5f, 0.5f,0));
            RaycastHit hit;


            GameObject pro;
            pro = Instantiate(Proyectil, ray.origin, transform.rotation);

            Rigidbody rb = pro.GetComponent<Rigidbody>();
            rb.AddForce(CamaraPrimeraPersona.transform.forward * 15, ForceMode.Impulse);

            Destroy(pro, 5);

            if((Physics.Raycast(ray, out hit)== true) && hit.distance < 5) 
            {
                Debug.Log("El rayo toco al objeto: " + hit.collider.name);
                
                if(hit.collider.name.Substring(0,3) == "Bot") // pregunta las primeras 3 letras del collider
                {
                    GameObject objetoTocado = GameObject.Find(hit.transform.name); //pregunta el nombre del objeto
                    ControlBot scriptobjetoTocado = (ControlBot)objetoTocado.GetComponent(typeof(ControlBot));

                    if(scriptobjetoTocado != null) //invoca el script del objeto tocado
                    {
                        scriptobjetoTocado.RecibirDaño();
                    }
                }
            }
        }
    }
}
