﻿using UnityEngine;

public class ParticleAttractor : MonoBehaviour {
    
    public ParticleSystem[] affectedParticles;
    public float speed;
    [Range(0f, 1f)]
    public float lerpFactor;

    private void Update() {
        foreach (ParticleSystem particle in affectedParticles) {
            if (particle) {
                ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particle.particleCount];
                particle.GetParticles(particles);

                for (int i = 0; i < particles.Length; i++) {
                    ParticleSystem.Particle p = particles[i];

                    Vector3 dist = transform.position - p.position;
                    Vector3 vel = dist.normalized;
                    p.velocity = Vector3.Lerp(p.velocity, vel * speed, lerpFactor * Time.unscaledDeltaTime * 60f);
                    p.startLifetime = (particle.transform.position - transform.position).magnitude;
                    p.remainingLifetime = Mathf.Min(p.remainingLifetime, dist.magnitude);
                    particles[i] = p;
                }

                particle.SetParticles(particles);
            }
        }
    }

}