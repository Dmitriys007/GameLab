using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flag.Meshes
{
    /// <summary>
    /// Создает полотно меша с заданными параметрами
    /// </summary>
    public class CustomMesh : MonoBehaviour
    {
        public static Mesh CreateMesh(int xSize, int ySize)
        {
            List<Vector3> vertixes = new List<Vector3>(); // Точки меша
            List<Vector2> uv = new List<Vector2>(); // текстурные координаты
            List<int> triangles = new List<int>(); // треугольники из точек            

            for (var i = 0; i < xSize; i++)
                for (var j = 0; j < ySize; j++)
                {
                    vertixes.Add(new Vector3(i, j, 0));
                    uv.Add(new Vector2((float)i / (xSize - 1), (float)j / (ySize - 1)));
                }

            for (var i = 0; i < xSize - 1; i++)
                for (var j = 0; j < ySize - 1; j++)
                {
                    triangles.Add(i * ySize + j);
                    triangles.Add(i * ySize + j + 1);
                    triangles.Add((i + 1) * ySize + j);

                    triangles.Add(i * ySize + j + 1);
                    triangles.Add((i + 1) * ySize + j + 1);
                    triangles.Add((i + 1) * ySize + j);
                }

            Mesh mesh = new Mesh();
            mesh.vertices = vertixes.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.uv = uv.ToArray();
            return mesh;
        }
    }
}