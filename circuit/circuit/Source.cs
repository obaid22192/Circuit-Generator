using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace circuit
{
    [Serializable()]
    public class Source : Gate
    {

        //Data Members:


        //Constructor:
        public Source(int x, int y, string type, Panel panel)
            : base(x, y, type)
        {
            base.Output = 0;
            Image = circuit.Properties.Resources.source;
        }

        //Properties:



        //Methods:

        /// <summary>
        /// description of truth table that going to be used to get the value of the output of a certain gate
        /// </summary>
        public override void truthTable()
        {
            if (base.Output == 0)
            {
                base.Output = 1;
                base.RaiseEvent(base.Output);
                MessageBox.Show(base.Output.ToString());
            }
            else if (base.Output == 1)
            {
                base.Output = 0;
                base.RaiseEvent(base.Output);
                MessageBox.Show(base.Output.ToString());
            }
        }

        /// <summary>
        /// to satisfy the compiler
        /// </summary>
        public override void dropGate(PictureBox pb)
        {
            pb.Image = Image;
        }
    }
}

