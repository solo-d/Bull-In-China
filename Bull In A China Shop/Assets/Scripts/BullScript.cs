using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public partial class BullScript : MonoBehaviour
{
    private Vector3 startPosition = new Vector3(8.74f, 1f, 3.46f);

    private IEnumerator bullMovement_coroutine;

    private bool dazed;

    private bool seeking;

    private Quaternion newTargetAngle;

    private Animator animator;

    // This is the bull initial direction after entering the shop.
    public float horizontalDir, verticalDir;
    
    Vector3 forward, right;    // Keeps track of our relative forward and right vectors

    void OnCollisionEnter(Collision collision)
    {

        var collidedWith = collision.gameObject; // Get the object that the bull collided with
        
        if (collidedWith.tag == "Floor") return;
        if (collidedWith.tag == "Wall")
        {
            //Debug.Log("Collided with Wall.");

            BullStop();
        };
        if (collidedWith.tag == "Shelf")
        {
            //Debug.Log("Collided with shelf.");
            StopCoroutine(bullMovement_coroutine);

            ChangeRotation("");
        };
        if (collidedWith.tag == "Trap") return;
    }
    
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float rotationSpeed = 100.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        BullInit();
    }

    void Update()
    {
        //var delta = Time.deltaTime;
        //if(dazed) return;
        //if (seeking)
        //{
        //    Debug.Log(delta);
        //    this.Seek(delta);
        //    return;
        //}
    }

    // Whatever starts the level should call 
    public void BullInit()
    {
        forward = Camera.main.transform.forward; // Set forward to equal the camera's forward vector
        forward.y = 0; // make sure y is 0
        forward = Vector3.Normalize(forward); // make sure the length of vector is set to a max of 1.0
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward; // set the right-facing vector to be facing right relative to the camera's forward vector   


        horizontalDir = -0.3f;
        verticalDir = 0.3f;

        animator = GetComponent<Animator>();
        animator.enabled = false;

        ToggleDoors(true);

        // We want the bull to start at the doorway
        this.transform.position = startPosition;
        this.transform.rotation = Quaternion.Euler(0, 0, 0);

        // We will calculate the bull running speedy based on the size of the man divided by 30 seconds. 
        // The bull should be able travel from one end of the map to teh other in 30 seconds
        Vector3 levelSize = GameObject.Find("Terrain").GetComponent<Terrain>().terrainData.size;
        float playingField = (levelSize.x * levelSize.z);
        moveSpeed = (playingField) / 60;
        BullRun(3.0f);
        ToggleDoors(false);
    }

    private void ToggleDoors(bool showDoors) 
    {
        //GameObject doors = GameObject.FindWithTag("Door");
        //doors.SetActive(showDoors);
    }

    public void BullRun(float timeDelay = 0.0f)
    {
        Debug.Log("Start Bull Run.");
        bullMovement_coroutine = MoveBull(timeDelay);
        StartCoroutine(bullMovement_coroutine);
    }

    public void BullStop()
    {
        animator.enabled = false;
        StopCoroutine(bullMovement_coroutine);
        this.dazed = true;
        animator.SetBool("Collided", true);
        animator.SetBool("Reset", false);
        ChangeRotation("");
        StartCoroutine(WaitSeconds(1.0f));

    }

    public void WakeBull()
    {
        this.dazed = false;
        this.seeking = true;
        var animator = GetComponent<Animator>();
        animator.SetBool("Collided", false);        
    }

    public void Seek(float deltaTime)
    {
        // this.transform.Rotate(0f, 1f* rotationSpeed, 0f, Space.World);

        this.transform.Rotate(Vector3.up, rotationSpeed * deltaTime);
        //*rotationSpeed*deltaTime
    }

    /// <summary>
    /// This will change the default speed of the object. 
    /// </summary>
    /// <param name="changeSpeedBy">A positive number will incress the spead of the object. a negative number will decrease the speed of the object.</param>
    public void ChangeSpeed(int changeSpeedBy) {
		moveSpeed = moveSpeed + changeSpeedBy;
	}

	public void ChangeStamina(int changeStaminaBy) { }

	public void ChangeRotation(string turnDirection) {
        //int i = 35;// Random.Range(0, 45);
        //Debug.Log("Rotate " + i + " degrees in the Y direction.");
        //for (; i > 0;i--)
        //{
        //    this.Seek(0.1f);            
        //}
        //switch (turnDirection.ToLower())
        switch("right_45")
        {
            case "left_45":
                horizontalDir = -0.3f;
                verticalDir = 0f;
                break;
            case "left_90":
                horizontalDir = -0.3f;
                verticalDir = -0.3f;
                Move(0.1f);
                break;
            case "left_135":
                horizontalDir = 0f;
                verticalDir = -0.3f;
                break;
            case "right_45":
                horizontalDir = 0f;
                verticalDir = 0.3f;
                break;
            case "right_90":
                horizontalDir = 0.3f;
                verticalDir = 0.3f;
                break;
            case "right_135":
                horizontalDir = 0.3f;
                verticalDir = 0f;
                break;
            case "reverse":
                horizontalDir = 0.3f;
                verticalDir = -0.3f;
                break;
        };

        this.seeking = false;
        var animator = GetComponent<Animator>();

        BullRun(2.0f);
        this.dazed = false;

        animator.SetBool("Reset", true);
        animator.SetBool("Collided", false);
    }


    //This is a coroutine that moves the bull
    IEnumerator WaitSeconds(float timeToWait)
    {
        Debug.Log("Wait " + timeToWait + " seconds.");
        yield return new WaitForSeconds(timeToWait);        
    }

    //This is a coroutine that moves the bull
    IEnumerator MoveBull(float initialWait)
    {
        //Debug.Log("Start Wait() function. The time is: " + Time.time);
        //Debug.Log("Float duration = " + initialWait);
            
            yield return new WaitForSeconds(initialWait);
        animator.enabled = true;

        //Debug.Log("End Wait() function and the time is: " + Time.time);
        //Debug.Log("Start Moving now");
        for (; ; )
        {
            yield return new WaitForSeconds(.1f);
            Move(0.1f);            
        }
    }

    void Move(float timeDelta)
	{
        //transform.Translate(this.transform.forward*moveSpeed*timeDelta, Camera.main.transform);

        Vector3 direction = new Vector3(horizontalDir, 0, verticalDir); // setup a direction Vector based on keyboard input. GetAxis returns a value between -1.0 and 1.0. If the A key is pressed, GetAxis(HorizontalKey) will return -1.0. If D is pressed, it will return 1.0
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * horizontalDir; // Our right movement is based on the right vector, movement speed, and our GetAxis command. We multiply by Time.deltaTime to make the movement smooth.
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * verticalDir; // Up movement uses the forward vector, movement speed, and the vertical axis inputs.
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement); // This creates our new direction. By combining our right and forward movements and normalizing them, we create a new vector that points in the appropriate direction with a length no greater than 1.0
        transform.forward = heading; // Sets forward direction of our game object to whatever direction we're moving in
        transform.position += rightMovement; // move our transform's position right/left
        transform.position += upMovement; // Move our transform's position up/down
    }
}
