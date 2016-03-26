using UnityEngine;
using System.Collections;

namespace BerlinJam
{
	public class MusicManager : MonoBehaviour
	{
		[SerializeField] private AudioClip[] musicLayers = null;
		[SerializeField] private AudioSource[] audioSources = null;

		private void Start()
		{
			for (int i = 0; i < this.musicLayers.Length; i++)
			{
				this.audioSources[i].volume = 0.0f;
				this.audioSources[i].clip = this.musicLayers[i];
				this.audioSources[i].Play();
			}
		}
		private void Update()
		{
			for (int i = 0; i < this.musicLayers.Length; i++)
			{
				this.audioSources[i].volume = Mathf.Clamp01(this.audioSources[i].volume - Time.deltaTime * 0.25f);
			}
		}

		public void BumpAudioTrack(int trackIndex, float bump)
		{
			this.audioSources[trackIndex].volume = Mathf.Clamp01(this.audioSources[trackIndex].volume + bump);
		}
	}
}
