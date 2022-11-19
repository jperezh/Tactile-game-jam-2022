using Code;
using UnityEngine;

public class GroundRumbler : MonoBehaviour
{
    [SerializeField] private AnimationCurve lowFrequencyRumbleCurve;
    [SerializeField] private AnimationCurve highFrequencyRumbleCurve;
    [SerializeField] private AnimationCurve durationCurve;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Block>() == null) return;

        var fallingSpeed = col.attachedRigidbody.velocity.y;
        
        var lowFrequencySpeed = lowFrequencyRumbleCurve.Evaluate(fallingSpeed);
        var highFrequencySpeed = highFrequencyRumbleCurve.Evaluate(fallingSpeed);

        var allCharacters = FindObjectsOfType<Character>();

        foreach (var character in allCharacters)
        {
            character.Rumble(durationCurve.Evaluate(fallingSpeed), lowFrequencySpeed, highFrequencySpeed);
        }
    }
}
