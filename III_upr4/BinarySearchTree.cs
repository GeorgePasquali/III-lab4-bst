using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static III_upr4.BinarySearchTree;

namespace III_upr4
{
    

    class BinarySearchTree
    {
        public Node root { get; set; }
        private int minWordLength = 2; // IF WE WANT TO REDUCE THE LENGTH OF THE MAX WORD

        public BinarySearchTree()
        {
            root = null;
        }

        public void insertWord(string word)
        {
            root = insert(word, root);
        }

        public void textToTreeView(TreeView treeView)
        {
            treeView.Nodes.Clear();

            TreeNode generatedNode = createViewTreeNode(root, "Root");
            if (generatedNode != null)
            {
                treeView.Nodes.Add(generatedNode);
            }
            
        }

        public void printTreeToTextBoxPostorder(TextBox box)
        {
            traversePostorder(root, box);

            
        }
        public void printTreeToTextBoxInorder(TextBox box)
        {
            traverseInorder(root, box);


        }
        public void printTreeToTextBoxPreorder(TextBox box)
        {
            traversePreorder(root, box);


        }

        private void traversePostorder(Node currentNode, TextBox box)
        {
            

            if(currentNode == null)
            {
                return;
            }

            traversePostorder( currentNode.left,  box);
            
            traversePostorder( currentNode.right,  box);

            box.AppendText(currentNode.value + ": " + currentNode.count + " \n");

        }

        private void traverseInorder(Node currentNode, TextBox box)
        {


            if (currentNode == null)
            {
                return;
            }

            traverseInorder(currentNode.left, box);

            box.AppendText(currentNode.value + ": " + currentNode.count + " \n");

            traverseInorder(currentNode.right, box);


        }

        private void traversePreorder(Node currentNode, TextBox box)
        {


            if (currentNode == null)
            {
                return;
            }

            box.AppendText(currentNode.value + ": " + currentNode.count + " \n");

            traversePreorder(currentNode.left, box);

            traversePreorder(currentNode.right, box);

        }

        private TreeNode createViewTreeNode(Node currentTreeRoot, string positionDesc)
        {
            string addedValue = (currentTreeRoot != null) ? currentTreeRoot.value : null;
            TreeNode currentNode = new TreeNode(positionDesc + ": " +addedValue);

            if (currentTreeRoot.left != null)
            {
                currentNode.Nodes.Add(createViewTreeNode(currentTreeRoot.left, "Left"));
            }

            if (currentTreeRoot.right != null)
            {
                currentNode.Nodes.Add(createViewTreeNode(currentTreeRoot.right, "Right"));
            }

            return currentNode;
        }


        public void addTextToTree(string text)
        {
            StringBuilder wordBuffer = new StringBuilder();


            int currentChar = 0; // char counter
            foreach (char singleChar in text)
            {
                if (
                    char.IsWhiteSpace(singleChar) ||
                    char.IsPunctuation(singleChar) ||
                    singleChar == '`'

                )
                {
                    if (wordBuffer.Length > minWordLength)
                    {

                        insertWord(wordBuffer.ToString().ToLower());
                    }

                    wordBuffer.Clear();
                }
                else
                {
                    wordBuffer.Append(singleChar);
                }

                currentChar++; // count the characters
            }

            if ((wordBuffer.Length > 0) && wordBuffer.Length > 2)
            {
                insertWord(wordBuffer.ToString().ToLower());
            }
        }

        private Node insert(string word,Node currentNode)
        {
            if (currentNode == null)
            {
                currentNode = new Node(word);
            }
            // else if (word < currentNode.value)
            else if ( word.CompareTo(currentNode.value) < 0) // case must go to left
            {
                currentNode.left = insert( word, currentNode.left);
            }
            else if ( word.CompareTo(currentNode.value) == 0)
            {
                currentNode.count++;
            }
            else
            {
                currentNode.right = insert(word, currentNode.right);
            }

            return currentNode;
        }

        public void traverse(Node root)
        {
            if (root == null)
            {
                return;
            }

            traverse(root.left);
            traverse(root.right);
        }

        internal class Node
        {
            public string value;
            public Node left;
            public Node right;
            public int count;

            public Node(string inputValue)
            {
                value = inputValue;
                count = 1;
            }

            public void incrementCount()
            {
                count++;
            }
        }
    }


    
}
