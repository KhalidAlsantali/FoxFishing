using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{

    public GameObject anchor;
    public Animator animator;
    public SpriteRenderer rodSprite;

    public Sprite[] rods;

    public bool goDown = true;
    public bool goUp = false;
    public bool moving = false;
    public float rodSpeed;
    public bool fishCaught = false;
    public bool interactable = false;
    public bool fishInAnimation = false;
    public bool canGoUp = true;
    public bool canGoDown = true;
    public int rodType;
    public int valueModifier = 1;

    private void Start()
    {
        rodType = PlayerPrefs.GetInt("rodType");

        switch (rodType)
        {
            case 1: 
                valueModifier = 1;
                rodSpeed = 4f;
                rodSprite.sprite = rods[rodType - 1];
                break;
            case 2:
                rodSpeed = 15f;
                valueModifier = 1;
                rodSprite.sprite = rods[rodType - 1];
                break;
            case 3:
                valueModifier = 3;
                rodSpeed = 6.5f;
                rodSprite.sprite = rods[rodType - 1];
                break;
            case 4:
                valueModifier = 3;
                rodSpeed = 6.5f;
                rodSprite.sprite = rods[rodType - 1];
                break;
            case 5:
                valueModifier = 10;
                rodSpeed = 6.5f;
                rodSprite.sprite = rods[rodType - 1];
                break;
            case 6:
                valueModifier = 3;
                rodSpeed = 6.7f;
                rodSprite.sprite = rods[rodType - 1];
                break;

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            if (PlayerPrefs.GetInt("rodType") != 6)
            {
                if (fishCaught)
                {
                    moveUp();
                    UpdateCrank();
                    return;
                }

                if (Input.GetKeyDown(KeyCode.Space) && interactable)
                {
                    if (moving)
                    {
                        goDown = !goDown;
                        goUp = !goUp;
                        moving = !moving;
                    }
                    else
                    {
                        moving = !moving;
                    }

                    UpdateCrank();
                }

                if (goDown && moving && !fishInAnimation)
                {
                    moveDown();
                }
                else if (goUp && moving && !fishInAnimation)
                {
                    moveUp();
                }
            }
            else
            {
                AdvancedRodMovement();
            }
        }

    }

    void moveDown()
    {
        transform.Translate(Vector2.down * Time.deltaTime * rodSpeed);
        UpdateCrank();

    }

    void moveUp()
    {
        transform.Translate(Vector2.up * Time.deltaTime * rodSpeed);
        UpdateCrank();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<HingeJoint2D>() == null && !fishCaught && collision.gameObject.CompareTag("Fish"))
        {
            fishCaught = true;
            

            UpdateCrank();


            ContactPoint2D[] contact = new ContactPoint2D[1];
            collision.GetContacts(contact);

            HingeJoint2D hinge = collision.gameObject.AddComponent<HingeJoint2D>();
            hinge.autoConfigureConnectedAnchor = false;
            hinge.connectedBody = anchor.gameObject.GetComponent<Rigidbody2D>();
            hinge.connectedAnchor = contact[0].point;

            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

    }
    
    public void UpdateCrank()
    {
        animator.SetBool("goUp", goUp);
        animator.SetBool("goDown", goDown);
        animator.SetBool("Moving", moving);
        animator.SetBool("FishCaught", fishCaught);
    }

    public void NormalRodMovement()
    {
        if (fishCaught)
        {
            moveUp();
            UpdateCrank();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && interactable)
        {
            if (moving)
            {
                goDown = !goDown;
                goUp = !goUp;
                moving = !moving;
            }
            else
            {
                moving = !moving;
            }

            UpdateCrank();
        }

        if (goDown && moving && !fishInAnimation)
        {
            moveDown();
        }
        else if (goUp && moving && !fishInAnimation)
        {
            moveUp();
        }
    }

    public void AdvancedRodMovement()
    {

        if (fishCaught)
        {
            moveUp();
            UpdateCrank();
            return;
        }

        if (Input.GetAxisRaw("Vertical") < 0 && canGoDown)
        {
            moveDown();
        }

        else if (Input.GetAxisRaw("Vertical") > 0 && canGoUp)
        {
            moveUp();
        }

        UpdateCrank();

    }
}
