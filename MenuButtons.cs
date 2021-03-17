using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaturalRendering;

public class MenuButtons : MonoBehaviour
{
    private NaturalRendering.Manager manager;
    NR_Input input;
    Button PeripheralBlurButton;
    PeripheralBlur pb;

    Button RadialDOFButton;
    DofRadialOptimised dof;

    Button WorldPosRenderButton;
    WorldPositionConfig wp;

    Button GlowButton;

    //Button ColourEnhanceButton;

    Button DistanceAdaptButton;

    Button ProtractorButton;
    public GameObject Protractor;

    Button NaturalRenderingButton;
    Button LinearButton;
    Button OrthographicFisheyeButton;
    Button EquidistantFisheyeButton;
    Button EquirectangularButton;
    Button PaniniButton;
    Button TessWireframeButton;
    Button UnityStandardLinearButton;
    Button SavePresetButton;
    Button LoadPresetButton;
    Button MousePosButton;
    Button TaurusButton;
    public GameObject Sprite2D;
    public GameObject Taurus3D;

    bool PeripheralBlurBool = false;
    bool DOFBool = false;
    bool WPRBool = false;
    bool GlowBool = false;
    //bool ColourEnhBool = false;
    bool DistAdaptBool = false;
    bool ProtractorBool = false;
    bool NRBool = false;
    bool LinearBool = false;
    bool OrthoFishBool = false;
    bool EquidistFishBool = false;
    bool EquirectBool = false;
    bool PaniniBool = false;
    bool TessWireBool = false;
    bool UnityStandardBool = false;
    bool SavePresetBool = false;
    bool LoadPresetBool = false;
    bool MousePosBool = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<NaturalRendering.Manager>();
        input = manager.NR_MainCam.GetComponent<NR_Input>();
        
        PeripheralBlurButton = GameObject.Find("PeripheralBlur").GetComponent<Button>();
        pb = manager.NR_MainCam.GetComponent<PeripheralBlur>();

        RadialDOFButton = GameObject.Find("RadialDOF").GetComponent<Button>();
        dof = manager.NR_MainCam.GetComponent<DofRadialOptimised>();

        WorldPosRenderButton = GameObject.Find("WorldPosRender").GetComponent<Button>();
        wp = manager.NR_MainCam.GetComponent<WorldPositionConfig>();

        GlowButton = GameObject.Find("Glow").GetComponent<Button>();

        //ColourEnhanceButton = GameObject.Find("ColourEnhance").GetComponent<Button>();

        DistanceAdaptButton = GameObject.Find("DistanceAdapt").GetComponent<Button>();

        ProtractorButton = GameObject.Find("ProtractorBut").GetComponent<Button>();
        //Protractor = GameObject.Find("Protractor");
        //Sprite2D = GameObject.Find("2DSprite");

        NaturalRenderingButton = GameObject.Find("NaturalRendering").GetComponent<Button>();
        LinearButton = GameObject.Find("Linear").GetComponent<Button>();
        OrthographicFisheyeButton = GameObject.Find("OrthographicFisheye").GetComponent<Button>();
        EquidistantFisheyeButton = GameObject.Find("EquidistantFisheye").GetComponent<Button>();
        EquirectangularButton = GameObject.Find("Equirectangular").GetComponent<Button>();
        PaniniButton = GameObject.Find("Panini").GetComponent<Button>();
        TessWireframeButton = GameObject.Find("TessWireframe").GetComponent<Button>();
        UnityStandardLinearButton = GameObject.Find("UnityStandardLinear").GetComponent<Button>();
        SavePresetButton = GameObject.Find("SavePreset").GetComponent<Button>();
        LoadPresetButton = GameObject.Find("LoadPreset").GetComponent<Button>();
        MousePosButton = GameObject.Find("MousePos").GetComponent<Button>();
        TaurusButton = GameObject.Find("TaurusAsset").GetComponent<Button>();

        PeripheralBlurButton.onClick.AddListener(delegate { BlurButt(); });
        RadialDOFButton.onClick.AddListener(delegate { DOFButt(); });
        WorldPosRenderButton.onClick.AddListener(delegate { WPRButt(); });
        GlowButton.onClick.AddListener(delegate { GlowButt(); });
        //ColourEnhanceButton.onClick.AddListener(delegate { ColourEnhButt(); });
        DistanceAdaptButton.onClick.AddListener(delegate { DistAdaptButt(); });
        ProtractorButton.onClick.AddListener(delegate { ProtractorButt(); });
        NaturalRenderingButton.onClick.AddListener(delegate { NRButt(); });
        LinearButton.onClick.AddListener(delegate { LinearButt(); });
        OrthographicFisheyeButton.onClick.AddListener(delegate { OrthoFishButt(); });
        EquidistantFisheyeButton.onClick.AddListener(delegate { EquiFishButt(); });
        EquirectangularButton.onClick.AddListener(delegate { EquirectButt(); });
        PaniniButton.onClick.AddListener(delegate { PaniniButt(); });
        TessWireframeButton.onClick.AddListener(delegate { TessWireButt(); });
        UnityStandardLinearButton.onClick.AddListener(delegate { UnityLinearButt(); });
        SavePresetButton.onClick.AddListener(delegate { SaveButt(); });
        LoadPresetButton.onClick.AddListener(delegate { LoadButt(); });
        MousePosButton.onClick.AddListener(delegate { MouseButt(); });
        TaurusButton.onClick.AddListener(delegate { TaurusButt(); });
    }

    // Update is called once per frame
    void Update()
    {
        if (PeripheralBlurBool)
        {
            if(pb != null)
            {
                pb.enabled = false;
            }

        }
        if (!PeripheralBlurBool)
        {
            pb.enabled = true;
        }
        if (DOFBool)
        {
            if(dof != null)
            {
                dof.enabled = false;
            }
        }
        if (!DOFBool)
        {
            dof.enabled = true;
        }
        if (WPRBool)
        {
            if(wp != null)
            {
                wp.NR_CheckWP.isOn = true;
                wp.NR_CheckWPRender();
            }

        }
        if (!WPRBool)
        {
            wp.NR_CheckWP.isOn = false;
        }
        if (GlowBool)
        {
            manager.GlowOn = true;
        }
        if (!GlowBool)
        {
            manager.GlowOn = false;
        }
        if (DistAdaptBool)
        {
            manager.NR_ProximityTrigger = true; 
        }
        if (!DistAdaptBool)
        {
            manager.NR_ProximityTrigger = false;
        }
        if (ProtractorBool)
        {
            Protractor.SetActive(true);
        }
        if (!ProtractorBool)
        {
            Protractor.SetActive(false);
        }
        if (TessWireBool)
        {
            NR_WireFrame.wireFrameMode = true;
        }
        if (!TessWireBool)
        {
            NR_WireFrame.wireFrameMode = false;
        }
    }
    
    //Peripheral Blur
    void BlurButt()
    {
        PeripheralBlurBool = !PeripheralBlurBool;
    }

    void DOFButt()
    {
        DOFBool = !DOFBool;
    }

    void WPRButt()
    {
        WPRBool = !WPRBool;
    }

    void GlowButt()
    {
        GlowBool = !GlowBool;
    }

    //void ColourEnhButt()
    //{
    //    input.ToggleColorEnhance();
    //}

    void DistAdaptButt()
    {
        DistAdaptBool = !DistAdaptBool;
    }

    void ProtractorButt()
    {
        ProtractorBool = !ProtractorBool;
    }

    void NRButt()
    {
        //manager.CurrentNRStyle = Manager.NR_Style.NR_NATURAL_VULKAN;
        manager.NR_SetNaturalPerspective();
        
    }

    void LinearButt()
    {
        //manager.CurrentNRStyle = Manager.NR_Style.NR_LINEAR;
        manager.NR_SetLinear();
    }

    void OrthoFishButt()
    {
        //manager.CurrentNRStyle = Manager.NR_Style.NR_FISHEYE_ORTHOGRAPHIC;
        manager.NR_SetFisheyeOrthographic();
    }

    void EquiFishButt()
    {
        //manager.CurrentNRStyle = Manager.NR_Style.NR_FISHEYE_EQUIDISTANT;
        manager.NR_SetFisheyeEquidistant();
    }

    void EquirectButt()
    {
        //manager.CurrentNRStyle = Manager.NR_Style.NR_EQUIRECTANGULAR;
        manager.NR_SetEquirectangular();
    }

    void PaniniButt()
    {
        //manager.CurrentNRStyle = Manager.NR_Style.NR_PANINI;
        manager.NR_SetPanini();
    }

    void TessWireButt()
    {
        TessWireBool = !TessWireBool;
    }
    void UnityLinearButt()
    {
        manager.NR_SetLinear();
        
    }
    void SaveButt()
    {
        manager.SaveSettings();
    }
    void LoadButt()
    {
        manager.LoadSettings();
    }

    void MouseButt()
    {
        Sprite2D.SetActive(!Sprite2D.activeSelf);
    }

    void TaurusButt()
    {
        Taurus3D.SetActive(!Taurus3D.activeSelf);
    }
}
