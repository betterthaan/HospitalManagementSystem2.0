using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Common
{
    public static class CmnMethods
    {

        public static void ResetGlobal()
        {
            Global.UserInfo = new Models.UserInfo();
        }

        public static SqlConnection OpenConnectionString(SqlConnection sqlCon)
        {
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            sqlCon.Open();
            return sqlCon;
        }

        public static void GetUserInfo(DataTable dt)
        {
            Global.UserInfo = (from rw in dt.AsEnumerable()
                               select new UserInfo()
                               {
                                   UserId = Convert.ToInt32(rw["UserId"]),
                                   UserName = Convert.ToString(rw["Username"]),
                                   UserPassword = Convert.ToString(rw["UserPassword"]),
                                   UserType = Convert.ToInt32(rw["UserType"]),
                                   DoctorId = Convert.ToInt32(rw["DoctorId"])
                               }).ToList().FirstOrDefault();
        }

    }
}
