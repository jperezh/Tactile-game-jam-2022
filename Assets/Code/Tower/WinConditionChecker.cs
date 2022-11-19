using System;
using UnityEngine;

public class WinConditionChecker : MonoBehaviour
{
    [SerializeField] private TowerArea warmTowerArea;
    [SerializeField] private TowerArea coldTowerArea;

    [SerializeField] private WinGoal warmWinGoal;
    [SerializeField] private WinGoal coldWinGoal;

    private const float WIN_TIME = 5f;
    
    public bool HasWarmTeamWon { get; private set; }
    public bool HasColdTeamWon { get; private set; }

    private bool warmOccupied;
    private bool coldOccupied;

    private float warmWinTimer;
    private float coldWinTimer;
    
    private void Start()
    {
        warmWinGoal.Occupied += OnWarmOccupied;
        warmWinGoal.Unoccupied += () => warmOccupied = false;

        coldWinGoal.Occupied += OnColdOccupied;
        coldWinGoal.Unoccupied += () => coldOccupied = false;
    }

    private void OnWarmOccupied()
    {
        warmOccupied = true;
        warmWinTimer = WIN_TIME;
    }
    
    private void OnColdOccupied()
    {
        coldOccupied = true;
        coldWinTimer = WIN_TIME;
    }

    private void Update()
    {
        if (HasWarmTeamWon || HasColdTeamWon) return;
        
        if (warmOccupied)
        {
            warmWinTimer -= Time.deltaTime;
            if (warmWinTimer <= 0f)
            {
                HasWarmTeamWon = true;
            }
        }

        if (coldOccupied)
        {
            coldWinTimer -= Time.deltaTime;
            if (coldWinTimer <= 0f)
            {
                HasColdTeamWon = true;
            }
        }
    }
}
