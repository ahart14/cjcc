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
    public partial class CJCCStrategy : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Item currentItem = Sitecore.Context.Item;

            Item[] strategyItems = currentItem.Axes.SelectItems("descendant::*[@@templatename='Strategy with Icon']");

            if (strategyItems != null && strategyItems.Length > 0)
            {

                rptStrategy.DataSource = strategyItems;
                rptStrategy.DataBind();
            }

            Item[] richTextItems = currentItem.Axes.SelectItems("descendant::*[@@templatename='Title with Rich Text']");

            if (richTextItems != null && richTextItems.Length > 0)
            {

                rptRichText.DataSource = richTextItems;
                rptRichText.DataBind();
            }

            Sitecore.Data.Fields.ImageField imgField = ((Sitecore.Data.Fields.ImageField)currentItem.Fields["Hero Image"]);
            if (imgField != null && imgField.MediaItem != null)
            {

                string heroBG = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);

                litHeroBG.Text = String.Format("<section class=\"purple overlay\" style=\"background-image: url('{0}')\">", heroBG);
                litHeroBGClose.Text = "</section>";
               
            }
            else {
                litHeroBG.Text = "<section>";
                litHeroBGClose.Text = "</section>";
            }



            fldPageTitle.Item = currentItem;
        }

        protected void rptStrategy_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;
                    Text fldTitle = (Text)e.Item.FindControl("fldTitle");
                    Text fldContent = (Text)e.Item.FindControl("fldContent");

                    Sitecore.Web.UI.WebControls.Image fldIcon = (Sitecore.Web.UI.WebControls.Image)e.Item.FindControl("fldIcon");


                    fldTitle.Item = nodeItm;
                    fldContent.Item = nodeItm;
                    fldIcon.Item = nodeItm;
                }
                catch (Exception ex) {

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