using System.IO;
using UnityEngine;

namespace SilverTau.RoomPlanUnity.Utilities
{
    public static class OBJUtility
    {
        #region OBJ Import

        /// <summary>
        /// Import an OBJ file from a file path. This function will also attempt to load the MTL defined in the OBJ file.
        /// </summary>
        /// <param name="path">Input path</param>
        /// <returns>Returns a GameObject represeting the OBJ file, with each imported object as a child.</returns>
        public static GameObject Import(string path, Shader shader)
        {
            if(string.IsNullOrEmpty(path)) return null;
            if(shader == null) return null;
            
            return new OBJImporter().Import(path, shader);
        }

        
        /// <summary>
        /// Import an OBJ file from a stream. No materials will be loaded, and will instead be supplemented by a blank white material.
        /// </summary>
        /// <param name="input">Input stream</param>
        /// <returns>Returns a GameObject represeting the OBJ file, with each imported object as a child.</returns>
        public static GameObject Import(Stream input, Shader shader)
        {
            if(input == null) return null;
            if(shader == null) return null;
            
            return new OBJImporter().Import(input, shader);
        }

        /// <summary>
        /// Import an OBJ and MTL file from a stream.
        /// </summary>
        /// <param name="input">Input stream</param>
        /// /// <param name="mtlInput">Input MTL stream</param>
        /// <returns>Returns a GameObject represeting the OBJ file, with each imported object as a child.</returns>
        public static GameObject Import(Stream input, Stream mtlInput, Shader shader)
        {
            if(input == null) return null;
            if(mtlInput == null) return null;
            if(shader == null) return null;

            return new OBJImporter().Import(input, mtlInput, shader);
        }


        /// <summary>
        /// Import an OBJ and MTL file from a file path.
        /// </summary>
        /// <param name="path">Input path</param>
        /// /// <param name="mtlPath">Input MTL path</param>
        /// <returns>Returns a GameObject represeting the OBJ file, with each imported object as a child.</returns>
        public static GameObject Import(string path, string mtlPath, Shader shader)
        {
            if(string.IsNullOrEmpty(path)) return null;
            if(string.IsNullOrEmpty(mtlPath)) return null;
            if(shader == null) return null;

            return new OBJImporter().Import(path, mtlPath, shader);
        }
        
        #endregion
        
        #region OBJ Export
        
        /// <summary>
        /// Export game object to OBJ format model.
        /// </summary>
        /// <param name="exportObject">Input GameObject.</param>
        /// <param name="path">The path to save the file.</param>
        /// <param name="modelName">Model name.</param>
        public static void Export(GameObject exportObject, string path, string modelName)
        {
            if(string.IsNullOrEmpty(path)) return;
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            path = Path.Combine(path, modelName + ".obj");
            ObjExporter.DoExportWSubmeshes(path, exportObject.transform);
        }
        
        #endregion
    }
}
