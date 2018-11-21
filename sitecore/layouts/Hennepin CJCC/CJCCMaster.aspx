<%@ Page language="c#" Codepage="65001" AutoEventWireup="true" Inherits="Hennepin.SCWeb.CJCC.CJCCMaster" CodeBehind="CJCCMaster.aspx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ OutputCache Location="None" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en" xml:lang="en" xmlns="http://www.w3.org/1999/xhtml">                  
  <head>
     <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="shortcut icon" href="/assets/favicon.ico" type="image/x-icon">
    <link rel="stylesheet" href="https://use.typekit.net/tex6jda.css">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="/cjcc-assets/css/main.css">
    <link rel="stylesheet" href="/cjcc-assets/css/cjcc.css">
    <title>Hennepin County | Criminal Justice Coordinating Committee</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

        
    <sc:VisitorIdentification runat="server" />
  </head>
  <body>
      <form method="post" runat="server" id="mainform">
            <!-- Navigation -->
            <div id="nav-wrapper">
                <div class="nav-purple">
                    <nav class="navbar navbar-default navbar-dark navbar-expand-xl">
                        <div class="d-flex flex-grow-1">
                            <a class="navbar-brand offset-lg-1 offset-xl-2" href="/cjcc">
                                <!-- Header template here -->
                                <sc:Text runat="server" ID="fldMasterTitle" Field="Title" />
                            </a>
                            <div class="w-100 text-right">
                                <button class="navbar-toggler collapsed" type="button" data-toggle="collapse" data-target="#main-nav" aria-controls="main-nav" aria-expanded="false" aria-label="Toggle navigation">
                                    <span class="toggle-button-text">Menu</span>
                                    <span class="sr-only">Toggle navigation</span>
                                    <span class="icon-bar top-bar"></span>
                                    <span class="icon-bar middle-bar"></span>
                                    <span class="icon-bar bottom-bar"></span>
                                </button>
                            </div>
                        </div>

                        <!-- Navigation repeater -->

                        <div class="collapse navbar-collapse flex-grow-1 text-right" id="main-nav">
                            <ul class="navbar-nav ml-auto flex-nowrap">

                                  <asp:Repeater ID="rptNav" runat="server" OnItemDataBound="rptNav_ItemDataBound">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li class="nav-item">
                                            <asp:HyperLink runat="server" ID="fldNavLink" CssClass="nav-link m-2 menu-item">
                                                <sc:Text ID="fldNavTitle" runat="server" Field="Page Title" />
                                            </asp:HyperLink>
                                        </li>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                                
                            </ul>
                        </div>


                    </nav>
                </div>
            </div>

          <sc:placeholder ID="phContent" runat="server" key="phContent"></sc:placeholder>

        <footer>
            <div class="container-wrapper">
                <div class="container">
                    <div class="col-sm-12">
                        <div class="pull-sm-left">

                            <sc:Text runat="server" ID="txtFooterLeft" Field="Left Content" />
                            
                        </div>
                        <div class="pull-sm-right footer-standard-info">
                            <!-- Footer template here -->
                            <sc:Text runat="server" ID="txtFooterRight" Field="Right Content" />
                            <p>© <script>document.write(new Date().getFullYear());</script> Hennepin County, Minnesota</p>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>


      </form>
  </body>
</html>
