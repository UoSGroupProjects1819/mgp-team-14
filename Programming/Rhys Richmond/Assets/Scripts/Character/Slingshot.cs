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
    //public GameObject LRenderProjectile;

    public Text Countertext;
    private bool IsPressed;
    public bool CanBeLanched = true;

    private float MaxDist = 2f;
    private float delay;
    public float ResetSlingShotDelay;

    private int CollectibleCounter;

    void Awake () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        sj = this.gameObject.GetComponent<SpringJoint2D>();
        LRender = this.gameObject.GetComponent<LineRenderer>();
        //LRenderProjectile = GameObject.FindGameObjectWithTag("PathRender");
        //ProjectileRender = LRenderProjectile.GetComponent<LineRenderer>();

        SlingRb = sj.connectedBody;
        LRender.enabled = false;

        delay = 1 / (sj.frequency * 4);
    }

    private void FixedUpdate()
    {
        CharacterDrag();
    }

    private void OnMouseDown()
    {
        IsPressed = true;
        rb.isKinematic = true;
        //LRender.enabled = true;
    }

    private void OnMouseUp()
    {
        IsPressed = false;
        rb.isKinematic = false;
        CanBeLanched = false;
        LRender.enabled = false;
        StartCoroutine(Release());
    }

    void CharacterDrag() {
        if (IsPressed){
            if (CanBeLanched == true) {
                LRender.enabled = true;
                SetLRenderPos();
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
        sj.enabled = false;

    }

    private IEnumerator BackToSlingShot() {
        yield return new WaitForSeconds(ResetSlingShotDelay);
        LinkPoint.transform.position = ResetPoint.transform.position;
        rb.isKinematic = true;
        sj.enabled = true;
        CanBeLanched = true;
        rb.isKinematic = false;

    }

    private void SetLRenderPos() {
        Vector3[] Positions = new Vector3[2];
        Positions[0] = rb.position;
        Positions[1] = SlingRb.position;
        LRender.SetPositions(Positions);
    }

    //Pure testing to allow to see the projectile path when testing.
    private void SettingProjectilePos()
    {
        Vector3[] Positions = new Vector3[2];
        Positions[0] = rb.position;
        Positions[1] = SlingRb.position;
        ProjectileRender.SetPositions(Positions);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform") {

            LinkPoint.transform.position = ResetPoint.transform.position;
            collision.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(BackToSlingShot());
        } else if (collision.tag == "Collectible")
        {
            CollectibleCounter += 1;
            collision.gameObject.SetActive(false);
            Countertext.text = ("Coins:" + CollectibleCounter);
        }
    }


}
