Shader "CosmicBeach/Water Shader"
{
	Properties
	{
		 _MainTex ("Main Texture", 2D) = "white" {}
		 _Visibility ("Visibility", Float) = 0
		 _Alpha ("Alpha", Float) = 0
	}
	
	SubShader
	{
		LOD 100

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Prop"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Fog { Mode Off }
			Offset 0, 0
			AlphaTest Off
			ZTest Off
			Blend SrcAlpha OneMinusSrcAlpha
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
			};

			sampler2D _MainTex;
			float _Visibility;
			float _Alpha;
			
			v2f vert (appdata_t v)
			{
				v2f o;
//UNITY_SHADER_NO_UPGRADE		
#if UNITY_VERSION >= 560				
				o.vertex = UnityObjectToClipPos(v.vertex);
#else
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
#endif
				o.texcoord = v.texcoord;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
            {
				float4 color = tex2D(_MainTex, i.texcoord);
            	color.a *= step(i.texcoord.y, _Visibility) * _Alpha;

            	return color;
            }
		ENDCG
		}
	}
}