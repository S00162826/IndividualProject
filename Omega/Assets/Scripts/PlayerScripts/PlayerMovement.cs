using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public event System.Action OnLevelComplete;

    private float moveSpeed = 5000;
    Rigidbody rb;

    private Vector3 moveVelocity;

    public Camera mainCamera;
    //public Camera fpsCamera;
    
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
    //private SkinnedMeshRenderer SkinMeshRenderer;

    public Animator animator;
    //public Animator playerAnimator;
    public Image Black;

    bool walking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = /*FindObjectOfType<Camera>();*/ GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        FieldOfViewDetection.PlayerSpotted += Disable;
        Pause.GameIsPaused += Disable;
        boxCollider = GetComponent<BoxCollider>();
        MeshRenderer = GetComponent<MeshRenderer>();
        //SkinMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        animator = GetComponent<Animator>();
    }

    IEnumerator Fading()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => Black.color.a == 1);
    }

    void Update()
    {
        Time.timeScale = 0;
        if (!disabled)
        {
            Time.timeScale = 1;
            

            //if (Input.GetKeyDown("w") || 
            //    Input.GetKeyDown("a") || 
            //    Input.GetKeyDown("s") || 
            //    Input.GetKeyDown("d"))
            //{
            //    playerAnimator.SetBool("walking", true);
            //}
            //else if (!Input.GetKeyDown("w"))
            //{
            //    playerAnimator.SetBool("walking", false);

            //}

           // Vector3 movement = Vector3.zero;

            //float horizontal = Input.GetAxis("Horizontal");
            //float vertical = Input.GetAxis("Vertical");
            ///*movement =*/ rb.AddForce(new Vector3(horizontal * moveSpeed * Time.deltaTime,
            //                              0, vertical * moveSpeed * Time.deltaTime));
            //if (Input.GetKey(KeyCode.D))
            //{
            //    rb.AddForce(Vector3.right * moveSpeed);
            //}


           // moveVelocity = movement * moveSpeed;

            //rb.MovePosition(transform.position + movement);

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
            ///SkinMeshRenderer.enabled = false;
            isCrawling = true;
            boxCollider.size = new Vector3(1.0f, .3f, 1.0f);
            boxCollider.center = new Vector3(0f, -.34f, 0f);
            crawling.SetActive(true);
            gun.SetActive(false);
            moveSpeed = 2500;
            MeshRenderer.enabled = false;
          
        }
        else if (Input.GetKeyDown("c") && isCrawling == true)
        {
            isCrawling = false;
            boxCollider.size = new Vector3(1.0f, 1.0f, 1.0f);
            boxCollider.center = new Vector3(0f, 0f, 0f);
            crawling.SetActive(false);
            gun.SetActive(true);
            moveSpeed = 5000;
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
            StartCoroutine(Fading());
            Disable();
            if (OnLevelComplete != null)
            {
                OnLevelComplete();
            }
        }
    }



    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(horizontal * moveSpeed * Time.deltaTime,
                       0, vertical * moveSpeed * Time.deltaTime));
        rb.velocity = moveVelocity;
    }

    private void OnDestroy()
    {
        FieldOfViewDetection.PlayerSpotted -= Disable;
    }

}

