using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FakeJointManager : MonoBehaviour
{
    [SerializeField] private bool stopUpdate;
    [SerializeField] private bool useQuaternion;
    [SerializeField] private float heightGap;
    [SerializeField] private float defaultLerpSpeed;

    [SerializeField] private Transform[] joints;
    [SerializeField] private Vector3 testWorldUp;


    private void Update()
    {
        if (!stopUpdate || Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 previousJointPosition;

            for (int i = 0; i < joints.Length; i++)
            {
                previousJointPosition = i == 0 ? transform.position : joints[i - 1].position;
                var curJointPos = joints[i].position;

                // var directionFromPreviousJoint = joints[i].position - previousJointPosition;
                var directionToPreviousJoint = previousJointPosition - joints[i].position;
                var distance = Vector2.Distance(previousJointPosition, curJointPos);

                var lerpSpeed = defaultLerpSpeed;
                // if (distance > heightGap * 1.3f)
                // {
                //     lerpSpeed *= 2;
                // }
                Debug.DrawRay(previousJointPosition, directionToPreviousJoint, Color.black);

                var desiredPos = curJointPos + (directionToPreviousJoint * (lerpSpeed * Time.deltaTime));
                desiredPos.y = previousJointPosition.y - heightGap;

                joints[i].position = desiredPos;


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
        }
    }
}