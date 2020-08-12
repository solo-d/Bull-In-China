using UnityEngine;

public class AudioMusic : MonoBehaviour
{
    public AudioSource BGM;
    private bool enableSound;

    void Start()
    {
        bool.TryParse(PlayerPrefs.GetString("enableSound"), out enableSound);
    }

    public void changeBGM(AudioClip music)
    {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }

    /* 
     * Function to adjust volume and introduce new instruments
     * Get list of soundtracks
     * 
     */
}
