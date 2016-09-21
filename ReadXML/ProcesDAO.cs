using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ReadXML
{
   public class ProcesDAO
    {
        public  SqlDataAdapter adapterState { get; set; }
        public  SqlDataAdapter adapterTransition { get; set; }
        public  SqlDataAdapter adapterChangeReason { get; set; }
        public  SqlCommandBuilder builder { get; set; }
        public  DataSet ds { get; set; }
        public  SqlConnection cn = new SqlConnection("Data Source=WIN7-PC\\SQLEXPRESS; Initial Catalog=RetailDeliveryMainALZDB;Integrated Security=True");

        public  DataSet getProcesData()
        {
            cn.Open();
            adapterChangeReason = new SqlDataAdapter("Select * from ChangeReason", cn);
            adapterTransition = new SqlDataAdapter("Select * from Transition", cn);
            adapterState = new SqlDataAdapter("Select * from state", cn);

            builder = new SqlCommandBuilder(adapterState);
            ds = new DataSet();

            adapterChangeReason.Fill(ds, "ChangeReason");
            adapterTransition.Fill(ds, "Transition");
            adapterState.Fill(ds, "State");

            cn.Close();
            return ds;
        }
        public  void saveProcesData()
        {
            SqlCommand sqlUpdateCommand = new SqlCommand();
            sqlUpdateCommand.Connection = cn;
            sqlUpdateCommand.CommandText = "UPDATE ChangeReason SET ShortName = @ShortName, Description = @Description  WHERE ChangeReasonID = @oldChangeReasonID";
            SqlParameter parameter = sqlUpdateCommand.Parameters.Add(
            "@oldChangeReasonID", SqlDbType.Int, 5, "ChangeReasonID");
            parameter.SourceVersion = DataRowVersion.Original;

            sqlUpdateCommand.Parameters.Add("@ShortName", SqlDbType.VarChar, 50, "ShortName");
            sqlUpdateCommand.Parameters.Add("@Description", SqlDbType.VarChar, 50, "Description");

            adapterChangeReason.UpdateCommand = sqlUpdateCommand;
            adapterChangeReason.Update(ds.Tables[0]);
        }

    }
}
