using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float timeBeforeRisingStarts = 60f;
    [SerializeField] private float risePerMinute = 1f;

    private float startTime;
    public bool IsRising => Time.time - startTime > timeBeforeRisingStarts;

    public void Initialize(float startTime)
    {
        this.startTime = startTime;
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
        var currentHeight = transform.localScale.y;
        var heightIncrease = (risePerMinute / 60f) * Time.deltaTime;

        SetHeight(currentHeight + heightIncrease);
    }

    private void SetHeight(float height)
    {
        var scale = transform.localScale;
        var bottom = transform.localPosition.y - scale.y / 2f;
                     
        transform.localScale = new Vector3(scale.x, height, scale.z);

        var localPosition = transform.localPosition;
        transform.localPosition = new Vector3(localPosition.x, bottom + height / 2f, localPosition.z);
    }

    public float GetLevel()
    {
        return (transform.localScale.y / 2f) + transform.position.y;
    }
}
