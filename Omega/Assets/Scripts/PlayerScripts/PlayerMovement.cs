using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public event System.Action OnLevelComplete;

    private float moveSpeed = 3;
    Rigidbody rb;

    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController theGun;

    public Text addAmmo;
    public float ammoPickUp;

    public float mediPackTimer;

    bool disabled;

    private BoxCollider boxCollider;
    public GameObject crawling;
    public GameObject gun;
    private bool isCrawling = false;
    private bool cansStand = true;
    private MeshRenderer MeshRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        FieldOfViewDetection.PlayerSpotted += Disable;
        boxCollider = GetComponent<BoxCollider>();
        MeshRenderer = GetComponent<MeshRenderer>();
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

            //
            if(cansStand == true)
            Standing();
        }

    }

    private void Disable()
    {
        disabled = true;
    }

    private void Standing()
    {
        if (Input.GetKeyDown("c") && isCrawling == false)
        {

            isCrawling = true;
            boxCollider.size = new Vector3(1.0f, .2f, 1.0f);
            crawling.SetActive(true);
            gun.SetActive(false);
            moveSpeed = 1;
            MeshRenderer.enabled = false;
        }
        else if (Input.GetKeyDown("c") && isCrawling == true)
        {
            isCrawling = false;
            boxCollider.size = new Vector3(1.0f, 1.0f, 1.0f);
            crawling.SetActive(false);
            gun.SetActive(true);
            moveSpeed = 3;
            MeshRenderer.enabled = true;

        }
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

        if (other.gameObject.tag == "NoStandZone")
        {
            cansStand = false;

        }

        if (other.gameObject.tag == "StandZone")
        {
            cansStand = true;

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

