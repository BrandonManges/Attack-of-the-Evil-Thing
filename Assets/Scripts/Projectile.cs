using UnityEngine;

public class Projectile : MonoBehaviour
{

    private float timer = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 1500f);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
