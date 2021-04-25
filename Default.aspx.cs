using System;
using System.Collections.Generic;
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

        }

        protected void lbtnDownload_Click(object sender, EventArgs e)
        {

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