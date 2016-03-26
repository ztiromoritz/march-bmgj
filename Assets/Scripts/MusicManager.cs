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
			for (int i = 0; i < musicLayers.Length; i++)
			{
				audioSources[i].clip = musicLayers[i];
				audioSources[i].Play();
			}
		}
	}
}
