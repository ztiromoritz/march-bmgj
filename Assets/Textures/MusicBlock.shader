Shader "Unlit/MusicBlock"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Noise("Fadeout Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1, 1, 1, 1)
		_FillState("Fill State", Range(0,1)) = 1
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color	: COLOR;
				float2 texcoord  : TEXCOORD0;
			};

			fixed4 _Color;
			float _FillState;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _Noise;

			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 texColor = tex2D(_MainTex, IN.texcoord);
				fixed4 noise = tex2D(_Noise, IN.texcoord);
				fixed4 color = texColor * IN.color;

				color.a *= (0.65 + 0.35 * _FillState);
				color.a *= smoothstep(noise.r, noise.r + 0.1, _FillState);

				color.rgb *= color.a;
				return color;
			}
			ENDCG
		}
	}
}
