using Common;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class E_Card : System.Web.UI.Page
    {
        string filepath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = Request.QueryString["UserName"].ToString();
            lblMemberShipNo.Text = Request.QueryString["MemberShipNo"].ToString();
            filepath = Request.QueryString["FilePath"].ToString();
            userimage.Attributes["src"] = filepath;
            ViewState["Email"] = Request.QueryString["Email"].ToString();
            LoadQRCode();
        }

        private void LoadQRCode()
        {

            string yourcode = lblName.Text + " # " + lblMemberShipNo.Text;
            QRCodeEncoder enc = new QRCodeEncoder();
            Bitmap qrcode = enc.Encode(yourcode);

            Bitmap img = new Bitmap(qrcode);
            MemoryStream memoryStream = new MemoryStream();
            img.Save(memoryStream, ImageFormat.Png);
            Byte[] bytes = new Byte[memoryStream.Length];
            memoryStream.Position = 0;
            memoryStream.Read(bytes, 0, (int)bytes.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            imgQRCode.ImageUrl = "data:image/png;base64," + base64String;
            imgQRCode.Visible = true;
        }
        public bool ThumbnailCallback()
        {
            return false;
        }

        protected void ExportToImage(object sender, EventArgs e)
        {
            string base64 = Request.Form[hfImageData.UniqueID].Split(',')[1];
            string fileNameWitPath = Server.MapPath("~/E-Card/") + lblMemberShipNo.Text + ".png";
            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(base64);
                    bw.Write(data);
                    bw.Close();
                }
            }
            EmailHelper obj = new EmailHelper();
            obj.SendEmailWithAttachment(fileNameWitPath, Convert.ToString(ViewState["Email"]), "Membership-Card", "Please download your Membership card from attachment." + "\n" + "Thank you.\n WebPortal Team.");
        }
    }
}