<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CJCCHomePage.ascx.cs" Inherits="Hennepin.SCWeb.CJCC.layouts.Hennepin_CJCC.CJCCHomePage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<section class="purple collapse-top collapse-bottom">
    <div class="container-wrapper">      
        <div class="">
            <asp:Literal runat="server" ID="litOpenVideoSpan"></asp:Literal>
                <div class="container-full vid-player-img">
                    <sc:Image runat="server" ID="imgHomeVideo" Field="Video Image" />
                </div>
            <asp:Literal runat="server" ID="litCloseVideoSpan"></asp:Literal>
            <section class="main-video">
                <div class="embed-responsive embed-responsive-16by9 .main-video-container">
                    <iframe id="ytplayer" type="text/html" src="" frameborder="0" allowfullscreen="1"></iframe>
			    </div>
            </section>
        </div> 
    </div> 
</section>
<section class="purple">
    <div class="container-wrapper text-column">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <!-- Next meeting information/rpt here -->
                    <h2>Next meeting</h2>
                    <div class="lead-text">
                        <p>
                            <asp:Literal Text="" runat="server" ID="litNextMeetingDate" />  | 
                            <asp:Literal Text="" runat="server" ID="litNextMeetingTime" />  |  
                            <asp:Literal Text="" runat="server" ID="litNextMeetingLocation" /> 
                        </p>
                    </div>
                    <div class="white-btn">
                        <asp:HyperLink ID="lnkNextMeetingAgenda" runat="server" Text="View agenda (PDF)"></asp:HyperLink>
                    </div>
                    <div class="outline-btn">
                       <asp:HyperLink ID="lnkNextMeetingMap" runat="server" Text="View map" Target="_blank"></asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<!-- Future meetings section-->
<div class="container-wrapper text-column"> 
    <div class="container">
        <div class="col-sm-12">
            <h2>Future meetings</h2>

            <ul class="meetings-list">

                <asp:Repeater runat="server" ID="rptFutureMeetings" OnItemDataBound="rptFutureMeetings_ItemDataBound">
                    <ItemTemplate> 
                        <li>
                            <asp:Literal Text="" runat="server" ID="litFutureMeetingDate" />  | 
                            <asp:Literal Text="" runat="server" ID="litFutureMeetingTime" />  |  
                            <asp:Literal Text="" runat="server" ID="litFutureMeetingLocation" /> 
                        </li>
                    </ItemTemplate>
                </asp:Repeater>

            </ul>

        </div>
    </div>
</div>