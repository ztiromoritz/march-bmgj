using UnityEngine;
using System.Collections;

namespace BerlinJam
{
	public class Parasit : MonoBehaviour {

		[SerializeField] private float speed = 1.0f;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			Rigidbody2D body = this.GetComponent<Rigidbody2D>();
			//body.velocity = new Vector2( 0.0f, - speed);
		}


		private void OnTriggerEnter2D(Collider2D collider)
		{
			if (collider.GetComponent<Bullet>() != null)
				Destroy (this.gameObject);
		}
		private void OnCollisionStay2D(Collision2D other)
		{
			MusicBlock block = other.collider.GetComponent<MusicBlock>();
			if (block != null)
			{
				block.FillState -= Time.deltaTime;
			}
		}
	
	
	}
}

