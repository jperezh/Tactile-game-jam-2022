using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TeamColors")]
public class TeamColors : ScriptableObject
{

    [SerializeField] private List<RuntimeAnimatorController> blueTeamAnimatorControllers;
    [SerializeField] private List<RuntimeAnimatorController> redTeamAnimatorControllers;


    public List<RuntimeAnimatorController> BlueTeamAnimatorControllers
    {
        get => blueTeamAnimatorControllers;
    }

    public List<RuntimeAnimatorController> RedTeamAnimatorControllers
    {
        get => redTeamAnimatorControllers;
    }
}
