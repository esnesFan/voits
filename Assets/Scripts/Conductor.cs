using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Conductor : MonoBehaviour
{
	public const float DEFAULT_VOLUME = 0.2f;
	
	// 音楽
	public AudioClip instrumentalMusicClip;		// 歌声を抜いた曲(インスト)
	public AudioClip musicClip;					// 曲
	
	private AudioSource instrumentalMusicSource;
	private AudioSource musicSource;
	
	
	// Start is called before the first frame update
	void Start ()
	{
		// ComponentからAudioSourceを取得する
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		
		// audioSourcesの長さを表示する
		Debug.Log ( this.GetType ().Name + "." + MethodBase.GetCurrentMethod ().Name + " ()  audioSources.Length : " + audioSources.Length );
		
		instrumentalMusicSource = audioSources[0];
		musicSource = audioSources[1];
		
		
		// 初期設定
		instrumentalMusicSource.clip = instrumentalMusicClip;
		musicSource.clip = musicClip;
		
		instrumentalMusicSource.volume = DEFAULT_VOLUME;
		musicSource.volume = DEFAULT_VOLUME;
		
		instrumentalMusicSource.mute = false;
		musicSource.mute = true;
		
		
		// 曲を再生
		instrumentalMusicSource.Play ();
		musicSource.Play ();
	}

	// Update is called once per frame
	void Update ()
	{
		if ( Input.GetKeyDown ( KeyCode.Space ) || Input.GetKeyUp ( KeyCode.Space ) )
		{
			instrumentalMusicSource.mute = !instrumentalMusicSource.mute;
			musicSource.mute = !musicSource.mute;
		}
	}
}
