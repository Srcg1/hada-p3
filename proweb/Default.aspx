<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proweb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* CSS para alinear el formulario como en la imagen */
        .form-row { margin-bottom: 15px; }
        .form-row label { 
            display: inline-block; 
            width: 120px; /* Fija el ancho para que los inputs se alineen */
            font-size: 16px;
        }
        .button-row { 
            margin-top: 25px; 
            display: flex; 
            gap: 10px; /* Espaciado entre los botones */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Products management</h2>

    <div class="form-row">
        <asp:Label ID="codeLabel" runat="server" Text="Code"></asp:Label>  
        <asp:TextBox ID="codeTextBox" runat="server"></asp:TextBox> 
    </div>
    
    <div class="form-row">
        <asp:Label ID="nameLabel" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
    </div>
    
    <div class="form-row">
        <asp:Label ID="amountLabel" runat="server" Text="Amount"></asp:Label>
        <asp:TextBox ID="amountTextBox" runat="server" TextMode="Number"></asp:TextBox>
    </div>
    
    <div class="form-row">
        <asp:Label ID="categoryLabel" runat="server" Text="Category"></asp:Label>
        <asp:DropDownList ID="categoryDropDown" runat="server">
            <asp:ListItem Value="0" Text="Computing"></asp:ListItem>
            <asp:ListItem Value="1" Text="Telephony"></asp:ListItem>
            <asp:ListItem Value="2" Text="Gaming"></asp:ListItem>
            <asp:ListItem Value="3" Text="Home appliances"></asp:ListItem>
        </asp:DropDownList>
    </div>
    
    <div class="form-row">
        <asp:Label ID="priceLabel" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="priceTextBox" runat="server" TextMode="Number" step="0.01"></asp:TextBox>
    </div>

    <div class="form-row">
        <asp:Label ID="creationDateLabel" runat="server" Text="Creation Date"></asp:Label>
        <asp:TextBox ID="creationDateTextBox" runat="server"></asp:TextBox>
    </div>
    
    <div class="button-row">
        <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"/>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"/>
        <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click"/>
        <asp:Button ID="btnReadFirst" runat="server" Text="Read First" OnClick="btnFirst_Click"/>
        <asp:Button ID="btnReadPrev" runat="server" Text="Read Prev" OnClick="btnNext_Click"/>
        <asp:Button ID="btnReadNext" runat="server" Text="Read Next" OnClick="btnPrev_Click"/>
    </div>

    <br />
    <asp:Label ID="statusLabel" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>

</asp:Content>