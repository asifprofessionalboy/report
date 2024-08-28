//using AspNetCore.Reporting;
//using Microsoft.AspNetCore.Mvc;
//using System.Data;
//using System.IO;
//using System.Threading.Tasks;

//namespace MyWebApplication.Controllers
//{
//    public class ReportController : Controller
//    {
//        public async Task<IActionResult> StudentReport()
//        {
//            // Define the path to your RDLC file
//            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Reports/StudentRPT.rdlc");

//            // Create a new LocalReport instance
//            var localReport = new LocalReport
//            {
//                ReportPath = reportPath
//            };

//            // Retrieve the data for the report (replace with your actual data retrieval)
//            var students = GetStudentData();

//            // Set up the data source
//            localReport.DataSources.Add(new ReportDataSource("StudentDataSet", students));

//            // Render the report to PDF
//            string mimeType;
//            string encoding;
//            string fileNameExtension;
//            Warning[] warnings;
//            string[] streams;

//            var renderedBytes = localReport.Render(
//                "PDF", null, out mimeType, out encoding, out fileNameExtension,
//                out streams, out warnings);

//            // Return PDF file
//            return File(renderedBytes, mimeType, "StudentReport.pdf");
//        }

//        private DataTable GetStudentData()
//        {
//            // Implement your data retrieval logic here
//            // For example, using ADO.NET to fetch data from a database
//            var dataTable = new DataTable();
//            // Fill the DataTable with data
//            return dataTable;
//        }
//    }
//}
