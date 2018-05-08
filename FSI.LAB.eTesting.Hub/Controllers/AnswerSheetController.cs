using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FSI.LAB.eTesting.Hub.Controllers
{
    public class AnswerSheetController : Controller
    {
        // GET: AnswerSheet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PilotExam()
        {


            var TitleLbl = Request.QueryString["Title"] ?? "TITLE";
            var VersionLbl = Request.QueryString["Version"] ?? "VERSION";

            //Guid AssessmentID;
            //try
            //{
            //    AssessmentID = new Guid(Request.QueryString["AssessmentID"]);
            //}
            //catch (Exception)
            //{
            //    AssessmentID = new Guid("EFC98F5A-8BD0-49BF-9BF8-A401C1965736");
            //}
            //SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString());
            //SqlCommand scom = new SqlCommand("getAssessmentQuestionCount", scon);
            //scom.CommandType = CommandType.StoredProcedure;
            //scom.Parameters.Add(new SqlParameter("AssessmentID", AssessmentID));
            //scom.Parameters.Add(new SqlParameter("digit", 3));
            //scon.Open();
            //SqlDataReader sr = scom.ExecuteReader();
            Dictionary<int, int> sectionCounts = new Dictionary<int, int>();
            sectionCounts.Add(1, 56);
            sectionCounts.Add(2, 12);
            sectionCounts.Add(3, 8);
            sectionCounts.Add(5, 8);
            sectionCounts.Add(7, 16);
            sectionCounts.Add(8, 8);
            //while (sr.Read())
            //{
            //    int section = 0;
            //    int sectionCount = 0;
            //    Int32.TryParse(sr["Section"].ToString(), out section);
            //    Int32.TryParse(sr["SectionCount"].ToString(), out sectionCount);
            //    sectionCounts.Add(section, sectionCount);
            //}
            //sr.Close();
            //scon.Close();

            string[] tables = { "Section1Tbl", "Section2Tbl", "Section3Tbl", "Section4Tbl", "Section5Tbl", "Section6Tbl", "Section7Tbl", "Section8Tbl" };
            string[] secdata = new string[8];
            int[] cols = { 4, 1, 1, 1, 1, 1, 1, 1 };
            int[] rows = { 20, 20, 10, 10, 10, 10, 20, 20 };
            for (int i = 0; i < tables.Length; i++)
            {
                try
                {
                    int qNum = sectionCounts[i + 1];
                    secdata[i] = loadPilotExamTable(tables[i], rows[i], cols[i], qNum);
                }
                catch (KeyNotFoundException) { }
            }

            //if (secdata[0] != null) ViewData["Section1Tbl"] = secdata[0];
            //if (secdata[1] != null) ViewData["Section2Tbl"] = secdata[1];
            //if (secdata[2] != null) ViewData["Section3Tbl"] = secdata[2];
            //if (secdata[3] != null) ViewData["Section4Tbl"] = secdata[3];
            //if (secdata[4] != null) ViewData["Section5Tbl"] = secdata[4];
            //if (secdata[5] != null) ViewData["Section6Tbl"] = secdata[5];
            //if (secdata[6] != null) ViewData["Section7Tbl"] = secdata[6];
            //if (secdata[7] != null) ViewData["Section8Tbl"] = secdata[7];

            ViewData["Section1Tbl"] = secdata[0] == null ? "" : secdata[0];
            ViewData["Section2Tbl"] = secdata[1] == null ? "" : secdata[1];
            ViewData["Section3Tbl"] = secdata[2] == null ? "" : secdata[2];
            ViewData["Section4Tbl"] = secdata[3] == null ? "" : secdata[3];
            ViewData["Section5Tbl"] = secdata[4] == null ? "" : secdata[4];
            ViewData["Section6Tbl"] = secdata[5] == null ? "" : secdata[5];
            ViewData["Section7Tbl"] = secdata[6] == null ? "" : secdata[6];
            ViewData["Section8Tbl"] = secdata[7] == null ? "" : secdata[7];

            //US579
            int qTotal = 0;
            foreach (int qSec in sectionCounts.Values)
                qTotal += qSec;
            var JAATotalLabel = qTotal.ToString();
            ViewData["SectionData"] = secdata;
            return View();
        }
        /*  Pilot Exam answer sheet functions  */
        string Response = "4";
        private String getPilotExamQuestionCell(int num, bool header, string sec)
        {
            String headerStr = "";
            String dataStr = "";


            if (header)
            {
                int ascii = 65;
                headerStr = @"<tr>
                           <td>&nbsp;</td>";
                for (int i = 1; i <= Convert.ToUInt32(Response); i++)
                {
                    char charcter = (char)ascii;
                    string option = charcter.ToString();
                    headerStr += string.Format("<td><div style='font-size:6pt;text-align:center;vertical-align:bottom'><b>{0}</b></div></td>", option);
                    ascii++;
                }
                headerStr += "</tr>";
            }
            dataStr = @"<table border='0' style='padding:0;border-spacing:0'>
                        {1}
                        <tr>
                            <td style='font-size:8pt' width='24%'>
                            <b>{0}.</b>
                        </td>";
            for (int j = 1; j <= Convert.ToUInt32(Response); j++)
            {
                dataStr += "<td style='text-align:center;width:19%;font-size:8pt;'><input type=\"checkbox\"  class=\"chkclass\" name=\"btn" + sec + num.ToString() + "\" ></td>";
            }
            dataStr += @"</tr>
                                   </table>";
            return string.Format(dataStr, num.ToString(), headerStr);

        }

        private string loadPilotExamTable(string section, int rows, int cols, int qNum)
        {

            string sectiondata = "";
            TableRow[] tr = new TableRow[rows];
            for (int i = 0; i < rows; i++)
            {
                tr[i] = new TableRow();
                for (int j = 0; j < cols; j++)
                {
                    TableCell cell = new TableCell();

                    tr[i].Cells.Add(cell);
                }
            }

            for (int i = 0; i < qNum; i++)
            {
                int row = i % rows;
                int col = i / rows;
                TableCell c = tr[row].Cells[col];
                c.Text = getPilotExamQuestionCell(i + 1, (i % 20 == 0),section);
            }
            foreach (TableRow trow in tr)
            {

                // Create writers to render contents of controls into
                StringWriter theStringWriter = new StringWriter();
                HtmlTextWriter theHtmlTextWriter = new HtmlTextWriter(theStringWriter);

                // Render the table row control into the writer
                trow.RenderControl(theHtmlTextWriter);


                sectiondata += theHtmlTextWriter.InnerWriter.ToString();
            }
            return sectiondata;
        }



        /****************************************************************/
    }
}