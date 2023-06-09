using Flag.Meshes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flag
{
    /// <summary>
    /// Флаг с анимацией CPU
    /// </summary>
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class CPUFlag : MonoBehaviour
    {
        /// <summary>
        /// Размер сетки по горизонтали
        /// </summary>
        [SerializeField] private int xSize = 4;

        /// <summary>
        /// Размер сетки по вертикали
        /// </summary>
        [SerializeField] private int ySize = 3;

        /// <summary>
        /// Для хранения ссылки на рисуемый меш
        /// </summary>
        [SerializeField] private MeshFilter meshFilter;

        /// <summary>
        /// Для хранения ссылки на отображаемый материал меша
        /// </summary>
        [SerializeField] private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshFilter.mesh = CustomMesh.CreateMesh(xSize, ySize);
        }

        private void Update()
        {
            Vector3[] vertixes = meshFilter.mesh.vertices;
            Vector2[] uv = meshFilter.mesh.uv;

            for (var i = 0; i < xSize; i++)
                for (var j = 0; j < ySize; j++)
                {
                    vertixes[i * ySize + j] = new Vector3(i, j, Mathf.Sin(Time.realtimeSinceStartup - i) * i / 2.5f); // чем дальше от древка - тем больше колебание (древко жестко держит флаг - около него не колебается)           
                    uv[i * ySize + j] = new Vector2((float)i / (xSize - 1) - Time.realtimeSinceStartup * 0.1f, (float)j / (ySize - 1));
                }

            meshFilter.mesh.vertices = vertixes;
            meshFilter.mesh.uv = uv;
        }
    }
}