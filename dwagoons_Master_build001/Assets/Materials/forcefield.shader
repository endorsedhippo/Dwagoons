// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:2,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33065,y:32804,varname:node_3138,prsc:2|normal-8527-OUT,emission-3046-OUT,alpha-6840-OUT,refract-9906-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31975,y:33711,ptovrint:False,ptlb:Fresnel_Color,ptin:_Fresnel_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2069637,c2:0.6862037,c3:0.9705882,c4:1;n:type:ShaderForge.SFN_Fresnel,id:6867,x:32031,y:33103,varname:node_6867,prsc:2|EXP-7310-OUT;n:type:ShaderForge.SFN_Slider,id:2275,x:31657,y:33261,ptovrint:False,ptlb:Fresnel_Intensity,ptin:_Fresnel_Intensity,varname:node_2275,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3,max:3;n:type:ShaderForge.SFN_Multiply,id:6102,x:32217,y:33181,varname:node_6102,prsc:2|A-6867-OUT,B-2275-OUT;n:type:ShaderForge.SFN_Clamp01,id:6826,x:32413,y:33181,varname:node_6826,prsc:2|IN-6102-OUT;n:type:ShaderForge.SFN_Slider,id:7310,x:31657,y:33126,ptovrint:False,ptlb:Fresnel_Amount,ptin:_Fresnel_Amount,varname:_RimAmount_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:10,cur:1.42,max:0;n:type:ShaderForge.SFN_Tex2d,id:2864,x:32381,y:32000,ptovrint:False,ptlb:Texture_1,ptin:_Texture_1,varname:node_2864,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:50f6702eb20290943b642ebe9ceff79f,ntxv:3,isnm:True|UVIN-4550-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9974,x:30940,y:32224,varname:node_9974,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:4550,x:32177,y:31946,varname:node_4550,prsc:2,spu:0,spv:0.005|UVIN-6552-UVOUT,DIST-9804-OUT;n:type:ShaderForge.SFN_Time,id:2421,x:30940,y:32379,varname:node_2421,prsc:2;n:type:ShaderForge.SFN_Slider,id:929,x:31283,y:32010,ptovrint:False,ptlb:Texture_1_Y_Pan,ptin:_Texture_1_Y_Pan,varname:_Y_Pan_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Multiply,id:9804,x:31798,y:32006,varname:node_9804,prsc:2|A-2421-T,B-929-OUT;n:type:ShaderForge.SFN_Panner,id:6552,x:31997,y:31839,varname:node_6552,prsc:2,spu:0.005,spv:0|UVIN-9974-UVOUT,DIST-8077-OUT;n:type:ShaderForge.SFN_Slider,id:5059,x:31283,y:31916,ptovrint:False,ptlb:Texture_1_X_Pan,ptin:_Texture_1_X_Pan,varname:_X_Pan_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.25,max:5;n:type:ShaderForge.SFN_Multiply,id:8077,x:31798,y:31862,varname:node_8077,prsc:2|A-2421-T,B-5059-OUT;n:type:ShaderForge.SFN_Slider,id:6612,x:32039,y:32961,ptovrint:False,ptlb:Refraction_Intensity,ptin:_Refraction_Intensity,varname:_RefractionIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.01,max:0.2;n:type:ShaderForge.SFN_ComponentMask,id:7992,x:32434,y:32860,varname:node_7992,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-8274-RGB;n:type:ShaderForge.SFN_Tex2d,id:8274,x:32196,y:32775,ptovrint:False,ptlb:Refraction_Texture,ptin:_Refraction_Texture,varname:_Refraction,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:44e4f1eca71ac2f458c3f28b8cb1a6dd,ntxv:3,isnm:True|UVIN-1609-UVOUT;n:type:ShaderForge.SFN_Lerp,id:5526,x:32434,y:32733,varname:node_5526,prsc:2|A-237-OUT,B-8274-RGB,T-6612-OUT;n:type:ShaderForge.SFN_Vector3,id:237,x:32196,y:32654,varname:node_237,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Multiply,id:1329,x:32434,y:33012,varname:node_1329,prsc:2|A-6612-OUT,B-2527-OUT;n:type:ShaderForge.SFN_Vector1,id:2527,x:32196,y:33040,varname:node_2527,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Panner,id:1609,x:32000,y:32774,varname:node_1609,prsc:2,spu:0,spv:0.005|UVIN-6864-UVOUT,DIST-7591-OUT;n:type:ShaderForge.SFN_Multiply,id:7591,x:31660,y:32820,varname:node_7591,prsc:2|A-2421-T,B-3350-OUT;n:type:ShaderForge.SFN_Panner,id:6864,x:31830,y:32656,varname:node_6864,prsc:2,spu:0.005,spv:0|UVIN-9974-UVOUT,DIST-4976-OUT;n:type:ShaderForge.SFN_Multiply,id:4976,x:31660,y:32676,varname:node_4976,prsc:2|A-2421-T,B-290-OUT;n:type:ShaderForge.SFN_Multiply,id:9906,x:32604,y:32933,varname:node_9906,prsc:2|A-7992-OUT,B-1329-OUT;n:type:ShaderForge.SFN_Slider,id:290,x:31261,y:32697,ptovrint:False,ptlb:Refraction_X_Pan,ptin:_Refraction_X_Pan,varname:node_290,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Slider,id:3350,x:31261,y:32841,ptovrint:False,ptlb:Refraction_Y_Pan,ptin:_Refraction_Y_Pan,varname:node_3350,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Lerp,id:1851,x:32642,y:32159,varname:node_1851,prsc:2|A-5526-OUT,B-2864-RGB,T-8151-OUT;n:type:ShaderForge.SFN_Slider,id:8151,x:32006,y:32138,ptovrint:False,ptlb:Texture_1_Fade,ptin:_Texture_1_Fade,varname:node_8151,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Panner,id:3543,x:32182,y:32392,varname:node_3543,prsc:2,spu:0,spv:0.005|UVIN-2522-UVOUT,DIST-3403-OUT;n:type:ShaderForge.SFN_Multiply,id:3403,x:31796,y:32427,varname:node_3403,prsc:2|A-2421-T,B-3200-OUT;n:type:ShaderForge.SFN_Panner,id:2522,x:31990,y:32258,varname:node_2522,prsc:2,spu:0.005,spv:0|UVIN-9974-UVOUT,DIST-3257-OUT;n:type:ShaderForge.SFN_Multiply,id:3257,x:31796,y:32283,varname:node_3257,prsc:2|A-2421-T,B-5396-OUT;n:type:ShaderForge.SFN_Tex2d,id:5114,x:32372,y:32392,ptovrint:False,ptlb:Texture_2,ptin:_Texture_2,varname:_Texture_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:44e4f1eca71ac2f458c3f28b8cb1a6dd,ntxv:3,isnm:True|UVIN-3543-UVOUT;n:type:ShaderForge.SFN_Lerp,id:8527,x:32860,y:32360,varname:node_8527,prsc:2|A-1851-OUT,B-5114-RGB,T-9024-OUT;n:type:ShaderForge.SFN_Slider,id:9024,x:32196,y:32585,ptovrint:False,ptlb:Texture_2_Fade,ptin:_Texture_2_Fade,varname:_TextureFade_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.061,max:1;n:type:ShaderForge.SFN_Slider,id:5396,x:31281,y:32345,ptovrint:False,ptlb:Texture_2_X_Pan,ptin:_Texture_2_X_Pan,varname:node_5396,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:3200,x:31281,y:32475,ptovrint:False,ptlb:Texture_2_Y_Pan,ptin:_Texture_2_Y_Pan,varname:node_3200,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:5094,x:31429,y:33766,ptovrint:False,ptlb:Highlight_Amount,ptin:_Highlight_Amount,varname:node_5094,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:10,cur:2.7,max:0;n:type:ShaderForge.SFN_Slider,id:373,x:31429,y:33916,ptovrint:False,ptlb:Highlight_Intensity,ptin:_Highlight_Intensity,varname:node_373,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3,max:3;n:type:ShaderForge.SFN_Fresnel,id:1320,x:31779,y:33772,varname:node_1320,prsc:2|EXP-5094-OUT;n:type:ShaderForge.SFN_Multiply,id:9463,x:31944,y:33896,varname:node_9463,prsc:2|A-1320-OUT,B-373-OUT;n:type:ShaderForge.SFN_Clamp01,id:8091,x:32121,y:33896,varname:node_8091,prsc:2|IN-9463-OUT;n:type:ShaderForge.SFN_Lerp,id:315,x:32373,y:33681,varname:node_315,prsc:2|A-7241-RGB,B-4458-RGB,T-8091-OUT;n:type:ShaderForge.SFN_Color,id:4458,x:32120,y:33711,ptovrint:False,ptlb:Highlight_Color,ptin:_Highlight_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9284572,c2:0.2069637,c3:0.9705882,c4:1;n:type:ShaderForge.SFN_OneMinus,id:7028,x:31736,y:33400,varname:node_7028,prsc:2|IN-9974-V;n:type:ShaderForge.SFN_Blend,id:6840,x:32614,y:33181,varname:node_6840,prsc:2,blmd:5,clmp:True|SRC-6826-OUT,DST-2232-OUT;n:type:ShaderForge.SFN_Clamp01,id:5046,x:32321,y:33373,varname:node_5046,prsc:2|IN-2232-OUT;n:type:ShaderForge.SFN_Lerp,id:5769,x:32609,y:33735,varname:node_5769,prsc:2|A-315-OUT,B-286-RGB,T-5046-OUT;n:type:ShaderForge.SFN_Color,id:286,x:32373,y:33872,ptovrint:False,ptlb:Rim_Glow_Color,ptin:_Rim_Glow_Color,varname:node_286,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:7460,x:31870,y:33498,varname:node_7460,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:4145,x:31870,y:33547,varname:node_4145,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:1725,x:31870,y:33599,varname:node_1725,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:2232,x:32068,y:33373,varname:node_2232,prsc:2|IN-7028-OUT,IMIN-5327-OUT,IMAX-7460-OUT,OMIN-4145-OUT,OMAX-1725-OUT;n:type:ShaderForge.SFN_Slider,id:5327,x:31450,y:33523,ptovrint:False,ptlb:Rim_Glow_Height,ptin:_Rim_Glow_Height,varname:node_5327,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.05,max:0.5;n:type:ShaderForge.SFN_SwitchProperty,id:3046,x:32809,y:33684,ptovrint:False,ptlb:Custom_Rim_Glow_Color,ptin:_Custom_Rim_Glow_Color,varname:node_3046,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-315-OUT,B-5769-OUT;proporder:7241-7310-2275-4458-5094-373-2864-8151-929-5059-5114-9024-3200-5396-8274-6612-3350-290-3046-286-5327;pass:END;sub:END;*/

Shader "Custom/forcefield" {
    Properties {
        _Fresnel_Color ("Fresnel_Color", Color) = (0.2069637,0.6862037,0.9705882,1)
        _Fresnel_Amount ("Fresnel_Amount", Range(10, 0)) = 1.42
        _Fresnel_Intensity ("Fresnel_Intensity", Range(0, 3)) = 3
        _Highlight_Color ("Highlight_Color", Color) = (0.9284572,0.2069637,0.9705882,1)
        _Highlight_Amount ("Highlight_Amount", Range(10, 0)) = 2.7
        _Highlight_Intensity ("Highlight_Intensity", Range(0, 3)) = 3
        _Texture_1 ("Texture_1", 2D) = "bump" {}
        _Texture_1_Fade ("Texture_1_Fade", Range(0, 1)) = 1
        _Texture_1_Y_Pan ("Texture_1_Y_Pan", Range(0, 5)) = 1
        _Texture_1_X_Pan ("Texture_1_X_Pan", Range(0, 5)) = 0.25
        _Texture_2 ("Texture_2", 2D) = "bump" {}
        _Texture_2_Fade ("Texture_2_Fade", Range(0, 1)) = 0.061
        _Texture_2_Y_Pan ("Texture_2_Y_Pan", Range(0, 1)) = 1
        _Texture_2_X_Pan ("Texture_2_X_Pan", Range(0, 1)) = 1
        _Refraction_Texture ("Refraction_Texture", 2D) = "bump" {}
        _Refraction_Intensity ("Refraction_Intensity", Range(0, 0.2)) = 0.01
        _Refraction_Y_Pan ("Refraction_Y_Pan", Range(0, 5)) = 1
        _Refraction_X_Pan ("Refraction_X_Pan", Range(0, 5)) = 1
        [MaterialToggle] _Custom_Rim_Glow_Color ("Custom_Rim_Glow_Color", Float ) = 0.9284572
        _Rim_Glow_Color ("Rim_Glow_Color", Color) = (1,1,1,1)
        _Rim_Glow_Height ("Rim_Glow_Height", Range(0, 0.5)) = 0.05
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float4 _Fresnel_Color;
            uniform float _Fresnel_Intensity;
            uniform float _Fresnel_Amount;
            uniform sampler2D _Texture_1; uniform float4 _Texture_1_ST;
            uniform float _Texture_1_Y_Pan;
            uniform float _Texture_1_X_Pan;
            uniform float _Refraction_Intensity;
            uniform sampler2D _Refraction_Texture; uniform float4 _Refraction_Texture_ST;
            uniform float _Refraction_X_Pan;
            uniform float _Refraction_Y_Pan;
            uniform float _Texture_1_Fade;
            uniform sampler2D _Texture_2; uniform float4 _Texture_2_ST;
            uniform float _Texture_2_Fade;
            uniform float _Texture_2_X_Pan;
            uniform float _Texture_2_Y_Pan;
            uniform float _Highlight_Amount;
            uniform float _Highlight_Intensity;
            uniform float4 _Highlight_Color;
            uniform float4 _Rim_Glow_Color;
            uniform float _Rim_Glow_Height;
            uniform fixed _Custom_Rim_Glow_Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 screenPos : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_2421 = _Time + _TimeEditor;
                float2 node_1609 = ((i.uv0+(node_2421.g*_Refraction_X_Pan)*float2(0.005,0))+(node_2421.g*_Refraction_Y_Pan)*float2(0,0.005));
                float3 _Refraction_Texture_var = UnpackNormal(tex2D(_Refraction_Texture,TRANSFORM_TEX(node_1609, _Refraction_Texture)));
                float2 node_4550 = ((i.uv0+(node_2421.g*_Texture_1_X_Pan)*float2(0.005,0))+(node_2421.g*_Texture_1_Y_Pan)*float2(0,0.005));
                float3 _Texture_1_var = UnpackNormal(tex2D(_Texture_1,TRANSFORM_TEX(node_4550, _Texture_1)));
                float2 node_3543 = ((i.uv0+(node_2421.g*_Texture_2_X_Pan)*float2(0.005,0))+(node_2421.g*_Texture_2_Y_Pan)*float2(0,0.005));
                float3 _Texture_2_var = UnpackNormal(tex2D(_Texture_2,TRANSFORM_TEX(node_3543, _Texture_2)));
                float3 normalLocal = lerp(lerp(lerp(float3(0,0,1),_Refraction_Texture_var.rgb,_Refraction_Intensity),_Texture_1_var.rgb,_Texture_1_Fade),_Texture_2_var.rgb,_Texture_2_Fade);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Refraction_Texture_var.rgb.rg*(_Refraction_Intensity*0.2));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float3 node_315 = lerp(_Fresnel_Color.rgb,_Highlight_Color.rgb,saturate((pow(1.0-max(0,dot(normalDirection, viewDirection)),_Highlight_Amount)*_Highlight_Intensity)));
                float node_4145 = (-1.0);
                float node_2232 = (node_4145 + ( ((1.0 - i.uv0.g) - _Rim_Glow_Height) * (1.0 - node_4145) ) / (0.0 - _Rim_Glow_Height));
                float3 emissive = lerp( node_315, lerp(node_315,_Rim_Glow_Color.rgb,saturate(node_2232)), _Custom_Rim_Glow_Color );
                float3 finalColor = emissive;
                return fixed4(lerp(sceneColor.rgb, finalColor,saturate(max(saturate((pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel_Amount)*_Fresnel_Intensity)),node_2232))),1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
