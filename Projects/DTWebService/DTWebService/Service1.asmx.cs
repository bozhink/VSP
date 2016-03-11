using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace DTWebService
{
    [WebService(Namespace = "http://localhost/DTWebService/",
        Description="A service displaying catalogs of Deepthoughts Publications")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(true)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        private IContainer components;

        private System.Data.Odbc.OdbcCommand sqlSelectCommand1;
        private System.Data.Odbc.OdbcCommand sqlInsertCommand1;
        private System.Data.Odbc.OdbcCommand sqlUpdateCommand1;
        private System.Data.Odbc.OdbcCommand sqlDeleteCommand1;
        private System.Data.Odbc.OdbcDataAdapter sqlDataAdapter1;
        //private DTWebService.dsDetails dsDetails1;

    
        public Service1()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {

        }
    }
}
