using UnityEngine;
using System.Collections;


namespace BerlinJam
{
	public class ParasitEmitter : MonoBehaviour {

		[SerializeField] private Parasit parasitPrefab = null;
		[SerializeField] private SongSweep songSweep = null;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKey (KeyCode.Space)) {
				DropParasit ();
			}
		}


		private void DropParasit(){

			Vector2 pos = new Vector2 (this.songSweep.transform.position.x /** + Random Faktor **/, 15 /** somewhere over the rainbow**/);

				//Vector2 velocity = new Vector2(0,-30); 

			Parasit parasit = GameObject.Instantiate<Parasit>(this.parasitPrefab);
			Rigidbody2D parasitBody = parasit.GetComponent<Rigidbody2D>();

			parasit.transform.position = pos;
			//parasit.transform.up = velocity.normalized;
			//parasit.Source = this.gameObject;
			//parasitBody.velocity = velocity;
			parasitBody.velocity = new Vector2( 0.0f, -1.0f);;
		}

	}
}
