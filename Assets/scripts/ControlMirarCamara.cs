using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMirarCamara : MonoBehaviour
{
    

    Vector2 SuavidadV;  // suavidad de movimiento
    Vector2 MouseMirar; // angulo en el que mira el mouse

    public float Sensibilidad = 5.0f; // cuanto se tiene que mover para que el jugadoor responda
    public float Suavizado = 2.0f; // suavizado del movimiento

    GameObject Player; 
    void Start()
    {
        Player = this.transform.parent.gameObject; // llamo al jugador via codigo
    }

    void Update()
    {   // cuanto cambia el movimiento 
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); 
        
        md = Vector2.Scale(md, new Vector2(Sensibilidad * Suavizado, Sensibilidad * Suavizado));

        SuavidadV.x = Mathf.Lerp(SuavidadV.x, md.x, 1f / Suavizado);
        SuavidadV.y = Mathf.Lerp(SuavidadV.y, md.y, 1f / Suavizado);

        MouseMirar += SuavidadV;
        MouseMirar.y = Mathf.Clamp(MouseMirar.y, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(-MouseMirar.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(MouseMirar.x, Player.transform.up);

    }
}
