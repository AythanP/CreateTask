/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: Very basic back and forth behavior for an enemy or thing.
 * Additional contributer: Aythan Pao
 * Last modified: 1-16-24
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float speed;
    public bool movingRight = false;

    public Transform frontDetection;
    public Transform backDetection;

    private Rigidbody2D myRB;

    public float groundRayDist = 2f;
    public float wallRayDist = 0.2f;

    // added to keep track of original position
    private Vector3 originalPos;
    public PlayerCollisionWithEnemyScript PCES;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir;
    
        if (movingRight)
        {
            moveDir = Vector2.right;

        }
        else
        {
            moveDir = -Vector2.right;
        }

        myRB.AddForce(moveDir * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(frontDetection.position, Vector2.down, groundRayDist);
        RaycastHit2D backGroundInfo = Physics2D.Raycast(backDetection.position, Vector2.down, groundRayDist);
        RaycastHit2D wallInfo = Physics2D.Raycast(frontDetection.position, moveDir, wallRayDist);
        RaycastHit2D backWallInfo = Physics2D.Raycast(backDetection.position, -moveDir, wallRayDist);
        //make sure that it can keep going a direction or switch, or just stop turning if trapped on both sides
        //if there wasn't a back check it would spaz if pushed into a strange place
        //print("Groundinfo " + (groundInfo.collider == false).ToString());
        //print("backgroundinfo " + (backGroundInfo.collider != false).ToString());
        //print("wallinfo " +  (wallInfo.collider != false).ToString());
        //print("backwallinfo " +  (backWallInfo.collider == false).ToString());
        if ((groundInfo.collider == false || wallInfo.collider != false) && (backGroundInfo.collider == true && backWallInfo.collider != true))
        {
           
            movingRight = !movingRight;
            transform.eulerAngles += new Vector3(0, 180, 0);
        }

        // if the player dies the enemies will return to their original position
        if (PCES != null && PCES.reset == true)
        {
            transform.position = originalPos;
        }
    }
}
