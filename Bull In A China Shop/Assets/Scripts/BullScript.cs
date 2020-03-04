using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public partial class BullScript : MonoBehaviour
{
    private Vector3 startPosition = new Vector3(8.74f, 0.69f, 3.46f);

    private IEnumerator bullMovement_coroutine;

    private bool dazed;

    private bool seeking;

    private Quaternion newTargetAngle;

    private Animator animator;

    void OnCollisionEnter(Collision collision)
    {

        var collidedWith = collision.gameObject; // Get the object that the bull collided with
        
        if (collidedWith.tag == "Floor") return;
        if (collidedWith.tag == "Wall")
        {
            Debug.Log("Collided with Wall.");

            BullStop();
        };
        if (collidedWith.tag == "Shelf")
        {
            Debug.Log("Collided with shelf.");
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
        animator = GetComponent<Animator>();
        animator.enabled = false;

        ToggleDoors(true);

        // We want the bull to start at the doorway
        this.transform.position = startPosition;

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
        this.transform.Rotate(Vector3.up, rotationSpeed*deltaTime);
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
        for (int i = Random.Range(0, 45); i > 0; i--)
        {
            this.Seek(0.1f);
        }

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
        Debug.Log("Start Wait() function. The time is: " + Time.time);
        Debug.Log("Float duration = " + initialWait);
            
            yield return new WaitForSeconds(initialWait);
        animator.enabled = true;

        Debug.Log("End Wait() function and the time is: " + Time.time);
        Debug.Log("Start Moving now");
        for (; ; )
        {
            yield return new WaitForSeconds(.1f);
            Move(0.1f);
            this.transform.rotation = new Quaternion(0, this.transform.rotation.y, 0, this.transform.rotation.w);
        }
    }

    void Move(float timeDelta)
	{
        transform.Translate(this.transform.forward*moveSpeed*timeDelta, Camera.main.transform);
    }
}
