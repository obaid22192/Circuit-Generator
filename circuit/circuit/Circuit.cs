using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.VisualBasic.PowerPacks;

namespace circuit
{
    [Serializable()]
    public class Circuit
    {
        //Data Members:
        private string circuitName; //the name of the circuit
        private List<Gate> gates; //the list that store all gates in the current circuit
        private List<Connection> connections; //the list that store all connections in the current circuit  
        [NonSerialized()] public Panel Sheetpanel;// panle that where circuit will be displayed
        [NonSerialized()] public CheckBox ConnectionCB;  // checkbox to add connection
        private bool areChangesSaved; //To control the changes in the circuit
        private int X1;//First point on Line On X-axis
        private int X2;//2nd point on X-axis
        private int Y1;//First point on Y-axis
        private int Y2;//2nd point on Y-axis
        public int ConnectionFlag = 0;//that will determine the clicks between gates to addconnection
        [NonSerialized()] private ContextMenu Cm; // Context menu bar for delete connection
        [NonSerialized()] private ContextMenu CmDeleteGate;// Context menu bar fo delete gate
        [NonSerialized()] private PictureBox PbTodelete;//Hold the object of picture box that will be deleted

        //Constructor:
        public Circuit(string name, Panel pb, CheckBox CB)
        {
            this.circuitName = name;
            this.gates = new List<Gate>();
            this.connections = new List<Connection>();
            Sheetpanel = pb;
            ConnectionCB = CB;
            areChangesSaved = false;
        }

        //Properties:
        public List<Connection> Connections
        {
            get { return connections; }
            set { this.connections = value; }
        }

        public List<Gate> Gates
        {
            get { return gates; }
            set { this.gates = value; }
        }

        public string CircuitName
        {
            get { return circuitName; }
            set { this.circuitName = value; }
        }

        public bool AreChangesSaved
        {
            get { return areChangesSaved; }
            set { this.areChangesSaved = value; }
        }


        //Methods:        

        /// <summary>
        /// description of add gate that draw a new gate in the grid
        /// </summary>
        /// <param name="x">the x cordinate of the left upper corner</param>
        /// <param name="y">the y cordinate of the left upper corner</param>
        /// <param name="type">the type of this new gate</param>
        /// <returns></returns>
        public virtual bool addGate(Gate gate)
        {
            try
            {
                if (islocationavailableforgate(gate.Location_x, gate.Location_y))
                {
                    PictureBox picture = new PictureBox
                    {
                        Size = new Size(100, 60),

                        Location = new Point(gate.Location_x, gate.Location_y),

                        SizeMode = PictureBoxSizeMode.StretchImage,
                    };
                    Sheetpanel.Controls.Add(picture);
                    if (gate is Source)
                    {
                        Source temp = (Source)gate;
                        picture.DoubleClick += new EventHandler(Sourceoutputchange);
                    }
                    gate.outputchanged += new Gate.GateEventHandler(UpdateCircuit);
                    picture.Visible = true;
                    picture.MouseClick += new MouseEventHandler(picture_MouseDown);
                    CmDeleteGate = new ContextMenu();
                    CmDeleteGate.MenuItems.Add("&Delete", new EventHandler(DeleteGate));
                    picture.ContextMenu = CmDeleteGate;
                    gate.dropGate(picture);
                    gates.Add(gate);
                    areChangesSaved = false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void DeleteGate(object sender, EventArgs e)
        {
           
            Gate Gtemp = getGate(X1,Y2);
            List<int> holdindexesofdeletedconnections = new List<int>();
            int i ;
            
            foreach (Connection c in connections)
            {
                if (Gtemp is And)
                {
                    And temp = (And)Gtemp;
                    if (temp.Input1 != null)
                    {
                        if (c.line.X2 == Gtemp.Location_x && c.line.Y2 == Gtemp.Location_y + 11)
                        {
                            c.DeleteConnection();
                            i = connections.IndexOf(c);
                            holdindexesofdeletedconnections.Add(i);
                        }
                    }
                    if (temp.Input2 != null && c.line.X2 == Gtemp.Location_x && c.line.Y2 == Gtemp.Location_y + 49)
                    {
                        c.DeleteConnection();
                        i = connections.IndexOf(c);
                        holdindexesofdeletedconnections.Add(i);
                    }
                    if (c.line.X1 == Gtemp.Location_x + 100 && c.line.Y1 == Gtemp.Location_y + 30)
                    {
                        c.DeleteConnection();
                        i = connections.IndexOf(c);
                        holdindexesofdeletedconnections.Add(i);
                    }
                }
                if (Gtemp is Or)
                {
                    Or temp = (Or)Gtemp;
                    if (temp.Input1 != null)
                    {
                        if (c.line.X2 == Gtemp.Location_x && c.line.Y2 == Gtemp.Location_y + 11)
                        {
                            c.DeleteConnection();
                            i = connections.IndexOf(c);
                            holdindexesofdeletedconnections.Add(i);
                        }
                    }
                    if (temp.Input2 != null && c.line.X2 == Gtemp.Location_x && c.line.Y2 == Gtemp.Location_y + 49)
                    {
                        c.DeleteConnection();
                        i = connections.IndexOf(c);
                        holdindexesofdeletedconnections.Add(i);   
                    }
                    if (c.line.X1 == Gtemp.Location_x + 100 && c.line.Y1 == Gtemp.Location_y + 30)
                    {
                        c.DeleteConnection();
                        i = connections.IndexOf(c);
                        holdindexesofdeletedconnections.Add(i);
                    }
                }
                if (Gtemp is Not)
                {
                    Not temp = (Not)Gtemp;
                    if (temp.Input != null)
                    {
                        if (c.line.X2 == Gtemp.Location_x && c.line.Y2 == Gtemp.Location_y + 30)
                        {
                            c.DeleteConnection();
                            i = connections.IndexOf(c);
                            holdindexesofdeletedconnections.Add(i);
                        }
                    }
                    if (c.line.X1 == Gtemp.Location_x +100 && c.line.Y1 == Gtemp.Location_y + 30)
                    {
                        c.DeleteConnection();
                        i = connections.IndexOf(c);
                        holdindexesofdeletedconnections.Add(i);
                    }
                }
                if (Gtemp is Sink)
                {
                    Sink temp = (Sink)Gtemp;
                    if (temp.Input != null)
                    {
                        if (c.line.X2 == Gtemp.Location_x && c.line.Y2 == Gtemp.Location_y + 30)
                        {
                            c.DeleteConnection();
                            i = connections.IndexOf(c);
                            holdindexesofdeletedconnections.Add(i);
                        }
                    }
                    if (c.line.X1 == Gtemp.Location_x+100 && c.line.Y1 == Gtemp.Location_y + 30)
                    {

                        c.DeleteConnection();

                        i = connections.IndexOf(c);
                        holdindexesofdeletedconnections.Add(i);
                    }
                }
                if (Gtemp is Source)
                {
                    Source temp = (Source)Gtemp;
                    if (c.line.X1 == Gtemp.Location_x + 100 && c.line.Y1 == Gtemp.Location_y + 30)
                    {
                        c.DeleteConnection();
                        i = connections.IndexOf(c);
                        holdindexesofdeletedconnections.Add(i);
                    }
                }
               
            }
            gates.Remove(Gtemp);

            for (int j = 0; j < holdindexesofdeletedconnections.Count; j++)
            {
                connections.RemoveAt(holdindexesofdeletedconnections[0]);
            }
            Sheetpanel.Controls.Remove(PbTodelete);
            PbTodelete.Dispose();
            Sheetpanel.Invalidate();
            Sheetpanel.Refresh();
            areChangesSaved = false;
        }
        
     
        /// <summary>
        /// This method remove from the list all connections and all Gates 
        /// from lists connections adn gates
        /// </summary> 
        /// <returns></returns>
        public void clearCircuit()
        {
            for (int i = this.connections.Count-1; i >= 0; --i)           
            {
                this.connections.RemoveAt(i);
            }
            for (int i = this.gates.Count-1; i >= 0; --i) 
            {
                this.gates.RemoveAt(i);
            }
            this.Sheetpanel.Controls.Clear();
        }

        /// <summary>
        /// this event raise when user will click on gate to add connection 
        /// </summary>
        /// <param name="Sender">Object that calls event</param>
        /// <param name="e"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public void picture_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox clickedpb = sender as PictureBox;
            if (e.Button == MouseButtons.Left)
            {
                if (ConnectionCB.Checked == true && ConnectionFlag == 0)
                {
                    X1 = clickedpb.Location.X;
                    Y1 = clickedpb.Location.Y;
                    ConnectionFlag = 1;
                }
                else if (ConnectionCB.Checked == true && ConnectionFlag == 1)
                {
                    X2 = clickedpb.Location.X;
                    Y2 = clickedpb.Location.Y;
                    ConnectionFlag = 0;
                    if (addConnection(getGate(X1, Y1), getGate(X2, Y2), e.X, e.Y))
                    {
                        X1 = 0;
                        X2 = 0;
                        Y1 = 0;
                        Y2 = 0;
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                X1 = clickedpb.Location.X;
                Y2 = clickedpb.Location.Y;
                PbTodelete = clickedpb;
            }
        }

        /// <summary>
        /// this method will be called when User will Doubleclick on Source to change the Source from 0 to 1 or vice versa 
        /// </summary>
        /// <param name="x">the x cordinate of the left upper corner</param>
        /// <param name="y">the y cordinate of the left upper corner</param>
        /// <param name="type">the type of this new gate</param>
        /// <returns></returns>
        public void Sourceoutputchange(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Source temp = (Source)getGate(pb.Location.X, pb.Location.Y);
            temp.truthTable();
            areChangesSaved = false;
        }
        public void UpdateCircuit(Gate sender, int output)
        {
            foreach (Gate g in gates)
            {
                if (g is Sink)
                {
                    Sink temp = (Sink)g;
                    if (temp.Input != null && temp.Input.Location_x == sender.Location_x && temp.Input.Location_y == sender.Location_y)
                    {
                        g.truthTable();
                    }
                }
                else if (g is And)
                {
                    And temp = (And)g;
                    if (temp.Input1 != null && temp.Input2 != null)
                    {
                        if (temp.Input1.Location_x == sender.Location_x && temp.Input1.Location_y == sender.Location_y || temp.Input2.Location_x == sender.Location_x && temp.Input2.Location_y == sender.Location_y)
                        {
                            g.truthTable();
                        }
                    }
                }
                else if (g is Or)
                {
                    Or temp = (Or)g;
                    if (temp.Input1 != null && temp.Input2 != null)
                    {
                        if (temp.Input1.Location_x == sender.Location_x && temp.Input1.Location_y == sender.Location_y || temp.Input2.Location_x == sender.Location_x && temp.Input2.Location_y == sender.Location_y)
                        {
                            g.truthTable();
                        }
                    }
                }
                else if (g is Not)
                {
                    Not temp = (Not)g;
                    if (temp.Input != null && temp.Input.Location_x == sender.Location_x && temp.Input.Location_y == sender.Location_y)
                    {
                        g.truthTable();
                    }
                }
            }

        }

        /// <summary>
        /// description of add connection that draw a new connection in the grid and
        /// check which gate is going to be considered as the one with output 
        /// (the one that more into the left) and which one going to be considered as the one with input
        /// </summary>
        /// <param name="g1">first gate of the connection (output)</param>
        /// <param name="g2">second gate of the connection (input)</param>
        ///  /// <param name="eX">eX is the point on x-axis on gate where user clicked </param>
        ///   /// <param name="eY">eY is the point on y-axis on gate  where user clicked  </param>
        /// <returns></returns>
        public virtual bool addConnection(Gate g1, Gate g2, int eX, int eY)
        {
            LineShape line = new LineShape();
            ShapeContainer canvas = new ShapeContainer();
            line.MouseDown += new MouseEventHandler(line_Click);
            line.MouseEnter += new EventHandler(Mouse_Enter);
            line.MouseLeave += new EventHandler(Mouse_leave);
            Cm = new ContextMenu();
            Cm.MenuItems.Add("&Delete", new EventHandler(Deleteconnection));
            line.ContextMenu = Cm;

            try
            {
                if (g1.FreeOutput)
                {

                    if (g2 is And)
                    {
                        And holder = (And)g2;
                        if (eY < 30 && holder.Input1 == null)
                        {
                            Connection con = new Connection(g1, g2, Sheetpanel);
                            con.drawConnection(eX, eY, line, canvas);
                            holder.Input1 = g1;
                            connections.Add(con);
                            areChangesSaved = false;
                            return true;
                        }
                        else if (eY > 30 && holder.Input2 == null)
                        {
                            Connection con = new Connection(g1, g2, Sheetpanel);
                            con.drawConnection(eX, eY, line, canvas);
                            holder.Input2 = g1;
                            connections.Add(con);
                            areChangesSaved = false;
                            return true;
                        }
                        else
                        {

                            return false;
                        }

                    }
                    else if (g2 is Or)
                    {
                        Or holder = (Or)g2;
                        if (eY < 30 && holder.Input1 == null)
                        {
                            Connection con = new Connection(g1, g2, Sheetpanel);
                            con.drawConnection(eX, eY, line, canvas);
                            holder.Input1 = g1;
                            connections.Add(con);
                            areChangesSaved = false;
                            return true;
                        }
                        else if (eY > 30 && holder.Input2 == null)
                        {
                            Connection con = new Connection(g1, g2, Sheetpanel);
                            con.drawConnection(eX, eY, line, canvas);
                            holder.Input2 = g1;
                            connections.Add(con);
                            areChangesSaved = false;
                            return true;
                        }
                        else
                        {

                            return false;
                        }


                    }
                    if (g2 is Not)
                    {
                        Not holder = (Not)g2;
                        if (holder.Input == null)
                        {
                            Connection con = new Connection(g1, g2, Sheetpanel);
                            con.drawConnection(eX, eY, line, canvas);
                            holder.Input = g1;
                            connections.Add(con);
                            areChangesSaved = false;
                            return true;
                        }

                        else
                        {

                            return false;
                        }

                    }
                    if (g2 is Sink)
                    {
                        Sink holder = (Sink)g2;
                        if (holder.Input == null)
                        {
                            Connection con = new Connection(g1, g2, Sheetpanel);
                            con.drawConnection(eX, eY, line, canvas);
                            holder.Input = g1;
                            g2.truthTable();
                            connections.Add(con);
                            areChangesSaved = false;
                            return true;
                        }

                        else
                        {

                            return false;
                        }

                    }

                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return false;
            }
        }

        public void line_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                LineShape TempLine = (LineShape)sender;
                X1 = TempLine.X1;
                X2 = TempLine.X2;
                Y1 = TempLine.Y1;
                Y2 = TempLine.Y2;
            }
        }

        public void Deleteconnection(object sender, EventArgs e)
        {
            Connection TempC = getConnection(X1, X2, Y1, Y2);
            TempC.DeleteConnection();
            connections.Remove(TempC);
            areChangesSaved = false;
        } 
        

        /// <summary>
        /// description of get connection that get a connection from the list connections
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual Connection getConnection(int x1, int x2, int y1, int y2)
        {
            foreach (Connection c in connections)
            {
                if (c.line.X1 == x1 && c.line.X2 == x2 && c.line.Y1 == y1 && c.line.Y2 == y2)
                {
                    return c;
                }

            }
            return null;
        }

        /// <summary>
        /// description of gat gate that get a gate from the list gates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual Gate getGate(int x, int y)
        {
            Gate gate = null;
            foreach (Gate g in gates)
            {

                if (g.Location_x == x && g.Location_y == y)
                {
                    gate = g;
                }
            }
            return gate;
        }
        

        /// <summary>
        /// description of draw circuit that draw a circuit (only gates) that comes from a file
        /// and it free outputs and inputs to each gate to put them after the gates are place on the circuit
        /// </summary>
        /// <param name="gr"></param>
        public virtual void drawCircuit(Gate g)
        {
            if (!g.FreeOutput)
            {
                g.FreeOutput = true;
            }
            if (g is And)
            {
                And holder = (And)g;
                if (holder.Input1 != null)
                {
                    holder.Input1 = null;
                }
                if (holder.Input2 != null)
                {
                    holder.Input2 = null;
                }
                if (this.addGate(holder))
                {

                }
                else
                {
                    MessageBox.Show("It is not adding the gates to gates list");
                }
            }
            else if (g is Or)
            {
                Or holder = (Or)g;
                if (holder.Input1 != null)
                {
                    holder.Input1 = null;
                }
                if (holder.Input2 != null)
                {
                    holder.Input2 = null;
                }
                if (this.addGate(holder))
                {

                }
                else
                {
                    MessageBox.Show("It is not adding the gates to gates list");
                }
            }
            else if (g is Not)
            {
                Not holder = (Not)g;
                if (holder.Input != null)
                {
                    holder.Input = null;
                }
                if (this.addGate(holder))
                {

                }
                else
                {
                    MessageBox.Show("It is not adding the gates to gates list");
                }
            }
            else if (g is Sink)
            {
                Sink holder = (Sink)g;
                if (holder.Input != null)
                {
                    holder.Input = null;
                }
                if (this.addGate(holder))
                {

                }
                else
                {
                    MessageBox.Show("It is not adding the gates to gates list");
                }
            }
            else if (g is Source)
            {
                Source holder = (Source)g;
                if (!holder.FreeOutput)
                {
                    holder.FreeOutput = false;
                }
                if (this.addGate(holder))
                {

                }
                else
                {
                    MessageBox.Show("It is not adding the gates to gates list");
                }
            }
        }
        /// <summary>
        /// this method will check that is user adding gate in circuit on correct place to prevent gate overlaping 
        /// </summary>
        /// <param name="x">the x cordinate of the grid where user wants to place the gate </param>
        /// <param name="y">the y cordinate of the grid where user wants to place the gate</param>

        /// <returns></returns>
        public bool islocationavailableforgate(int x, int y)
        {

            foreach (Gate g in gates)
            {
                if (g != null)
                {

                    if (x >= g.Location_x && x <= g.Location_x + 140 && y >= g.Location_y && y <= g.Location_y + 90 || x >= g.Location_x - 140 && x <= g.Location_x & y >= g.Location_y && y <= g.Location_y + 90 || x >= g.Location_x - 140 && x <= g.Location_x && y >= g.Location_y && y <= g.Location_y + 90 || x >= g.Location_x && x <= g.Location_x + 100 && y <= g.Location_y && y >= g.Location_y - 60 || x <= g.Location_x && x >= g.Location_x - 100 && y <= g.Location_y && y >= g.Location_y - 60)
                    {
                        MessageBox.Show("Sorry, try to place the gate in another location.");
                        return false;
                    }

                }
            }
            return true;
        }

        public void Mouse_Enter(object sender, EventArgs e)
        {
            LineShape L = (LineShape)sender;
            L.BorderWidth = 3;
        }

        public void Mouse_leave(object sender, EventArgs e)
        {
            LineShape L = (LineShape)sender;
            L.BorderWidth = 2;
        }
    }
}

