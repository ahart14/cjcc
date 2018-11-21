namespace Hennepin.SCWeb.CJCC
{
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using Sitecore.Data.Items;
    using Sitecore.Web.UI.WebControls;
    using Sitecore.Collections;
    using System.Linq;
    using Sitecore.Data.Fields;
    using Sitecore;

    public partial class CJCCMaster : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {


            //TODO:  literal for head

            //Load header configuration
            Item currentItem = Sitecore.Context.Item;

            Item configItemHeader = currentItem.Axes.SelectSingleItem("/sitecore/content/CJCC/Configuration//*[@@templateid='{B5D7D6ED-CCEA-463C-8CEF-7D7B4E8A45E3}']");

            if (configItemHeader != null) {
                fldMasterTitle.Item = configItemHeader;
            }

            Item configItemFooter = currentItem.Axes.SelectSingleItem("/sitecore/content/CJCC/Configuration//*[@@templateid='{478521A2-B366-485A-8C53-C747B46C37FE}']");

            if (configItemFooter != null)
            {
                txtFooterLeft.Item = configItemFooter;
                txtFooterRight.Item = configItemFooter;
            }

            Item[] navItems = currentItem.Axes.SelectItems("/sitecore/content/CJCC//*[@@templatename='Page with Hero Image']");

            if (navItems != null && navItems.Length > 0)
            {
                rptNav.DataSource = navItems;
                rptNav.DataBind();
            }
        }

        protected void rptNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;

                    CheckboxField showInNavigation = nodeItm.Fields["Show in Navigation"];

                    var isChecked = showInNavigation.Checked;

                    if (isChecked)
                    {

                        HyperLink fldNavLink = (HyperLink)e.Item.FindControl("fldNavLink");
                        fldNavLink.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(nodeItm);

                        Text fldNavTitle = (Text)e.Item.FindControl("fldNavTitle");
                        fldNavTitle.Item = nodeItm;
                    }
                    else
                    {
                        e.Item.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                   
                }

            }

        }
    }
}
