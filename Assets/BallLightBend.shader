// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Standard,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33456,y:33603,varname:node_9361,prsc:2|custl-4600-OUT;n:type:ShaderForge.SFN_ScreenPos,id:6414,x:31702,y:33721,varname:node_6414,prsc:2,sctp:2;n:type:ShaderForge.SFN_SceneColor,id:2753,x:31711,y:34281,varname:node_2753,prsc:2|UVIN-524-OUT;n:type:ShaderForge.SFN_Set,id:2985,x:31908,y:33721,varname:__ScreenPos,prsc:2|IN-6414-UVOUT;n:type:ShaderForge.SFN_Add,id:2774,x:30914,y:34151,varname:node_2774,prsc:2|A-3577-OUT,B-1028-OUT;n:type:ShaderForge.SFN_Get,id:3577,x:30707,y:34151,varname:node_3577,prsc:2|IN-2985-OUT;n:type:ShaderForge.SFN_Slider,id:139,x:30696,y:33744,ptovrint:False,ptlb:Offset,ptin:_Offset,varname:node_139,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1185141,max:1;n:type:ShaderForge.SFN_Set,id:991,x:31505,y:33767,varname:__Offset,prsc:2|IN-7944-OUT;n:type:ShaderForge.SFN_Get,id:1028,x:30707,y:34203,varname:node_1028,prsc:2|IN-991-OUT;n:type:ShaderForge.SFN_Set,id:5937,x:31908,y:33767,varname:__ScreenPosU,prsc:2|IN-6414-U;n:type:ShaderForge.SFN_Set,id:8591,x:31908,y:33813,varname:__ScreenPosV,prsc:2|IN-6414-V;n:type:ShaderForge.SFN_Add,id:9429,x:31323,y:34151,varname:node_9429,prsc:2|A-9308-OUT,B-758-OUT;n:type:ShaderForge.SFN_Get,id:9308,x:31116,y:34151,varname:node_9308,prsc:2|IN-5937-OUT;n:type:ShaderForge.SFN_Get,id:758,x:31116,y:34203,varname:node_758,prsc:2|IN-991-OUT;n:type:ShaderForge.SFN_Append,id:524,x:31533,y:34117,varname:node_524,prsc:2|A-1134-OUT,B-9429-OUT;n:type:ShaderForge.SFN_Get,id:1134,x:31302,y:34076,varname:node_1134,prsc:2|IN-8591-OUT;n:type:ShaderForge.SFN_Get,id:5104,x:31116,y:34390,varname:node_5104,prsc:2|IN-8591-OUT;n:type:ShaderForge.SFN_Get,id:8825,x:31116,y:34439,varname:node_8825,prsc:2|IN-991-OUT;n:type:ShaderForge.SFN_Append,id:2170,x:31533,y:34349,varname:node_2170,prsc:2|A-7555-OUT,B-7750-OUT;n:type:ShaderForge.SFN_Get,id:7555,x:31323,y:34308,varname:node_7555,prsc:2|IN-5937-OUT;n:type:ShaderForge.SFN_SceneColor,id:1022,x:31711,y:34439,varname:node_1022,prsc:2|UVIN-2170-OUT;n:type:ShaderForge.SFN_Add,id:5728,x:31984,y:34391,varname:node_5728,prsc:2|A-4092-RGB,B-2753-RGB,C-1022-RGB,D-6115-RGB,E-3043-RGB;n:type:ShaderForge.SFN_Divide,id:4600,x:32763,y:34057,varname:node_4600,prsc:2|A-8202-OUT,B-4006-OUT;n:type:ShaderForge.SFN_Vector1,id:4006,x:32212,y:34922,varname:node_4006,prsc:2,v1:9;n:type:ShaderForge.SFN_SceneColor,id:4092,x:31710,y:34009,varname:node_4092,prsc:2|UVIN-3532-OUT;n:type:ShaderForge.SFN_Get,id:3532,x:31512,y:34009,varname:node_3532,prsc:2|IN-2985-OUT;n:type:ShaderForge.SFN_SceneColor,id:6115,x:31711,y:34602,varname:node_6115,prsc:2|UVIN-4717-OUT;n:type:ShaderForge.SFN_Get,id:4880,x:31120,y:34627,varname:node_4880,prsc:2|IN-5937-OUT;n:type:ShaderForge.SFN_Get,id:1887,x:31120,y:34679,varname:node_1887,prsc:2|IN-991-OUT;n:type:ShaderForge.SFN_Append,id:4717,x:31537,y:34612,varname:node_4717,prsc:2|A-2316-OUT,B-7384-OUT;n:type:ShaderForge.SFN_Get,id:2316,x:31306,y:34535,varname:node_2316,prsc:2|IN-8591-OUT;n:type:ShaderForge.SFN_Get,id:9087,x:31120,y:34866,varname:node_9087,prsc:2|IN-8591-OUT;n:type:ShaderForge.SFN_Get,id:5567,x:31120,y:34915,varname:node_5567,prsc:2|IN-991-OUT;n:type:ShaderForge.SFN_Append,id:1649,x:31537,y:34825,varname:node_1649,prsc:2|A-6361-OUT,B-621-OUT;n:type:ShaderForge.SFN_Get,id:6361,x:31327,y:34784,varname:node_6361,prsc:2|IN-5937-OUT;n:type:ShaderForge.SFN_SceneColor,id:3043,x:31711,y:34736,varname:node_3043,prsc:2|UVIN-1649-OUT;n:type:ShaderForge.SFN_Get,id:6045,x:31123,y:35060,varname:node_6045,prsc:2|IN-2985-OUT;n:type:ShaderForge.SFN_Get,id:3661,x:31123,y:35116,varname:node_3661,prsc:2|IN-991-OUT;n:type:ShaderForge.SFN_Subtract,id:7384,x:31327,y:34627,varname:node_7384,prsc:2|A-4880-OUT,B-1887-OUT;n:type:ShaderForge.SFN_Subtract,id:621,x:31327,y:34866,varname:node_621,prsc:2|A-9087-OUT,B-5567-OUT;n:type:ShaderForge.SFN_Add,id:7750,x:31320,y:34390,varname:node_7750,prsc:2|A-5104-OUT,B-8825-OUT;n:type:ShaderForge.SFN_Add,id:7154,x:31343,y:35080,varname:node_7154,prsc:2|A-6045-OUT,B-3661-OUT;n:type:ShaderForge.SFN_SceneColor,id:5735,x:31734,y:35085,varname:node_5735,prsc:2|UVIN-7154-OUT;n:type:ShaderForge.SFN_Add,id:385,x:31952,y:35136,varname:node_385,prsc:2|A-5735-RGB,B-2242-RGB,C-6809-RGB,D-6682-RGB;n:type:ShaderForge.SFN_Subtract,id:1204,x:31343,y:35214,varname:node_1204,prsc:2|A-6045-OUT,B-3661-OUT;n:type:ShaderForge.SFN_SceneColor,id:2242,x:31734,y:35218,varname:node_2242,prsc:2|UVIN-1204-OUT;n:type:ShaderForge.SFN_Get,id:5520,x:31113,y:35364,varname:node_5520,prsc:2|IN-5937-OUT;n:type:ShaderForge.SFN_Get,id:5422,x:31113,y:35524,varname:node_5422,prsc:2|IN-8591-OUT;n:type:ShaderForge.SFN_Add,id:4899,x:31343,y:35364,varname:node_4899,prsc:2|A-5520-OUT,B-2839-OUT;n:type:ShaderForge.SFN_Get,id:2839,x:31113,y:35444,varname:node_2839,prsc:2|IN-991-OUT;n:type:ShaderForge.SFN_Subtract,id:6180,x:31343,y:35488,varname:node_6180,prsc:2|A-5422-OUT,B-2839-OUT;n:type:ShaderForge.SFN_Append,id:5236,x:31558,y:35425,varname:node_5236,prsc:2|A-4899-OUT,B-6180-OUT;n:type:ShaderForge.SFN_SceneColor,id:6809,x:31734,y:35425,varname:node_6809,prsc:2|UVIN-5236-OUT;n:type:ShaderForge.SFN_Get,id:6902,x:31113,y:35627,varname:node_6902,prsc:2|IN-8591-OUT;n:type:ShaderForge.SFN_Get,id:4681,x:31113,y:35787,varname:node_4681,prsc:2|IN-5937-OUT;n:type:ShaderForge.SFN_Add,id:4447,x:31343,y:35627,varname:node_4447,prsc:2|A-6902-OUT,B-248-OUT;n:type:ShaderForge.SFN_Get,id:248,x:31113,y:35707,varname:node_248,prsc:2|IN-991-OUT;n:type:ShaderForge.SFN_Subtract,id:7754,x:31343,y:35751,varname:node_7754,prsc:2|A-4681-OUT,B-248-OUT;n:type:ShaderForge.SFN_Append,id:8527,x:31558,y:35688,varname:node_8527,prsc:2|A-7754-OUT,B-4447-OUT;n:type:ShaderForge.SFN_SceneColor,id:6682,x:31734,y:35688,varname:node_6682,prsc:2|UVIN-8527-OUT;n:type:ShaderForge.SFN_Add,id:8202,x:32212,y:34790,varname:node_8202,prsc:2|A-5728-OUT,B-385-OUT;n:type:ShaderForge.SFN_ObjectPosition,id:6913,x:30750,y:33860,varname:node_6913,prsc:2;n:type:ShaderForge.SFN_ViewPosition,id:6459,x:30750,y:33984,varname:node_6459,prsc:2;n:type:ShaderForge.SFN_Distance,id:6467,x:30939,y:33874,varname:node_6467,prsc:2|A-6913-XYZ,B-6459-XYZ;n:type:ShaderForge.SFN_Divide,id:7944,x:31323,y:33767,varname:node_7944,prsc:2|A-139-OUT,B-3023-OUT;n:type:ShaderForge.SFN_Log,id:7253,x:31031,y:34009,varname:node_7253,prsc:2,lt:0|IN-6467-OUT;n:type:ShaderForge.SFN_Divide,id:3023,x:31177,y:33874,varname:node_3023,prsc:2|A-6467-OUT,B-7253-OUT;n:type:ShaderForge.SFN_Vector2,id:8991,x:31965,y:32965,varname:node_8991,prsc:2,v1:0.1,v2:0;n:type:ShaderForge.SFN_Time,id:5454,x:31965,y:33072,varname:node_5454,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7883,x:32225,y:33010,varname:node_7883,prsc:2|A-8991-OUT,B-5454-T;n:type:ShaderForge.SFN_Add,id:175,x:32473,y:33116,varname:node_175,prsc:2|A-7883-OUT,B-9646-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9646,x:32225,y:33217,varname:node_9646,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:554,x:32712,y:33116,varname:node_554,prsc:2|A-175-OUT,B-8650-OUT;n:type:ShaderForge.SFN_Vector1,id:8650,x:32473,y:33295,varname:node_8650,prsc:2,v1:4;n:type:ShaderForge.SFN_Frac,id:1180,x:32887,y:33116,varname:node_1180,prsc:2|IN-554-OUT;n:type:ShaderForge.SFN_Multiply,id:2962,x:33124,y:33257,varname:node_2962,prsc:2|A-1180-OUT,B-1926-OUT;n:type:ShaderForge.SFN_Vector1,id:1926,x:32864,y:33315,varname:node_1926,prsc:2,v1:4;n:type:ShaderForge.SFN_Subtract,id:7775,x:33319,y:33257,varname:node_7775,prsc:2|A-2962-OUT,B-3877-OUT;n:type:ShaderForge.SFN_Vector1,id:3877,x:33124,y:33403,varname:node_3877,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:406,x:33529,y:33128,varname:node_406,prsc:2|A-1180-OUT,B-1180-OUT,C-7775-OUT;n:type:ShaderForge.SFN_Noise,id:6282,x:33617,y:33459,varname:node_6282,prsc:2|XY-406-OUT;n:type:ShaderForge.SFN_Fresnel,id:7725,x:33211,y:33654,varname:node_7725,prsc:2|NRM-1053-OUT,EXP-9863-OUT;n:type:ShaderForge.SFN_Color,id:7986,x:32595,y:33923,ptovrint:False,ptlb:node_7986,ptin:_node_7986,varname:node_7986,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9191176,c2:0,c3:0,c4:0.2;n:type:ShaderForge.SFN_Vector1,id:9863,x:32991,y:33849,varname:node_9863,prsc:2,v1:15;n:type:ShaderForge.SFN_FragmentPosition,id:8631,x:32595,y:33564,varname:node_8631,prsc:2;n:type:ShaderForge.SFN_ViewPosition,id:3062,x:32595,y:33732,varname:node_3062,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1053,x:32991,y:33704,varname:node_1053,prsc:2|B-7986-RGB;n:type:ShaderForge.SFN_Distance,id:9071,x:32773,y:33639,varname:node_9071,prsc:2|A-8631-XYZ,B-3062-XYZ;n:type:ShaderForge.SFN_Power,id:2140,x:32971,y:33555,varname:node_2140,prsc:2|VAL-9071-OUT;proporder:139-7986;pass:END;sub:END;*/

Shader "Shader Forge/BallLightBend" {
    Properties {
        _Offset ("Offset", Range(0, 1)) = 0.1185141
        _node_7986 ("node_7986", Color) = (0.9191176,0,0,0.2)
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float _Offset;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 projPos : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
                float2 __ScreenPos = sceneUVs.rg;
                float __ScreenPosV = sceneUVs.g;
                float __ScreenPosU = sceneUVs.r;
                float node_6467 = distance(objPos.rgb,_WorldSpaceCameraPos);
                float __Offset = (_Offset/(node_6467/log(node_6467)));
                float2 node_6045 = __ScreenPos;
                float node_3661 = __Offset;
                float node_2839 = __Offset;
                float node_248 = __Offset;
                float3 finalColor = (((tex2D( _GrabTexture, __ScreenPos).rgb+tex2D( _GrabTexture, float2(__ScreenPosV,(__ScreenPosU+__Offset))).rgb+tex2D( _GrabTexture, float2(__ScreenPosU,(__ScreenPosV+__Offset))).rgb+tex2D( _GrabTexture, float2(__ScreenPosV,(__ScreenPosU-__Offset))).rgb+tex2D( _GrabTexture, float2(__ScreenPosU,(__ScreenPosV-__Offset))).rgb)+(tex2D( _GrabTexture, (node_6045+node_3661)).rgb+tex2D( _GrabTexture, (node_6045-node_3661)).rgb+tex2D( _GrabTexture, float2((__ScreenPosU+node_2839),(__ScreenPosV-node_2839))).rgb+tex2D( _GrabTexture, float2((__ScreenPosU-node_248),(__ScreenPosV+node_248))).rgb))/9.0);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Standard"
    CustomEditor "ShaderForgeMaterialInspector"
}
