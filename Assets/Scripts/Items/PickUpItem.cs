using Player;
using UnityEngine;

namespace Items
{
    public class PickUpItem : MonoBehaviour
    {
        [SerializeField] private int _mass = 1;

        private bool _pickedUp = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_pickedUp)
            {
                return;
            }

            if (collision.CompareTag("Player"))
            {
                var playerInventory = collision.GetComponent<PlayerInventory>();
                playerInventory.Mass += _mass;
                _pickedUp = true;
            }
        }
    }
}
