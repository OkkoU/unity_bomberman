using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        BlastRadius,
        ExtraBomb,
        SpeedIncrease,
    }

    public ItemType type;


    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.BlastRadius:
                player.GetComponent<BombController>().explosionRadius++;
                break;

            case ItemType.ExtraBomb:
                player.GetComponent<BombController>().AddBomb();
                break;

            case ItemType.SpeedIncrease:
                player.GetComponent<MovementController>().speed++;
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
