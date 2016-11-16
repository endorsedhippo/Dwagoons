// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:2,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:34434,y:32823,varname:node_3138,prsc:2|normal-8816-OUT,emission-2686-OUT,alpha-5838-OUT,refract-132-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31805,y:33177,ptovrint:False,ptlb:Fresnel_Color,ptin:_Fresnel_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2069637,c2:0.6862037,c3:0.9705882,c4:1;n:type:ShaderForge.SFN_Fresnel,id:6867,x:31116,y:33552,varname:node_6867,prsc:2|EXP-7310-OUT;n:type:ShaderForge.SFN_Slider,id:2275,x:30779,y:33721,ptovrint:False,ptlb:Fresnel_Intensity,ptin:_Fresnel_Intensity,varname:node_2275,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:3;n:type:ShaderForge.SFN_Multiply,id:6102,x:31317,y:33552,varname:node_6102,prsc:2|A-6867-OUT,B-2275-OUT;n:type:ShaderForge.SFN_Clamp01,id:6826,x:31479,y:33552,varname:node_6826,prsc:2|IN-6102-OUT;n:type:ShaderForge.SFN_Slider,id:7310,x:30779,y:33573,ptovrint:False,ptlb:Fresnel_Amount,ptin:_Fresnel_Amount,varname:_RimAmount_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:10,cur:1.42,max:0;n:type:ShaderForge.SFN_Tex2d,id:2864,x:32372,y:32072,ptovrint:False,ptlb:Texture_1,ptin:_Texture_1,varname:node_2864,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:50f6702eb20290943b642ebe9ceff79f,ntxv:3,isnm:True|UVIN-4550-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9974,x:30841,y:32327,varname:node_9974,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:4550,x:32193,y:32072,varname:node_4550,prsc:2,spu:0,spv:0.005|UVIN-6552-UVOUT,DIST-9804-OUT;n:type:ShaderForge.SFN_Time,id:2421,x:30091,y:33924,varname:node_2421,prsc:2;n:type:ShaderForge.SFN_Slider,id:929,x:31274,y:32082,ptovrint:False,ptlb:Texture_1_Y_Pan,ptin:_Texture_1_Y_Pan,varname:_Y_Pan_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Multiply,id:9804,x:31796,y:32158,varname:node_9804,prsc:2|A-3119-OUT,B-929-OUT;n:type:ShaderForge.SFN_Panner,id:6552,x:31990,y:32072,varname:node_6552,prsc:2,spu:0.005,spv:0|UVIN-6009-OUT,DIST-8077-OUT;n:type:ShaderForge.SFN_Slider,id:5059,x:31274,y:31988,ptovrint:False,ptlb:Texture_1_X_Pan,ptin:_Texture_1_X_Pan,varname:_X_Pan_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.25,max:5;n:type:ShaderForge.SFN_Multiply,id:8077,x:31796,y:32026,varname:node_8077,prsc:2|A-3119-OUT,B-5059-OUT;n:type:ShaderForge.SFN_Slider,id:6612,x:32046,y:32946,ptovrint:False,ptlb:Refraction_Intensity,ptin:_Refraction_Intensity,varname:_RefractionIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.01,max:0.2;n:type:ShaderForge.SFN_ComponentMask,id:7992,x:32434,y:32860,varname:node_7992,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-8274-RGB;n:type:ShaderForge.SFN_Tex2d,id:8274,x:32196,y:32749,ptovrint:False,ptlb:Refraction_Texture,ptin:_Refraction_Texture,varname:_Refraction,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:44e4f1eca71ac2f458c3f28b8cb1a6dd,ntxv:3,isnm:True|UVIN-1609-UVOUT;n:type:ShaderForge.SFN_Lerp,id:5526,x:32434,y:32733,varname:node_5526,prsc:2|A-237-OUT,B-8274-RGB,T-6612-OUT;n:type:ShaderForge.SFN_Vector3,id:237,x:32196,y:32654,varname:node_237,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Multiply,id:1329,x:32434,y:33012,varname:node_1329,prsc:2|A-6612-OUT,B-2527-OUT;n:type:ShaderForge.SFN_Vector1,id:2527,x:32196,y:33040,varname:node_2527,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Panner,id:1609,x:32017,y:32656,varname:node_1609,prsc:2,spu:0,spv:0.005|UVIN-6864-UVOUT,DIST-7591-OUT;n:type:ShaderForge.SFN_Multiply,id:7591,x:31796,y:32821,varname:node_7591,prsc:2|A-8124-OUT,B-3350-OUT;n:type:ShaderForge.SFN_Panner,id:6864,x:31830,y:32656,varname:node_6864,prsc:2,spu:0.005,spv:0|UVIN-6009-OUT,DIST-4976-OUT;n:type:ShaderForge.SFN_Multiply,id:4976,x:31660,y:32676,varname:node_4976,prsc:2|A-8124-OUT,B-290-OUT;n:type:ShaderForge.SFN_Multiply,id:9906,x:32604,y:32933,cmnt:Refraction,varname:node_9906,prsc:2|A-7992-OUT,B-1329-OUT;n:type:ShaderForge.SFN_Slider,id:290,x:31261,y:32697,ptovrint:False,ptlb:Refraction_X_Pan,ptin:_Refraction_X_Pan,varname:node_290,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Slider,id:3350,x:31261,y:32841,ptovrint:False,ptlb:Refraction_Y_Pan,ptin:_Refraction_Y_Pan,varname:node_3350,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Lerp,id:1851,x:32652,y:32245,varname:node_1851,prsc:2|A-5526-OUT,B-2864-RGB,T-8151-OUT;n:type:ShaderForge.SFN_Slider,id:8151,x:32215,y:32283,ptovrint:False,ptlb:Texture_1_Fade,ptin:_Texture_1_Fade,varname:node_8151,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Panner,id:3543,x:32182,y:32392,varname:node_3543,prsc:2,spu:0,spv:0.005|UVIN-2522-UVOUT,DIST-3403-OUT;n:type:ShaderForge.SFN_Multiply,id:3403,x:31796,y:32427,varname:node_3403,prsc:2|A-3119-OUT,B-3200-OUT;n:type:ShaderForge.SFN_Panner,id:2522,x:31990,y:32258,varname:node_2522,prsc:2,spu:0.005,spv:0|UVIN-6009-OUT,DIST-3257-OUT;n:type:ShaderForge.SFN_Multiply,id:3257,x:31796,y:32283,varname:node_3257,prsc:2|A-3119-OUT,B-5396-OUT;n:type:ShaderForge.SFN_Tex2d,id:5114,x:32372,y:32392,ptovrint:False,ptlb:Texture_2,ptin:_Texture_2,varname:_Texture_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:44e4f1eca71ac2f458c3f28b8cb1a6dd,ntxv:3,isnm:True|UVIN-3543-UVOUT;n:type:ShaderForge.SFN_Lerp,id:8527,x:32860,y:32360,cmnt:Normals,varname:node_8527,prsc:2|A-1851-OUT,B-5114-RGB,T-9024-OUT;n:type:ShaderForge.SFN_Slider,id:9024,x:32196,y:32585,ptovrint:False,ptlb:Texture_2_Fade,ptin:_Texture_2_Fade,varname:_TextureFade_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.061,max:1;n:type:ShaderForge.SFN_Slider,id:5396,x:31281,y:32345,ptovrint:False,ptlb:Texture_2_X_Pan,ptin:_Texture_2_X_Pan,varname:node_5396,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:3200,x:31281,y:32475,ptovrint:False,ptlb:Texture_2_Y_Pan,ptin:_Texture_2_Y_Pan,varname:node_3200,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:5094,x:31259,y:33232,ptovrint:False,ptlb:Highlight_Amount,ptin:_Highlight_Amount,varname:node_5094,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:10,cur:2.7,max:0;n:type:ShaderForge.SFN_Slider,id:373,x:31259,y:33382,ptovrint:False,ptlb:Highlight_Intensity,ptin:_Highlight_Intensity,varname:node_373,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:3;n:type:ShaderForge.SFN_Fresnel,id:1320,x:31609,y:33238,varname:node_1320,prsc:2|EXP-5094-OUT;n:type:ShaderForge.SFN_Multiply,id:9463,x:31774,y:33362,varname:node_9463,prsc:2|A-1320-OUT,B-373-OUT;n:type:ShaderForge.SFN_Clamp01,id:8091,x:31951,y:33362,varname:node_8091,prsc:2|IN-9463-OUT;n:type:ShaderForge.SFN_Lerp,id:315,x:32203,y:33148,varname:node_315,prsc:2|A-7241-RGB,B-4458-RGB,T-8091-OUT;n:type:ShaderForge.SFN_Color,id:4458,x:31950,y:33177,ptovrint:False,ptlb:Highlight_Color,ptin:_Highlight_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2078431,c2:0.972549,c3:0.7490196,c4:1;n:type:ShaderForge.SFN_OneMinus,id:7028,x:31669,y:33833,varname:node_7028,prsc:2|IN-9974-V;n:type:ShaderForge.SFN_Clamp01,id:5046,x:32087,y:33833,cmnt:BaseRim Highlight Mask,varname:node_5046,prsc:2|IN-2232-OUT;n:type:ShaderForge.SFN_Lerp,id:5769,x:32434,y:33219,cmnt:Add Rim Highlight,varname:node_5769,prsc:2|A-315-OUT,B-286-RGB,T-5046-OUT;n:type:ShaderForge.SFN_Color,id:286,x:32203,y:33338,ptovrint:False,ptlb:Rim_Glow_Color,ptin:_Rim_Glow_Color,varname:node_286,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0.4627451,c4:1;n:type:ShaderForge.SFN_Vector1,id:7460,x:31669,y:33959,varname:node_7460,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:4145,x:31669,y:34008,varname:node_4145,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:1725,x:31669,y:34060,varname:node_1725,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:2232,x:31923,y:33833,varname:node_2232,prsc:2|IN-7028-OUT,IMIN-5327-OUT,IMAX-7460-OUT,OMIN-4145-OUT,OMAX-1725-OUT;n:type:ShaderForge.SFN_Slider,id:5327,x:30779,y:33999,ptovrint:False,ptlb:Rim_Glow_Height,ptin:_Rim_Glow_Height,varname:node_5327,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.05,max:0.5;n:type:ShaderForge.SFN_SwitchProperty,id:3046,x:32639,y:33150,ptovrint:False,ptlb:Custom_Rim_Glow_Color,ptin:_Custom_Rim_Glow_Color,cmnt:Emissive Colour,varname:node_3046,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-315-OUT,B-5769-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:7681,x:31915,y:35203,varname:node_7681,prsc:2;n:type:ShaderForge.SFN_Distance,id:6528,x:32091,y:35203,varname:node_6528,prsc:2|A-7681-XYZ,B-9799-XYZ;n:type:ShaderForge.SFN_ViewPosition,id:9799,x:31915,y:35339,varname:node_9799,prsc:2;n:type:ShaderForge.SFN_Divide,id:2471,x:32261,y:35203,varname:node_2471,prsc:2|A-6528-OUT,B-7501-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8251,x:30936,y:34251,ptovrint:False,ptlb:Proxy Transition Falloff,ptin:_ProxyTransitionFalloff,varname:node_8251,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:15;n:type:ShaderForge.SFN_Power,id:2768,x:32467,y:35203,varname:node_2768,prsc:2|VAL-2471-OUT,EXP-8251-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7501,x:30936,y:34171,ptovrint:False,ptlb:Proxy Transition Distance,ptin:_ProxyTransitionDistance,varname:node_7501,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:90;n:type:ShaderForge.SFN_Clamp01,id:6042,x:32640,y:35203,varname:node_6042,prsc:2|IN-2768-OUT;n:type:ShaderForge.SFN_OneMinus,id:1513,x:32807,y:35203,cmnt:Depth Alpha,varname:node_1513,prsc:2|IN-6042-OUT;n:type:ShaderForge.SFN_Blend,id:9025,x:33378,y:34060,cmnt:Opacity Mask,varname:node_9025,prsc:2,blmd:5,clmp:True|SRC-4905-OUT,DST-4276-OUT;n:type:ShaderForge.SFN_Subtract,id:7011,x:31669,y:33685,varname:node_7011,prsc:2|A-9287-OUT,B-6826-OUT;n:type:ShaderForge.SFN_Add,id:1376,x:32002,y:33549,varname:node_1376,prsc:2|A-6826-OUT,B-672-OUT;n:type:ShaderForge.SFN_Clamp01,id:672,x:31827,y:33685,varname:node_672,prsc:2|IN-7011-OUT;n:type:ShaderForge.SFN_Lerp,id:393,x:32399,y:33830,varname:node_393,prsc:2|A-5493-OUT,B-5046-OUT,T-322-OUT;n:type:ShaderForge.SFN_Vector1,id:322,x:32202,y:33960,varname:node_322,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:4905,x:32561,y:33830,varname:node_4905,prsc:2|A-393-OUT,B-7246-OUT;n:type:ShaderForge.SFN_Vector1,id:7246,x:32371,y:33960,varname:node_7246,prsc:2,v1:2;n:type:ShaderForge.SFN_Slider,id:9287,x:30779,y:33820,ptovrint:False,ptlb:Min Opacity,ptin:_MinOpacity,varname:node_9287,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Clamp01,id:734,x:32166,y:33587,varname:node_734,prsc:2|IN-1376-OUT;n:type:ShaderForge.SFN_Relay,id:8124,x:31431,y:32767,varname:node_8124,prsc:2|IN-2421-T;n:type:ShaderForge.SFN_Relay,id:3119,x:31472,y:32204,varname:node_3119,prsc:2|IN-2421-T;n:type:ShaderForge.SFN_Relay,id:6009,x:31472,y:32263,varname:node_6009,prsc:2|IN-9974-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:5417,x:32378,y:34506,ptovrint:False,ptlb:Proxy Texture,ptin:_ProxyTexture,varname:node_5417,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:86f4aee481d92cb4da5dbf5ddc11f149,ntxv:0,isnm:False|UVIN-7054-OUT;n:type:ShaderForge.SFN_Relay,id:5838,x:34338,y:33083,varname:node_5838,prsc:2|IN-9025-OUT;n:type:ShaderForge.SFN_Relay,id:8816,x:34338,y:32901,varname:node_8816,prsc:2|IN-8527-OUT;n:type:ShaderForge.SFN_Relay,id:132,x:34338,y:33124,varname:node_132,prsc:2|IN-9906-OUT;n:type:ShaderForge.SFN_Lerp,id:2510,x:33028,y:34532,varname:node_2510,prsc:2|A-3681-OUT,B-8396-OUT,T-1716-OUT;n:type:ShaderForge.SFN_TexCoord,id:3189,x:31480,y:34443,varname:node_3189,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:5331,x:31702,y:34465,varname:node_5331,prsc:2|A-3189-U,B-4617-OUT;n:type:ShaderForge.SFN_Vector1,id:4617,x:31480,y:34595,varname:node_4617,prsc:2,v1:12;n:type:ShaderForge.SFN_Multiply,id:7706,x:31702,y:34595,varname:node_7706,prsc:2|A-3189-V,B-3790-OUT;n:type:ShaderForge.SFN_Vector1,id:3790,x:31480,y:34659,varname:node_3790,prsc:2,v1:7;n:type:ShaderForge.SFN_Append,id:225,x:31923,y:34497,varname:node_225,prsc:2|A-5331-OUT,B-7706-OUT;n:type:ShaderForge.SFN_Relay,id:7845,x:33601,y:34608,cmnt:Emissive Out,varname:node_7845,prsc:2|IN-2165-OUT;n:type:ShaderForge.SFN_Lerp,id:2165,x:33331,y:34608,cmnt:Proxy Masked,varname:node_2165,prsc:2|A-297-OUT,B-2510-OUT,T-1513-OUT;n:type:ShaderForge.SFN_Vector3,id:297,x:32562,y:34662,varname:node_297,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Sin,id:8633,x:32369,y:34899,varname:node_8633,prsc:2|IN-1044-OUT;n:type:ShaderForge.SFN_Relay,id:9567,x:31620,y:34895,cmnt:Time,varname:node_9567,prsc:2|IN-2421-T;n:type:ShaderForge.SFN_Multiply,id:1044,x:32201,y:34899,varname:node_1044,prsc:2|A-9567-OUT,B-8950-OUT;n:type:ShaderForge.SFN_Vector1,id:8950,x:32201,y:35047,cmnt:Proximity Pulse Speed,varname:node_8950,prsc:2,v1:5;n:type:ShaderForge.SFN_Lerp,id:1716,x:32779,y:34576,cmnt:Sine Proxy Texture,varname:node_1716,prsc:2|A-5240-OUT,B-297-OUT,T-7058-OUT;n:type:ShaderForge.SFN_RemapRange,id:5240,x:32562,y:34506,cmnt:Darkened Proxy Texture,varname:node_5240,prsc:2,frmn:0.5,frmx:1,tomn:-1,tomx:0.5|IN-5417-RGB;n:type:ShaderForge.SFN_Vector3,id:3681,x:32823,y:34348,varname:node_3681,prsc:2,v1:0,v2:1,v3:0.9568628;n:type:ShaderForge.SFN_Vector3,id:8396,x:32823,y:34433,varname:node_8396,prsc:2,v1:0,v2:0.3882353,v3:0.2588235;n:type:ShaderForge.SFN_RemapRange,id:7058,x:32543,y:34899,cmnt:Sine Wave,varname:node_7058,prsc:2,frmn:-1,frmx:1,tomn:0.7,tomx:1|IN-8633-OUT;n:type:ShaderForge.SFN_Blend,id:2686,x:34192,y:32950,varname:node_2686,prsc:2,blmd:5,clmp:True|SRC-3046-OUT,DST-7845-OUT;n:type:ShaderForge.SFN_Add,id:7054,x:32141,y:34497,varname:node_7054,prsc:2|A-225-OUT,B-3700-OUT;n:type:ShaderForge.SFN_Multiply,id:3700,x:31923,y:34627,varname:node_3700,prsc:2|A-9567-OUT,B-2714-OUT;n:type:ShaderForge.SFN_Multiply,id:4276,x:33046,y:35203,varname:node_4276,prsc:2|A-1513-OUT,B-3262-OUT;n:type:ShaderForge.SFN_RemapRange,id:5493,x:32448,y:33580,cmnt:Adjustment?,varname:node_5493,prsc:2,frmn:0,frmx:1,tomn:0,tomx:1|IN-734-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3262,x:30968,y:35448,ptovrint:False,ptlb:Proxy Opacity,ptin:_ProxyOpacity,varname:node_3262,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.9;n:type:ShaderForge.SFN_ValueProperty,id:2714,x:30956,y:34765,ptovrint:False,ptlb:Proxy Pan Speed,ptin:_ProxyPanSpeed,varname:node_2714,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.03;n:type:ShaderForge.SFN_RemapRange,id:1081,x:34731,y:33530,varname:node_1081,prsc:2,frmn:0.5,frmx:1,tomn:-1,tomx:0.5;n:type:ShaderForge.SFN_RemapRange,id:5141,x:34795,y:33594,varname:node_5141,prsc:2,frmn:0.5,frmx:1,tomn:-1,tomx:0.5;proporder:7241-2275-7310-4458-373-5094-2864-8151-929-5059-5114-9024-3200-5396-8274-6612-3350-290-3046-286-5327-5417-2714-7501-8251-3262-9287;pass:END;sub:END;*/

Shader "Custom/forcefield" {
    Properties {
        _Fresnel_Color ("Fresnel_Color", Color) = (0.2069637,0.6862037,0.9705882,1)
        _Fresnel_Intensity ("Fresnel_Intensity", Range(0, 3)) = 1
        _Fresnel_Amount ("Fresnel_Amount", Range(10, 0)) = 1.42
        _Highlight_Color ("Highlight_Color", Color) = (0.2078431,0.972549,0.7490196,1)
        _Highlight_Intensity ("Highlight_Intensity", Range(0, 3)) = 2
        _Highlight_Amount ("Highlight_Amount", Range(10, 0)) = 2.7
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
        [MaterialToggle] _Custom_Rim_Glow_Color ("Custom_Rim_Glow_Color", Float ) = 0.2078431
        _Rim_Glow_Color ("Rim_Glow_Color", Color) = (0,1,0.4627451,1)
        _Rim_Glow_Height ("Rim_Glow_Height", Range(0, 0.5)) = 0.05
        _ProxyTexture ("Proxy Texture", 2D) = "white" {}
        _ProxyPanSpeed ("Proxy Pan Speed", Float ) = 0.03
        _ProxyTransitionDistance ("Proxy Transition Distance", Float ) = 90
        _ProxyTransitionFalloff ("Proxy Transition Falloff", Float ) = 15
        _ProxyOpacity ("Proxy Opacity", Float ) = 0.9
        _MinOpacity ("Min Opacity", Range(0, 1)) = 0.5
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
            uniform float _ProxyTransitionFalloff;
            uniform float _ProxyTransitionDistance;
            uniform float _MinOpacity;
            uniform sampler2D _ProxyTexture; uniform float4 _ProxyTexture_ST;
            uniform float _ProxyOpacity;
            uniform float _ProxyPanSpeed;
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
                float node_8124 = node_2421.g;
                float2 node_6009 = i.uv0;
                float2 node_1609 = ((node_6009+(node_8124*_Refraction_X_Pan)*float2(0.005,0))+(node_8124*_Refraction_Y_Pan)*float2(0,0.005));
                float3 _Refraction_Texture_var = UnpackNormal(tex2D(_Refraction_Texture,TRANSFORM_TEX(node_1609, _Refraction_Texture)));
                float node_3119 = node_2421.g;
                float2 node_4550 = ((node_6009+(node_3119*_Texture_1_X_Pan)*float2(0.005,0))+(node_3119*_Texture_1_Y_Pan)*float2(0,0.005));
                float3 _Texture_1_var = UnpackNormal(tex2D(_Texture_1,TRANSFORM_TEX(node_4550, _Texture_1)));
                float2 node_3543 = ((node_6009+(node_3119*_Texture_2_X_Pan)*float2(0.005,0))+(node_3119*_Texture_2_Y_Pan)*float2(0,0.005));
                float3 _Texture_2_var = UnpackNormal(tex2D(_Texture_2,TRANSFORM_TEX(node_3543, _Texture_2)));
                float3 normalLocal = lerp(lerp(lerp(float3(0,0,1),_Refraction_Texture_var.rgb,_Refraction_Intensity),_Texture_1_var.rgb,_Texture_1_Fade),_Texture_2_var.rgb,_Texture_2_Fade);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Refraction_Texture_var.rgb.rg*(_Refraction_Intensity*0.2));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float3 node_315 = lerp(_Fresnel_Color.rgb,_Highlight_Color.rgb,saturate((pow(1.0-max(0,dot(normalDirection, viewDirection)),_Highlight_Amount)*_Highlight_Intensity)));
                float node_4145 = (-1.0);
                float node_5046 = saturate((node_4145 + ( ((1.0 - i.uv0.g) - _Rim_Glow_Height) * (1.0 - node_4145) ) / (0.0 - _Rim_Glow_Height))); // BaseRim Highlight Mask
                float3 node_297 = float3(0,0,0);
                float node_9567 = node_2421.g; // Time
                float2 node_7054 = (float2((i.uv0.r*12.0),(i.uv0.g*7.0))+(node_9567*_ProxyPanSpeed));
                float4 _ProxyTexture_var = tex2D(_ProxyTexture,TRANSFORM_TEX(node_7054, _ProxyTexture));
                float3 node_5240 = (_ProxyTexture_var.rgb*3.0+-2.5); // Darkened Proxy Texture
                float node_8633 = sin((node_9567*5.0));
                float3 node_2510 = lerp(float3(0,1,0.9568628),float3(0,0.3882353,0.2588235),lerp(node_5240,node_297,(node_8633*0.15+0.85)));
                float node_1513 = (1.0 - saturate(pow((distance(i.posWorld.rgb,_WorldSpaceCameraPos)/_ProxyTransitionDistance),_ProxyTransitionFalloff))); // Depth Alpha
                float3 node_2165 = lerp(node_297,node_2510,node_1513); // Proxy Masked
                float3 node_2686 = saturate(max(lerp( node_315, lerp(node_315,_Rim_Glow_Color.rgb,node_5046), _Custom_Rim_Glow_Color ),node_2165));
                float3 emissive = node_2686;
                float3 finalColor = emissive;
                float node_6826 = saturate((pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel_Amount)*_Fresnel_Intensity));
                float node_1376 = (node_6826+saturate((_MinOpacity-node_6826)));
                float node_734 = saturate(node_1376);
                float node_9025 = saturate(max((lerp((node_734*1.0+0.0),node_5046,0.5)*2.0),(node_1513*_ProxyOpacity))); // Opacity Mask
                return fixed4(lerp(sceneColor.rgb, finalColor,node_9025),1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
