using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
  [SerializeField]
  AudioSource asHappy;
  [SerializeField]
  AudioSource asScared;
  [SerializeField]
  AudioSource asAngry;

  // Use this for initialization
  void Start()
  {
    asHappy.Play();
    asScared.Play();
    asAngry.Play();

    asHappy.volume = 0.15f;
    asScared.volume = 0;
    asAngry.volume = 0;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void ChangeAudio(PlayerCharacter.StateOfEmotion emotionType)
  {
    switch (emotionType)
    {
      case PlayerCharacter.StateOfEmotion.Happy:
        StartCoroutine(Fade(asHappy, 0.5f, 3));
        StartCoroutine(Fade(asScared, 0, 3));
        StartCoroutine(Fade(asAngry, 0, 3));
        break;
      case PlayerCharacter.StateOfEmotion.Scared:
        StartCoroutine(Fade(asHappy, 0, 3));
        StartCoroutine(Fade(asScared, 0.5f, 3));
        StartCoroutine(Fade(asAngry, 0, 3));
        break;
      case PlayerCharacter.StateOfEmotion.Angry:
        StartCoroutine(Fade(asHappy, 0, 3));
        StartCoroutine(Fade(asScared, 0, 3));
        StartCoroutine(Fade(asAngry, 0.2f, 3));
        break;
      default:
        break;
    }
  }

  IEnumerator Fade(AudioSource audio, float targetVolume, float seconds)
  {
    float initialVolume = audio.volume;

    float volDiff = targetVolume - initialVolume;
    float volStep = volDiff / (seconds * 10);

    for (int i = 0; i < seconds * 10; i++)
    {
      audio.volume += volStep;
      yield return new WaitForSeconds(.1f);
    }

  }
}
