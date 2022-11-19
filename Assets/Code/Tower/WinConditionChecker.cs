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
    
    public bool WarmHasWon { get; private set; }
    public bool ColdHadWon { get; private set; }

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
        if (WarmHasWon || ColdHadWon) return;
        
        if (warmOccupied)
        {
            warmWinTimer -= Time.deltaTime;
            if (warmWinTimer <= 0f)
            {
                WarmHasWon = true;
            }
        }

        if (coldOccupied)
        {
            coldWinTimer -= Time.deltaTime;
            if (coldWinTimer <= 0f)
            {
                ColdHadWon = true;
            }
        }
    }
}
