using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using EventPlanner.DBConnection;
using EventPlanner.DataAccessLayer;
using EventPlanner.Models;

namespace EventPlanner.DataAccessLayer
{
    public class db
    {
        OracleConnection con = null;
        DbConnection dbConnection = null;

        public List<UpEventModel> UpcomingEvents()
        {
            List<UpEventModel> UpEventModelList = new List<UpEventModel>();

            try
            {
                dbConnection = new DbConnection();
                con = new OracleConnection(dbConnection.getConnectionString());
                using (OracleCommand command = new OracleCommand())
                {
                    DataSet ds = new DataSet();
                    command.CommandText = "SP_GET_UPCOMING_EVENTS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = con;
                    command.BindByName = true;

                    command.Parameters.Add("O_up_events", OracleDbType.RefCursor, ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter();
                    da.SelectCommand = command;
                    da.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        UpEventModelList = (from DataRow dr in ds.Tables[0].Rows
                                                         select new UpEventModel()
                                                         {
                                                             id_num = dr["ID_NUM"].ToString(),
                                                             name = dr["NAME"].ToString(),
                                                             location = dr["LOCATION"].ToString(),
                                                             event_date = dr["EVENT_DATE"].ToString(),
                                                             organizer_name = dr["ORGANIZER_NAME"].ToString(),
                                                             event_type = dr["EVENT_TYPE"].ToString(),
                                                             picture = dr["PICTURE"].ToString(),
                                                         }).ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }

            return UpEventModelList;
        }

        public ResponseModel SaveNewEvent(UpEventModel allData)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                dbConnection = new DbConnection();
                con = new OracleConnection(dbConnection.getConnectionString());
                using (OracleCommand command = new OracleCommand())
                {
                    DataSet ds = new DataSet();
                    command.CommandText = "SP_SAVE_NEW_EVENT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = con;
                    command.BindByName = true;

                    command.Parameters.Add("p_location", OracleDbType.Varchar2, ParameterDirection.Input).Value = allData.location;
                    command.Parameters.Add("p_event_date", OracleDbType.Date, ParameterDirection.Input).Value = DateTime.Parse(allData.event_date).ToString("dd/MM/yyyy");
                    command.Parameters.Add("p_organizer_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = allData.organizer_name;
                    command.Parameters.Add("p_event_type", OracleDbType.Varchar2, ParameterDirection.Input).Value = allData.event_type;
                    command.Parameters.Add("p_event_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = allData.name;
                    command.Parameters.Add("p_picture", OracleDbType.NVarchar2, ParameterDirection.Input).Value = allData.picture;
                    
                    command.Parameters.Add("O_Response", OracleDbType.RefCursor, ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter();
                    da.SelectCommand = command;
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    int count = dt.Rows.Count;
                    if (count > 0)
                    {
                        responseModel.Status = ds.Tables[0].Rows[0]["status"].ToString();
                        responseModel.Message = ds.Tables[0].Rows[0]["message"].ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }

            return responseModel;
        }

        public List<EventTypeModel> GetEventType()
        {
            List<EventTypeModel> objEventTypeList = new List<EventTypeModel>();

            try
            {
                dbConnection = new DbConnection();
                con = new OracleConnection(dbConnection.getConnectionString());
                using (OracleCommand command = new OracleCommand())
                {
                    DataSet ds = new DataSet();
                    command.CommandText = "SP_GET_Event_Type";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = con;
                    command.BindByName = true;

                    command.Parameters.Add("O_EventType", OracleDbType.RefCursor, ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter();
                    da.SelectCommand = command;
                    da.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        objEventTypeList = (from DataRow dr in ds.Tables[0].Rows
                                            select new EventTypeModel()
                                            {
                                                Text = dr["TYPE_NAME"].ToString(),
                                            }).ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }

            return objEventTypeList;
        }

        public List<EventTypeModel> GetEventID()
        {
            List<EventTypeModel> objEventTypeList = new List<EventTypeModel>();
            //string str = "";
            try
            {
                dbConnection = new DbConnection();
                con = new OracleConnection(dbConnection.getConnectionString());
                using (OracleCommand command = new OracleCommand())
                {
                    DataSet ds = new DataSet();
                    command.CommandText = "SP_GET_Event_ID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = con;
                    command.BindByName = true;

                    command.Parameters.Add("O_EventID", OracleDbType.RefCursor, ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter();
                    da.SelectCommand = command;
                    da.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        objEventTypeList = (from DataRow dr in ds.Tables[0].Rows
                                            select new EventTypeModel()
                                            {
                                                Text = dr["ID_NUM"].ToString(),
                                            }).ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }

            return objEventTypeList;
        }

    }
}