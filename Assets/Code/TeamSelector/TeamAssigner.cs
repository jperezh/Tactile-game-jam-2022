using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Code.TeamSelector
{
    public class TeamAssigner : MonoBehaviour
    {
        [SerializeField] private TeamTrigger warmTeamTrigger;
        [SerializeField] private TeamTrigger coldTeamTrigger;
        [SerializeField] private StartGameTrigger startGameTrigger;
        [SerializeField] private TeamColors teamColors;
        [SerializeField] private TextMeshProUGUI countdownTimerText;

        private const float COUNTDOWN_TIME = 3f;
        
        private readonly List<PlayerInput> warmTeamPlayers = new List<PlayerInput>();
        private readonly List<PlayerInput> coldTeamPlayers = new List<PlayerInput>();

        private float countdownTimer;
        private bool isCountingDown;

        private enum Team
        {
            Warm,
            Cold,
        }

        private void Start()
        {
            warmTeamTrigger.PlayerEntered += playerInput => OnPlayerEntered(playerInput, Team.Warm);
            coldTeamTrigger.PlayerEntered += playerInput => OnPlayerEntered(playerInput, Team.Cold);

            startGameTrigger.PressStarted += OnStartGamePressStarted;
            startGameTrigger.PressEnded += OnStartGamePressEnded;
        }

        private void Update()
        {
            if (isCountingDown)
            {
                UpdateCountdownTimer();
            }
        }

        private void UpdateCountdownTimer()
        {
            countdownTimer -= Time.deltaTime;
            countdownTimerText.text = Mathf.CeilToInt(countdownTimer).ToString();
            if (countdownTimer <= 0f)
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        private void OnStartGamePressStarted()
        {
            isCountingDown = true;
            countdownTimer = COUNTDOWN_TIME;
            countdownTimerText.gameObject.SetActive(true);
        }

        private void OnStartGamePressEnded()
        {
            isCountingDown = false;
            countdownTimerText.gameObject.SetActive(false);
        }

        private void OnPlayerEntered(PlayerInput playerInput, Team team)
        {
            bool alreadyJoinedTeam = team == Team.Warm && warmTeamPlayers.Contains(playerInput)
                                     || team == Team.Cold && coldTeamPlayers.Contains(playerInput);

            if (alreadyJoinedTeam)
            {
                return;
            }
            
            warmTeamPlayers.Remove(playerInput);
            coldTeamPlayers.Remove(playerInput);
            
            var character = playerInput.gameObject.GetComponent<Character>();
            
            if (team == Team.Warm)
            {
                warmTeamPlayers.Add(playerInput);
                Color color = GetUnusedWarmColor();
                character.Color = color;
            }
            else
            {
                coldTeamPlayers.Add(playerInput);
                Color color = GetUnusedColdColor();
                character.Color = color;
            }
        }

        private Color GetUnusedWarmColor()
        {
            var warmCharacters = warmTeamPlayers.Select(p => p.GetComponent<Character>());
            var unusedColor = teamColors.WarmTeamColors.First(color => warmCharacters.All(c => c.Color != color));
            return unusedColor;
        }
        
        private Color GetUnusedColdColor()
        {
            var coldCharacters = coldTeamPlayers.Select(p => p.GetComponent<Character>());
            var unusedColor = teamColors.ColdTeamColors.First(color => coldCharacters.All(c => c.Color != color));
            return unusedColor;
        }
    }
}