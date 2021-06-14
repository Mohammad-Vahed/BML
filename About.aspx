<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="test1.About" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>Data Submission Form</h2>
    <p>Perform motif discovery on DNA.</p>
    <h3>Settings</h3>
    <p>Choose the Data Format:<asp:RadioButtonList ID="radRiskLevel" runat="server" RepeatDirection="Horizontal">
     <asp:ListItem Value="1" Selected="True">Fasta Format &nbsp;</asp:ListItem>
     <asp:ListItem Value="2">Text Format</asp:ListItem>
     </asp:RadioButtonList>
    </p>
    <style>
            .wide {
                width: 80%;
                min-width: 80%;
             }
        </style>
    <h3>Input Sequence Data:</h3>
    <p>
        <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" Height="200px" CssClass="wide"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;</p>
    <p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        Choose Analysis Methode:<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" >
     <asp:ListItem Value="1" Selected="True">Mono-Nucleotide &nbsp;</asp:ListItem>
     <asp:ListItem Value="2">DI-Nucleotide &nbsp;</asp:ListItem>
            <asp:ListItem Value="3">Machine Learning</asp:ListItem>
     </asp:RadioButtonList>
        
        <asp:CheckBox ID="CheckBox2" runat="server"  Text="Just Show Web logo" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged1" />
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC0066" Text="If you choose this, you cannot access to program parameters" Visible="False"></asp:Label>
    </p>
    Do you want more degenerate sites?
    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" >
     <asp:ListItem Value="1">Yes</asp:ListItem>
     <asp:ListItem Value="2" Selected="True">No</asp:ListItem>
     </asp:RadioButtonList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<p>Left Motif Length:&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="40px">
        <asp:ListItem Value="1"></asp:ListItem>
        <asp:ListItem Value="2"></asp:ListItem>
        <asp:ListItem Value="3"></asp:ListItem>
        <asp:ListItem Value="4"></asp:ListItem>
        <asp:ListItem Value="5"></asp:ListItem>
        <asp:ListItem Value="6"></asp:ListItem>
        <asp:ListItem Value="7"></asp:ListItem>
        <asp:ListItem Value="8"></asp:ListItem>
        <asp:ListItem Value="9"></asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Right Motif Length:&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server" Width="40px">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
    <p>Minimum Gap: &nbsp;&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="DropDownList3" runat="server" Height="21px" Width="40px">
        <asp:ListItem Value="0"></asp:ListItem>
        <asp:ListItem Value="1"></asp:ListItem>
        <asp:ListItem Value="2"></asp:ListItem>
        <asp:ListItem Value="3"></asp:ListItem>
        <asp:ListItem Value="4"></asp:ListItem>
        <asp:ListItem Value="5"></asp:ListItem>
        <asp:ListItem Value="6"></asp:ListItem>
        <asp:ListItem Value="7"></asp:ListItem>
        <asp:ListItem Value="8"></asp:ListItem>
        <asp:ListItem Value="9"></asp:ListItem>
        <asp:ListItem Value="10"></asp:ListItem>
        <asp:ListItem Value="11"></asp:ListItem>
        <asp:ListItem Value="12"></asp:ListItem>
        <asp:ListItem Value="13"></asp:ListItem>
        <asp:ListItem Value="14"></asp:ListItem>
        <asp:ListItem Value="15"></asp:ListItem>
        <asp:ListItem Value="16"></asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Maximum Gap:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList4" runat="server" Width="40px">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
            <asp:ListItem Value="10"></asp:ListItem>
            <asp:ListItem Value="11"></asp:ListItem>
            <asp:ListItem Value="12"></asp:ListItem>
            <asp:ListItem Value="13"></asp:ListItem>
            <asp:ListItem Value="14"></asp:ListItem>
            <asp:ListItem Value="15"></asp:ListItem>
            <asp:ListItem Value="16"></asp:ListItem>
            <asp:ListItem Value="17"></asp:ListItem>
            <asp:ListItem Value="18"></asp:ListItem>
            <asp:ListItem Value="19"></asp:ListItem>
            <asp:ListItem Value="20"></asp:ListItem>
            <asp:ListItem Value="21"></asp:ListItem>
            <asp:ListItem Value="22"></asp:ListItem>
            <asp:ListItem Value="23"></asp:ListItem>
            <asp:ListItem Value="24"></asp:ListItem>
            <asp:ListItem Value="25"></asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>Number of time trying to repeat process
        <asp:DropDownList ID="DropDownList5" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem Selected="True">30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
            <asp:ListItem>32</asp:ListItem>
            <asp:ListItem>33</asp:ListItem>
            <asp:ListItem>34</asp:ListItem>
            <asp:ListItem>35</asp:ListItem>
            <asp:ListItem>36</asp:ListItem>
            <asp:ListItem>35</asp:ListItem>
            <asp:ListItem>38</asp:ListItem>
            <asp:ListItem>39</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>41</asp:ListItem>
            <asp:ListItem>42</asp:ListItem>
            <asp:ListItem>43</asp:ListItem>
            <asp:ListItem>44</asp:ListItem>
            <asp:ListItem>45</asp:ListItem>
            <asp:ListItem>46</asp:ListItem>
            <asp:ListItem>47</asp:ListItem>
            <asp:ListItem>48</asp:ListItem>
            <asp:ListItem>49</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>Can motif sites be on both stands?
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Search given stand only"  />
    </p>
    <p>&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Run" Width="85px" />
    </p>
    <p>
        
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
        <asp:Button ID="Button5" runat="server"  Text="Machine Learning" />
    </p>
    <p><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" ItemStyle-Width="30" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Count1" HeaderText="Count1" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Count2" HeaderText="Count2" ItemStyle-Width="150" />
                </Columns>
            </asp:GridView>
        <br />
        <br/>

        <asp:Chart ID="ChartBar" runat="server" Width="800px" BackColor="#FFFFCC" Palette="BrightPastel"
                BorderWidth="2" BorderColor="#cc9900">
                <Legends>
                    <asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
                    </asp:Legend>
                </Legends>
                <Series>
                        <asp:Series Name="Series1" BorderColor="180, 26, 59, 105">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <br />
        
        &nbsp;</p>
    <p>
        <a runat="server" href="~/result1.aspx">Show result</a>
    </p>
    <p>output<asp:TextBox ID="TextBox5" runat="server" Height="115px" TextMode="MultiLine" Width="665px"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button-help" />
    </p>
    <p>
        <asp:TextBox TextMode="MultiLine" ID="TextBox2" runat="server" Height="116px" Width="388px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Height="116px" TextMode="MultiLine" Width="548px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="TextBox4" runat="server" Height="102px" TextMode="MultiLine" Width="684px"></asp:TextBox>
    </p>
    <p>
       
    </p>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>
