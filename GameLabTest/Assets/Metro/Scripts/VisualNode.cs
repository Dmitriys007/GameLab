using Metro.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Metro
{
    /// <summary>
    /// Визуализация узловой точки метро
    /// </summary>
    public class VisualNode : MonoBehaviour
    {
        /// <summary>
        /// Визуализация названия узла
        /// </summary>
        [SerializeField] private TMP_Text nameText;

        /// <summary>
        /// Заготовка для показа линий соединения с другими узлами
        /// </summary>
        [SerializeField] private LineRenderer lineRendererPrefab;

        /// <summary>
        /// Событие клика на узел
        /// </summary>
        public UnityEvent<Node> OnMouseClickEvent;

        /// <summary>
        /// Ссылка на данные отображаемой ноды
        /// </summary>
        private Node node;

        internal void AplyNode(Node myNode)
        {
            node = myNode;
            nameText.text = myNode.name;

            Node[] targets = node.nodes;
            LineRenderer line;

            for (var i = 0; i < targets.Length; i++)
            {
                line = Instantiate(lineRendererPrefab, transform);
                line.SetPositions(new Vector3[] { node.position, node.nodes[i].position });
                line.startColor = GetColor(node.CheckPathId(node.nodes[i].pathId));
                line.endColor = line.startColor;
            }
            lineRendererPrefab.gameObject.SetActive(false);
        }

        private void OnMouseDown()
        {
            OnMouseClickEvent.Invoke(node);
        }

        /// <summary>
        /// Подбор подходящего цвета для указанной ветки метро
        /// </summary>
        /// <param name="targetPathId"></param>
        /// <returns></returns>
        private Color GetColor(PathIds targetPathId)
        {
            switch (targetPathId)
            {
                case PathIds.Green: return Color.green;
                case PathIds.Red: return Color.red;
                case PathIds.Blue: return Color.blue;
                case PathIds.Black: return Color.black;              
            }

            Debug.LogError($"Unknown color finded: {targetPathId}");
            return Color.yellow;
        }
    }
}