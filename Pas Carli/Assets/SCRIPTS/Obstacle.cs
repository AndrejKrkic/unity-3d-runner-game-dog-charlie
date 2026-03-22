using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    [SerializeField]
    private int type;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>().gameObject;
        anim = gameObject.GetComponent<Animator>();
        if(type==1)
        anim.Play("Killanim", 0, Random.Range(0, 0.95f));

        if (type == 2)
            anim.Play("level2Animation", 0, Random.Range(0, 0.95f));

        if (type == 3)
            anim.Play("DeerAnim", 0, Random.Range(0, 0.95f));
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Player>().Dead();
    }
}
