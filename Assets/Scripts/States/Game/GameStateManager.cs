﻿using System;
using UnityEngine;

namespace States.Game
{
    public static class GameStateManager
    {
        private static GameState currentGameState;
        private static GameState prePauseGameState;

        public static void Awake()
        {
            currentGameState = GameState.SPAWNING;
        }

        public static void Update()
        {
            if (currentGameState == GameState.PAUSED)
            {
                if (Input.GetKeyDown(KeyCode.U))
                {
                    Unpause();
                }
                return;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Pause();
            }
        }

        public static void Pause()
        {
            prePauseGameState = currentGameState;
            currentGameState = GameState.PAUSED;
        }

        public static void SetGameState(GameState gameState)
        {
            currentGameState = gameState;
        }

        public static void Unpause()
        {
            currentGameState = prePauseGameState;
        }

        public static GameState GetGameState()
        {
            return currentGameState;
        }
    }
}
