using Flag.Meshes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flag
{
    /// <summary>
    /// Флаг с анимацией GPU
    /// </summary>
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class GPUFlag : MonoBehaviour
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
    }
}