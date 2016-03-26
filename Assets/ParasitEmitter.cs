using UnityEngine;
using System.Collections;


namespace BerlinJam
{
	public class ParasitEmitter : MonoBehaviour {

		[SerializeField] private Parasit parasitPrefab = null;
		[SerializeField] private SongSweep songSweep = null;

		private float spawnTimer = 0.0f;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			this.spawnTimer += Time.deltaTime;
			if (Input.GetKey (KeyCode.Space) || this.spawnTimer > 0.5f) {
				this.spawnTimer = 0.0f;
				DropParasit ();
			}
		}


		private void DropParasit(){

			Vector2 pos = new Vector2 (this.songSweep.transform.position.x + 5 + Random.Range(0, 20)/** + Random Faktor **/, 12 - Random.Range(0, 15) /** somewhere over the rainbow**/);

				//Vector2 velocity = new Vector2(0,-30); 

			Parasit parasit = GameObject.Instantiate<Parasit>(this.parasitPrefab);
			Rigidbody2D parasitBody = parasit.GetComponent<Rigidbody2D>();

			parasit.transform.position = pos;
			//parasit.transform.up = velocity.normalized;
			//parasit.Source = this.gameObject;
			//parasitBody.velocity = velocity;
			parasitBody.velocity = new Vector2( 0.2f, -1.25f);
		}

	}
}
