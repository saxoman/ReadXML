using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ReadXML
{
   
    
    public partial class Form1 : Form
    {
        private SqlDataAdapter adapterState;
        private SqlDataAdapter adapterTransition;
        private SqlDataAdapter adapterChangeReason;
        private SqlCommandBuilder builder;
        private DataSet ds;
        private SqlConnection cn = new SqlConnection("Data Source=WIN7-PC\\SQLEXPRESS; Initial Catalog=RetailDeliveryMainALZDB;Integrated Security=True");


        public class State
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

        }
        public class Transition
        {
            public State From { get; set; }
            public State To { get; set; }
            public string Group { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            List<State> state_list = new List<State>();

            listBox1.Items.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile1.xml");

            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns1", "http://graphml.graphdrawing.org/xmlns");

             var key_description_node_id = "/ns1:graphml/ns1:key[@for='node' and @attr.name='description']/@id";
            //// var id_edge = "/ns1:graphml/ns1:key[@for='edge' and @attr.name='description']/@id";
             string idn = doc.SelectSingleNode(key_description_node_id, ns).Value;// id node.description = d5
             //string ide= doc.SelectSingleNode(id_node, ns).Value;// id node.description = d9

            List<Transition> transition_lists = new List<Transition>();
       
            foreach (XmlNode edg in doc.SelectNodes("//ns1:edge", ns))
            {
                //XmlNode group_id = edg.SelectSingleNode("/ns1:graphml/ns1:graph[1]/ns1:node[1]/@id", ns);
              
                Transition tr = new Transition();
                State stateFrom = new State();
                State stateTO = new State();

                //State form
                stateFrom.ID = edg.Attributes["source"].Value;//n0:n0
                XmlNode node_from = doc.SelectSingleNode("//ns1:node[@id=\"" + stateFrom.ID + "\"]", ns);//nodovi sa id-om n0::n1...
                stateFrom.Name = node_from.InnerText;
                XmlNode data_from = doc.SelectSingleNode("//ns1:node[@id=\"" + stateFrom.ID + "\"]/ns1:data[@key=\""+idn+"\"]", ns);
                stateFrom.Description = data_from.InnerText;
                tr.From = stateFrom;

                //StateTO
                stateTO.ID = edg.Attributes["target"].Value;//n0:n0
                XmlNode node_to = doc.SelectSingleNode("//ns1:node[@id=\"" + stateFrom.ID + "\"]", ns);
                stateTO.Name = node_to.InnerText;
                XmlNode data_to = doc.SelectSingleNode("//ns1:node[@id=\"" + stateTO.ID + "\"]/ns1:data[@key=\"" + idn + "\"]", ns);
                stateTO.Description = data_to.InnerText;
                tr.To = stateTO;

                transition_lists.Add(tr);
            }

            foreach (var listBoxItem in transition_lists)
            {
                listBox1.Items.Add("ID: " + listBoxItem.From.ID + " Name: " + listBoxItem.From.Name + " Description: " + listBoxItem.From.Description +"               "+ "ID: " + listBoxItem.To.ID + " Name: " + listBoxItem.To.Name + " Description: " + listBoxItem.To.Description);
               
            }
        }

        private void dataStateGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Da li želite da sačuvate izmene?", "Sačuvati?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    Validate();
                    dataStateGridView.EndEdit();
                    adapterState.Update(ds.Tables[0]); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            cn.Open();

            adapterState = new SqlDataAdapter("Select * from state", cn);
            adapterTransition = new SqlDataAdapter("Select * from Transition", cn);
            adapterChangeReason = new SqlDataAdapter("Select * from ChangeReason", cn);

            builder = new SqlCommandBuilder(adapterState);
            ds = new DataSet();
            adapterState.Fill(ds, "State");
            adapterTransition.Fill(ds, "Transition");
            adapterChangeReason.Fill(ds, "ChangeReason");

            dataStateGridView.DataSource = ds.Tables["State"];
            dataTransitionGridView.DataSource = ds.Tables["Transition"];
            dataReasonGridView.DataSource = ds.Tables["ChangeReason"];
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cn != null)
            {
                cn.Close();
            }
        }

        private void dataTransitionGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Da li želite da sačuvate izmene?", "Sačuvati?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    SqlCommand command = new SqlCommand("Select * from Transition", cn);
                    adapterTransition.SelectCommand = command;
                    SqlCommandBuilder cb = new SqlCommandBuilder(adapterTransition);
                    Validate();
                    dataTransitionGridView.EndEdit();
                    adapterTransition.Update(ds.Tables[1]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void dataReasonGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Da li želite da sačuvate izmene?", "Sačuvati?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    SqlCommand command = new SqlCommand("Select * from ChangeReason", cn);
                    adapterChangeReason.SelectCommand = command;
                    SqlCommandBuilder cb = new SqlCommandBuilder(adapterChangeReason);
                    Validate();
                    dataReasonGridView.EndEdit();
                    adapterChangeReason.Update(ds.Tables[2]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

}
