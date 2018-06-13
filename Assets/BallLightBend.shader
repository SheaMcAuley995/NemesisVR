// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Standard,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33245,y:32598,varname:node_9361,prsc:2|custl-4600-OUT;n:type:ShaderForge.SFN_ScreenPos,id:6414,x:32556,y:32554,varname:node_6414,prsc:2,sctp:2;n:type:ShaderForge.SFN_SceneColor,id:2753,x:32618,y:33153,varname:node_2753,prsc:2|UVIN-524-OUT;n:type:ShaderForge.SFN_Set,id:2985,x:32762,y:32554,varname:__ScreenPos,prsc:2|IN-6414-UVOUT;n:type:ShaderForge.SFN_Add,id:2774,x:32196,y:32791,varname:node_2774,prsc:2|A-3577-OUT,B-1028-OUT;n:type:ShaderForge.SFN_Get,id:3577,x:31989,y:32791,varname:node_3577,prsc:2|IN-2985-OUT;n:type:ShaderForge.SFN_Slider,id:139,x:31999,y:32600,ptovrint:False,ptlb:Offset,ptin:_Offset,varname:node_139,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4511604,max:1;n:type:ShaderForge.SFN_Set,id:991,x:32359,y:32600,varname:__Offset,prsc:2|IN-139-OUT;n:type:ShaderForge.SFN_Get,id:1028,x:31989,y:32843,varname:node_1028,prsc:2|IN-991-OUT;n:type:ShaderForge.SFN_Set,id:5937,x:32762,y:32600,varname:__ScreenPosU,prsc:2|IN-6414-U;n:type:ShaderForge.SFN_Set,id:8591,x:32762,y:32646,varname:__ScreenPosV,prsc:2|IN-6414-V;n:type:ShaderForge.SFN_Add,id:9429,x:32203,y:33168,varname:node_9429,prsc:2|A-9308-OUT,B-758-OUT;n:type:ShaderForge.SFN_Get,id:9308,x:31996,y:33168,varname:node_9308,prsc:2|IN-5937-OUT;n:type:ShaderForge.SFN_Get,id:758,x:31996,y:33220,varname:node_758,prsc:2|IN-991-OUT;n:type:ShaderForge.SFN_Append,id:524,x:32413,y:33134,varname:node_524,prsc:2|A-1134-OUT,B-9429-OUT;n:type:ShaderForge.SFN_Get,id:1134,x:32182,y:33093,varname:node_1134,prsc:2|IN-8591-OUT;n:type:ShaderForge.SFN_Add,id:8071,x:32203,y:33407,varname:node_8071,prsc:2|A-5104-OUT,B-8825-OUT;n:type:ShaderForge.SFN_Get,id:5104,x:31996,y:33407,varname:node_5104,prsc:2|IN-8591-OUT;n:type:ShaderForge.SFN_Get,id:8825,x:31996,y:33456,varname:node_8825,prsc:2|IN-991-OUT;n:type:ShaderForge.SFN_Append,id:2170,x:32413,y:33366,varname:node_2170,prsc:2|A-7555-OUT,B-8071-OUT;n:type:ShaderForge.SFN_Get,id:7555,x:32203,y:33325,varname:node_7555,prsc:2|IN-5937-OUT;n:type:ShaderForge.SFN_SceneColor,id:1022,x:32618,y:33356,varname:node_1022,prsc:2|UVIN-2170-OUT;n:type:ShaderForge.SFN_Add,id:5728,x:32842,y:33153,varname:node_5728,prsc:2|A-4092-RGB,B-2753-RGB,C-1022-RGB;n:type:ShaderForge.SFN_Divide,id:4600,x:33053,y:33153,varname:node_4600,prsc:2|A-5728-OUT,B-4006-OUT;n:type:ShaderForge.SFN_Vector1,id:4006,x:32863,y:33423,varname:node_4006,prsc:2,v1:3;n:type:ShaderForge.SFN_SceneColor,id:4092,x:32599,y:32800,varname:node_4092,prsc:2|UVIN-3532-OUT;n:type:ShaderForge.SFN_Get,id:3532,x:32394,y:32800,varname:node_3532,prsc:2|IN-2985-OUT;n:type:ShaderForge.SFN_SceneColor,id:6115,x:32615,y:33668,varname:node_6115,prsc:2;n:type:ShaderForge.SFN_Get,id:4880,x:31993,y:33683,varname:node_4880,prsc:2;n:type:ShaderForge.SFN_Get,id:1887,x:31993,y:33735,varname:node_1887,prsc:2;n:type:ShaderForge.SFN_Append,id:4717,x:32410,y:33649,varname:node_4717,prsc:2|A-7384-OUT,B-2316-OUT;n:type:ShaderForge.SFN_Get,id:2316,x:32179,y:33591,varname:node_2316,prsc:2;n:type:ShaderForge.SFN_Get,id:9087,x:31993,y:33922,varname:node_9087,prsc:2;n:type:ShaderForge.SFN_Get,id:5567,x:31993,y:33971,varname:node_5567,prsc:2;n:type:ShaderForge.SFN_Append,id:1649,x:32410,y:33881,varname:node_1649,prsc:2|A-621-OUT,B-6361-OUT;n:type:ShaderForge.SFN_Get,id:6361,x:32200,y:33840,varname:node_6361,prsc:2;n:type:ShaderForge.SFN_SceneColor,id:3043,x:32615,y:33871,varname:node_3043,prsc:2|UVIN-1649-OUT;n:type:ShaderForge.SFN_Subtract,id:4010,x:32014,y:33551,varname:node_4010,prsc:2|A-6045-OUT,B-3661-OUT;n:type:ShaderForge.SFN_Get,id:6045,x:31825,y:33551,varname:node_6045,prsc:2;n:type:ShaderForge.SFN_Get,id:3661,x:31825,y:33604,varname:node_3661,prsc:2;n:type:ShaderForge.SFN_Subtract,id:7384,x:32200,y:33683,varname:node_7384,prsc:2|A-4880-OUT,B-1887-OUT;n:type:ShaderForge.SFN_Subtract,id:621,x:32200,y:33922,varname:node_621,prsc:2|A-9087-OUT,B-5567-OUT;proporder:139;pass:END;sub:END;*/

Shader "Shader Forge/BallLightBend" {
    Properties {
        _Offset ("Offset", Range(0, 1)) = 0.4511604
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
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
                float2 __ScreenPos = sceneUVs.rg;
                float __ScreenPosV = sceneUVs.g;
                float __ScreenPosU = sceneUVs.r;
                float __Offset = _Offset;
                float2 node_524 = float2(__ScreenPosV,(__ScreenPosU+__Offset));
                float2 node_2170 = float2(__ScreenPosU,(__ScreenPosV+__Offset));
                float3 finalColor = ((tex2D( _GrabTexture, __ScreenPos).rgb+tex2D( _GrabTexture, node_524).rgb+tex2D( _GrabTexture, node_2170).rgb)/3.0);
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
