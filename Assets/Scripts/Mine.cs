using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    PlayerController player;
    public ParticleSystem explosion;
    public AudioClip explosound;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == player.GetComponent<Collider>())
        {
            Instantiate(explosion, transform.position, Quaternion.identity); //создаем партикл взрыва
            Destroy(gameObject);
            player.Dead();
            player.GetComponent<AudioSource>().PlayOneShot(explosound);
        }
    }
}
