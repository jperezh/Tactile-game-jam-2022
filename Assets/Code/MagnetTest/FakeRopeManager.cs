using UnityEngine;

public class FakeRopeManager : MonoBehaviour
{
    [SerializeField] private bool stopUpdate;
    [SerializeField] private bool useQuaternion;
    [SerializeField] private float heightGap;
    [SerializeField] private float defaultLerpSpeed;

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
        if (!stopUpdate || Input.GetKeyDown(KeyCode.Q))
        {
            CalculateJointPositions();
        }
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
        Debug.DrawRay(previousJointPosition, directionToPreviousJoint, Color.black);
        
        var result = currentPos + (directionToPreviousJoint * (defaultLerpSpeed * Time.deltaTime));
        result.y = previousJointPosition.y - heightGap;

        return result;
    }
    
    // if (i == joints.Length - 1)
    // {
    //     var direction = joints[i].position - previousJointPosition;
    //     var lookAtPosition = joints[i].position + direction;
    //
    //
    //     if (!useQuaternion)
    //     {
    //         joints[i].LookAt(lookAtPosition, testWorldUp);
    //     }
    //     else
    //     {
    //         joints[i].rotation = Quaternion.LookRotation(lookAtPosition, testWorldUp);
    //     }
    // }
}