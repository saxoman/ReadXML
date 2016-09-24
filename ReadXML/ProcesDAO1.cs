using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReadXML
{
   public class ProcesDAO1
    {
        public SqlConnection cn = new SqlConnection("Data Source=WIN7-PC\\SQLEXPRESS; Initial Catalog=RetailDeliveryMainALZDB;Integrated Security=True");

        public DataSet getProcesData()
        {
            cn.Open();
            SqlDataAdapter adapterChangeReason = new SqlDataAdapter("Select * from ChangeReason", cn);
            SqlDataAdapter adapterTransition = new SqlDataAdapter("Select * from Transition", cn);
            SqlDataAdapter adapterState = new SqlDataAdapter("Select * from state", cn);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapterState);
            DataSet ds = new DataSet();

            adapterChangeReason.Fill(ds, "ChangeReason");
            adapterTransition.Fill(ds, "Transition");
            adapterState.Fill(ds, "State");

            cn.Close();
            return ds;
        }

        public void saveProcesData(DataSet dataset)
        {
            //UPDATE COMMAND

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                switch (dr.RowState.ToString())
                {
                    case "Modified":
                        SqlCommand sqlUpdateCommand = new SqlCommand();
                        sqlUpdateCommand.Connection = cn;
                        string shortname = dr.ItemArray.GetValue(1).ToString().Replace("'", "''"); 
                        string desc = dr.ItemArray.GetValue(2).ToString().Replace("'", "''"); 
                        sqlUpdateCommand.CommandText = "UPDATE ChangeReason SET ShortName = '" + shortname + "', Description = '" + desc + "' WHERE ChangeReasonID = " + dr.ItemArray.GetValue(0);
                        sqlUpdateCommand.Parameters.AddWithValue("@ShortName", shortname);
                        sqlUpdateCommand.Parameters.AddWithValue("@Description", desc);
                        cn.Open();
                        sqlUpdateCommand.ExecuteNonQuery();
                        cn.Close();
                        break;
                    case "Deleted":
                        SqlCommand deleteCommand = new SqlCommand();
                        deleteCommand.Connection = cn;
                        deleteCommand.CommandText = "DELETE FROM ChangeReason WHERE ChangeReasonID=@ChangeReasonID";
                        SqlParameter parameter = deleteCommand.Parameters.AddWithValue("@ChangeReasonID", dr["ChangeReasonID", DataRowVersion.Original]);
                        parameter.SourceVersion = DataRowVersion.Original;
                        cn.Open();
                        deleteCommand.ExecuteNonQuery();
                        cn.Close();
                        break;
                    case "Added":
                        SqlCommand insertCommand = new SqlCommand();
                        insertCommand.Connection = cn;
                        string sn = dr.ItemArray.GetValue(1).ToString().Replace("'", "''");
                        string dsc = dr.ItemArray.GetValue(2).ToString().Replace("'", "''");
                        int tID = Convert.ToInt32(dr.ItemArray.GetValue(3));
                        int pID = Convert.ToInt32(dr.ItemArray.GetValue(4));
                        insertCommand.CommandText = "INSERT INTO ChangeReason (ShortName, Description,TransitionID, ProcessTemplateID) VALUES ('" + sn+ "', '" + dsc + "', '" + tID + "', '" +pID+"')";
                        insertCommand.Parameters.AddWithValue("@ShortName", sn);
                        insertCommand.Parameters.AddWithValue("@Description", dsc);
                        insertCommand.Parameters.AddWithValue("@TransitionID", tID);
                        insertCommand.Parameters.AddWithValue("@ProcessTemplateID", pID);
                        cn.Open();
                        insertCommand.ExecuteNonQuery();
                        cn.Close();
                        break;
                }
            }
            return;
        }
    }
}
