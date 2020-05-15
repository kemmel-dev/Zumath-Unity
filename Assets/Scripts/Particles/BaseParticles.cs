﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    public abstract class BaseParticles : MonoBehaviour
    {
        public ParticleSystem particle;
        protected bool hasEmitted;

        protected void EmitParticles()
        {
            hasEmitted = true;
            particle.Emit(1);
        }
    }
}
