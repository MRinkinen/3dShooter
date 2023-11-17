using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public float speed;
    public bool isAlive;
    public bool isMoving;

    void Start()
    {
        isAlive = true;
        player = GameObject.FindGameObjectWithTag("Player");
        animator.SetBool("run", true);
    }
    void Update()
    {
        if (isAlive == true && isMoving == true)
        {
            gameObject.transform.LookAt(player.transform.position);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 1f)
        {
            isMoving = false;
            animator.SetTrigger("attack");
        }
        else
        {
            isMoving = true;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            animator.SetTrigger("die");
            isAlive = false;
            Destroy(gameObject, 5);
        }
        if (other.gameObject.CompareTag("Player"))
        {


        }
    }

}
