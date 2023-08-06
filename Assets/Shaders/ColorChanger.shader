Shader "Unlit/ColorChanger"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_ColorTex("ColorTexture", 2D) = "white" {}
		_Color1("Color1", Color) = (0.0, 0.0, 0.0, 0.0)
		_Color2("Color2", Color) = (0.0, 0.0, 0.0, 0.0)
		_Color3("Color3", Color) = (0.0, 0.0, 0.0, 0.0)		
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float4 vertex : SV_POSITION;
					float2 uv : TEXCOORD0;
				};
				
				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;

					return o;
				}

				sampler2D _MainTex;
				sampler2D _ColorTex;
				float4 _Color1;
				float4 _Color2;
				float4 _Color3;				

				fixed4 frag(v2f i) : SV_Target
				{
					fixed4 baseCol = tex2D(_MainTex, i.uv);
					fixed4 texCol = tex2D(_ColorTex, i.uv);

					fixed4 redCol = (1.0f, 0.0, 0.0, 1.0);
					fixed4 greenCol = (0.0f, 1.0, 0.0, 1.0);
					fixed4 blueCol = (0.0f, 1.0, 0.0, 1.0);

					fixed4 finalCol = baseCol;
					if (texCol.rgba == redCol.rgba)
					{
						finalCol = _Color1;
					}
					else if (texCol == greenCol)
					{
						finalCol = _Color2;
					}
					else if (texCol == blueCol)
					{
						finalCol = _Color3;
					}

					return finalCol;
				}

			ENDCG
			}
		}
}