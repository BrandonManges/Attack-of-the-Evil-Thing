using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float playerDistance;
    
    [SerializeField] float chaseRange = 5f, attackRange = 1f, speed = 2.5f;

    private GameObject player;

    private Vector3 idlePos = Vector3.zero;
    
    [SerializeField] float knockbackTime = 0.5f;
    
    private bool isKnockedBack = false;
    
    private Rigidbody rb;

    [SerializeField] float attackCooldown = 1f;
    
    private float attackTimer;
    
    private PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        idlePos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.linearDamping = 5f;
        playerHealth = player.GetComponentInParent<PlayerHealth>();
        attackTimer = 0f;


        Debug.Log("PlayerHealth ref = " + playerHealth);

    }

    void RecoverFromKnockback()
    {
        rb.linearVelocity = Vector3.zero; 
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        isKnockedBack = false;
    }

    public void ApplyKnockback(Vector3 force)
    {
        CancelInvoke(nameof(RecoverFromKnockback));

        isKnockedBack = true;

        rb.AddForce(force, ForceMode.Impulse);

        Invoke(nameof(RecoverFromKnockback), knockbackTime);
    }

    void OnEnable()
    {
        player = GameObject.FindWithTag("Player");

        idlePos = transform.position;

        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        attackTimer = 0f;
        isKnockedBack = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (isKnockedBack) return;

        var playerLoc = player.transform.position;
        Debug.Log("Distance to player: " + playerDistance);
        playerDistance = Vector3.Distance(playerLoc, transform.position);

        // ALWAYS tick cooldown ONCE
        attackTimer -= Time.deltaTime;
        if (attackTimer < 0f)
            attackTimer = 0f;

        if (playerDistance < attackRange)
        {
            transform.LookAt(playerLoc, transform.up);

            if (attackTimer <= 0f)
            {
                Debug.Log("Attacking Player");
                Debug.Log("PlayerHealth = " + playerHealth);

                playerHealth.TakeDamage(1);
                attackTimer = attackCooldown;
            }
        }
        else if (playerDistance < chaseRange)
        {
            Debug.Log("Chasing Player");
            transform.LookAt(playerLoc, transform.up);

            var moveVector = transform.forward * Time.deltaTime * speed;
            var correctedVector = new Vector3(moveVector.x, 0f, moveVector.z);

            rb.MovePosition(rb.position + correctedVector);
        }
        else if (Vector3.Distance(transform.position, idlePos) > .25f)
        {
            Debug.Log("Going to Idle");
            transform.LookAt(idlePos);

            var moveVector = transform.forward * Time.deltaTime * speed;
            var correctedVector = new Vector3(moveVector.x, 0f, moveVector.z);

            rb.MovePosition(rb.position + correctedVector);
        }


    }
}
