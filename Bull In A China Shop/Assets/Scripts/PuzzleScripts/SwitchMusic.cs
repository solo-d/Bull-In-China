using UnityEngine;

public class SwitchMusic : MonoBehaviour
{
    public AudioClip newTrack;
    private AudioMusic theAM;
    public bool gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        theAM = FindObjectOfType<AudioMusic>();
        GetComponent<WinScript>().checkWin = gameStatus;
        gameStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus == false)
        {
            gameStatus = true;
            if (newTrack != null)
                theAM.changeBGM(newTrack);
            Debug.Log(gameStatus);
        }
    }
}
