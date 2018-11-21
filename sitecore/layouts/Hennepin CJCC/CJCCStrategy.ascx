<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CJCCStrategy.ascx.cs" Inherits="Hennepin.SCWeb.CJCC.layouts.Hennepin_CJCC.CJCCStrategy" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<!--Open section tag with BG-->
 <asp:Literal runat="server" ID="litHeroBG"></asp:Literal>

    <div class="container-wrapper">
        <div class="container hero-image">
            <h1>
                <sc:Text ID="fldPageTitle" runat="server" Field="Page Title" />
            </h1>
        </div>
        <div class="lines">
            <img src="/cjcc-assets/images/lines.png" alt="image overlay">
        </div>
    </div>
<asp:Literal runat="server" ID="litHeroBGClose"></asp:Literal>

<section class="accent-purple">
    <div class="container-wrapper">
        <div class="container col-sm-12">


            <!--Rich text Section with Title-->
            <!--Title-->
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


            <div class="row media-object-full">
                <div class="col-sm-12">


                    <asp:Repeater ID="rptStrategy" runat="server" OnItemDataBound="rptStrategy_ItemDataBound">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>

                            <div class="media">
                                <div class="media-left">
                                    <sc:Image ID="fldIcon" runat="server" Field="Icon" CssClass="media-object" />
                                </div>
                                <div class="media-body">
                                    <h3>
                                        <sc:Text ID="fldTitle" runat="server" Field="Title" />
                                    </h3>
                                    <sc:Text ID="fldContent" runat="server" Field="Content" />
                                </div>
                            </div>

                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>


                    <!--Strategy repeater-->

                </div>
            </div>
        </div>
    </div>

</section>
