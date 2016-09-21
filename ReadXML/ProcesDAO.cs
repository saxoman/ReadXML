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
   public class ProcesDAO
    {
        public  SqlConnection cn = new SqlConnection("Data Source=WIN7-PC\\SQLEXPRESS; Initial Catalog=RetailDeliveryMainALZDB;Integrated Security=True");

        public  DataSet getProcesData()
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
        
        public  void saveProcesData(DataSet dataset)
        {
            //UPDATE COMMAND
            SqlCommand sqlUpdateCommand = new SqlCommand();
            sqlUpdateCommand.Connection = cn;
            sqlUpdateCommand.CommandText = "UPDATE ChangeReason SET ShortName = @ShortName, Description = @Description  WHERE ChangeReasonID = @oldChangeReasonID";
            SqlParameter parameter = sqlUpdateCommand.Parameters.Add(
            "@oldChangeReasonID", SqlDbType.Int, 5, "ChangeReasonID");
            parameter.SourceVersion = DataRowVersion.Original;

            sqlUpdateCommand.Parameters.Add("@ShortName", SqlDbType.VarChar, 50, "ShortName");
            sqlUpdateCommand.Parameters.Add("@Description", SqlDbType.VarChar, 50, "Description");

            SqlDataAdapter adapterChangeReason = new SqlDataAdapter("Select * from ChangeReason", cn);
            adapterChangeReason.UpdateCommand = sqlUpdateCommand;
            
            //Insert command
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = cn;
            insertCommand.CommandText = "INSERT INTO ChangeReason (ShortName, Description,TransitionID, ProcessTemplateID) VALUES (@ShortName, @Description, @TransitionID, @ProcessTemplateID)";
            insertCommand.Parameters.Add("@ShortName", SqlDbType.VarChar,50, "ShortName");
            insertCommand.Parameters.Add("@Description", SqlDbType.VarChar, 50, "Description");
            insertCommand.Parameters.Add("@TransitionID", SqlDbType.Int, 5, "TransitionID");
            insertCommand.Parameters.Add("@ProcessTemplateID", SqlDbType.Int, 4, "ProcessTemplateID");
            adapterChangeReason.InsertCommand = insertCommand;

            //delete comand
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = cn;
            deleteCommand.CommandText = "DELETE FROM ChangeReason WHERE ChangeReasonID=@ChangeReasonID";
            deleteCommand.Parameters.Add("@ChangeReasonID", SqlDbType.Int, 5, "ChangeReasonID");
            parameter.SourceVersion = DataRowVersion.Original;
            adapterChangeReason.DeleteCommand = deleteCommand;


            adapterChangeReason.Update(dataset.Tables[0]);
        }

    }
}
