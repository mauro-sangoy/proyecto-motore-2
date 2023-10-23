using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bot;  //asigna el bot desde el editor
    private List<GameObject> ListaEnemigos;
    float TiempoRestante;
    void Start()
    {
        ComenzarJuego();
    }

    void Update()
    {
        if(TiempoRestante == 0) 
        {
            ComenzarJuego(); //si termina la ronda vuelve a empezar
        }
    }
    
    void ComenzarJuego()  //posiciona a los bots y los vuelve a crear
    {
        Player.transform.position = new Vector3(0f, 2f, 0f);

        foreach (GameObject item in ListaEnemigos) 
        {
            Destroy(item);
        }

        ListaEnemigos.Add(Instantiate(Bot, new Vector3(5, 2f, 3f), Quaternion.identity));
        ListaEnemigos.Add(Instantiate(Bot, new Vector3(3, 2f, 3f), Quaternion.identity));
        ListaEnemigos.Add(Instantiate(Bot, new Vector3(1, 2f, 3f), Quaternion.identity));
        StartCoroutine(ComenzarCronometro(30));
    }

    public IEnumerator ComenzarCronometro(float ValorCronometro = 30) //corrutina que crea un temporalizador
    {
        TiempoRestante = ValorCronometro;
        while(TiempoRestante > 0) 
        {
            Debug.Log("Restan" + TiempoRestante + " segundos.");
            yield return new WaitForSeconds(1.0f);
            TiempoRestante--;
        }
    }




}
