using UnityEngine;

public class Card : MonoBehaviour
{
    public int rank;
    public int suit;
    public SpriteRenderer SpriteRenderer;

    public void SetupCard(string rank, string suit, string imagePath)
    {
        this.rank = int.Parse(rank);
        this.suit = int.Parse(suit);
        if (SpriteRenderer == null)
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
        this.SpriteRenderer.sprite = Resources.Load<Sprite>(imagePath);
    }

    public void SetTransform(Vector3 position)
    {
        transform.SetPositionAndRotation(position, Quaternion.identity);
    }
}
