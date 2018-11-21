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
    public partial class CJCCHomePage : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Item currentItem = Sitecore.Context.Item;
            ChildList childItems = currentItem.Children;
            string pageURL = Sitecore.Links.LinkManager.GetItemUrl(currentItem);
            string pageTitle = "Home";

            try
            {
                //Set Video data from Home Page data item
                string videoEmbedCode = "";
                videoEmbedCode = currentItem.Fields["Video Embed URL"].Value;

                litOpenVideoSpan.Text = String.Format("<span onclick=\"jQuery('#ytplayer').attr('src','{0}');jQuery('.video-container').show();jQuery('.vid-player-img').hide();jQuery('.main-video').show();\">", videoEmbedCode);
                litCloseVideoSpan.Text = "</span>";

                imgHomeVideo.Item = currentItem;
            }
            catch (Exception ex) { }
            List<Item> meetingItems = Sitecore.Context.Item.Axes.SelectItems("descendant::*[@@templatename='Meeting']").Where(x => DateUtil.ParseDateTime(x["Meeting Date"], DateTime.MaxValue) >= DateTime.UtcNow.Date).OrderBy(x => x["Meeting Date"]).Take(3).ToList<Item>();

            if (meetingItems != null && meetingItems.Any())
            {
                try { 
                    Item nextMeeting = meetingItems.First();
                    litNextMeetingDate.Text = DateUtil.ParseDateTime(nextMeeting.Fields["Meeting Date"].Value, DateTime.MaxValue).ToString("D");
                    litNextMeetingTime.Text = nextMeeting.Fields["Meeting Time"].Value;
                    litNextMeetingLocation.Text = nextMeeting.Fields["Location"].Value;

                   

                    try
                    {
                        Sitecore.Data.Fields.LinkField viewMapLink = (Sitecore.Data.Fields.LinkField)nextMeeting.Fields["Map Link"];

                        string navUrl = viewMapLink.Url;

                        if (navUrl != "")
                        {

                            lnkNextMeetingMap.NavigateUrl = navUrl;
                        }
                        
                        Sitecore.Data.Fields.FileField fileField = ((Sitecore.Data.Fields.FileField)nextMeeting.Fields["Agenda"]);

                        if (fileField != null && nextMeeting.Fields["Agenda"].HasValue)
                        {
                            string agendaURL = Sitecore.Resources.Media.MediaManager.GetMediaUrl(fileField.MediaItem);
                            lnkNextMeetingAgenda.NavigateUrl = agendaURL;
                        }
                    }
                    catch (Exception ex) { 
                    }

                    //Bind additional meeting items to "Future" meetings section
                    if (meetingItems.Count > 1)
                    {
                        Item[] futureMeetings = meetingItems.Skip(1).ToArray();
                        rptFutureMeetings.DataSource = futureMeetings;
                        rptFutureMeetings.DataBind();
                    }
                }
                catch(Exception ex){
                }
            }
        }

        protected void rptFutureMeetings_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;

                    Literal litFutureMeetingDate = (Literal)e.Item.FindControl("litFutureMeetingDate");
                    Literal litFutureMeetingTime = (Literal)e.Item.FindControl("litFutureMeetingTime");
                    Literal litFutureMeetingLocation = (Literal)e.Item.FindControl("litFutureMeetingLocation");

                    if (nodeItm.Fields["Meeting Date"].Value != "")
                    {
                        litFutureMeetingDate.Text = DateUtil.ParseDateTime(nodeItm.Fields["Meeting Date"].Value.ToString(), DateTime.MaxValue).ToString("D");
                    }

                    if (nodeItm.Fields["Meeting Time"].Value != "")
                    {
                        litFutureMeetingTime.Text = nodeItm.Fields["Meeting Time"].Value.ToString();
                    }

                    if (nodeItm.Fields["Location"].Value != "")
                    {
                        litFutureMeetingLocation.Text = nodeItm.Fields["Location"].Value.ToString();
                    }

                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }
            }
        }

        Boolean handleException(Exception ex)
        {
            bool handled = false;
            try
            {
                handled = true;
            }
            catch (Exception e)
            {
                bool exHandled = handleException(e);
            }

            return handled;
        }
    }
}