Shader "Custom/XRayShader"
{
    SubShader
    {
        // this uses the currently rendered output as the object's skin
        Pass {
            ColorMask GB
            Blend Zero One
        }
    }
}