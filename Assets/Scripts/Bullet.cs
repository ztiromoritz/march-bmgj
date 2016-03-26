using UnityEngine;
using System.Collections;


namespace BerlinJam
{
	public class Bullet : MonoBehaviour
	{
		private GameObject source;

		public GameObject Source
		{
			get { return this.source; }
			set { this.source = value; }
		}

		private void OnTriggerEnter2D(Collider2D collider)
		{
			if (this.source == collider.gameObject) return;
			if (collider.GetComponent<Bullet>() != null) return;
			if (collider.GetComponent<SongSweep>() != null) return;

			Destroy(this.gameObject);
		}
	}
}
