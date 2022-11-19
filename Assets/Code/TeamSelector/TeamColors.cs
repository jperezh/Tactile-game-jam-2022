using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "TeamColors")]
public class TeamColors : ScriptableObject
{

    [SerializeField] private List<AnimatorController> blueTeamAnimatorControllers;
    [SerializeField] private List<AnimatorController> redTeamAnimatorControllers;


    public List<AnimatorController> BlueTeamAnimatorControllers
    {
        get => blueTeamAnimatorControllers;
    }

    public List<AnimatorController> RedTeamAnimatorControllers
    {
        get => redTeamAnimatorControllers;
    }
}
