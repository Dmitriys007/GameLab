using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metro.Nodes
{
    /// <summary>
    /// Идентификаторы веток
    /// </summary>
    public enum PathIds : int
    { 
        Unknown = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
        Black = 4,        
    }

    /// <summary>
    /// Узел станции метро
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Уникальный ИД узла
        /// </summary>
        public int id;

        /// <summary>
        /// Метка / Имя узла
        /// </summary>
        public string name;

        /// <summary>
        /// Координаты ноды
        /// </summary>
        public Vector3 position;

        /// <summary>
        /// ИД веток метро которым принадлежит нода
        /// </summary>
        public PathIds[] pathId;

        /// <summary>
        /// Доступные пути в другие ноды
        /// </summary>
        public Node[] nodes;

        /// <summary>
        /// Вернуть совпадающий у обоих код пути
        /// </summary>
        /// <param name="idPath"></param>
        /// <returns></returns>
        public PathIds CheckPathId(PathIds[] otherPath)
        {
            for (var i = 0; i < pathId.Length; i++)
                for (var j = 0; j < otherPath.Length; j++ )
                if (pathId[i] == otherPath[j])
                        return pathId[i];

            return PathIds.Unknown;
        }

        /// <summary>
        /// Найти путь к указанной ноде
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        internal List<Node> FindPath(List<Node> path, Node node)
        {
            Debug.Log($"Find path {name} => {node.name}");
            if (id == node.id) // проверяем себя
            { 
                path.Add(node);
                return path;
            }

            for (var i = 0; i < nodes.Length; i++)
            {
                var pathnext = nodes[i].FindPath(path, node);
                if ( pathnext != null)
                    return pathnext;
            }

            return null; // если ничего не нашлось
        }
    }
}
