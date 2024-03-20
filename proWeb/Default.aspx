<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>        
        <h2>Products Management</h2>

        <p>Code <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>        

        <p>Name <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></p>        

        <p>Amount <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></p>

        <p>Category <asp:ListBox ID="ListBox1" runat="server" Height="24px"></asp:ListBox></p>        

        <p>Price <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></p>
       
        <p>Creation Date <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></p>        
    </div>
</asp:Content>
