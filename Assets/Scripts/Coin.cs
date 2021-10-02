using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Coin : MonoBehaviour
{
    PlayerController player;
    public AudioClip coinSound;
    public ParticleSystem particle;
    private GameManager gm;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0.3f, 0); // анимация вращения монетки
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == player.GetComponent<Collider>()) 
        {
            player.GetComponent<AudioSource>().PlayOneShot(coinSound);            
            Instantiate(particle, transform.position, Quaternion.identity).transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Destroy(gameObject);
            Task.Delay(1000);
            Destroy(transform.parent.gameObject); // удаляется пустой объект со скриптом монетки
            gm.AddPoint();
        }
    }
}
