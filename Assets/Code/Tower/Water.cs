using System;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float timeBeforeRisingStarts = 60f;
    [SerializeField] private float risePerMinute = 1f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private static readonly int visibility = Shader.PropertyToID("_Visibility");

    private float startTime;
    private float height;
    private float top;
    private float bottom;
    public bool IsRising => Time.time - startTime > timeBeforeRisingStarts;

    private void Start()
    {
        startTime = Time.time;
        spriteRenderer.material.SetFloat(visibility, 0f);
        
        top = spriteRenderer.transform.position.y + ((spriteRenderer.sprite.texture.height / spriteRenderer.sprite.pixelsPerUnit ) / 2f) * transform.localScale.y;
        bottom = spriteRenderer.transform.position.y - ((spriteRenderer.sprite.texture.height / spriteRenderer.sprite.pixelsPerUnit ) / 2f) * transform.localScale.y;
    }

    private void Update()
    {
        if (IsRising)
        {
            Rise();
        }
    }

    private void Rise()
    {
        var heightIncrease = (risePerMinute / 60f) * Time.deltaTime;
        SetHeight(height + heightIncrease);
    }

    private void SetHeight(float height)
    {
        var percentageToFill = (GetLevel() - bottom) / (top - bottom);

        spriteRenderer.material.SetFloat(visibility, percentageToFill);

        this.height = height;
    }

    public float GetLevel()
    {
        return bottom + height;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float level = GetLevel();
        Gizmos.DrawLine(new Vector3(-100f, level, 0f), new Vector3(100f, level, 0f));
    }
}
