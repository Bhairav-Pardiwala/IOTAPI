using CNTKTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace IOTAPI.Controllers
{
    public class DoorController : ApiController
    {
        //http://localhost:63838/api/Door/UploadFiles
        [HttpPost()]
        public String UploadFiles( string text)
        {
            int iUploadedCnt = 0;

            List<valperc> test =null;
            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";

            String randomfilename = Guid.NewGuid().ToString();
            String randomoutputname = Guid.NewGuid().ToString();
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/tempstorage/");

            System.Web.HttpFileCollection httpfilecollection = System.Web.HttpContext.Current.Request.Files;

            //var someText = System.Web.HttpContext.Current.Request .ReadAsStringAsync().Result;


            int iCnt = 0;
                System.Web.HttpPostedFile hpf = httpfilecollection[iCnt];

                if (hpf.ContentLength > 0)
                {
                   
                    if (!File.Exists(sPath + randomfilename))
                    {
                       
                        hpf.SaveAs(sPath + randomfilename);

                   

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "iotcheck";
                    process.StartInfo.WorkingDirectory = @"C:\iotcheck";

                    process.StartInfo.Arguments = @""""+sPath + randomoutputname +@""""+" "+ @""""+sPath + randomfilename+@"""";
                   
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    process.Start();
                    process.WaitForExit();
                    while (!process.HasExited)
                    {
                        Thread.Sleep(500);
                    }

                   

                    String returnStr= File.ReadLines(sPath + randomoutputname).First();

                    File.Delete(sPath + randomoutputname);
                    File.Delete(sPath + randomfilename);

                    return returnStr;

                    //   test=Utility.EvaluationSingleImage(CNTK.DeviceDescriptor.DefaultDevice());


                }
                }
            


            // RETURN A MESSAGE (OPTIONAL).
            if (iUploadedCnt > 0)
            {
                return "invalid";
            }
            else
            {
                return "Please upload a file to this api";
            }
        }
        //http://localhost:63838/api/Switch/UploadFiles
        [HttpPost()]
        public String Switch(string text)
        {
            int iUploadedCnt = 0;

            List<valperc> test = null;
            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";

            String randomfilename = Guid.NewGuid().ToString();
            String randomoutputname = Guid.NewGuid().ToString();
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/tempstorage/");

            System.Web.HttpFileCollection httpfilecollection = System.Web.HttpContext.Current.Request.Files;

            //var someText = System.Web.HttpContext.Current.Request .ReadAsStringAsync().Result;


            int iCnt = 0;
            System.Web.HttpPostedFile hpf = httpfilecollection[iCnt];

            if (hpf.ContentLength > 0)
            {

                if (!File.Exists(sPath + randomfilename))
                {

                    hpf.SaveAs(sPath + randomfilename);



                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "iotcheck";
                    process.StartInfo.WorkingDirectory = @"C:\iotcheck";

                    process.StartInfo.Arguments = @"""" + sPath + randomoutputname + @"""" + " " + @"""" + sPath + randomfilename + @"""";

                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    process.Start();
                    process.WaitForExit();
                    while (!process.HasExited)
                    {
                        Thread.Sleep(500);
                    }



                    String returnStr = File.ReadLines(sPath + randomoutputname).First();

                    File.Delete(sPath + randomoutputname);
                    File.Delete(sPath + randomfilename);

                    return returnStr;

                    //   test=Utility.EvaluationSingleImage(CNTK.DeviceDescriptor.DefaultDevice());


                }
            }



            // RETURN A MESSAGE (OPTIONAL).
            if (iUploadedCnt > 0)
            {
                return "invalid";
            }
            else
            {
                return "Please upload a file to this api";
            }
        }

    }
}
