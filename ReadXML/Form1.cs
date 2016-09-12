using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public class State
        {
            public string ID{ get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

        }
        public class Transition
        {
            public string From { get; set; }
            public string To { get; set; }
            public string Group { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            List<State> state_list = new List<State>();
            
            
            
           listBox1.Items.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile1.xml");

            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns1", "http://graphml.graphdrawing.org/xmlns");

            var id_node = "/ns1:graphml/ns1:key[@for='node' and @attr.name='description']/@id";
            var id_edge = "/ns1:graphml/ns1:key[@for='edge' and @attr.name='description']/@id";

            string idn = doc.SelectSingleNode(id_node,ns).Value;// id node.description = d5
            string ide= doc.SelectSingleNode(id_node, ns).Value;// id node.description = d9

            //Node
            int i = 0;
            foreach (XmlNode cvor in doc.SelectNodes("/*[local-name()='graphml' and namespace-uri()='http://graphml.graphdrawing.org/xmlns']/*[local-name()='graph' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][1]/*[local-name()='node' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][1]/*[local-name()='graph' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][1]/*", ns))//ovo su svi nodovi
            {
                State st = new State();

                //Lista svih descritiona
                List< string > description_lists = new List<string>();
                foreach (XmlNode data in cvor.SelectNodes("/*[local-name()='graphml' and namespace-uri()='http://graphml.graphdrawing.org/xmlns']/*[local-name()='graph' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][1]/*[local-name()='node' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][1]/*[local-name()='graph' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][1]//*[local-name()='node' and namespace-uri()='http://graphml.graphdrawing.org/xmlns']/*[local-name()='data' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][@key='d5']",ns))
                {
                    description_lists.Add(data.InnerText);                   
                }

                //lista svih id-ova nodova
                List<string> id_lists = new List<string>();
                foreach (XmlNode data in cvor.SelectNodes("/*[local-name()='graphml' and namespace-uri()='http://graphml.graphdrawing.org/xmlns']/*[local-name()='graph' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][1]/*[local-name()='node' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][1]//*[local-name()='graph' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][1]/*", ns))
                {
                    id_lists.Add(data.Attributes["id"].Value);
                }


                st.ID = id_lists.ElementAt(i);
                st.Name = cvor.InnerText;
                st.Description=description_lists.ElementAt(i);

                state_list.Add(st);
                //////////////////////////
                string description = description_lists.ElementAt(i);
                listBox1.Items.Add(cvor.InnerText);
               // listBox1.Items.Add("X - Koordinata: " + x+ " " + "Y - Koordinata: " + y +" Širina: " + width + " Visina: " + height+ " Description:"+ description);         
                i++;
            }

            //Edge
           
            List<Transition> transition_lists = new List<Transition>();
            foreach (XmlNode edg in doc.SelectNodes("//ns1:edge[@source][@target]", ns))
            {
                XmlNode group_id = edg.SelectSingleNode("/*[local-name()='graphml' and namespace-uri()='http://graphml.graphdrawing.org/xmlns']/*[local-name()='graph' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][1]/*[local-name()='node' and namespace-uri()='http://graphml.graphdrawing.org/xmlns'][1]/@id", ns);

                Transition tr = new Transition();
                tr.From = edg.Attributes["source"].Value;
                tr.To = edg.Attributes["target"].Value;
                tr.Group = group_id.InnerText.ToString();
                transition_lists.Add(tr);
                listBox1.Items.Add("Source: " + edg.Attributes["source"].Value + " " + "Target: " + edg.Attributes["target"].Value);
            }
        }
    }

}
