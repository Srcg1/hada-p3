<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proweb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Products Managment</h2>

    <asp:Label ID="codeLabel" runat="server" Text="Code"></asp:Label>  
    <asp:TextBox ID="codeTextBox" runat="server"></asp:TextBox> 
    
    <br />
    <asp:Label ID="nameLabel" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
    
    <br />
    <asp:Label ID="amountLabel" runat="server" Text="Amount"></asp:Label>
    <asp:TextBox ID="amountTextBox" runat="server" TextMode="Number"></asp:TextBox>
    
    <br />
    <asp:Label ID="categoryLabel" runat="server" Text="Category"></asp:Label>
    <asp:TextBox ID="categoryTextBox" runat="server"></asp:TextBox>
    
    <br />
    <asp:Label ID="priceLabel" runat="server" Text="Price"></asp:Label>
    <asp:TextBox ID="priceTextBox" runat="server" TextMode="Number"></asp:TextBox>
    
    <br /> <br />
    <asp:Button ID="crear_btn" runat="server" Text="Crear" OnClick="crear_btn_Click" />
    <asp:Button ID="Leer_btn" runat="server" Text="Leer" OnClick="Leer_btn_Click" />

</asp:Content>
