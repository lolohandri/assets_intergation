using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCoin : MonoBehaviour
{
    float Score;

    [Header("Add score for extra coin")]
    [Range(3.5f,5.5f)]
    public float extraScore;

    [Header("ParticleSystem")]
    public ParticleSystem particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cylinder") || other.CompareTag("MainCylinder") || other.CompareTag("Player"))
        {
            Score = PlayerPrefs.GetFloat("Score"); //Get score number
            Score += extraScore; //Inscrease score
            PlayerPrefs.SetFloat("Score", Score); //Save data
            Destroy(this.gameObject);
            particle.Stop();
        }
    }
}
