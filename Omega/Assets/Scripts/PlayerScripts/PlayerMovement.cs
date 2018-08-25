using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //This is so the win lose condition script know when to
    //activate certain methods
    public event System.Action OnLevelComplete;
    public event System.Action LaserContact;

    //Movement variables
    bool disabled;
    bool disablePlayer = false;
    public float moveSpeed = 5000;
    private Vector3 moveVelocity;
    Rigidbody rb;

    //To access objects
    public Camera mainCamera;   
    public GunController theGun;
    private BoxCollider boxCollider;
    public GameObject gun;
    private MeshRenderer MeshRenderer;
    private SkinnedMeshRenderer SkinMeshRenderer;
    public Animator animator;
    private Animator playerAnimator;
    public Image Black;

    //Ammo is in interaction with player
    //Text for display, float for how much
    public Text addAmmo;
    public float ammoPickUp;
    
    public float mediPackTimer;

    //To access audio objects
    AudioSource heal;
    AudioSource burning;
    AudioSource ammo;

    void Start()
    {
        //Finds the objects I want to assign to the variables
        rb = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
        heal = GameObject.FindGameObjectWithTag("HealthSFX").GetComponent<AudioSource>();
        burning = GameObject.FindGameObjectWithTag("BurningSFX").GetComponent<AudioSource>();
        ammo = GameObject.FindGameObjectWithTag("GunSFX").GetComponent<AudioSource>();
    }

    IEnumerator Fading()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => Black.color.a == 1);
    }

    void Update()
    {
        //Player can only move if disabled is false
        //This lets me pick time when I want the player 
        //to be uncontrollable e.g. when player dies
        if (!disabled)
        {
            Time.timeScale = 1;

            //Setting keys to set off animations
            //Simply use the same keys that move the player
            if (Input.GetKey("w") ||
                Input.GetKey("a") ||
                Input.GetKey("s") ||
                Input.GetKey("d") ||
                Input.GetKey("up") ||
                Input.GetKey("down") ||
                Input.GetKey("left") ||
                Input.GetKey("right")) 
            {
                playerAnimator.SetBool("IsWalking", true);
            }
            else
            {
                playerAnimator.SetBool("IsWalking", false);
            }


            //Determines where the player will face using camera and mouse positions
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

            //Gun only shoots when isFiring is true
            //Only true when left click on mouse and has more
            //than 0 bullets
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

    //All the trigger interactions
    //Determine what happen when the player enters these triggers
    void OnTriggerEnter(Collider other)
    {
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
            ammo.Play();
            theGun.ammo = theGun.ammo + ammoPickUp;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Heal" && other.gameObject.tag != "FloorTrap")
        {
            heal.Play();
            Destroy(other.gameObject, mediPackTimer);
        }

        if (other.gameObject.tag != "Heal" && other.gameObject.tag == "FloorTrap")
        {
            burning.Play();
        }

        if (other.gameObject.tag == "NoStandZone")
        {
            gun.SetActive(false);
            boxCollider.enabled = false;
        }

        if (other.gameObject.tag == "StandZone")
        {
            gun.SetActive(true);
            boxCollider.enabled = true;
        }

        if (other.tag == "Finish")
        {
            gameObject.SetActive(true);
            Disable();

            if (OnLevelComplete != null)
            {
                OnLevelComplete();
                disablePlayer = true;
            }
        }
    }

    void FixedUpdate()
    {
        //What determines how the player moves
        if (disablePlayer == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            rb.AddForce(new Vector3(horizontal * moveSpeed * Time.deltaTime,
                           0, vertical * moveSpeed * Time.deltaTime));
            rb.velocity = moveVelocity;
        }
        
    }

    private void OnDestroy()
    {
        //Uses PlayerSpotted for gameover and disable player
        FieldOfViewDetection.PlayerSpotted -= Disable;
    }

}

