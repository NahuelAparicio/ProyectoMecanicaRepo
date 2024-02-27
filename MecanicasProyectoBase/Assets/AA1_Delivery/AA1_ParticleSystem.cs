using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
[System.Serializable]
public class AA1_ParticleSystem
{
    [System.Serializable]
    public struct Settings
    {
        public Vector3C gravity;
        public float bounce;
    }
    public Settings settings;

    [System.Serializable]
    public struct SettingsCascade
    {
        public Vector3C PointA;
        public Vector3C PointB;
        public float particlesPerSecond;
    }
    public SettingsCascade settingsCascade;

    [System.Serializable]
    public struct SettingsCannon
    {
        public Vector3C Start;
        public Vector3C Direction;
        public float angle;
        public float particlesPerSecond;
    }
    public SettingsCannon settingsCannon;

    [System.Serializable]
    public struct SettingsCollision
    {
        public PlaneC[] planes;
        public SphereC[] spheres;
        public CapsuleC[] capsules;
    }
    public SettingsCollision settingsCollision;


    [System.Serializable]
    public struct Particle
    {
        public Vector3C position;
        public Vector3C velocity;
        public float size;

        public Particle(Vector3C pos, Vector3C _velocity, float _size)
        {
            position = pos;
            velocity = _velocity;
            size = _size;
        }

        public void Update(float dt, Vector3C gravity)
        {
            //Apply gravity
            velocity.y -= gravity.y * dt;
            //Update position
            position.x += velocity.x * dt;
            position.y += velocity.y * dt;
        }
    }

    public void ApplyForceToPoint(int particleIndex, Vector3C force)
    {
        particles[particleIndex].velocity += force;
    }

    public Particle[] particles;

    public Particle[] Update(float dt)
    {
        for (int i = 0; i < particles.Length; ++i)
        {
            //particles[i].position = new Vector3C(-4.5f + i, 0.0f, 0);
            //particles[i].size = 0.1f;
            particles[i].Update(dt, settings.gravity);

            if (IsCollidingWithPlanes(particles[i]))
            {
                Debug.Log("is colliding");
            }
            
        }
        return particles;
    }

    public bool IsCollidingWithPlanes(Particle particle)
    {
        foreach (PlaneC plane in settingsCollision.planes)
        {
            Vector3C nearestPoint = plane.NearestPoint(plane, particle.position);
            Vector3C distanceVector = particle.position - nearestPoint;
            //float distance = Vector3C.Dot(plane.normal, particle.position - plane.position);
            float distance = Vector3C.Dot(distanceVector, plane.normal);

            if (distance <= particle.size)
            {
                return true;
            }
        }
        return false;
    }

    //public void Debug()
    //{
    //    foreach (var item in settingsCollision.planes)
    //    {
    //        item.Print(Vector3C.red);
    //    }
    //    foreach (var item in settingsCollision.capsules)
    //    {
    //        item.Print(Vector3C.green);
    //    }
    //    foreach (var item in settingsCollision.spheres)
    //    {
    //        item.Print(Vector3C.blue);
    //    }
    //}
}
