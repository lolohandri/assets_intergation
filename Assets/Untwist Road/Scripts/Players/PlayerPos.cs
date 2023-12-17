using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private CylinderCont cylinder;
    public ParticleSystem particle;
    public AudioSource audioSrc;

    void Start()
    {
        cylinder = GameObject.FindGameObjectWithTag("MainCylinder").GetComponent<CylinderCont>();
    }

    void LateUpdate()
    {
        if (cylinder != null)
        {
            transform.position = new Vector3(cylinder.transform.position.x, transform.position.y, cylinder.transform.position.z); //Player movement behind the cylinder from above
        }
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.collider.tag == "GroundOn")
        {
            PlayerPrefs.SetInt("isDeaded", 1); //Set game over = 1
            PlayerPrefs.SetInt("isStarted", 0);
            cylinder.animator.Play("dead"); //Play dead animation
            particle.Play();
            audioSrc.Play();
            cylinder.playerrb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX; //Freeze rotaiton and position x
        }
    }
}