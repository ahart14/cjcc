using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Sitecore.Collections;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore;
using Sitecore.Resources.Media;

namespace Hennepin.SCWeb.CJCC.layouts.Hennepin_CJCC
{


    public partial class CJCCDocumentsPage : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Item currentItem = Sitecore.Context.Item;

                IEnumerable<Item> meetingItems = Sitecore.Context.Item.Axes.SelectItems("/sitecore/content/CJCC//*[@@templatename='Meeting']").Where(x => DateUtil.ParseDateTime(x["Meeting Date"], DateTime.MaxValue) <= DateTime.UtcNow.Date).OrderByDescending(x => x["Meeting Date"]);

                if (meetingItems != null && meetingItems.Any())
                {

                    rptMeetingDocuments.DataSource = meetingItems;
                    rptMeetingDocuments.DataBind();
                }

                Sitecore.Data.Fields.ImageField imgField = ((Sitecore.Data.Fields.ImageField)currentItem.Fields["Hero Image"]);
                if (imgField != null && imgField.MediaItem != null)
                {

                    string heroBG = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);

                    litHeroBG.Text = String.Format("<section class=\"purple overlay\" style=\"background-image: url('{0}')\">", heroBG);
                    litHeroBGClose.Text = "</section>";

                }
                else
                {
                    litHeroBG.Text = "<section>";
                    litHeroBGClose.Text = "</section>";
                }

                Item[] richTextItems = currentItem.Axes.SelectItems("descendant::*[@@templatename='Title with Rich Text']");

                if (richTextItems != null && richTextItems.Length > 0)
                {

                    rptRichText.DataSource = richTextItems;
                    rptRichText.DataBind();
                }

                fldPageTitle.Item = currentItem;

            }
            catch (Exception ex)
            {

            }

        }

        protected void rptMeetingDocuments_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Item nodeItm = (Item)e.Item.DataItem;

                    Text fldAdditionalDocuments = (Text)e.Item.FindControl("fldAdditionalDocuments");
                    HyperLink lnkMeetingAgenda = (HyperLink)e.Item.FindControl("lnkMeetingAgenda");
                    HyperLink lnkMeetingMinutes = (HyperLink)e.Item.FindControl("lnkMeetingMinutes");

                    Literal litMeetingMonthYear = (Literal)e.Item.FindControl("litMeetingMonthYear");

                    if (nodeItm.Fields["Meeting Date"].HasValue)
                    {
                        litMeetingMonthYear.Text = DateUtil.ParseDateTime(nodeItm.Fields["Meeting Date"].Value.ToString(), DateTime.MaxValue).ToString("MMMM yyyy");
                    }

                    Sitecore.Data.Fields.FileField agenda = ((Sitecore.Data.Fields.FileField)nodeItm.Fields["Agenda"]);

                    if (agenda != null && nodeItm.Fields["Agenda"].HasValue)
                    {
                        string agendaURL = Sitecore.Resources.Media.MediaManager.GetMediaUrl(agenda.MediaItem);
                        lnkMeetingAgenda.NavigateUrl = agendaURL;
                    }

                    Sitecore.Data.Fields.FileField minutes = ((Sitecore.Data.Fields.FileField)nodeItm.Fields["Meeting Minutes"]);

                    if (minutes != null && nodeItm.Fields["Meeting Minutes"].HasValue)
                    {
                        string minutesURL = Sitecore.Resources.Media.MediaManager.GetMediaUrl(minutes.MediaItem);
                        lnkMeetingMinutes.NavigateUrl = minutesURL;
                    }

                    fldAdditionalDocuments.Item = nodeItm;


                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void rptRichText_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;
                    Text fldTitle = (Text)e.Item.FindControl("fldTitle");
                    Text fldContent = (Text)e.Item.FindControl("fldContent");


                    fldTitle.Item = nodeItm;
                    fldContent.Item = nodeItm;

                }
                catch (Exception ex)
                {

                }

            }
        }
    }

}
