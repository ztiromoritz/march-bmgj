using UnityEngine;
using System.Collections;


namespace BerlinJam
{
	public class SongSweep : MonoBehaviour
	{
		[SerializeField] private MusicManager manager = null;
		[SerializeField] private float speed = 0.0f;

		private void Update()
		{
			Rigidbody2D body = this.GetComponent<Rigidbody2D>();
			body.velocity = new Vector2(speed, 0.0f);
		}
		private void OnTriggerEnter2D(Collider2D other)
		{
			MusicBlock block = other.GetComponent<MusicBlock>();
			if (block != null)
			{ 
				this.manager.BumpAudioTrack(block.MusicLayerIndex, block.FillState);
			}
		}
	}
}
