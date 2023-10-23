using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Rigidbody rb;
    public int velocidad;
    public Text ObjetosRecolectados;
    public Text Ganaste;
    private int Contador;

    public LayerMask CapaPiso;
    public float MagnitudSalto;
    public SphereCollider col;

    float HorizontalMov;
    float VerticalMov;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        Contador = 0;
        Ganaste.text = "";
        SetearTextos();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && EstaEnPiso()) 
        {
            rb.AddForce(Vector3.up * MagnitudSalto, ForceMode.Impulse);
        }
    }

    private bool EstaEnPiso() 
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, CapaPiso);
    }

    private void SetearTextos()
    {
        ObjetosRecolectados.text = "Lingotes de oro: " + Contador.ToString();
        if (Contador >= 10) 
        {
            Ganaste.text = "ganaste";
        }
    }


    void FixedUpdate()
    {
        HorizontalMov = Input.GetAxis("Horizontal");
        VerticalMov = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(HorizontalMov, 0.0f, VerticalMov);
        rb.AddForce(direccion * velocidad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coleccionable") == true)
        {
            Contador = Contador + 1;
            SetearTextos();
            other.gameObject.SetActive(false);
        }
    }
}
