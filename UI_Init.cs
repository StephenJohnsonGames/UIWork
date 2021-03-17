using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UI_Init : MonoBehaviour
    {

        public void Awake()
        {
        //instantiate UI
        string fileLocation = "Packages/com.fovotec.util/Runtime/FOVOUI.prefab";
        GameObject UI_Object = (GameObject)AssetDatabase.LoadAssetAtPath(fileLocation, typeof(GameObject));
        Object.Instantiate(UI_Object);

        //find camera for attaching objects to
        Camera activeCamera = Camera.main;
        GameObject cameraObj = activeCamera.gameObject;

        //instantiate taurus
        string taurusLocation = "Packages/com.fovotec.util/Runtime/taurus.prefab";
        GameObject taurusPf = (GameObject)AssetDatabase.LoadAssetAtPath(taurusLocation, typeof(GameObject));
        GameObject taurusObj = Object.Instantiate(taurusPf);
        taurusObj.transform.parent = cameraObj.transform;
        taurusObj.transform.position = cameraObj.transform.position;
        taurusObj.transform.rotation = cameraObj.transform.rotation;

        ////instantiate protractor
        string protractorLocation = "Packages/com.fovotec.util/Runtime/Protractor.fbx";
        GameObject protractorPf = (GameObject)AssetDatabase.LoadAssetAtPath(protractorLocation, typeof(GameObject));
        GameObject protractorObj = Object.Instantiate(protractorPf);
        protractorObj.transform.parent = cameraObj.transform;
        protractorObj.transform.rotation = cameraObj.transform.rotation;
        protractorObj.transform.position = cameraObj.transform.position;

    }
    }

