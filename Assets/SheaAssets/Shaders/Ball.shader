// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-7011-RGB,voffset-2405-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32254,y:32818,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_NormalVector,id:991,x:30810,y:33338,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:2405,x:32569,y:33380,varname:node_2405,prsc:2|A-991-OUT,B-4013-OUT,C-3859-OUT;n:type:ShaderForge.SFN_Slider,id:4013,x:31690,y:33399,ptovrint:False,ptlb:Offset,ptin:_Offset,varname:node_4013,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6480603,max:5;n:type:ShaderForge.SFN_TexCoord,id:5510,x:31263,y:33757,varname:node_5510,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Step,id:7533,x:32292,y:33801,varname:node_7533,prsc:2|A-5510-V,B-9492-OUT;n:type:ShaderForge.SFN_Slider,id:9492,x:31684,y:33946,ptovrint:False,ptlb:Offset_copy,ptin:_Offset_copy,varname:_Offset_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.1,cur:-0.1,max:1;n:type:ShaderForge.SFN_Transform,id:8449,x:31589,y:33112,varname:node_8449,prsc:2,tffrom:0,tfto:3|IN-991-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8736,x:31753,y:33112,varname:node_8736,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-8449-XYZ;n:type:ShaderForge.SFN_Tex2d,id:7011,x:32372,y:33101,ptovrint:False,ptlb:node_7011,ptin:_node_7011,varname:node_7011,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a4259037a0bba7b41884b33f9653b20e,ntxv:0,isnm:False|UVIN-8050-OUT;n:type:ShaderForge.SFN_RemapRange,id:5563,x:31919,y:33112,varname:node_5563,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-8736-OUT;n:type:ShaderForge.SFN_Clamp01,id:8050,x:32079,y:33112,varname:node_8050,prsc:2|IN-5563-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:2702,x:32257,y:33424,varname:node_2702,prsc:2|IN-5510-V,IMIN-208-OUT,IMAX-3914-OUT,OMIN-5674-OUT,OMAX-2182-OUT;n:type:ShaderForge.SFN_Vector1,id:7966,x:31635,y:33569,varname:node_7966,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Vector1,id:5674,x:31967,y:33674,varname:node_5674,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2182,x:31967,y:33727,varname:node_2182,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:3914,x:31815,y:33650,varname:node_3914,prsc:2|A-7966-OUT,B-208-OUT;n:type:ShaderForge.SFN_Slider,id:208,x:31269,y:33493,ptovrint:False,ptlb:sdfdsaf,ptin:_sdfdsaf,varname:_Offset_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Clamp01,id:3859,x:32413,y:33424,varname:node_3859,prsc:2|IN-2702-OUT;proporder:7241-4013-9492-7011-208;pass:END;sub:END;*/

Shader "Shader Forge/Ball" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Offset ("Offset", Range(0, 5)) = 0.6480603
        _Offset_copy ("Offset_copy", Range(-0.1, 1)) = -0.1
        _node_7011 ("node_7011", 2D) = "white" {}
        _sdfdsaf ("sdfdsaf", Range(0, 1)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Offset;
            uniform sampler2D _node_7011; uniform float4 _node_7011_ST;
            uniform float _sdfdsaf;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_5674 = 0.0;
                v.vertex.xyz += (v.normal*_Offset*saturate((node_5674 + ( (o.uv0.g - _sdfdsaf) * (1.0 - node_5674) ) / ((0.1+_sdfdsaf) - _sdfdsaf))));
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float2 node_8050 = saturate((mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb.rg*0.5+0.5));
                float4 _node_7011_var = tex2D(_node_7011,TRANSFORM_TEX(node_8050, _node_7011));
                float3 emissive = _node_7011_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Offset;
            uniform float _sdfdsaf;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_5674 = 0.0;
                v.vertex.xyz += (v.normal*_Offset*saturate((node_5674 + ( (o.uv0.g - _sdfdsaf) * (1.0 - node_5674) ) / ((0.1+_sdfdsaf) - _sdfdsaf))));
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
