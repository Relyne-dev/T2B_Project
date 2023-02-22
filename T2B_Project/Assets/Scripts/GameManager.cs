using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<GameObject> tiles;
    public static List<GameObject> cards;
    public static GameObject player;



    // Awake is used for initializing the whole Game with GameManager
    void Awake()
    {
        tiles = new List<GameObject>();
        tiles.FindAll


        cards = new List<GameObject>();

        player = GameObject.FindGameObjectWithTag("Player");

        //cards.Add(Instantiate());
    }


    void Update()
    {
        
    }
}
