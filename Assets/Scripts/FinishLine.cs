using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private PlayerController player;
    public AudioClip heey;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>())
        {
            other.GetComponent<PlayerController>().disableControl = true; // выключаем движение персонажа 
            player.GetComponent<AudioSource>().PlayOneShot(heey);
            other.GetComponent<PlayerController>().PlayRandomDance();
        }
    }
}
