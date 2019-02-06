using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {

    private SpringJoint2D sj;
    private Rigidbody2D rb;
    public GameObject ResetPoint;
    private bool IsPressed;
    public float force;
    public bool CanBeLanched = true;

    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        sj = this.gameObject.GetComponent<SpringJoint2D>();
    }

    private void FixedUpdate()
    {
        CharacterDrag();
    }

    private void OnMouseDown()
    {
        IsPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        IsPressed = false;
        rb.isKinematic = false;
        Debug.Log("This is letting go");
        sj.attachedRigidbody.AddForce(Vector2.right * force);
        sj.enabled = false;
        CanBeLanched = false;
    }

    void CharacterDrag() {
        if (Input.GetMouseButton(0)){
            if (CanBeLanched == true) {
                Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rb.transform.position = MousePos;
            }
        }
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
