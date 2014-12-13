using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace circuit
{
    [Serializable()]
    public class And : Gate
    {

        //Data Members:
        private Gate input1; //the upper value of an and gate
        private Gate input2; //: the lower value of an and gate

        //Constructor:
        public And(int x, int y, string type, Panel panel)
            : base(x, y, type)
        {
            if (Location_x < 107)
            {
                Location_x = 110;
            }
            input1 = null;
            input2 = null;

            Image = circuit.Properties.Resources.and;
        }


        //Properties:
        public Gate Input1
        {
            get { return input1; }
            set { this.input1 = value; }
        }

        public Gate Input2
        {
            get { return input2; }
            set { this.input2 = value; }
        }


        //Methods:

        /// <summary>
        /// description of drop gate that drop an and gate into the grid
        /// </summary>
        public override void dropGate(PictureBox pb)
        {
            pb.Image = Image;
        }

        /// <summary>
        /// description of truth table that going to be used to get the value of the output of an and gate
        /// 
        /// T = 1, F = 0
        /// 1 && 1 = 1
        /// 1 && 0 = 0
        /// 0 && 1 = 0
        /// 0 && 0 = 0
        /// </summary>
        public override void truthTable()
        {
            if (input1 == null || input2 == null)
            {
                Output = 0;
                base.RaiseEvent(base.Output);
            }
            else
            {

                if (input1.Output == 1 && input2.Output == 1)
                {
                    base.Output = 1;
                    base.RaiseEvent(base.Output);
                }
                else
                {
                    base.Output = 0;
                    base.RaiseEvent(base.Output);
                }
            }
        }
        

        public void line_Click(object sender, EventArgs e)
        {
            MessageBox.Show("deleteme");
        }

    }
}

