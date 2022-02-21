using System;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float acceleration;
    public float steerPower;
    public float steerAmount;
    public float speed;
    public float direction;
    private bool arrow1entered = false;
    private bool arrow2entered = false;
    private bool arrow3entered = false;
    public GameObject passenger1;
    public GameObject passenger2;
    public GameObject passenger3;
    Rigidbody2D rb;

    public static event Action ArrowDrivenOver = delegate {};
    public static event Action RaceComplete = delegate {};

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       steerAmount = -Input.GetAxis("Horizontal");
       speed = Input.GetAxis("Vertical") * acceleration;
       direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
       rb.rotation += steerAmount * steerPower * rb.velocity.magnitude * direction;

       rb.AddRelativeForce(Vector2.up * speed);
       rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steerAmount / 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(arrow1entered && arrow2entered && arrow3entered && collision.tag.Equals("FinishLine"))
      {
        RaceComplete();
      }
      if(!arrow1entered && collision.tag.Equals("Arrow1"))
      {
        Destroy(passenger1);
        arrow1entered = true;
        ArrowDrivenOver();
      }
      if(!arrow2entered && collision.tag.Equals("Arrow2"))
      {
        Destroy(passenger2);
        arrow2entered = true;
        ArrowDrivenOver();
      }
      if(!arrow3entered && collision.tag.Equals("Arrow3"))
      {
        Destroy(passenger3);
        arrow3entered = true;
        ArrowDrivenOver();
      }
    }
}
