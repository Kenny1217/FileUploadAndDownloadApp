using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadAndDownloadApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Show download link if file was uploaded
            if (Session["File_Data"] != null)
            {
                lbtnDownload.Visible = true; //Make link button visible
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Check if file was entered
            if (fUpload.HasFile)
            {
                HttpPostedFile postedFile = fUpload.PostedFile;
                string fileExtension = Path.GetExtension(fUpload.FileName); // Get the file extension
                //Check file extension type
                if (!IsVaildFileType(fileExtension.ToLower()))
                {
                    Response.Write("Please upload supported file types only.");
                }
                else
                {
                    int fileSize = fUpload.PostedFile.ContentLength; // Get the file size

                    //Check file size
                    if (IsValidFileSize(fileSize))
                    {
                        Response.Write("File size too big");
                    }
                    else
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                        Session["File_Name"] = postedFile.FileName; //Store file name
                        Session["File_Data"] = bytes; //Store byte data of file
                        Session["File_Ext"] = fileExtension; //Store file extension
                        Response.Redirect(Request.RawUrl);
                    }
                }
            }
            else
            {
                Response.Write("No file entered");
            }
        }

        protected void lbtnDownload_Click(object sender, EventArgs e)
        {
            String FileName = Session["File_Name"].ToString();
            String FileType = Session["File_Ext"].ToString();
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = FileType;
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite((byte[])Session["File_data"]);
            Response.End();
        }

        //Checks if file type is valid
        public static bool IsVaildFileType(String fileType)
        {
            String[] vaildFileTypes = { ".txt", ".pdf", ".doc" }; //Array of valid file types

            //Go through each value in the array 
            foreach (var file in vaildFileTypes)
            {
                //Check for matching file type
                if (file == fileType) 
                {
                    return true; //Vaild file type
                }
            }
            return false; //Invaild file type
        }

        //Checks if file size is valid
        public static bool IsValidFileSize(int fileSize)
        {
            int fileSizeLimit = 10000000; //File size limit in bytes. Ex. 10000000B = 10MB
            return (fileSize > fileSizeLimit); //Return if file size is valid or not
        }
    }
}