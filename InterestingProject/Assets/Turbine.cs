using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : MonoBehaviour
{
    [SerializeField] private ParticleSystem turbineParticle = null;
    private Rigidbody rb = null;
    private ParticleSystem.MainModule particleMain = default;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        particleMain = turbineParticle.main;
    }

    private void Update()
    {
        float turbineFireLength = Mathf.Clamp(rb.velocity.sqrMagnitude/100, 0, 30);

        particleMain.startSpeed
            = new ParticleSystem.MinMaxCurve
            (turbineParticle.main.startSpeed.constantMin, turbineFireLength);
    }
}
