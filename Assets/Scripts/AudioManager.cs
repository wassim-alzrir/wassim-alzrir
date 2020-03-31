// This script is a Manager that controls all of the audio for the project. All audio
// commands are issued through the static methods of this class. Additionally, this 
// class creates AudioSource "channels" at runtime and manages them

using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	//This class holds a static reference to itself to ensure that there will only be
	//one in existence. This is often referred to as a "singleton" design pattern. Other
	//scripts access this one through its public static methods
	static AudioManager current;

	[Header("Ambient Audio")]
	public AudioClip ambientClip;       //The background ambient sound
	public AudioClip musicClip;         //The background music 



	AudioSource ambientSource;          //Reference to the generated ambient Audio Source
	AudioSource musicSource;            //Reference to the generated music Audio Source
	

	void Awake()
	{
		//If an AudioManager exists and it is not this...
		if (current != null && current != this)
		{
			//...destroy this. There can be only one AudioManager
			Destroy(gameObject);
			return;
		}

		//This is the current AudioManager and it should persist between scene loads
		current = this;
		DontDestroyOnLoad(gameObject);

		//Generate the Audio Source "channels" for our game's audio
		ambientSource = gameObject.AddComponent<AudioSource>() as AudioSource;
		musicSource = gameObject.AddComponent<AudioSource>() as AudioSource;
		


		//Being playing the game audio
		StartLevelAudio();
	}

	void StartLevelAudio()
	{
		//Set the clip for ambient audio, tell it to loop, and then tell it to play
		current.ambientSource.clip = current.ambientClip;
		current.ambientSource.loop = true;
		current.ambientSource.Play();

		//Set the clip for music audio, tell it to loop, and then tell it to play
		current.musicSource.clip = current.musicClip;
		current.musicSource.loop = true;
		current.musicSource.Play();



	}
}
