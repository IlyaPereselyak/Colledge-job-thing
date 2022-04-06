using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Audio;
 
public class PlayerController : MonoBehaviour
{
    AudioSource mine;
    AudioClip Explosion;
    Animation mineAnim;
    public float speed = 0;
    public TextMeshProUGUI score;
    public GameObject winTextObject;
    public GameObject deathTextObject;
    public GameObject finishTextObject;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private float jumpForce = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        //SetScore();
        //SetDeath();
        //SetFinish();
        winTextObject.SetActive(false);
        deathTextObject.SetActive(false);
        finishTextObject.SetActive(false);
        mine = GetComponent<AudioSource>();
        Explosion = mine.clip;
        mineAnim = GetComponent<Animation>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    public void SetScore()
    {
        score.text = "Score:" + count.ToString();
    }
    public void SetDeath()
    {
        if (GameObject.FindWithTag("Player"))
        {
            deathTextObject.SetActive(true);
        }
    }
    public void SetFinish()
    {
        if(GameObject.FindWithTag("Player"))
        {
           finishTextObject.SetActive(true);
        }
    }
    public void SetWin()
    {
        winTextObject.SetActive(true);
    }

    public void BlowUp()
    {
        mineAnim.Play("BlowUp");
        mine.Play();
    }
    public void Jump()
    {
        rb.AddForce(transform.up*jumpForce,ForceMode.Impulse);
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0.0f,movementY);
        rb.AddForce(movement*speed);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            ++count;
            SetScore();
        }
        if (other.gameObject.CompareTag("Finish") && count == 26)
        {
            Destroy(gameObject, .2f);
            Invoke("SetWin", 3f);
            SetWin();
            Invoke("SetFinish", 5f);
            SetFinish();
        }
    }
    private void OnCollisionEnter(Collision other2)
    {
        if (other2.gameObject.CompareTag("Door"))
        {
            Destroy(gameObject, .10f);
            Invoke("SetDeath", 5f);
            SetDeath();
        }
        if (other2.gameObject.CompareTag("Mine"))
        {
            rb.freezeRotation = true;
            rb.mass = 1000000000000;
            Invoke("BlowUp", 5f);
            BlowUp();
            Destroy(gameObject, .999f);
            Invoke("SetDeath", 10f);
            SetDeath();
        }
        if (other2.gameObject.CompareTag("FallingOf"))
        {
            Destroy(gameObject, .2f);
            Invoke("SetDeath", 10f);
            SetDeath();
        }
    }
}
