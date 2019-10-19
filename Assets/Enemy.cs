using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private float speed = 0.7f;

    private Vector3 player;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Walk_Anim", true);
        player = Camera.main.transform.position;
        player.y = transform.position.y;


    }

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(
            transform.position,
            player,
            Time.deltaTime * speed);
    }
}
