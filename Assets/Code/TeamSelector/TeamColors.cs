using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TeamColors")]
public class TeamColors : ScriptableObject
{
    [SerializeField] private List<Color> warmTeamColors;
    [SerializeField] private List<Color> coldTeamColors;


    public List<Color> WarmTeamColors
    {
        get => warmTeamColors;
    }

    public List<Color> ColdTeamColors
    {
        get => coldTeamColors;
    }
}
