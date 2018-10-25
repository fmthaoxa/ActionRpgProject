using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigibody;

    public bool isWalking;

    public float walkTime;
    private float walkTimeCounter;

    public float waitTime;
    private float waitTimeCounter;

    private int WalkDirection;

    public Collider2D walkZone;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private bool hasWalkZone;

    public bool canMove;

    private DialogueManager dialogueManger;

	// Use this for initialization
	void Start () {
        myRigibody = GetComponent<Rigidbody2D>();
        dialogueManger = FindObjectOfType<DialogueManager>();

        waitTimeCounter = waitTime;
        walkTimeCounter = walkTime;

        ChooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (dialogueManger.dialogueActive == false) {
            canMove = true;
        }

        if (!canMove)
        {
            myRigibody.velocity = Vector2.zero;
            return;
        }

        if (isWalking)
        {
            walkTimeCounter -= Time.deltaTime;


            switch (WalkDirection)
            {
                case 0:
                    myRigibody.velocity = new Vector2(0, moveSpeed);
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y) {
                        isWalking = false;
                        waitTimeCounter = waitTime;
                    }
                    break;
                case 1:
                    myRigibody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitTimeCounter = waitTime;
                    }
                    break;
                case 2:
                    myRigibody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitTimeCounter = waitTime;
                    }
                    break;
                case 3:
                    myRigibody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitTimeCounter = waitTime;
                    }
                    break;
            }

            if (walkTimeCounter < 0)
            {
                isWalking = false;
                waitTimeCounter = waitTime;
            }

        }

        else {
            waitTimeCounter -= Time.deltaTime;
            myRigibody.velocity = Vector2.zero;

            if (waitTimeCounter < 0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection() {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkTimeCounter = walkTime;
    }
}
