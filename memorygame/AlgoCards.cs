using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memorygame
{
    public partial class AlgoCards : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "BFS","O(V+E)","DFS","O(V+E)","Dijkstra’s","O(E log V)","Prim’s(MST)","O(E log V)",
            "Merge Sort","θ(n log(n))","Quick Sort","O(n²)","Kadane","O(n)","Z-algorithm","O(m + n) {Text length: n and Pattern length: m}"
        };

        Label firstCliked, secondClicked;
        public AlgoCards()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void label_Click(object sender, MouseEventArgs e)
        {
            if (firstCliked != null && secondClicked != null)
                return;


            Label clickedLabel = sender as Label; // same like type casting

            if (clickedLabel == null)
                return;

            if (clickedLabel.ForeColor == Color.Black)
                return;
             
            if(firstCliked==null)
            {
                firstCliked = clickedLabel;
                firstCliked.ForeColor = Color.Black;
                return;
            }
            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            CheckForWinner();

            if((firstCliked.Text=="BFS" && secondClicked.Text== "O(V+E)") || (firstCliked.Text == "O(V+E)" && secondClicked.Text == "BFS"))
            {
                firstCliked = null;
                secondClicked = null;
            }
            else if((firstCliked.Text == "DFS" && secondClicked.Text == "O(V+E)") || (firstCliked.Text == "O(V+E)" && secondClicked.Text == "DFS"))
            {

                firstCliked = null;
                secondClicked = null;
            }
            else if ((firstCliked.Text == "Dijkstra’s" && secondClicked.Text == "O(E log V)") || (firstCliked.Text == "O(E log V)" && secondClicked.Text == "Dijkstra’s"))
            {

                firstCliked = null;
                secondClicked = null;
            }
            else if ((firstCliked.Text == "Prim’s(MST)" && secondClicked.Text == "O(E log V)") || (firstCliked.Text == "O(E log V)" && secondClicked.Text == "Prim’s(MST)"))
            {

                firstCliked = null;
                secondClicked = null;
            }
            else if ((firstCliked.Text == "Merge Sort" && secondClicked.Text == "θ(n log(n))") || (firstCliked.Text == "θ(n log(n))" && secondClicked.Text == "Merge Sort"))
            {

                firstCliked = null;
                secondClicked = null;
            }
            else if ((firstCliked.Text == "Quick Sort" && secondClicked.Text == "O(n²)") || (firstCliked.Text == "O(n²)" && secondClicked.Text == "Quick Sort"))
            {

                firstCliked = null;
                secondClicked = null;
            }
            else if ((firstCliked.Text == "Kadane" && secondClicked.Text == "O(n)") || (firstCliked.Text == "O(n)" && secondClicked.Text == "Kadane"))
            {

                firstCliked = null;
                secondClicked = null;
            }
            else if ((firstCliked.Text == "Z-algorithm" && secondClicked.Text == "O(m + n) {Text length: n and Pattern length: m}") || (firstCliked.Text == "O(m + n) {Text length: n and Pattern length: m}" && secondClicked.Text == "Z-algorithm"))
            {

                firstCliked = null;
                secondClicked = null;
            } 
            else
                timer1.Start();
        }

        private void CheckForWinner()
        {
            Label label;
            for(int i=0;i<tableLayoutPanel1.Controls.Count;i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            MessageBox.Show("You matched all the Time-Complexities,Faad Coder!!");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstCliked.ForeColor = firstCliked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            
            firstCliked = null;
            secondClicked = null;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AssignIconsToSquares()
        {
            Label label;
            int randomNumber;
            
            for(int i=0;i<tableLayoutPanel1.Controls.Count;i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);
            }
        }

    }
}
