using Metro.Nodes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metro
{
    /// <summary>
    /// Визуальное отображение метро города
    /// </summary>
    public class VisualSity : MonoBehaviour
    {
        [SerializeField] private VisualNode visualNodePrefab;

        /// <summary>
        /// Данные по всему метро в городе
        /// </summary>
        private Sity sity = new Sity();

        /// <summary>
        /// Стартовая точка маршрута
        /// </summary>
        private Node startNodeClicked;


        /// <summary>
        /// Показ метро
        /// </summary>
        public void Start()
        {
            int i = 0;
            foreach (var node in sity.nodes)
            {
                VisualNode visualNode = Instantiate(visualNodePrefab, node.Value.position, Quaternion.identity);
                visualNode.AplyNode(node.Value);
                visualNode.OnMouseClickEvent.AddListener(NodeClicked);
                i++;
            }
            Destroy(visualNodePrefab.gameObject);
        }

        /// <summary>
        /// Кликнули на узел, ищем путь если второй клик (первый клик: стартовая точка. Второй клик: финишная точка)
        /// </summary>
        /// <param name="node"></param>
        private void NodeClicked(Node node)
        {
            if (startNodeClicked == null)
                startNodeClicked = node;
            else // это второй клик, ищем путь
            { 
                List<Node> nodes = sity.FindPath(startNodeClicked, node);
                startNodeClicked = null;
            }
        }
    }

}