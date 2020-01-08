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
		
		
		// 曲を再生する
		instrumentalMusicSource.Play ();
		musicSource.Play ();
	}

	// Update is called once per frame
	void Update ()
	{
		// SpaceKeyが押されていたらインストをmuteに、押されていなければ曲をmuteに設定する
		if ( KeyboardListener.pressingKeyList.Contains ( KeyCode.Space ) )
		{
			instrumentalMusicSource.mute = true;
			musicSource.mute = false;
		}
		else
		{
			instrumentalMusicSource.mute = false;
			musicSource.mute = true;
		}
	}
}
