using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float timeBeforeRisingStarts = 60f;
    [SerializeField] private float risePerMinute = 1f;

    private float startTime;
    
    public void Initialize(float startTime)
    {
        this.startTime = startTime;
    }

    private void Update()
    {
        if (Time.time - startTime <= timeBeforeRisingStarts)
        {
            return;
        }

        Rise();
    }

    private void Rise()
    {
        var currentHeight = transform.localScale.y;
        var heightIncrease = (risePerMinute / 60f) * Time.deltaTime;

        SetHeight(currentHeight + heightIncrease);
    }

    private void SetHeight(float height)
    {
        var scale = transform.localScale;
        transform.localScale = new Vector3(scale.x, height, scale.z);

        var position = transform.position;
        transform.localPosition = new Vector3(position.x, height / 2f, position.z);
    }
}
