using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{

    public GameObject Player;
    public Vector3 offset;


    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
