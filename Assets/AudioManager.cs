using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance = null;

	public AudioSource m_musicStream;

	void Awake() {
		if (instance == null) {
			instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
			Destroy (gameObject);
		}
	}

    public void PlayMusic(AudioClip musicClipToPlay, bool mustLoop, float volume = 1.0f, float pitch = 1.0f)
    {
        m_musicStream.pitch = pitch;
        m_musicStream.volume = volume;
        m_musicStream.loop = mustLoop;
        m_musicStream.clip = musicClipToPlay;
        m_musicStream.Play();
    }

    public void StopMusic() {
		m_musicStream.Stop();
	}

}
