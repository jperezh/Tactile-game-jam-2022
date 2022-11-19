using System.Collections.Generic;
using UnityEngine;

public class TowerArea : MonoBehaviour
{
    public List<Block> Blocks { get; } = new List<Block>();
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var block = other.gameObject.GetComponent<Block>();
        if (block != null)
        {
            Blocks.Add(block);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var block = other.gameObject.GetComponent<Block>();
        if (block != null)
        {
            Blocks.Remove(block);
        }
    }
}
