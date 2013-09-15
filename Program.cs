using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Model model = new Model();
            model.Results = new Results { Comment = "Comment", FinancialYear = 2013, TEP = 0.6m };
            model.PDF = new byte[3] { 1, 1, 1 };
            model.Status = new Status { RequestID = "RequestID", RequestStatus = new RequestStatus { RequestStatusEnum= RequestStatusEnum.COMPLETED, CancellationReason="CancellationReason" }, TestStatus = "TestStatus" };
            string xml = model.OutputXML();
        }
    }
}
