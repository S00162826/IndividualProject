using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public event System.Action OnLevelComplete;
    public event System.Action LaserContact;

    bool disablePlayer = false;

    private float moveSpeed = 5000;
    Rigidbody rb;

    private Vector3 moveVelocity;

    public Camera mainCamera;
    //public Camera fpsCamera;
    
    public GunController theGun;

    public Text addAmmo;
    public float ammoPickUp;

    public bool canCrawl;

    public float mediPackTimer;

    bool disabled;

    private BoxCollider boxCollider;
   // public GameObject crawling;
    public GameObject gun;
    private bool isCrawling = false;
    public bool cansStand = true;
    private MeshRenderer MeshRenderer;
    private SkinnedMeshRenderer SkinMeshRenderer;

    public Animator animator;
    public Animator playerAnimator;
    public Image Black;

    bool walking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = /*FindObjectOfType<Camera>();*/ GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        FieldOfViewDetection.PlayerSpotted += Disable;
        Pause.GameIsPaused += Disable;
        FinalPause.GameIsPaused += Disable;
        Pause.GameIsUnPaused += RemoveDisabling;
        FinalPause.GameIsUnPaused += RemoveDisabling;
        boxCollider = GetComponent<BoxCollider>();
        MeshRenderer = GetComponent<MeshRenderer>();
        SkinMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        animator = GetComponent<Animator>();
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        //playerAnimator.SetBool("IsWalking", false);
    }

    IEnumerator Fading()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => Black.color.a == 1);
    }

    void Update()
    {
        //Time.timeScale = 0;
        

        if (!disabled)
        {
            Time.timeScale = 1;
            //disablePlayer = false;
            if (cansStand == true)
                Standing();
            if (Input.GetKey("w") ||
                Input.GetKey("a") ||
                Input.GetKey("s") ||
                Input.GetKey("d"))
            {
                playerAnimator.SetBool("IsWalking", true);
            }
            else
            {
                playerAnimator.SetBool("IsWalking", false);

            }

            


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
        disablePlayer = true;
        disabled = true;
    }

    private void RemoveDisabling()
    {
        disablePlayer = false;

        disabled = false;
    }

    private void Standing()
    {
        
            if (canCrawl == true)
            {
                if (Input.GetKeyDown("c") && isCrawling == false)
                {
                    SkinMeshRenderer.enabled = false;
                    isCrawling = true;
                boxCollider.enabled = false;
                //boxCollider.size = new Vector3(1.0f, .3f, 1.0f);
                boxCollider.size = new Vector3(18.7f, 27.49f, 34.8f);
               boxCollider.center = new Vector3(1.0f, 12.94f, 1.0f);            
                //boxCollider.center = new Vector3(0f, -.34f, 0f);            
               // crawling.SetActive(true);
                    gun.SetActive(false);
                    moveSpeed = 2500;
                   // MeshRenderer.enabled = false;

                }
                else if (Input.GetKeyDown("c") && isCrawling == true)
                {
                    isCrawling = false;
                //boxCollider.size = new Vector3(1.0f, 1.0f, 1.0f);
                //boxCollider.size = new Vector3(1.0f, 1.0f, 1.0f);
                boxCollider.size = new Vector3(19.6f, 85.7f, 1.0f);
                boxCollider.center = new Vector3(1.0f, 44.8f, 1.0f);
               // crawling.SetActive(false);
                    gun.SetActive(true);
                    moveSpeed = 5000;
                  //  MeshRenderer.enabled = true;
                    SkinMeshRenderer.enabled = true;
            }

        }
        }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnableCrawling")
        {
            canCrawl = true;
        }

        if (other.gameObject.tag == "Laser")
        {
            Disable();
            if (LaserContact != null)
            {
                LaserContact();
            }

        }

        if (other.gameObject.tag == "AmmoCrate")
        {
            theGun.ammo = theGun.ammo + ammoPickUp;
            Destroy(other.gameObject);
            addAmmo.text = "+" + ammoPickUp.ToString();
            Destroy(addAmmo, 5f);
        }

        if (other.gameObject.tag == "Heal" && other.gameObject.tag != "FloorTrap")
        {
            Destroy(other.gameObject, mediPackTimer);
        }

        if (other.gameObject.tag == "NoStandZone")
        {
            cansStand = false;
            boxCollider.enabled = false;
        }

        if (other.gameObject.tag == "StandZone")
        {
            cansStand = true;
            boxCollider.enabled = true;
        }

        if (other.tag == "Finish")
        {
            //StartCoroutine(Fading());
            Disable();
            if (OnLevelComplete != null)
            {
                OnLevelComplete();
                disablePlayer = true;
                isCrawling = false;
                

            }
        }
    }



    void FixedUpdate()
    {
        //disablePlayer = false;

        if (disablePlayer == false)
        {
           // playerAnimator.SetBool("IsWalking", true);
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            rb.AddForce(new Vector3(horizontal * moveSpeed * Time.deltaTime,
                           0, vertical * moveSpeed * Time.deltaTime));
            rb.velocity = moveVelocity;
        }
        
    }

    private void OnDestroy()
    {
        FieldOfViewDetection.PlayerSpotted -= Disable;
    }

}

