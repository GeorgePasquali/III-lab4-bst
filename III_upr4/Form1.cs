using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace III_upr4
{

    public partial class Form1 : Form
    {

        private BinarySearchTree myBinaryTree;
        private string currentString;
        private Benchmarker myTester;

        public Form1()
        {
            InitializeComponent();
            myTester = new Benchmarker(textBox5);
        }

        private void  pushTextInsideTreeView()
        {
            myBinaryTree = new BinarySearchTree();

            myTester.StartBenchmark();
            myBinaryTree.addTextToTree(currentString);
            myTester.EndBenchmark();

            myBinaryTree.textToTreeView(treeView1);
            

        }

        private void clearBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            myBinaryTree = null;
        }

        private void pushTextInMainTextView()
        {
            myTester.StartBenchmark();
            textBox1.Text = currentString;
            myTester.EndBenchmark();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentString = "The Online Etymology Dictionary gives the first attested use of \"computer\" in the \"1640s, [meaning] \"one who calculates,\"; this is an \"... agent noun from compute (v.)\". The Online Etymology Dictionary states that the use of the term to mean \"calculating machine\" (of any type) is from 1897.\" The Online Etymology Dictionary indicates that the \"modern use\" of the term, to mean \"programmable digital electronic computer\" dates from \"... 1945 under this name; [in a] theoretical[sense] from 1937, as Turing machine";
            clearBoxes();
            pushTextInMainTextView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentString = "Computer programming is the process of writing or editing source code. Editing source code involves testing, analyzing, refining, and sometimes coordinating with other programmers on a jointly developed program. A person who practices this skill is referred to as a computer programmer, software developer, and sometimes coder. The sometimes lengthy process of computer programming is usually referred to as software development.The term software engineering is becoming popular as the process is seen as an engineering discipline. ";
            clearBoxes();
            pushTextInMainTextView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentString = "The word software was first used in the late 1960s to show the difference from computer hardware, which are the parts of a machine that can be seen and touched. Software is the instructions that the computer follows. Before compact discs (CDs) or Internet downloads, software came on various computer data storage media like paper punch cards, magnetic discs or magnetic tape";
            clearBoxes();
            pushTextInMainTextView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentString = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            clearBoxes();
            pushTextInMainTextView();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentString = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).";
            clearBoxes();
            pushTextInMainTextView();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pushTextInsideTreeView();
            treeView1.ExpandAll();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            myTester.StartBenchmark();
            if(myBinaryTree != null)
            {
                myBinaryTree.printTreeToTextBoxPostorder(textBox2);
            }
            else
            {
                showEmptyTreeError();
            }
            
            myTester.EndBenchmark();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            myTester.StartBenchmark();
            if (myBinaryTree != null)
            {
                myBinaryTree.printTreeToTextBoxInorder(textBox3);
            }
            else
            {
                showEmptyTreeError();
            }
            myTester.EndBenchmark();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            myTester.StartBenchmark();
            if (myBinaryTree != null)
            {
                myBinaryTree.printTreeToTextBoxPreorder(textBox4);
            }
            else
            {
                showEmptyTreeError();
            }
            myTester.EndBenchmark();
        }


        private void showEmptyTreeError()
        {

            string message = "The tree is still empty, You should parse The text first.";
            string title = "You missed a step!";
            MessageBox.Show(message, title);

        }
    }
}
