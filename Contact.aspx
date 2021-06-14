<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="test1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Chiba University</h2>
    <h3>Contact:</h3>
    <address>
        Medical Mycology Research Center(MMRC), Chiba University</address>
    <address>
        1-8-1 Inohana, Chuo-ku, Chiba, Japan</address>
    <address>
     <table id="tableContent" border="1" runat="server"></table>
        &nbsp;Postal-code:260-8673</address>
    <address>
        TEL:+81-43-222-7171</address>
    <address>
        FAX:+81-43-226-2486</address>
    <address>
        &nbsp;</address>
    
    <address>
        <asp:Button ID="btnconvert" runat="server" Text="Button" OnClick="Button1_Click" />
        <style>
            .wide {
                width: 100%;
                min-width: 100%;
             }
        </style>
                <asp:TextBox ID="txttext" runat="server" Font-Size="Large" Height="42px" CssClass="wide">A</asp:TextBox>
           
            <hr />
       
        <asp:TextBox ID="TextBox1" runat="server" Height="92px" TextMode="MultiLine" Width="242px"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Height="95px" TextMode="MultiLine" Width="251px"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" Height="99px" TextMode="MultiLine" Width="219px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
        <asp:Button ID="Button3" runat="server" Text="chart" OnClick="Button3_Click" />
    <br />
    <asp:Chart ID="Chart1" runat="server" Width="600px" >
    
         <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas> 
  
    </asp:Chart>
        <br />
        <asp:Image ID="imgtext" runat="server" Visible="false" BorderColor="#0000CC" Height="300px" Width="900px" />
    </address>
    <address>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </address>
    <address>
        &nbsp;</address>
    <address>
        &nbsp;</address>
    
    <div>
        <asp:Table ID="tb1" runat="server" Height="114" Width="439" BackColor=Aqua>
         
        </asp:Table>
    </div>
        
    <address>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
