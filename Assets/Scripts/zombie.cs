using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public bool isAlive;
    public bool isMoving;
    public NavMeshAgent agent;
    public AudioSource zombieAudio;

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
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * GameManager.Instance.zombieSpeed);
            //Vector3 playerPos = new Vector3(player.transform.position.x, 1, player.transform.position.z);
            //agent.Move(playerPos);
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
            zombieAudio.Play();
            animator.SetTrigger("die");
            isAlive = false;
            GameManager.Instance.score += 1;
            Destroy(gameObject.GetComponent<CapsuleCollider>());
            Destroy(gameObject, 5);
        }
        if (other.gameObject.CompareTag("Player"))
        {


        }
    }

}
