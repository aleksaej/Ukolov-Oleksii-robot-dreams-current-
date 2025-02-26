using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BlasterCombiner : MonoBehaviour
{
    [SerializeField] private MeshFilter[] _meshFilters;
    private Mesh _mesh;

    [ContextMenu("Generate Blaster Mesh")]
    private void GenerateBlasterMesh()
    {
        _mesh = new Mesh();

        Matrix4x4 objectMatrix = transform.worldToLocalMatrix;
        CombineInstance[] instances = new CombineInstance[_meshFilters.Length];

        for (int i = 0; i < _meshFilters.Length; i++)
        {
            CombineInstance instance = new CombineInstance
            {
                mesh = _meshFilters[i].sharedMesh,
                transform = objectMatrix * _meshFilters[i].transform.localToWorldMatrix
            };
            instances[i] = instance;
        }

        _mesh.CombineMeshes(instances, false, true);

        #if UNITY_EDITOR
        string path = EditorUtility.SaveFilePanelInProject("Save Blaster Mesh", "New Blaster Mesh", "asset", "");
        if (!string.IsNullOrEmpty(path))
        {
            AssetDatabase.CreateAsset(_mesh, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
       #endif
    }
}
