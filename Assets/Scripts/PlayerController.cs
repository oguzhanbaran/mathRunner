using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float time = 0f;
    TextMeshProUGUI skor;
    public ParticleSystem ps;
    public Animator animationController;
    public float jumpPower = 10.0f;
    public float speed = 10f;
    private Rigidbody rb;
    bool hareket;
    int skorSayisi = 0;
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    void Start()
    {
        dragDistance = Screen.height * 5 / 100;
        skor = GameObject.Find("Canvas/Sayac").GetComponent<TextMeshProUGUI>();
        skor.text = "0";
        ps.Play();
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Hareket();  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Gem")
        {  
            Destroy(collision.gameObject);
        }
       
    }
    private void Hareket()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {
                       
                            if ((lp.x > fp.x))  //If the movement was to the right)
                            {
                                rb.velocity = Vector3.right * 6.5f;
                            }
                            else
                            {   //Left swipe
                                rb.velocity = Vector3.left * 6.5f;
                            }
                        
                            
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            if (transform.position.y < 0)
                            {
                                animationController.SetBool("Zipla", true);
                                rb.velocity = Vector3.up * jumpPower;
                                Invoke("ZiplamaIptal", 0.5f);
                            }
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
      
        }
        transform.Translate(0,0,speed*Time.deltaTime);
    }
    public void ZiplamaIptal()
    {
        animationController.SetBool("Zipla", false);
    }
}
