using UnityEngine;

public class InstantiationInteraction : MonoBehaviour
{

    private GameObject mainCamera;

    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectileSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = FindFirstObjectByType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectile, projectileSpawn.transform.position, mainCamera.transform.rotation);
        }
    }
}
