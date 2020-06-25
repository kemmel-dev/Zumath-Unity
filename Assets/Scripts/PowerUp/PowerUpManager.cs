﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nodes;
using Assets.Scripts.DevTools;

namespace PowerUps
{
    public static class PowerUpManager
    {
        private static PowerUpList powerUpList = new PowerUpList();

        // If true, the powerup will activate
        public static bool triggerPowerUp = false;

        // Amount of seconds the powerup effect lasts
        public static float powerUpEffectTimeLeft = 6f;

        public static void AddPowerUps(PowerUp powerUp)
        {
            powerUpList.powerUpLinkedList.AddFirst(powerUp);
        }

        public static void RemovePowerUps(PowerUp powerUp)
        {
           powerUpList.powerUpLinkedList.Remove(powerUp);
        }

        public static void PowerUpEffect()
        {
            if (triggerPowerUp)
            {
                //insert time slow
                powerUpEffectTimeLeft -= Time.deltaTime;
                if (powerUpEffectTimeLeft < 0)
                {
                    //revert back to regular speed
                    triggerPowerUp = false;
                }
            }
        }

        public static void Update()
        {
            PowerUpEffect();
        }

        public static LinkedList<PowerUp> GetPowerUps()
        {
            if (powerUpList != null)
            {
                return powerUpList.powerUpLinkedList;
            }
            return new LinkedList<PowerUp>();
        }
    }
}