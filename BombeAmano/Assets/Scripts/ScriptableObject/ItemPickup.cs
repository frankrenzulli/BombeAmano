using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData data;

    private void OnItemPickup(GameObject player)
    {
        switch (data.itemType)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombPlacerScript>().AddBomb();
                break;

            case ItemType.BlastRadius:
                player.GetComponent<BombPlacerScript>().explosionRadius++;
                break;

            case ItemType.SpeedIncrease:
                player.GetComponent<P1Movement>().speed++;
                break;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemPickup(other.gameObject);
        }
    }
}