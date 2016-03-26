using UnityEngine;
using System.Collections;

namespace BerlinJam
{
	public class Parasit : MonoBehaviour {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
		
		}


		private void OnTriggerEnter2D(Collider2D collider)
		{
			if (collider.GetComponent<Bullet>() != null)
				Destroy (this.gameObject);
		}
	
	
	}
}

