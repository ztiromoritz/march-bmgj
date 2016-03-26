using UnityEngine;
using System.Collections;


namespace BerlinJam
{
	public class MusicBlock : MonoBehaviour
	{
		[SerializeField] private Renderer fillRenderer = null;
		[Range(0, 1)]
		[SerializeField] private float fillState = 1.0f;
		[SerializeField] private int musicLayerIndex = 0;
		[SerializeField] private Material blockMaterial = null;

		private Material material;

		public int MusicLayerIndex
		{
			get { return this.musicLayerIndex; }
		}
		public float FillState
		{
			get { return this.fillState; }
		}

		private void Awake()
		{
			this.material = new Material(this.blockMaterial);
			this.fillRenderer.material = this.material;
		}
		private void Update()
		{
			this.material.SetFloat("_FillState", this.fillState);
		}
	}
}
