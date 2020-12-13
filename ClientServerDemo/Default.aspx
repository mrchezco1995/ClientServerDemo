<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClientServerDemo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Simple Client-Server Design Demo</h1>
        <p class="lead">An ASP.NET WebApp demo by Renz Hernandez and Shandee Abegonia</p>
    </div>

    <div class="container">
    <div class="row">
      <div class="col-25">
        <label for="txtFirstName">First Name</label>
      </div>
      <div class="col-75">
        <asp:textbox runat="server" type="text" id="txtFirstName" name="firstname" placeholder="Your name.." required="required"/>
      </div>
    </div>
    <div class="row">
      <div class="col-25">
        <label for="txtLastName">Last Name</label>
      </div>
      <div class="col-75">
        <asp:textbox runat="server" type="text" id="txtLastName" name="lastname" placeholder="Your last name.." required="required"/>
      </div>
    </div>
    <div class="row">
      <div class="col-25">
        <label for="txtMessage">Your Message</label>
      </div>
      <div class="col-75">
        <asp:textbox runat="server" id="txtMessage" name="Message" placeholder="Write something..." style="height:200px" TextMode="MultiLine" required="required"/>
      </div>
    </div>
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
    </div>
    </div>

    <hr />

    <div class="container">
        <h1>Messages</h1>
        <asp:Literal runat="server" ID="litMessages" />
    </div>

</asp:Content>
