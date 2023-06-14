using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    public static Turn currentTurn;
    public static Phase currentTurnStep;

    public List<GameObject> deck = new List<GameObject>();
    public Transform[] hand = new Transform[5];

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
