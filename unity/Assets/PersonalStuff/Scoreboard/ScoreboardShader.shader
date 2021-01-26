Shader "Custom/ScoreboardShader"
{
   Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NumberOfElectrodesW ("NBEW",Float) = 18
        _NumberOfElectrodesH ("NBEH",Float) = 15
        _tailleZoneW ("tailleZoneW",Float) = 0.05555555555 // = 1/18 en flotant
        _tailleZoneH ("tailleZoneH",Float) = 0.06666666666 // = 1/15 en flotant
        _sizeWindowSobel("SizeWindowSobel", Float) = 0.002
        _rayon("rayon", Float) = 0.02
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // Param de shader
            sampler2D _MainTex;
            float _NumberOfElectrodesW;
            float _NumberOfElectrodesH;
            float _tailleZoneH;
            float _tailleZoneW;
            float _sizeWindowSobel;
            float _rayon;
            
            //////////////////////////////////////////////////////////////////////////////////////////////
            // Fonction : vert VERTEX SHADER                                                            //
            //////////////////////////////////////////////////////////////////////////////////////////////
            v2f vert (appdata v)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(v.vertex);
                OUT.uv = v.uv;
                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap(OUT.vertex);
                #endif
                return OUT;
            }

            //////////////////////////////////////////////////////////////////////////////////////////////
            // Fonction : getZoneFromUV                                                                 //
            // Sémantique : récupère le centre de la zone la plus proche étant données des coordonnées  //
            //              de texture dans i.uv                                                        //
            // Param : - v2f i, le pixel considéré                                                      //
            // Retour : float2, coordonnée de texture du pixel central de la zone correspondante        //
            //////////////////////////////////////////////////////////////////////////////////////////////
            float2 getZoneFromUV(v2f i)
            {
                // Zone trouvée ?
                bool zoneTrouve = false;
                // Coord texture
                float uvX = i.uv.x;
                float uvY = i.uv.y;
                // resultat
                float2 res = (-1,-1);

                // Pour toutes les zones, est-ce la bonne ?
                for (int w = 0; w < _NumberOfElectrodesW; w++) {
                    for (int h = 0; h < _NumberOfElectrodesH; h++) {
                        // Si dans la boite englobante 
                        if (h * _tailleZoneH < uvY && uvY < (h + 1) * _tailleZoneH
                        && w * _tailleZoneW < uvX  && uvX < (w + 1) * _tailleZoneW) {
                            // Mettre à jour les valeurs UNE PAR UNE ET PAS LES DEUX A LA FOIS
                            res.x = _tailleZoneW * (w + 0.5);
                            res.y = _tailleZoneH * (h + 0.5);
                            return res;
                        }
                    }
                }
                return res;
            }

            //////////////////////////////////////////////////////////////////////////////////////////////
            // Fonction : frag FRAGMENT SHADER                                                          //
            //////////////////////////////////////////////////////////////////////////////////////////////
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 accumulateur = fixed4(0,0,0,1);
                float2 milieuZone = getZoneFromUV(i);
                float distance = sqrt((milieuZone.x - i.uv.x)*(milieuZone.x - i.uv.x) + (milieuZone.y - i.uv.y) * (milieuZone.y - i.uv.y));
                if (distance <= _rayon) {
                    for (int i = 0; i < 10; ++i) {
                        for (int j = 0; j < 10; ++j) {
                            accumulateur += tex2D(_MainTex, milieuZone + (- _tailleZoneW / 2 + (i / 10 * _tailleZoneW),(-_tailleZoneH / 2 + j / 10 * _tailleZoneH)));
                        }
                    }
                    accumulateur /= 100;
                    float gray = (0.3 * accumulateur.r) + (0.59 * accumulateur.g) + (0.11 * accumulateur.b);
                    return fixed4(gray,gray,gray,1);
                }
                return accumulateur;
            }
            ENDCG
        }
    }
}
