#region

using System;

#endregion

namespace AlgorithmsDataStructuresTest {
    /// <summary>
    /// </summary>
    public class LHeap {
        private LNode _root;

        public void Print() {
            PrintInternal(_root, 1);
        }

        private void PrintInternal(LNode node, int deepth) {
            if (node == null) {
                return;
            }
            PrintInternal(node.Right, deepth + 1);
            for (int i = 1; i < deepth; i++) {
                Console.Write("       ");
            }
            Console.WriteLine("{0}({1})", node.Element, node.NPL);
            Console.WriteLine();
            PrintInternal(node.Left, deepth + 1);
        }

        public void Insert(int element) {
            var insertingNode = new LNode(element);
            _root = MergeInternal(_root, insertingNode);
        }

        public void Merge(LHeap toMerge) {
            _root = MergeInternal(_root, toMerge._root);
        }

        private LNode MergeInternal(LNode node1, LNode node2) {
            if (node1 == null) {
                return node2;
            }
            if (node2 == null) {
                return node1;
            }
            var newRootNode = node1.Element >= node2.Element ? node2 : node1;
            var toAppendNode = node1.Element >= node2.Element ? node1 : node2;
            newRootNode.Right = MergeInternal(newRootNode.Right, toAppendNode);
            Balance(newRootNode);
            UpdateNpl(newRootNode);
            return newRootNode;
        }

        private void Balance(LNode root) {
            if (root.Right == null) {
                return;
            }
            if ((root.Left != null) && (root.Left.NPL > root.Right.NPL)) {
                return;
            }

            var swapTemp = root.Left;
            root.Left = root.Right;
            root.Right = swapTemp;
        }

        private void UpdateNpl(LNode root) {
            root.NPL = Math.Min(root.Left == null ? 0 : root.Left.NPL,
                           root.Right == null ? 0 : root.Right.NPL)
                       + 1;
        }


        /// <summary>
        /// </summary>
        public class LNode {
            /// <summary>
            /// </summary>
            /// <param name="element"></param>
            public LNode(int element) {
                Element = element;
            }

            /// <summary>
            /// </summary>
            public int Element { get; private set; }

            /// <summary>
            /// </summary>
            public LNode Left { get; set; }

            /// <summary>
            /// </summary>
            public LNode Right { get; set; }

            /// <summary>
            /// </summary>
            public int NPL { get; set; }
        }
    }
}