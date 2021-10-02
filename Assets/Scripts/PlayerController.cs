using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public int speed;
    private float sensitivity = 0.5f;
    public bool disableControl = false;
    public Animator animator;
    public Text test;
    private GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        disableControl = false;
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!disableControl) //отключает управление после финиша или смерти
        {
            if (Input.GetMouseButton(0))
            {
                gm.HideInstructions(); //убираем инструкции
                transform.position += transform.forward * speed * Time.deltaTime;
                transform.position += transform.right * Input.GetAxis("Mouse X") * sensitivity;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f), 0, transform.position.z);                
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    public async void Dead()
    {
        transform.GetChild(0).eulerAngles = new Vector3(0, 180, 0);
        disableControl = true;
        animator.SetTrigger("dead");
        await Task.Delay(2000);
        gm.Lose();
    }

    public async void PlayRandomDance()
    {
        string[] dances = {"samba", "sillyone", "sillytwo"};
        transform.GetChild(0).eulerAngles = new Vector3(0, 180, 0);
        animator.SetTrigger(dances[Random.Range(0,dances.Length)]);//включает анимацию
        await Task.Delay(4000);
        gm.Win();
    }
}
