<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>        
        <h2>Products Management</h2>

        <p>Code <asp:TextBox ID="TextBox_code" runat="server"></asp:TextBox></p>        

        <p>Name <asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox></p>        

        <p>Amount <asp:TextBox ID="TextBox_amount" runat="server"></asp:TextBox></p>

        <p>Category <asp:ListBox ID="ListBox1" runat="server" Height="50px" DataSourceID="Database" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
            <asp:SqlDataSource ID="Database" runat="server" ConnectionString="<%$ ConnectionStrings:conexion %>" SelectCommand="SELECT * FROM [Categories]"></asp:SqlDataSource>
        </p>        

        <p>Price <asp:TextBox ID="TextBox_price" runat="server"></asp:TextBox></p>
       
        <p>Creation Date <asp:TextBox ID="TextBox_date" runat="server"></asp:TextBox></p>        

        <p>
            <asp:Button ID="Button_Create" runat="server" Text="Create" OnClick="create_click"/>
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button_Update" runat="server" Text="Update" OnClick="update_click" />
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button_Delete" runat="server" Text="Delete" OnClick="delete_click" />
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button_Read" runat="server" Text="Read" OnClick="read_click"/>
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button_ReadFirst" runat="server" Text="Read first" OnClick="read_first_click"/>
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button_ReadPrev" runat="server" Text="Read Prev" OnClick="read_prev_click"/>
            <span style="margin-right: 10px;"></span>

            <asp:Button ID="Button_ReadNext" runat="server" Text="Read Next" OnClick="read_next_click" />

        </p>
         <br />
          <b>
        <asp:Label ID="message" runat="server" Text=""></asp:Label>
            </b>
</asp:Content>
