using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {

    private SpringJoint2D sj;
    private Rigidbody2D rb;
    private Rigidbody2D SlingRb;
    private LineRenderer LRender;
    public GameObject ResetPoint;

    private bool IsPressed;
    public bool CanBeLanched = true;

    private float MaxDist = 2f;
    private float delay;

    void Awake () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        sj = this.gameObject.GetComponent<SpringJoint2D>();
        LRender = this.gameObject.GetComponent<LineRenderer>();

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
        LRender.enabled = true;
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

    private void SetLRenderPos() {
        Vector3[] Positions = new Vector3[2];
        Positions[0] = rb.position;
        Positions[1] = SlingRb.position;
        LRender.SetPositions(Positions);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform") {
            this.gameObject.transform.position = ResetPoint.transform.position;
            sj.enabled = true;
            CanBeLanched = true;
            }
    }
}
