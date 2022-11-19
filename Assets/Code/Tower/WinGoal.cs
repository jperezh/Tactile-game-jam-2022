using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WinGoal : MonoBehaviour
{
    public List<Block> Blocks { get; } = new List<Block>();

    public event Action Occupied;
    public event Action Unoccupied;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var block = other.gameObject.GetComponentInParent<Block>();
        if (block != null)
        {
            if (!Blocks.Any())
            {
                Occupied?.Invoke();
            }
            Blocks.Add(block);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        var block = other.gameObject.GetComponentInParent<Block>();
        if (block != null)
        {
            Blocks.Remove(block);
            if (!Blocks.Any())
            {
                Unoccupied?.Invoke();
            }
        }
    }
}
