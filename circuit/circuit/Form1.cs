using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace circuit
{
    public partial class Form1 : Form
    {
        Circuit circuit;
        Circuit circuitFromFile;
        int flag;                                       // to identify which gate is selected to drag
        bool isSaved;                                   //if the circuit was ever saved
        public string currentfile;                      //the name of the current saved circuit
        public BinarySerializationHelper binaryHelper;
        
        public Form1()
        {
            InitializeComponent();
            circuit = new Circuit("NewCircuit",Panelmain,CBLine);
            isSaved = false;
            this.Panelmain.AutoScroll = true;
            binaryHelper = new BinarySerializationHelper();
        }

        private void Panelmain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Panelmain_DragDrop(object sender, DragEventArgs e)
        {
            Point screenCoords = Cursor.Position;
            Point controlRelatedCoords = this.Panelmain.PointToClient(screenCoords); 
            switch(flag)
            {
                case 1:
                    And AndGate = new And(controlRelatedCoords.X,controlRelatedCoords.Y,"AndGate", Panelmain);
                    circuit.addGate(AndGate);
                    break;
                case 2:
                    Or OrGate = new Or(controlRelatedCoords.X, controlRelatedCoords.Y, "OrGate", Panelmain);
                    circuit.addGate(OrGate);
                    break;
                case 3:
                    Not NotGate = new Not(controlRelatedCoords.X, controlRelatedCoords.Y, "NotGate", Panelmain);
                    circuit.addGate(NotGate);
                    break;
                case 4:
                    Sink sink = new Sink(controlRelatedCoords.X, controlRelatedCoords.Y, "Sink", Panelmain);
                    circuit.addGate(sink);
                     break;
                case 5:
                    Source source = new Source(controlRelatedCoords.X, controlRelatedCoords.Y, "soure", Panelmain);
                    circuit.addGate(source);
                    break;
            }
        }

        private void Panelmain_MouseMove(object sender, MouseEventArgs e)
        {
            string temp = e.X.ToString();
            temp += "," + e.Y;

        }
        private void pband_MouseDown(object sender, MouseEventArgs e)
        {
            flag = 1;
            pband.DoDragDrop(pband.Image, DragDropEffects.Copy);
        }

        private void pbor_MouseDown(object sender, MouseEventArgs e)
        {
            flag = 2;
            pbor.DoDragDrop(pbor.Image, DragDropEffects.Copy);
        }

        private void pbnot_MouseDown(object sender, MouseEventArgs e)
        {
            flag = 3;
            pbnot.DoDragDrop(pbnot.Image, DragDropEffects.Copy);
        }

        private void pbsource_MouseDown(object sender, MouseEventArgs e)
        {
            flag =5;
            pbsource.DoDragDrop(pbsource.Image, DragDropEffects.Copy);
        }

        private void pbsink_MouseDown(object sender, MouseEventArgs e)
        {
            flag = 4;
            pbsink.DoDragDrop(pbsink.Image, DragDropEffects.Copy);
        }

        private void CBLine_Click(object sender, EventArgs e)
        {
            if (CBLine.Checked == true)
            {
                panelline.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                panelline.BorderStyle = BorderStyle.None;
               CBLine.Checked = false;
            }
        }

        private void Panelmain_MouseDown(object sender, MouseEventArgs e)
        {
           
            if (CBLine.Checked == true)
            {
                CBLine.Checked = false;
                panelline.BorderStyle = BorderStyle.None;
                circuit.ConnectionFlag = 0;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (CBLine.Checked == true)
            {
                CBLine.Checked = false;
                panelline.BorderStyle = BorderStyle.None;
                circuit.ConnectionFlag = 0;
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (CBLine.Checked == true)
            {
                CBLine.Checked = false;
                panelline.BorderStyle = BorderStyle.None;
            }
        }

        private void Panelmain_Click(object sender, EventArgs e)
        {
            if (CBLine.Checked == true)
            {
                CBLine.Checked = false;
                panelline.BorderStyle = BorderStyle.None;
            }
        }

        private void pbsource_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("true");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelline.BorderStyle = BorderStyle.None;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (circuit.Gates.Count >= 1)
            {
                if (isSaved == false)
                {
                    saveFileDialog1.InitialDirectory = Application.StartupPath;
                    DialogResult result1 = saveFileDialog1.ShowDialog();
                    if (result1 == DialogResult.OK)
                    {
                        this.saveCircuit(saveFileDialog1.FileName);
                        isSaved = true;
                        currentfile = saveFileDialog1.FileName;
                        circuit.AreChangesSaved = true;
                    }
                }
                else
                {
                    this.saveCircuit(currentfile);
                    MessageBox.Show(" The circuit is saved!");
                    circuit.AreChangesSaved = true;
                }
            }
            else
            {
                MessageBox.Show(" There is nothing to save!");
                isSaved = false;
                circuit.AreChangesSaved = false;
            }
        }

        public void saveCircuit(string fileName)
        {
            try
            {
                binaryHelper.serializeObject(fileName, circuit);
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem during saving!");
            }
        }

        public void loadCircuit(String fileName)
        {
            try
            {
                circuitFromFile = binaryHelper.deSerializeObject(fileName);
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem during loading!");
            }
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (circuit.AreChangesSaved == false && circuit.Gates.Count >= 1)
            {
                if ((MessageBox.Show("Do you want to save the current Digital Circuit before loading another one?", "Load Digital Circuit", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                {
                    circuit.AreChangesSaved = true;
                    this.saveToolStripMenuItem_Click(sender, e);
                }
                circuit.clearCircuit();
            }            
            DialogResult result2 = openFileDialog1.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                if (circuit.AreChangesSaved == true && circuit.Gates.Count >= 1)
                {
                    circuit.clearCircuit();
                }
                this.loadCircuit(openFileDialog1.FileName);
                currentfile = openFileDialog1.FileName;
                isSaved = true;                

                foreach (Gate g in circuitFromFile.Gates)
                {
                    circuit.drawCircuit(g);

                }
                foreach (Connection c in circuitFromFile.Connections)
                {
                    if (circuit.addConnection(c.Gate1, c.Gate2, c.XPos, c.YPos))
                    {

                    }
                    else
                    {
                        MessageBox.Show("It is not adding the connection to connections list");
                    }
                }
                circuit.AreChangesSaved = true;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (circuit.Gates.Count >= 1)
            {
                saveFileDialog1.InitialDirectory = Application.StartupPath;
                DialogResult result1 = saveFileDialog1.ShowDialog();
                if (result1 == DialogResult.OK)
                {
                    this.saveCircuit(saveFileDialog1.FileName);
                    isSaved = true;
                    currentfile = saveFileDialog1.FileName;
                    circuit.AreChangesSaved = true;
                }
            }
            else
            {
                MessageBox.Show(" There is nothing to save!");
                isSaved = false;
                circuit.AreChangesSaved = false;
            }
            
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (circuit.AreChangesSaved == false && circuit.Gates.Count >= 1)
            {
                if ((MessageBox.Show("Do you want to save the current Digital Circuit before creating a new one?", "Save Digital Circuit", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                {
                    circuit.AreChangesSaved = true;
                    this.saveToolStripMenuItem_Click(sender, e);
                }                
            }
            circuit.clearCircuit();
            isSaved = false;
            circuit.AreChangesSaved = false;
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            circuit.clearCircuit();
            isSaved = false;
            circuit.AreChangesSaved = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Application was developed by Pablo, Obaid, Ahmed and Santi. 09 April 2014 all rights reserved.");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (circuit.AreChangesSaved == false && circuit.Gates.Count >= 1)
            {
                if ((MessageBox.Show("Do you want to save the current Digital Circuit before Exit?", "Save Digital Circuit", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                {
                    circuit.AreChangesSaved = true;
                    this.saveToolStripMenuItem_Click(sender, e);
                }
            }
            circuit.clearCircuit();
            isSaved = false;
            circuit.AreChangesSaved = false;
            this.Close();
        }
    }
}





