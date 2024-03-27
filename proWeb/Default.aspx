<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>        
        <h2>Products Management</h2>

        <p>Code <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>        

        <p>Name <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></p>        

        <p>Amount <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></p>

        <p>Category <asp:ListBox ID="ListBox1" runat="server" Height="24px" DataSourceID="Database" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
            <asp:SqlDataSource ID="Database" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Categories]"></asp:SqlDataSource>
        </p>        

        <p>Price <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></p>
       
        <p>Creation Date <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></p>        

        <p>
            <asp:Button ID="Button1" runat="server" Text="Create" />
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button2" runat="server" Text="Update" />
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button3" runat="server" Text="Delete" />
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button4" runat="server" Text="Read" />
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button5" runat="server" Text="Read first" />
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button6" runat="server" Text="Read Prev" />
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button7" runat="server" Text="Read Next" />

        </p>
    </div>
</asp:Content>
