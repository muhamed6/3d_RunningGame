using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    public float moveSpeed = 5;

    public float leftRightSpeed = 4;
    static public bool canMove = false;

    public bool isJumping = false;
    public bool comingDown = false;

    public GameObject playerObject;
    public LevelDistance levelDistance;

    // Update is called once per frame

    void Start()
    {
        // Optionally, find the LevelDistance component if you don't set it in the editor
        levelDistance = FindObjectOfType<LevelDistance>();
    }

    void Update()
    {

        if (levelDistance != null && levelDistance.disRun % 30 == 0)
        {

            moveSpeed += 0.04f;
        }

        transform.Translate(Vector3.forward *Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true)
        {

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundry.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }

            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundry.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }

            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.Space))
            {
                if (isJumping==false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());

                }

            }

        }
        if(isJumping==true) 
        {
         if(comingDown==false) 
            
            {
             transform.Translate(Vector3.up* Time.deltaTime * 5 , Space.World);
            }

         if(comingDown==true) 
            
            {
             transform.Translate(Vector3.up* Time.deltaTime * -5 , Space.World);
            }
        }
    
    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping=false;
        comingDown=false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
}
