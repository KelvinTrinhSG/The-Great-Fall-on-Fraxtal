using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    GameObject Nuke;
    // Start is called before the first frame update
    void Start()
    {
        Nuke = GameObject.Find("NukeExplosion");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Lift")) {

    //        Nuke.transform.position = collision.gameObject.transform.position;
    //        Nuke.GetComponent<ParticleSystem>().Play();
    //        collision.gameObject.tag = "Untagged";
            
    //        GameManager.instance.GameOver();
    //    }
    //}


    public void OnTriggerEnter(Collider collision)
    {
        if (!GameManager.instance.GameEnd)
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Stick"))
            {

                Nuke.transform.position = collision.gameObject.transform.position;
                Nuke.GetComponent<ParticleSystem>().Play();
                collision.gameObject.tag = "Untagged";

                GameManager.instance.GameOver();
            }
        }

    }
}
