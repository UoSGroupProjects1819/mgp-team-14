using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slingshot : MonoBehaviour {

    private SpringJoint2D sj;

    private Rigidbody2D rb;
    private Rigidbody2D SlingRb;

    private LineRenderer LRender;
    private LineRenderer ProjectileRender;

    public GameObject ResetPoint;
    public GameObject LinkPoint;
    public GameObject EndScreen;

    public GameObject PreviousPlatform;

    private GameObject CoinCollectObject;
    private GameObject JumpCollectObject;
    private GameObject JumpedCollectObject;
    private GameObject CoinCollectedObject;
    //public GameObject LRenderProjectile;

    public Text Countertext;
    public Text SlingShotCounterText;

    public Text EndScreenCounterText;
    public Text EndScreenSlingShotText;

    private bool IsPressed;
    public bool CanBeLanched = true;
    public bool CanBeClicked = true;
    public bool CanBeLaunched = true;

    private float MaxDist = 2f;
    private float delay;
    public float ResetSlingShotDelay;

    public int CollectibleCounter;
    public int SlingShotTimes;

    public GameObject PlayerLaunchLocation;

    void Awake () {
        //PlayerLaunchLocation = ResetPoint.transform;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        sj = this.gameObject.GetComponent<SpringJoint2D>();
        LRender = this.gameObject.GetComponent<LineRenderer>();

        CoinCollectObject = GameObject.Find("CollectibleText");
        JumpCollectObject = GameObject.Find("SlingshotCounter");
        JumpedCollectObject = GameObject.Find("JumpedText");
        CoinCollectedObject = GameObject.Find("CoinsCollected");
        EndScreen = GameObject.Find("LevelCompleteCanvas");
        PreviousPlatform = GameObject.Find("StartingPlatform");

        Countertext = CoinCollectObject.GetComponent<Text>();
        SlingShotCounterText = JumpCollectObject.GetComponent<Text>();
        EndScreenCounterText = CoinCollectedObject.GetComponent<Text>();
        EndScreenSlingShotText = JumpedCollectObject.GetComponent<Text>();


        EndScreen.SetActive(false);

        PlayerLaunchLocation = GameObject.Find("PlayerReset");

        SlingRb = sj.connectedBody;
        LRender.enabled = false;

        delay = 1 / (sj.frequency * 4);
    }

    private void FixedUpdate()
    {
        CharacterDrag();
        SlingShotCounterText.text = ("Jumps: " + SlingShotTimes);
        EndScreenCounterText.text = ("" + CollectibleCounter);
        EndScreenSlingShotText.text = ("" + SlingShotTimes);
        //PlayerLaunchLocation.transform.position = this.gameObject.transform.position;
    }

    private void OnMouseDown()
    {
        if (CanBeClicked == true)
        {
            IsPressed = true;
            rb.isKinematic = true;
            CanBeClicked = false;
            CanBeLaunched = true;
        }
        //LRender.enabled = true;
    }

    private void OnMouseUp()
    {
        if (CanBeLaunched)
        {
            IsPressed = false;
            rb.isKinematic = false;
            //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            LRender.enabled = false;
            StartCoroutine(Release());
            if (CanBeClicked == false)
            {
                CanBeLanched = false;
            }
            sj.enabled = true;
            CanBeLaunched = false;
        }
        

    }

    void CharacterDrag() {
        if (IsPressed){
            if (CanBeLanched == true) {
                LRender.enabled = true;
                SetLRenderPos();
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float CurrentDist = Vector2.Distance(MousePos, SlingRb.position);
                if (CurrentDist > MaxDist)
                {
                    Vector2 direction = (MousePos - SlingRb.position).normalized;
                    rb.position = SlingRb.position + direction * MaxDist;
                }
                else {
                    rb.position = MousePos;
                }
            }
        }
    }
    private IEnumerator Release() {
        yield return new WaitForSeconds(delay);
        SlingShotTimes += 1;
        PlayerLaunchLocation.transform.position = this.gameObject.transform.position;
        sj.enabled = false;
        PreviousPlatform.GetComponent<BoxCollider2D>().enabled = true;


    }

    private IEnumerator BackToSlingShot() {
        yield return new WaitForSeconds(ResetSlingShotDelay);
        rb.isKinematic = true;
        sj.enabled = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        this.gameObject.transform.position = LinkPoint.transform.position;
        LinkPoint.transform.position = ResetPoint.transform.position;
        rb.isKinematic = false;
        CanBeClicked = true;
        CanBeLanched = true;
        CanBeLaunched = true;



    }

    private void SetLRenderPos() {
        Vector3[] Positions = new Vector3[2];
        Positions[0] = rb.position;
        Positions[1] = SlingRb.position;
        LRender.SetPositions(Positions);
    }

    //Pure testing to allow to see the projectile path when testing.
    // This has already been cut as it wasn't drawing correctly.
    private void SettingProjectilePos()
    {
        Vector3[] Positions = new Vector3[2];
        Positions[0] = rb.position;
        Positions[1] = SlingRb.position;
        ProjectileRender.SetPositions(Positions);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {

            LinkPoint.transform.position = collision.transform.GetChild(0).position;
            //collision.transform.GetChild(0);
            PreviousPlatform = collision.gameObject;
            collision.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(BackToSlingShot());
        }
        else if (collision.tag == "Collectible")
        {
            CollectibleCounter += 1;
            collision.gameObject.SetActive(false);
            Countertext.text = ("Coins:" + CollectibleCounter);
        }
        else if (collision.tag == "FinishPlatform")
        {
            EndScreen.SetActive(true);
        }
        else if (collision.tag == "PlayerFalling")
        {
            Debug.Log("Does something");
            this.gameObject.transform.position = PlayerLaunchLocation.transform.position;
            StartCoroutine(BackToSlingShot());
        }
       
    }


}
