using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Cards = new();
    public GameObject cardPf;
    private readonly int positionOffsetX = 5;
    private readonly float positionOffsetZ = 0.0001f;
    public int amountOfCardsToDeal = 10;

    void Start()
    {
        foreach (var item in CardMapper.keyValuePairs.Select((e, index) => new { e, index }))
        {
            var card = Instantiate(cardPf);
            var cardComponent = card.GetComponent<Card>();
            var keySplit = item.e.Key.Split('_');
            cardComponent.SetupCard(keySplit[1], keySplit[0], item.e.Value);
            card.SetActive(false);
            Cards.Add(card);
        }

        var shuffledItems = GetRandomElements(Cards, amountOfCardsToDeal);

        for (var i = 0; i < shuffledItems.Count; i++)
        {
            var card = shuffledItems[i];
            var xPos = card.transform.position.x + (positionOffsetX * i);
            var zPos = card.transform.position.z - (positionOffsetZ * i);
            card.SetActive(true);
            var cardComponent = card.GetComponent<Card>();
            cardComponent.SetTransform(new Vector3(xPos, card.transform.position.y, zPos));
        }
    }

    public static List<t> GetRandomElements<t>(IEnumerable<t> list, int elementsCount)
    {
        var rnd = new System.Random();
        return list.OrderBy(_ => rnd.Next()).Take(elementsCount).ToList();
    }
}


