using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBuilder : MonoBehaviour
{

    public int deckSize;
    GameObject[] allCards;
    public List<Card> cards;

    void Start()
    {
        allCards = Resources.LoadAll<GameObject>("Cards");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
