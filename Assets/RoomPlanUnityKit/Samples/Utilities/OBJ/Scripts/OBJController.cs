using SilverTau.RoomPlanUnity.Utilities;
using SilverTau.Sample;
using UnityEngine;
using UnityEngine.UI;

namespace SilverTau.Utilities.Sample
{
    public class OBJController : MonoBehaviour
    {
        [Tooltip("3D viewer camera control script.")]
        [SerializeField] private Camera3DViewController camera3DViewController;
        [Tooltip("Target object for export to .obj format.")]
        [SerializeField] private GameObject targetExportObject;
        [Tooltip("A container for an imported object.")]
        [SerializeField] private Transform container;
        
        [Tooltip("The button that will perform the actions of importing the .obj.")]
        [SerializeField] private Button buttonImport;
        [Tooltip("Button that will perform the actions of exporting the .obj.")]
        [SerializeField] private Button buttonExport;

        [Tooltip("The path to the .obj file you would like to import into the scene.")]
        [SerializeField] private string importPath;
        [Tooltip("The path where the original .obj model will be exported and saved.")]
        [SerializeField] private string exportPath;
        [Tooltip("The name of the output .obj model.")]
        [SerializeField] private string exportModelName;
        
        [Tooltip("Target shader for the model to be imported. ")]
        [SerializeField] private Shader shader;

        /// <summary>
        /// The last imported object.
        /// </summary>
        private GameObject _lastImportModel;
        
        private void Start()
        {
            buttonImport.onClick.AddListener(Import);
            buttonExport.onClick.AddListener(Export);
        }

        private void OnDisable()
        {
            if (_lastImportModel != null)
            {
                Destroy(_lastImportModel.gameObject);
            }
        }

        /// <summary>
        /// The function that performs the action of importing the .obj model.
        /// </summary>
        private void Import()
        {
            if (string.IsNullOrEmpty(importPath)) return;
            
            camera3DViewController.enabled = false;
            
            if (_lastImportModel != null)
            {
                Destroy(_lastImportModel.gameObject);
            }

            _lastImportModel = OBJUtility.Import(importPath, shader);
            _lastImportModel.transform.parent = container;
            _lastImportModel.transform.localPosition = Vector3.zero;

            camera3DViewController.enabled = true;
        }

        /// <summary>
        /// The function that performs the action of exporting the .obj model.
        /// </summary>
        private void Export()
        {
            if (string.IsNullOrEmpty(exportPath))
            {
                exportPath = Application.persistentDataPath;
            }
            
            OBJUtility.Export(targetExportObject, exportPath, exportModelName);
        }
    }
}
