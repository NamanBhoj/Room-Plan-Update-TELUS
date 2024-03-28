using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SilverTau.RoomPlanUnity.Utilities;
// using SilverTau.Sample;
using UnityEngine;
using UnityEngine.UI;

public class ExportObjects : MonoBehaviour
{
    public GameObject exportObject;
    string modelName = "helloAli";
    public string path = "/Users/justn/Documents";
    [Tooltip("Target shader for the model to be imported. ")]
    [SerializeField] private Shader shader;
    // [Tooltip("3D viewer camera control script.")]
    // [SerializeField] private Camera3DViewController camera3DViewController;
    // Start is called before the first frame update
   void Start() {
    
     if(string.IsNullOrEmpty(path)){
        Debug.Log("comes here");
        return;
     }
     if (!Directory.Exists(path)) 
     {
        Debug.Log("comes here2");
         Directory.CreateDirectory(path); 
     }
          path = Path.Combine(path, modelName + ".obj");
          OBJUtility.Export(exportObject,path, modelName); 
          Debug.Log(Application.persistentDataPath);
        // Import(); 
    } 

        //     private void Import()
        // {
        //     if (string.IsNullOrEmpty(path)) return;
            
        //     camera3DViewController.enabled = false;
            
        //     if (_lastImportModel != null)
        //     {
        //         Destroy(_lastImportModel.gameObject);
        //     }

        //     _lastImportModel = OBJUtility.Import(path, shader);
        //     _lastImportModel.transform.parent = container;
        //     _lastImportModel.transform.localPosition = Vector3.zero;

        //     camera3DViewController.enabled = true;
        // }
}
