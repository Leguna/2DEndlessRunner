using UnityEngine;

public class CharacterSoundController : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip scoreHighlight;

    private AudioSource _audioPlayer;


    private void Start()
    {
        _audioPlayer = GetComponent<AudioSource>();
    }

    public void PlayScoreHighlight()
    {
        _audioPlayer.PlayOneShot(scoreHighlight);
    }


    public void PlayJump()
    {
        _audioPlayer.PlayOneShot(jump);
    }
}
