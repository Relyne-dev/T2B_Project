using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public static GameObject tile;
    public static List<GameObject> tiles;
    public static List<GameObject> cards;
    public static GameObject player;
    public TMP_Text cardCost;
    public TMP_Text cheese;

    [Header("Scene Info")]
    public Scene _currentScene;

    // Awake is used for initializing the whole Game with GameManager
    void Awake()
    {
        




        tile = Resources.Load("Tile") as GameObject;

        tiles = new List<GameObject>();
        tiles.Add(Instantiate(tile));


        cards = new List<GameObject>();

        player = GameObject.FindGameObjectWithTag("Player");

        //cards.Add(Instantiate());
    }

    public void LoadMinigame(string gameName)
    {
        SceneManager.LoadScene(gameName, LoadSceneMode.Additive);
    }


    void Update()
    {
        cheese.text = "Damage: ";
    }



    void changeTurn()
    {

    }





}
