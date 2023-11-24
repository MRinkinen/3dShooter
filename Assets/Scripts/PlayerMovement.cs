using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerInput playerInput;
    public Animator animator;
    public Rigidbody rb;
    public float shootCoolDown;
    public float moveSpeed;
    public float inputMovement;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public Transform barrel;
    public AudioSource audioSource;
    public bool isAlive = true;

    void FixedUpdate()
    {
        if (isAlive)
        {
            HandleMovement();
            HandleMouseLook();
            HandleShooting();
        }

    }
    void HandleShooting()
    {
        shootCoolDown += Time.deltaTime;
        if (playerInput.actions["fire"].IsPressed() && shootCoolDown > 0.5f)
        {
            audioSource.Play();
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, barrel.position, barrel.transform.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

            animator.SetTrigger("shoot");
            shootCoolDown = 0;
        }
    }
    void HandleMovement()
    {
        // New Input systemin liikkuminen
        float horizontal = playerInput.actions["Move"].ReadValue<Vector2>().x;
        float vertical = playerInput.actions["Move"].ReadValue<Vector2>().y;

        gameObject.transform.Translate(Vector3.forward * moveSpeed * vertical * Time.deltaTime);
        gameObject.transform.Translate(Vector3.right * moveSpeed * horizontal * Time.deltaTime);

        if (vertical != 0)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }
    void HandleMouseLook()
    {
        float horizontal = playerInput.actions["Look"].ReadValue<Vector2>().x;
        gameObject.transform.Rotate(0, horizontal, 0);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("zombie"))
        {
            GameManager.Instance.gameOverText.gameObject.SetActive(true);
            isAlive = false;
        }

    }
}
