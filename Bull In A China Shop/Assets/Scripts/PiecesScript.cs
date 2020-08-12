using System.Collections;
using UnityEngine;

public class PiecesScript : MonoBehaviour
{
    private Vector3 snapToCorrectPosition; //Snaps dropped piece to the correct location
    public bool CorrectPosition;
    public bool Selected;
    public GameObject WinMenu; //you fixed it menu
    public GameObject correctVisual;
    public float threshold;
    public bool vibCheck;
    private bool enableVib;
    public AudioSource dropPiece;
    public AudioClip soundFX;

    private bool coroutine_running = false;
    

    void Start()
    {
        //tag = GetComponent<WinScript>().ceramic;
        //pieces = GameObject.FindGameObjectsWithTag(tag);
        //plates = GameObject.FindGameObjectsWithTag("Plate");
        snapToCorrectPosition = transform.position;
        transform.position = new Vector3(Random.Range(-2f, 2), Random.Range(4f, 2)); //randomize pieces on the top side
        threshold = PlayerPrefs.GetFloat("threshold", 0.1f); //Originally 0.3f, Putting on Hard for testing
        Debug.Log("threshold " + threshold);
        vibCheck = bool.TryParse(PlayerPrefs.GetString("enableVib"), out enableVib);
        dropPiece = GetComponent<AudioSource>();
    }

    IEnumerator PlayDropAudio()
    {
        coroutine_running = true;
        dropPiece.clip = soundFX;
        dropPiece.Play();
        yield return new WaitForSeconds(dropPiece.clip.length);
        coroutine_running = false;
    }


    // Update is called once per frame
    void Update()
    {
        // If the piece is already inthe correct position we do not need to iterate through the logic. Just run away.
        if (CorrectPosition) { return; }

        if (Vector3.Distance(transform.position, snapToCorrectPosition) < threshold) //threshold before snapping
        {
            if (!Selected) //but this number keeps increasing because it is no longer selected
            {
                transform.position = snapToCorrectPosition; //if puzzle is placed correctly
                Debug.Log("Position is correct");
                CorrectPosition = true; //set this to true


                if (vibCheck == true)
                {
                    correctVisual.SetActive(true); //edgeParticles activated per piece
                    //Handheld.Vibrate(); //Vibrate whenever the top is activate
                    Debug.Log("Edge + Vibration");
                    StartCoroutine(PlayDropAudio());                     
                }
                else
                {
                    correctVisual.SetActive(true);
                    StartCoroutine(PlayDropAudio());
                }
            }
        }


        /*if (plates.All(x => x.GetComponent<PiecesScript>().CorrectPosition == true)) {
            Score = plates.Length;
            Debug.Log("You win!");
            //WinMenu.GetComponent<WinScript>().fixedIt();
    
        }*/


        //foreach (GameObject plates in plates) {
        //    if (plates.GetComponent<PiecesScript>().CorrectPosition)
        //    {
        //        Score++;
        //    }
        //    else { break; }
        //}

    }
}