// This code is related to an answer I provided in the Unity forums at:
// http://forum.unity3d.com/threads/circular-fade-in-out-shader.344816/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Screen Transition")]
public class ScreenTransitionImageEffect : MonoBehaviour
{
    /// Provides a shader property that is set in the inspector
    /// and a material instantiated from the shader
    public Shader shader;

    [Range(0,1.0f)]
    private float maskValue = 1.052f;
    public Color maskColor = Color.black;
    public Texture2D maskTexture;
    public bool maskInvert;
    public bool activated = false;
    public GameObject button;
    public GameObject logo;
    public bool isFading = false;

    private Material m_Material;
    private bool m_maskInvert;

    Material material
    {
        get
        {
            if (m_Material == null)
            {
                m_Material = new Material(shader);
                m_Material.hideFlags = HideFlags.HideAndDontSave;
            }
            return m_Material;
        }
    }

    void Start()
    {
        // Disable if we don't support image effects
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        }

        shader = Shader.Find("Hidden/ScreenTransitionImageEffect");

        // Disable the image effect if the shader can't
        // run on the users graphics card
        if (shader == null || !shader.isSupported)
            enabled = false;
    }

    void FixedUpdate(){
        if(activated)
            maskValue -= .01f;
        if(maskValue <= .25f){
            //load scene
			SceneManager.LoadScene(0, LoadSceneMode.Single);

        }

        if(isFading){
            fadeLogo();
        }
    }

    void fadeLogo(){
        Color lc = logo.GetComponent<Image>().color;
        logo.GetComponent<Image>().color = new Color(lc.r, lc.g, lc.b, lc.a - 0.03f);
	}


    void OnDisable()
    {
        if (m_Material)
        {
            DestroyImmediate(m_Material);
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (!enabled)
        {
            Graphics.Blit(source, destination);
            return;
        }

        material.SetColor("_MaskColor", maskColor);
        material.SetFloat("_MaskValue", maskValue);
        material.SetTexture("_MainTex", source);
        material.SetTexture("_MaskTex", maskTexture);

        if (material.IsKeywordEnabled("INVERT_MASK") != maskInvert)
        {
            if (maskInvert)
                material.EnableKeyword("INVERT_MASK");
            else
                material.DisableKeyword("INVERT_MASK");
        }

        Graphics.Blit(source, destination, material);
    }
}
