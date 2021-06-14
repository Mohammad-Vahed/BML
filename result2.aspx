<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="result2.aspx.cs" Inherits="test1.result1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <style>
            .wide {
                min-width: 80%;
             }
        </style>
    <form id="form1" runat="server">
        <div>
            <h3>Result 1:</h3>
            <p><br />
    <asp:Chart ID="Chart2" runat="server" Width="900px" >
        
         <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas> 
         
    </asp:Chart>
        <br /></p>
            <p> 
                &nbsp;</p>
            <p> <br />
        <asp:Image ID="imgtext2" runat="server" Visible="false" BorderColor="#0000CC" Height="300px" Width="900px" />
                <br />
            </p>
            <p>
                <asp:TextBox ID="TextBox2" runat="server" Height="483px" TextMode="MultiLine" CssClass="wide" ReadOnly="True" Width="1583px"></asp:TextBox>
            </p>
        </div>
    </form>
</body>
</html>
