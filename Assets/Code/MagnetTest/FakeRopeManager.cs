using UnityEngine;

public class FakeRopeManager : MonoBehaviour
{
    [SerializeField] private float heightGap;
    [Range(10, 50)] 
    [SerializeField] private float defaultLerpSpeed;

    [SerializeField] private Vector2 positionXLimits;
    [SerializeField] private Vector2 positionYLimits;

    [SerializeField] private Transform[] joints;
    [SerializeField] private Transform magnet;

    

    private void Start()
    {
        foreach (var jointTransform in joints)
        {
            jointTransform.SetParent(null);
        }
    }

    private void Update()
    {
        LimitPosition();

        CalculateJointPositions();
    }

    private void CalculateJointPositions()
    {
        Vector3 previousJointPosition;

        for (int i = 0; i < joints.Length; i++)
        {
            previousJointPosition = i == 0 ? transform.position : joints[i - 1].position;

            joints[i].position = CalculatePosition(joints[i].position, previousJointPosition);
        }

        magnet.position = CalculatePosition(magnet.position, joints[joints.Length - 1].position);
    }

    private Vector3 CalculatePosition(Vector3 currentPos, Vector3 previousJointPosition)
    {
        var directionToPreviousJoint = previousJointPosition - currentPos;

        var result = currentPos + (directionToPreviousJoint * (defaultLerpSpeed * Time.deltaTime));
        result.y = previousJointPosition.y - heightGap;

        return result;
    }

    private void LimitPosition()
    {

        //limits x
        if (transform.position.x < positionXLimits.x)
        {
            var limitedPos = transform.position;
            limitedPos.x = positionXLimits.x;
            transform.position = new Vector2(limitedPos.x,transform.position.y);
        }

        if (transform.position.x > positionXLimits.y)
        {
            var limitedPos = transform.position;
            limitedPos.x = positionXLimits.y;
            transform.position = new Vector2(limitedPos.x,transform.position.y);
        }

        //limits y
        if (transform.position.y < positionYLimits.x)
        {
            var limitedPos = transform.position;
            limitedPos.y = positionYLimits.x;
            transform.position = new Vector2(transform.position.x, limitedPos.y);
        }

        if (transform.position.y > positionYLimits.y)
        {
            var limitedPos = transform.position;
            limitedPos.y = positionYLimits.y;
            transform.position = new Vector2(transform.position.x, limitedPos.y);
        }
    }
}