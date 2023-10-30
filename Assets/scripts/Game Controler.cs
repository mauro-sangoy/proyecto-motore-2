using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int remainingEnemies;

    private void Start()
    {
        remainingEnemies = GameObject.FindGameObjectsWithTag("Bot").Length;
    }




}
