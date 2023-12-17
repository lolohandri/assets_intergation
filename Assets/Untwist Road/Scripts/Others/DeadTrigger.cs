using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    CylinderCont cylinder;
    void Start()
    {
        cylinder = GameObject.FindGameObjectWithTag("MainCylinder").GetComponent<CylinderCont>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("isDeaded", 1); //Set game over = 1
            PlayerPrefs.SetInt("isStarted", 0);
            cylinder.animator.Play("fly");
        }
    }
}
