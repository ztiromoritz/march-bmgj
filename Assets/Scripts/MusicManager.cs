using UnityEngine;
using System.Collections;

namespace BerlinJam
{
	public class MusicManager : MonoBehaviour
	{
		[SerializeField] private AudioClip[] musicLayers = null;
		[SerializeField] private AudioSource[] audioSources = null;
		[SerializeField] private float[] bumpBuffer = null;
		[SerializeField] private bool fullSong = false;

		private void Start()
		{
			this.bumpBuffer = new float[this.audioSources.Length];
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
				this.bumpBuffer[i] -= Time.deltaTime;
				if (this.bumpBuffer[i] <= 0.0f)
				{
					this.bumpBuffer[i] = 0.0f;
					this.audioSources[i].volume = fullSong ? 1.0f : Mathf.Clamp01(this.audioSources[i].volume - Time.deltaTime * 0.25f);
				}
			}
		}

		public void BumpAudioTrack(int trackIndex, float bump)
		{
			this.bumpBuffer[trackIndex] = 0.65f;
			this.audioSources[trackIndex].volume = Mathf.Clamp01(this.audioSources[trackIndex].volume + bump);
		}
	}
}
