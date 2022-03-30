using System;
using UnityEngine;
using UnityEngine.UI;
public class Drive : MonoBehaviour
{
    public float acceleration;
    public float steerPower;
    public float steerAmount;
    public float speed;
    public float direction;
    private float boostTimer;
    private String slowedHexColor = "#6F5858";
    public Color slowedColor;
    private bool arrow1entered = false;
    private bool arrow2entered = false;
    private bool arrow3entered = false;
    private bool mudEntered = false;
    private bool boostEnabled = false;
    public GameObject passenger1;
    public GameObject passenger2;
    public GameObject passenger3;
    public Text speedText;
    Rigidbody2D rb;
    public static event Action ArrowDrivenOver = delegate {};
    public static event Action RaceComplete = delegate {};
    SpriteRenderer sprite;
    public SpriteRenderer selectedSprite;
    public GameObject selectedCar;
    public Animator animator;

  
    private void Start()
    {

        selectedCar.SetActive(false);
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = SkinManager.instance.carSprite;
        rb = GetComponent<Rigidbody2D>();
        ColorUtility.TryParseHtmlString(slowedHexColor, out slowedColor);
        DetermineCarType();
    }

    private void FixedUpdate()
    {
       steerAmount = -Input.GetAxis("Horizontal");
       DetermineSpeed();
       direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
       rb.rotation += steerAmount * steerPower * rb.velocity.magnitude * direction;

       rb.AddRelativeForce(Vector2.up * speed);
       rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steerAmount / 2);
       

    }


    private void LateUpdate(){

       if(speed<0){
         speedText.color = Color.red; 
       }else if(speed>0){
          speedText.color = Color.green; 
       }else{
          speedText.color = Color.white; 
       }
       speedText.text = ((int)speed*4).ToString()+  " km/h";
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
      if(collision.tag.Equals("Mud")){
        sprite.color = slowedColor;
        mudEntered = true;
      }
      if(collision.tag.Equals("Boost")){
        boostEnabled = true;
        animator.SetBool("TurboOn", true);
        Destroy(collision.gameObject);
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
    private void OnTriggerExit2D(Collider2D collision)
    {
      if(collision.tag.Equals("Mud")){
       sprite.color = Color.white;
       mudEntered = false;
      }
    }
    private void DetermineSpeed(){
      if(mudEntered)
        speed = Input.GetAxis("Vertical") * acceleration /2.5f;
      if(boostEnabled){
        speed = Input.GetAxis("Vertical") * acceleration * 2;
        boostTimer += Time.deltaTime;
        if(boostTimer >= 3){
          boostEnabled = false;
          animator.SetBool("TurboOn", false);
          boostTimer = 0;
        }
      }
      if(mudEntered && boostEnabled)
        speed = Input.GetAxis("Vertical") * acceleration * 0.5f;
      if(!mudEntered && !boostEnabled)
        speed = Input.GetAxis("Vertical") * acceleration;
    }
    private void DetermineCarType(){
      switch(SkinManager.instance.carSprite.ToString()){
        case "F1_car08":
          acceleration = 50;
          steerPower = 0.2f;
          break;
        case "F1_car07":
          acceleration = 45;
          steerPower = 0.3f;
          break;
        case "F1_car06":
          acceleration = 40;
          steerPower = 0.3f;
          break;
        case "F1_car05":
          acceleration = 45;
          steerPower = 0.4f;
          break;
        case "F1_car04":
          acceleration = 50;
          steerPower = 0.5f;
          break;
        case "F1_car03":
          acceleration = 30;
          steerPower = 0.2f;
          break;
        case "F1_car02":
          acceleration = 35;
          steerPower = 0.6f;
          break;
        case "F1_car01":
          acceleration = 55;
          steerPower = 0.8f;
          break;
      }
    }
}
