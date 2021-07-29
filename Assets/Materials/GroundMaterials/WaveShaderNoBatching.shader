Shader "WaveShaderNoBatching"
{
    Properties
    {
        [NoScaleOffset]_MainTex("MainTex", 2D) = "white" {}
        WaveSpeed("WaveSpeed", Float) = 1
        [HDR]_TintColor("TintColor", Color) = (0, 0, 0, 0)
        _Offset("Offset", Float) = 0
        [HideInInspector][NoScaleOffset]unity_Lightmaps("unity_Lightmaps", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset]unity_LightmapsInd("unity_LightmapsInd", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset]unity_ShadowMasks("unity_ShadowMasks", 2DArray) = "" {}
    }
    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Transparent"
            "UniversalMaterialType" = "Unlit"
            "Queue"="Transparent"
            "DisableBatching"="True"
        }
        Pass
        {
            Name "Sprite Unlit"
            Tags
            {
                "LightMode" = "Universal2D"
            }

            // Render State
            Cull Off
        Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
        ZTest LEqual
        ZWrite Off

            // Debug
            // <None>

            // --------------------------------------------------
            // Pass

            HLSLPROGRAM

            // Pragmas
            #pragma target 2.0
        #pragma exclude_renderers d3d11_9x
        #pragma vertex vert
        #pragma fragment frag

            // DotsInstancingOptions: <None>
            // HybridV1InjectedBuiltinProperties: <None>

            // Keywords
            // PassKeywords: <None>
            // GraphKeywords: <None>

            // Defines
            #define _SURFACE_TYPE_TRANSPARENT 1
            #define ATTRIBUTES_NEED_NORMAL
            #define ATTRIBUTES_NEED_TANGENT
            #define ATTRIBUTES_NEED_TEXCOORD0
            #define ATTRIBUTES_NEED_COLOR
            #define VARYINGS_NEED_TEXCOORD0
            #define VARYINGS_NEED_COLOR
            #define FEATURES_GRAPH_VERTEX
            /* WARNING: $splice Could not find named fragment 'PassInstancing' */
            #define SHADERPASS SHADERPASS_SPRITEUNLIT
            /* WARNING: $splice Could not find named fragment 'DotsInstancingVars' */

            // Includes
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

            // --------------------------------------------------
            // Structs and Packing

            struct Attributes
        {
            float3 positionOS : POSITION;
            float3 normalOS : NORMAL;
            float4 tangentOS : TANGENT;
            float4 uv0 : TEXCOORD0;
            float4 color : COLOR;
            #if UNITY_ANY_INSTANCING_ENABLED
            uint instanceID : INSTANCEID_SEMANTIC;
            #endif
        };
        struct Varyings
        {
            float4 positionCS : SV_POSITION;
            float4 texCoord0;
            float4 color;
            #if UNITY_ANY_INSTANCING_ENABLED
            uint instanceID : CUSTOM_INSTANCE_ID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
            uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
            uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
            #endif
        };
        struct SurfaceDescriptionInputs
        {
            float4 uv0;
        };
        struct VertexDescriptionInputs
        {
            float3 ObjectSpaceNormal;
            float3 ObjectSpaceTangent;
            float3 ObjectSpacePosition;
            float3 TimeParameters;
        };
        struct PackedVaryings
        {
            float4 positionCS : SV_POSITION;
            float4 interp0 : TEXCOORD0;
            float4 interp1 : TEXCOORD1;
            #if UNITY_ANY_INSTANCING_ENABLED
            uint instanceID : CUSTOM_INSTANCE_ID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
            uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
            uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
            #endif
        };

            PackedVaryings PackVaryings (Varyings input)
        {
            PackedVaryings output;
            output.positionCS = input.positionCS;
            output.interp0.xyzw =  input.texCoord0;
            output.interp1.xyzw =  input.color;
            #if UNITY_ANY_INSTANCING_ENABLED
            output.instanceID = input.instanceID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
            output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
            output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            output.cullFace = input.cullFace;
            #endif
            return output;
        }
        Varyings UnpackVaryings (PackedVaryings input)
        {
            Varyings output;
            output.positionCS = input.positionCS;
            output.texCoord0 = input.interp0.xyzw;
            output.color = input.interp1.xyzw;
            #if UNITY_ANY_INSTANCING_ENABLED
            output.instanceID = input.instanceID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
            output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
            output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            output.cullFace = input.cullFace;
            #endif
            return output;
        }

            // --------------------------------------------------
            // Graph

            // Graph Properties
            CBUFFER_START(UnityPerMaterial)
        float4 _MainTex_TexelSize;
        float WaveSpeed;
        float4 _TintColor;
        float _Offset;
        CBUFFER_END

        // Object and Global properties
        SAMPLER(SamplerState_Linear_Repeat);
        TEXTURE2D(_MainTex);
        SAMPLER(sampler_MainTex);

            // Graph Functions
            
        void Unity_Absolute_float(float In, out float Out)
        {
            Out = abs(In);
        }

        void Unity_Divide_float(float A, float B, out float Out)
        {
            Out = A / B;
        }

        void Unity_Multiply_float(float A, float B, out float Out)
        {
            Out = A * B;
        }

        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }

        void Unity_Sine_float(float In, out float Out)
        {
            Out = sin(In);
        }

        void Unity_Subtract_float(float A, float B, out float Out)
        {
            Out = A - B;
        }

        void Unity_Combine_float(float R, float G, float B, float A, out float4 RGBA, out float3 RGB, out float2 RG)
        {
            RGBA = float4(R, G, B, A);
            RGB = float3(R, G, B);
            RG = float2(R, G);
        }

        void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
        {
            Out = A * B;
        }

            // Graph Vertex
            struct VertexDescription
        {
            float3 Position;
            float3 Normal;
            float3 Tangent;
        };

        VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
        {
            VertexDescription description = (VertexDescription)0;
            float _Split_50059cd4be47438dace6645e315be2d6_R_1 = IN.ObjectSpacePosition[0];
            float _Split_50059cd4be47438dace6645e315be2d6_G_2 = IN.ObjectSpacePosition[1];
            float _Split_50059cd4be47438dace6645e315be2d6_B_3 = IN.ObjectSpacePosition[2];
            float _Split_50059cd4be47438dace6645e315be2d6_A_4 = 0;
            float _Absolute_3528164477d84da28ecd10c1cad21b85_Out_1;
            Unity_Absolute_float(_Split_50059cd4be47438dace6645e315be2d6_R_1, _Absolute_3528164477d84da28ecd10c1cad21b85_Out_1);
            float _Divide_2e44b69dbd46472f8712b6488ba55fbf_Out_2;
            Unity_Divide_float(_Split_50059cd4be47438dace6645e315be2d6_R_1, _Absolute_3528164477d84da28ecd10c1cad21b85_Out_1, _Divide_2e44b69dbd46472f8712b6488ba55fbf_Out_2);
            float _Property_f2e16403f68747a3aac4c40d4ab0c89c_Out_0 = _Offset;
            float _Property_12b83d65d3244496937da101e2054deb_Out_0 = WaveSpeed;
            float _Multiply_04598316979d44f8b3981247dc8e4a90_Out_2;
            Unity_Multiply_float(IN.TimeParameters.x, _Property_12b83d65d3244496937da101e2054deb_Out_0, _Multiply_04598316979d44f8b3981247dc8e4a90_Out_2);
            float _Add_d10dbf00043c4cdd8d8dee72969e6e73_Out_2;
            Unity_Add_float(_Property_f2e16403f68747a3aac4c40d4ab0c89c_Out_0, _Multiply_04598316979d44f8b3981247dc8e4a90_Out_2, _Add_d10dbf00043c4cdd8d8dee72969e6e73_Out_2);
            float _Sine_4ecb96c44395490e8f77794b3c39b444_Out_1;
            Unity_Sine_float(_Add_d10dbf00043c4cdd8d8dee72969e6e73_Out_2, _Sine_4ecb96c44395490e8f77794b3c39b444_Out_1);
            float _Divide_dfdee99591ce4688ad855bccef9fb791_Out_2;
            Unity_Divide_float(_Sine_4ecb96c44395490e8f77794b3c39b444_Out_1, 20, _Divide_dfdee99591ce4688ad855bccef9fb791_Out_2);
            float _Subtract_f18e02d31e0e47c6be32c1a1918dbe8d_Out_2;
            Unity_Subtract_float(_Divide_dfdee99591ce4688ad855bccef9fb791_Out_2, 0.05, _Subtract_f18e02d31e0e47c6be32c1a1918dbe8d_Out_2);
            float _Multiply_bf271ffd21a54fe298306391f33e5c5b_Out_2;
            Unity_Multiply_float(_Divide_2e44b69dbd46472f8712b6488ba55fbf_Out_2, _Subtract_f18e02d31e0e47c6be32c1a1918dbe8d_Out_2, _Multiply_bf271ffd21a54fe298306391f33e5c5b_Out_2);
            float _Add_f88f224b2dc14611a6cc9a69be1465b4_Out_2;
            Unity_Add_float(_Split_50059cd4be47438dace6645e315be2d6_R_1, _Multiply_bf271ffd21a54fe298306391f33e5c5b_Out_2, _Add_f88f224b2dc14611a6cc9a69be1465b4_Out_2);
            float _Absolute_3c361f55e7704224b1492705e29888e8_Out_1;
            Unity_Absolute_float(_Split_50059cd4be47438dace6645e315be2d6_G_2, _Absolute_3c361f55e7704224b1492705e29888e8_Out_1);
            float _Divide_f1c0c768cbaf4a9388bfdace4f165fb5_Out_2;
            Unity_Divide_float(_Split_50059cd4be47438dace6645e315be2d6_G_2, _Absolute_3c361f55e7704224b1492705e29888e8_Out_1, _Divide_f1c0c768cbaf4a9388bfdace4f165fb5_Out_2);
            float _Multiply_808e9d00ecd54b6ea16bf72c6a4149c1_Out_2;
            Unity_Multiply_float(_Divide_f1c0c768cbaf4a9388bfdace4f165fb5_Out_2, _Subtract_f18e02d31e0e47c6be32c1a1918dbe8d_Out_2, _Multiply_808e9d00ecd54b6ea16bf72c6a4149c1_Out_2);
            float _Add_dc74aaf1c7274fcca54309b43e820fb1_Out_2;
            Unity_Add_float(_Split_50059cd4be47438dace6645e315be2d6_G_2, _Multiply_808e9d00ecd54b6ea16bf72c6a4149c1_Out_2, _Add_dc74aaf1c7274fcca54309b43e820fb1_Out_2);
            float4 _Combine_6b8f35f1fc334037993598ec19020126_RGBA_4;
            float3 _Combine_6b8f35f1fc334037993598ec19020126_RGB_5;
            float2 _Combine_6b8f35f1fc334037993598ec19020126_RG_6;
            Unity_Combine_float(_Add_f88f224b2dc14611a6cc9a69be1465b4_Out_2, _Add_dc74aaf1c7274fcca54309b43e820fb1_Out_2, _Split_50059cd4be47438dace6645e315be2d6_B_3, 0, _Combine_6b8f35f1fc334037993598ec19020126_RGBA_4, _Combine_6b8f35f1fc334037993598ec19020126_RGB_5, _Combine_6b8f35f1fc334037993598ec19020126_RG_6);
            description.Position = _Combine_6b8f35f1fc334037993598ec19020126_RGB_5;
            description.Normal = IN.ObjectSpaceNormal;
            description.Tangent = IN.ObjectSpaceTangent;
            return description;
        }

            // Graph Pixel
            struct SurfaceDescription
        {
            float3 BaseColor;
            float Alpha;
        };

        SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
        {
            SurfaceDescription surface = (SurfaceDescription)0;
            UnityTexture2D _Property_648a8c34d56d4dbbac7421d4cbe73d4c_Out_0 = UnityBuildTexture2DStructNoScale(_MainTex);
            float4 _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0 = SAMPLE_TEXTURE2D(_Property_648a8c34d56d4dbbac7421d4cbe73d4c_Out_0.tex, _Property_648a8c34d56d4dbbac7421d4cbe73d4c_Out_0.samplerstate, IN.uv0.xy);
            float _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_R_4 = _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0.r;
            float _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_G_5 = _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0.g;
            float _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_B_6 = _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0.b;
            float _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_A_7 = _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0.a;
            float4 _Property_800209e6b7fe4ef8b6fba5d06e7a04c7_Out_0 = IsGammaSpace() ? LinearToSRGB(_TintColor) : _TintColor;
            float4 _Multiply_04ef26bcb8be4135ab35550d01afc734_Out_2;
            Unity_Multiply_float(_SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0, _Property_800209e6b7fe4ef8b6fba5d06e7a04c7_Out_0, _Multiply_04ef26bcb8be4135ab35550d01afc734_Out_2);
            surface.BaseColor = (_Multiply_04ef26bcb8be4135ab35550d01afc734_Out_2.xyz);
            surface.Alpha = _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_A_7;
            return surface;
        }

            // --------------------------------------------------
            // Build Graph Inputs

            VertexDescriptionInputs BuildVertexDescriptionInputs(Attributes input)
        {
            VertexDescriptionInputs output;
            ZERO_INITIALIZE(VertexDescriptionInputs, output);

            output.ObjectSpaceNormal =           input.normalOS;
            output.ObjectSpaceTangent =          input.tangentOS.xyz;
            output.ObjectSpacePosition =         input.positionOS;
            output.TimeParameters =              _TimeParameters.xyz;

            return output;
        }
            SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
        {
            SurfaceDescriptionInputs output;
            ZERO_INITIALIZE(SurfaceDescriptionInputs, output);





            output.uv0 =                         input.texCoord0;
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
        #else
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
        #endif
        #undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN

            return output;
        }

            // --------------------------------------------------
            // Main

            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/SpriteUnlitPass.hlsl"

            ENDHLSL
        }
        Pass
        {
            Name "Sprite Unlit"
            Tags
            {
                "LightMode" = "UniversalForward"
            }

            // Render State
            Cull Off
        Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
        ZTest LEqual
        ZWrite Off

            // Debug
            // <None>

            // --------------------------------------------------
            // Pass

            HLSLPROGRAM

            // Pragmas
            #pragma target 2.0
        #pragma exclude_renderers d3d11_9x
        #pragma vertex vert
        #pragma fragment frag

            // DotsInstancingOptions: <None>
            // HybridV1InjectedBuiltinProperties: <None>

            // Keywords
            // PassKeywords: <None>
            // GraphKeywords: <None>

            // Defines
            #define _SURFACE_TYPE_TRANSPARENT 1
            #define ATTRIBUTES_NEED_NORMAL
            #define ATTRIBUTES_NEED_TANGENT
            #define ATTRIBUTES_NEED_TEXCOORD0
            #define ATTRIBUTES_NEED_COLOR
            #define VARYINGS_NEED_TEXCOORD0
            #define VARYINGS_NEED_COLOR
            #define FEATURES_GRAPH_VERTEX
            /* WARNING: $splice Could not find named fragment 'PassInstancing' */
            #define SHADERPASS SHADERPASS_SPRITEFORWARD
            /* WARNING: $splice Could not find named fragment 'DotsInstancingVars' */

            // Includes
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

            // --------------------------------------------------
            // Structs and Packing

            struct Attributes
        {
            float3 positionOS : POSITION;
            float3 normalOS : NORMAL;
            float4 tangentOS : TANGENT;
            float4 uv0 : TEXCOORD0;
            float4 color : COLOR;
            #if UNITY_ANY_INSTANCING_ENABLED
            uint instanceID : INSTANCEID_SEMANTIC;
            #endif
        };
        struct Varyings
        {
            float4 positionCS : SV_POSITION;
            float4 texCoord0;
            float4 color;
            #if UNITY_ANY_INSTANCING_ENABLED
            uint instanceID : CUSTOM_INSTANCE_ID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
            uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
            uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
            #endif
        };
        struct SurfaceDescriptionInputs
        {
            float4 uv0;
        };
        struct VertexDescriptionInputs
        {
            float3 ObjectSpaceNormal;
            float3 ObjectSpaceTangent;
            float3 ObjectSpacePosition;
            float3 TimeParameters;
        };
        struct PackedVaryings
        {
            float4 positionCS : SV_POSITION;
            float4 interp0 : TEXCOORD0;
            float4 interp1 : TEXCOORD1;
            #if UNITY_ANY_INSTANCING_ENABLED
            uint instanceID : CUSTOM_INSTANCE_ID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
            uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
            uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
            #endif
        };

            PackedVaryings PackVaryings (Varyings input)
        {
            PackedVaryings output;
            output.positionCS = input.positionCS;
            output.interp0.xyzw =  input.texCoord0;
            output.interp1.xyzw =  input.color;
            #if UNITY_ANY_INSTANCING_ENABLED
            output.instanceID = input.instanceID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
            output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
            output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            output.cullFace = input.cullFace;
            #endif
            return output;
        }
        Varyings UnpackVaryings (PackedVaryings input)
        {
            Varyings output;
            output.positionCS = input.positionCS;
            output.texCoord0 = input.interp0.xyzw;
            output.color = input.interp1.xyzw;
            #if UNITY_ANY_INSTANCING_ENABLED
            output.instanceID = input.instanceID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
            output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
            output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            output.cullFace = input.cullFace;
            #endif
            return output;
        }

            // --------------------------------------------------
            // Graph

            // Graph Properties
            CBUFFER_START(UnityPerMaterial)
        float4 _MainTex_TexelSize;
        float WaveSpeed;
        float4 _TintColor;
        float _Offset;
        CBUFFER_END

        // Object and Global properties
        SAMPLER(SamplerState_Linear_Repeat);
        TEXTURE2D(_MainTex);
        SAMPLER(sampler_MainTex);

            // Graph Functions
            
        void Unity_Absolute_float(float In, out float Out)
        {
            Out = abs(In);
        }

        void Unity_Divide_float(float A, float B, out float Out)
        {
            Out = A / B;
        }

        void Unity_Multiply_float(float A, float B, out float Out)
        {
            Out = A * B;
        }

        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }

        void Unity_Sine_float(float In, out float Out)
        {
            Out = sin(In);
        }

        void Unity_Subtract_float(float A, float B, out float Out)
        {
            Out = A - B;
        }

        void Unity_Combine_float(float R, float G, float B, float A, out float4 RGBA, out float3 RGB, out float2 RG)
        {
            RGBA = float4(R, G, B, A);
            RGB = float3(R, G, B);
            RG = float2(R, G);
        }

        void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
        {
            Out = A * B;
        }

            // Graph Vertex
            struct VertexDescription
        {
            float3 Position;
            float3 Normal;
            float3 Tangent;
        };

        VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
        {
            VertexDescription description = (VertexDescription)0;
            float _Split_50059cd4be47438dace6645e315be2d6_R_1 = IN.ObjectSpacePosition[0];
            float _Split_50059cd4be47438dace6645e315be2d6_G_2 = IN.ObjectSpacePosition[1];
            float _Split_50059cd4be47438dace6645e315be2d6_B_3 = IN.ObjectSpacePosition[2];
            float _Split_50059cd4be47438dace6645e315be2d6_A_4 = 0;
            float _Absolute_3528164477d84da28ecd10c1cad21b85_Out_1;
            Unity_Absolute_float(_Split_50059cd4be47438dace6645e315be2d6_R_1, _Absolute_3528164477d84da28ecd10c1cad21b85_Out_1);
            float _Divide_2e44b69dbd46472f8712b6488ba55fbf_Out_2;
            Unity_Divide_float(_Split_50059cd4be47438dace6645e315be2d6_R_1, _Absolute_3528164477d84da28ecd10c1cad21b85_Out_1, _Divide_2e44b69dbd46472f8712b6488ba55fbf_Out_2);
            float _Property_f2e16403f68747a3aac4c40d4ab0c89c_Out_0 = _Offset;
            float _Property_12b83d65d3244496937da101e2054deb_Out_0 = WaveSpeed;
            float _Multiply_04598316979d44f8b3981247dc8e4a90_Out_2;
            Unity_Multiply_float(IN.TimeParameters.x, _Property_12b83d65d3244496937da101e2054deb_Out_0, _Multiply_04598316979d44f8b3981247dc8e4a90_Out_2);
            float _Add_d10dbf00043c4cdd8d8dee72969e6e73_Out_2;
            Unity_Add_float(_Property_f2e16403f68747a3aac4c40d4ab0c89c_Out_0, _Multiply_04598316979d44f8b3981247dc8e4a90_Out_2, _Add_d10dbf00043c4cdd8d8dee72969e6e73_Out_2);
            float _Sine_4ecb96c44395490e8f77794b3c39b444_Out_1;
            Unity_Sine_float(_Add_d10dbf00043c4cdd8d8dee72969e6e73_Out_2, _Sine_4ecb96c44395490e8f77794b3c39b444_Out_1);
            float _Divide_dfdee99591ce4688ad855bccef9fb791_Out_2;
            Unity_Divide_float(_Sine_4ecb96c44395490e8f77794b3c39b444_Out_1, 20, _Divide_dfdee99591ce4688ad855bccef9fb791_Out_2);
            float _Subtract_f18e02d31e0e47c6be32c1a1918dbe8d_Out_2;
            Unity_Subtract_float(_Divide_dfdee99591ce4688ad855bccef9fb791_Out_2, 0.05, _Subtract_f18e02d31e0e47c6be32c1a1918dbe8d_Out_2);
            float _Multiply_bf271ffd21a54fe298306391f33e5c5b_Out_2;
            Unity_Multiply_float(_Divide_2e44b69dbd46472f8712b6488ba55fbf_Out_2, _Subtract_f18e02d31e0e47c6be32c1a1918dbe8d_Out_2, _Multiply_bf271ffd21a54fe298306391f33e5c5b_Out_2);
            float _Add_f88f224b2dc14611a6cc9a69be1465b4_Out_2;
            Unity_Add_float(_Split_50059cd4be47438dace6645e315be2d6_R_1, _Multiply_bf271ffd21a54fe298306391f33e5c5b_Out_2, _Add_f88f224b2dc14611a6cc9a69be1465b4_Out_2);
            float _Absolute_3c361f55e7704224b1492705e29888e8_Out_1;
            Unity_Absolute_float(_Split_50059cd4be47438dace6645e315be2d6_G_2, _Absolute_3c361f55e7704224b1492705e29888e8_Out_1);
            float _Divide_f1c0c768cbaf4a9388bfdace4f165fb5_Out_2;
            Unity_Divide_float(_Split_50059cd4be47438dace6645e315be2d6_G_2, _Absolute_3c361f55e7704224b1492705e29888e8_Out_1, _Divide_f1c0c768cbaf4a9388bfdace4f165fb5_Out_2);
            float _Multiply_808e9d00ecd54b6ea16bf72c6a4149c1_Out_2;
            Unity_Multiply_float(_Divide_f1c0c768cbaf4a9388bfdace4f165fb5_Out_2, _Subtract_f18e02d31e0e47c6be32c1a1918dbe8d_Out_2, _Multiply_808e9d00ecd54b6ea16bf72c6a4149c1_Out_2);
            float _Add_dc74aaf1c7274fcca54309b43e820fb1_Out_2;
            Unity_Add_float(_Split_50059cd4be47438dace6645e315be2d6_G_2, _Multiply_808e9d00ecd54b6ea16bf72c6a4149c1_Out_2, _Add_dc74aaf1c7274fcca54309b43e820fb1_Out_2);
            float4 _Combine_6b8f35f1fc334037993598ec19020126_RGBA_4;
            float3 _Combine_6b8f35f1fc334037993598ec19020126_RGB_5;
            float2 _Combine_6b8f35f1fc334037993598ec19020126_RG_6;
            Unity_Combine_float(_Add_f88f224b2dc14611a6cc9a69be1465b4_Out_2, _Add_dc74aaf1c7274fcca54309b43e820fb1_Out_2, _Split_50059cd4be47438dace6645e315be2d6_B_3, 0, _Combine_6b8f35f1fc334037993598ec19020126_RGBA_4, _Combine_6b8f35f1fc334037993598ec19020126_RGB_5, _Combine_6b8f35f1fc334037993598ec19020126_RG_6);
            description.Position = _Combine_6b8f35f1fc334037993598ec19020126_RGB_5;
            description.Normal = IN.ObjectSpaceNormal;
            description.Tangent = IN.ObjectSpaceTangent;
            return description;
        }

            // Graph Pixel
            struct SurfaceDescription
        {
            float3 BaseColor;
            float Alpha;
        };

        SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
        {
            SurfaceDescription surface = (SurfaceDescription)0;
            UnityTexture2D _Property_648a8c34d56d4dbbac7421d4cbe73d4c_Out_0 = UnityBuildTexture2DStructNoScale(_MainTex);
            float4 _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0 = SAMPLE_TEXTURE2D(_Property_648a8c34d56d4dbbac7421d4cbe73d4c_Out_0.tex, _Property_648a8c34d56d4dbbac7421d4cbe73d4c_Out_0.samplerstate, IN.uv0.xy);
            float _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_R_4 = _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0.r;
            float _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_G_5 = _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0.g;
            float _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_B_6 = _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0.b;
            float _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_A_7 = _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0.a;
            float4 _Property_800209e6b7fe4ef8b6fba5d06e7a04c7_Out_0 = IsGammaSpace() ? LinearToSRGB(_TintColor) : _TintColor;
            float4 _Multiply_04ef26bcb8be4135ab35550d01afc734_Out_2;
            Unity_Multiply_float(_SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_RGBA_0, _Property_800209e6b7fe4ef8b6fba5d06e7a04c7_Out_0, _Multiply_04ef26bcb8be4135ab35550d01afc734_Out_2);
            surface.BaseColor = (_Multiply_04ef26bcb8be4135ab35550d01afc734_Out_2.xyz);
            surface.Alpha = _SampleTexture2D_d94d54abf8cd4308b1dbd9ab31ab9131_A_7;
            return surface;
        }

            // --------------------------------------------------
            // Build Graph Inputs

            VertexDescriptionInputs BuildVertexDescriptionInputs(Attributes input)
        {
            VertexDescriptionInputs output;
            ZERO_INITIALIZE(VertexDescriptionInputs, output);

            output.ObjectSpaceNormal =           input.normalOS;
            output.ObjectSpaceTangent =          input.tangentOS.xyz;
            output.ObjectSpacePosition =         input.positionOS;
            output.TimeParameters =              _TimeParameters.xyz;

            return output;
        }
            SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
        {
            SurfaceDescriptionInputs output;
            ZERO_INITIALIZE(SurfaceDescriptionInputs, output);





            output.uv0 =                         input.texCoord0;
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
        #else
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
        #endif
        #undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN

            return output;
        }

            // --------------------------------------------------
            // Main

            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/SpriteUnlitPass.hlsl"

            ENDHLSL
        }
    }
    FallBack "Hidden/Shader Graph/FallbackError"
}