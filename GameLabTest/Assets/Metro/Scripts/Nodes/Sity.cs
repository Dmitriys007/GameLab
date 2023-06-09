using Metro.Nodes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metro
{
    /// <summary>
    /// Город с метро / корневой объект
    /// </summary>
    public class Sity
    {
        /// <summary>
        /// Все станции города, условно поделены на отдельные маршруты / ветки (некоторые станции принадлежат сразу нескольким веткам)
        /// </summary>
        public Dictionary<char, Node> nodes { get; private set; } // todo: Хранить лучше массивом, но труднее вручну заполнять, в идеале требует редактора / сохранения / загрузки - выходит за рамки тестового задания

        public Sity()
        {
            nodes = new Dictionary<char, Node> {
                //Red
                {'A', new Node() { id = 0, name = "A", pathId = new PathIds[]{ PathIds.Red }, position = new Vector3(1, 9, 0) } },
                {'B', new Node() { id = 1, name = "B", pathId = new PathIds[]{ PathIds.Red, PathIds.Black }, position = new Vector3(2, 8, 0)} },
                {'C', new Node() { id = 2, name = "C", pathId = new PathIds[]{ PathIds.Red, PathIds.Green }, position = new Vector3(3, 6, 0) } },
                {'D', new Node() { id = 3, name = "D", pathId = new PathIds[]{ PathIds.Red, PathIds.Blue }, position = new Vector3(5, 5, 0)} },
                {'E', new Node() { id = 4, name = "E", pathId = new PathIds[]{ PathIds.Red, PathIds.Green }, position = new Vector3(7, 5, 0)} },
                {'F', new Node() { id = 5, name = "F", pathId = new PathIds[]{ PathIds.Red, PathIds.Black },position = new Vector3(10, 5, 0) } },
                //Black
                {'G', new Node() { id = 6, name = "G", pathId = new PathIds[]{ PathIds.Black }, position = new Vector3(10, 3, 0)} },
                {'H', new Node() { id = 7, name = "H", pathId = new PathIds[]{ PathIds.Black }, position = new Vector3(5, 8, 0)} },
                {'J', new Node() { id = 8, name = "J", pathId = new PathIds[]{ PathIds.Black, PathIds.Green, PathIds.Blue },position = new Vector3(6, 7, 0) } },
                //Green
                {'K', new Node() { id = 9, name = "K", pathId = new PathIds[]{ PathIds.Green },position = new Vector3(2, 4, 0) } },
                {'L',new Node() { id = 10, name = "L", pathId = new PathIds[]{ PathIds.Green, PathIds.Blue }, position = new Vector3(4, 3, 0) } },
                {'M',new Node() { id = 11, name = "M", pathId = new PathIds[]{ PathIds.Green }, position = new Vector3(6, 3, 0)} },
                //Blue
                {'N',new Node() { id = 12, name = "N", pathId = new PathIds[]{ PathIds.Blue }, position = new Vector3(2, 1, 0)} },
                {'O',new Node() { id = 13, name = "O", pathId = new PathIds[]{ PathIds.Blue }, position = new Vector3(8, 7, 0)} },                
            };

            //Указываем связи
            //Green
            nodes['A'].nodes = new Node[] { nodes['B'], };
            nodes['B'].nodes = new Node[] { nodes['A'], nodes['C'], nodes['H'] };
            nodes['C'].nodes = new Node[] { nodes['B'], nodes['D'], nodes['J'], nodes['K'] };
            nodes['D'].nodes = new Node[] { nodes['C'], nodes['E'], nodes['L'], nodes['J'] };
            nodes['E'].nodes = new Node[] { nodes['D'], nodes['F'], nodes['J'], nodes['M'] };
            nodes['F'].nodes = new Node[] { nodes['E'], nodes['J'], nodes['G'] };
            //Black
            nodes['G'].nodes = new Node[] { nodes['F'], };
            nodes['H'].nodes = new Node[] { nodes['B'], nodes['J'] };
            nodes['J'].nodes = new Node[] { nodes['H'], nodes['F'], nodes['C'], nodes['D'], nodes['E'], nodes['O'] };
            //Green
            nodes['K'].nodes = new Node[] { nodes['L'], nodes['C'] };
            nodes['L'].nodes = new Node[] { nodes['K'], nodes['M'], nodes['D'], nodes['N'] };
            nodes['M'].nodes = new Node[] { nodes['L'], nodes['E'] };
            //Blue
            nodes['N'].nodes = new Node[] { nodes['L'], };
            nodes['O'].nodes = new Node[] { nodes['J'], };
        }

        /// <summary>
        /// Поиск пути между узлами
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<Node> FindPath(Node start, Node end)
        {
            bool[] checkDublikates = new bool[nodes.Count];

            List<Node> res = new List<Node>(); // Ветка путей расходится от стартовой
            if (start == end)
                return new List<Node> { start, end };

            PathNodes pathNode = new PathNodes() { node = start };

            ProcesFind findResult = ProcesFind.Progres;
            int i = 0;
            while (i < nodes.Count && findResult != ProcesFind.Finded)
            {
                i++;
                findResult = pathNode.GetPath(end, checkDublikates);

                if (findResult == ProcesFind.Finded)
                {
                    string toDebug = "Finded path";
                    int transferCount = 0; // кол-во пересадок
                    PathIds[] currentPath = start.pathId;

                    for (var j = 0; j < pathNode.FindedPath.Count; j++)
                    {
                        if (pathNode.FindedPath[j].node.CheckPathId(currentPath) == PathIds.Unknown)
                        {
                            transferCount++;
                            currentPath = pathNode.FindedPath[j-1].node.pathId;
                        }
                        toDebug += " => " + pathNode.FindedPath[j].node.name;
                    }

                    Debug.Log(toDebug + " Transfer = " + transferCount);
                }
                else if (findResult == ProcesFind.NotFinded)
                {
                    Debug.Log("PATH NOT FOUND!");
                    break;
                }
            }

            return null;
        }
    }

    public enum ProcesFind
    { 
        Start,
        Progres,
        Finded,
        NotFinded
    }

    public class PathNodes
    { 
        public Node node;
        public List<PathNodes> Path = new List<PathNodes>();
        public List<PathNodes> FindedPath = new List<PathNodes>();
        public ProcesFind procesFind = ProcesFind.Start;       

        public ProcesFind GetPath(Node endNode, bool[] checkDublikates)
        {
            if (procesFind == ProcesFind.Start) // Проверяем свою ноду
            {
                if (checkDublikates[node.id] == true)
                    return ProcesFind.NotFinded;
                else
                    checkDublikates[node.id] = true;

                if (endNode.id == node.id)
                {
                    FindedPath.Add(this);
                    procesFind = ProcesFind.Finded;
                    return procesFind;
                }                

                for (var i = 0; i < node.nodes.Length; i++) // Заполняем дочерние пути
                    Path.Add(new PathNodes() { node = node.nodes[i] });

                procesFind = ProcesFind.Progres;
                return procesFind;
            }
            else if (procesFind == ProcesFind.Progres) 
            {                
                for (var i = 0; i < Path.Count; i++)
                { 
                    var result = Path[i].GetPath(endNode, checkDublikates);
                    if (result == ProcesFind.NotFinded)
                    {
                        Path.RemoveAt(i);
                        i--;
                    }

                    if (result == ProcesFind.Finded)
                    {
                        FindedPath.Add(this);
                        FindedPath.AddRange(Path[i].FindedPath);                        
                        return ProcesFind.Finded;
                    }
                }

                if (Path.Count == 0)
                    return ProcesFind.NotFinded;
                else
                    return ProcesFind.Progres;
            }
            
            return ProcesFind.NotFinded;
        }
    }
}