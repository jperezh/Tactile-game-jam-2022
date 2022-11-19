using System.Linq;
using Code.Tower;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchStateManager : MonoBehaviour
{
    [SerializeField] private LoseConditionChecker loseConditionChecker;
    [SerializeField] private WinConditionChecker winConditionChecker;
    [SerializeField] private TextMeshProUGUI textLabel;

    private const float RESTART_TIME = 5f;
    
    private bool hasGameEnded;
    private float restartTimer;

    private void Update()
    {
        if (hasGameEnded)
        {
            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0f)
            {
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            CheckWaterConditions();
            CheckGoalConditions();
        }
    }

    private void CheckGoalConditions()
    {
        if (winConditionChecker.HasColdTeamWon && winConditionChecker.HasWarmTeamWon)
        {
            textLabel.text = "No one wins! (Game will restart in 5 seconds)";
            PrepareForRestart();
           
        }
        else if (winConditionChecker.HasWarmTeamWon)
        {
            textLabel.text = "Warm team wins! (Game will restart in 5 seconds)";
            PrepareForRestart();
        }
        else if (winConditionChecker.HasColdTeamWon)
        {
            textLabel.text = "Cold team wins! (Game will restart in 5 seconds)";
            PrepareForRestart();
        }
    }

    private void CheckWaterConditions()
    {
        if (loseConditionChecker.HasColdTeamLost && loseConditionChecker.HasWarmTeamLost)
        {
            textLabel.text = "No one wins! (Game will restart in 5 seconds)";
            PrepareForRestart();
           
        }
        else if (loseConditionChecker.HasColdTeamLost)
        {
            textLabel.text = "Warm team wins! (Game will restart in 5 seconds)";
            PrepareForRestart();
        }
        else if (loseConditionChecker.HasWarmTeamLost)
        {
            textLabel.text = "Cold team wins! (Game will restart in 5 seconds)";
            PrepareForRestart();
        }
    }

    private void PrepareForRestart()
    {
        hasGameEnded = true;
        restartTimer = RESTART_TIME;
    }
}
