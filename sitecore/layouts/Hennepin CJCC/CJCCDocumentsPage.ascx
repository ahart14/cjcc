<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CJCCDocumentsPage.ascx.cs" Inherits="Hennepin.SCWeb.CJCC.layouts.Hennepin_CJCC.CJCCDocumentsPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

 <asp:Literal runat="server" ID="litHeroBG"></asp:Literal>

    <div class="container-wrapper">
        <div class="container hero-image">
            <h1>
                <sc:Text ID="fldPageTitle" runat="server" Field="Page Title" />
            </h1>
        </div>
        <div class="lines">
            <img src="/cjcc-assets/images/lines.png" alt="image overlay lines">
        </div>
    </div>
<asp:Literal runat="server" ID="litHeroBGClose"></asp:Literal>

<section class="accent-purple collapse-top">
    <div class="container-wrapper">
        <div class="container">
            <div class="col-sm-12">

                <h2>Meeting documents</h2>

                <asp:Repeater runat="server" ID="rptMeetingDocuments" OnItemDataBound="rptMeetingDocuments_ItemDataBound">
                    <HeaderTemplate>
                        
                        
                    </HeaderTemplate>
                    <ItemTemplate>
                        <h3>
                            <asp:Literal Text="" runat="server" ID="litMeetingMonthYear" />
                        </h3>
                        <ul class="documents-list">
                        <li>
                            <asp:HyperLink ID="lnkMeetingAgenda" runat="server" Text="View agenda (PDF)"></asp:HyperLink>

                        </li>
                        <li>
                            <asp:HyperLink ID="lnkMeetingMinutes" runat="server" Text="Meeting minutes"></asp:HyperLink>

                        </li>
                        <li>
                            <sc:Text ID="fldAdditionalDocuments" runat="server" Field="Additional documents" />
                        </li>
                            </ul>
                    </ItemTemplate>
                    <FooterTemplate>
                      
                    </FooterTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rptRichText" runat="server" OnItemDataBound="rptRichText_ItemDataBound">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <h2>
                        <sc:Text ID="fldTitle" runat="server" Field="Title" />
                    </h2>
                    <div class="rich-text-section">
                        <sc:Text ID="fldContent" runat="server" Field="Content" />
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>

                <!--FORM-->
                <p>For access, fill out the request form and we will get back to you within 5 business days. For questions, contact Jill Hermanutz at <a href="mailto:jill.hermanutz.us">jill.hermanutz.us</a>.</p>
                <sc:PlaceHolder runat="server" ID="phForm" key="phForm"></sc:PlaceHolder>
            </div>
        </div>
    </div>
</section>
