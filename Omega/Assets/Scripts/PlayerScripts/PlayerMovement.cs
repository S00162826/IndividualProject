using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public event System.Action OnLevelComplete;

    public float moveSpeed = 5;
    Rigidbody rb;

    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController theGun;

    public Text addAmmo;
    public float ammoPickUp;

    public float mediPackTimer;

    bool disabled;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        FieldOfViewDetection.PlayerSpotted += Disable;
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        Time.timeScale = 0;
        if (!disabled)
        {
            Time.timeScale = 1;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            movement = new Vector3(horizontal * moveSpeed * Time.deltaTime,
                                          0, vertical * moveSpeed * Time.deltaTime);

            moveVelocity = movement * moveSpeed;

            rb.MovePosition(transform.position + movement);
            
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;
        
            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

            if (Input.GetMouseButtonDown(0) && theGun.ammo > 0)
            {
                theGun.isFiring = true;
            }

            if (Input.GetMouseButtonUp(0))
                theGun.isFiring = false;


        }
    }

    private void Disable()
    {
        disabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AmmoCrate")
        {
            theGun.ammo = theGun.ammo + ammoPickUp;
            Destroy(other.gameObject);
            addAmmo.text = "+" + ammoPickUp.ToString();
            Destroy(addAmmo, 5f);
        }

        if (other.gameObject.tag == "Heal")
        {
            Destroy(other.gameObject, mediPackTimer);
        }

        if (other.gameObject.tag == "EnemyBullet")
        {
          
        }

        if (other.tag == "Finish")
        {
            Disable();
            if (OnLevelComplete != null)
            {
                OnLevelComplete();
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }

    private void OnDestroy()
    {
        FieldOfViewDetection.PlayerSpotted -= Disable;
    }

}

