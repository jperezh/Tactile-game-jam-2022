using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlatformScaler : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Awake() {
        var boxColliderSize = boxCollider.size;
        var size = spriteRenderer.size;
        
        boxColliderSize.x = size.x - 0.2f;
        boxColliderSize.y = size.y / 2;
        
        boxCollider.size = boxColliderSize;
    }
}
