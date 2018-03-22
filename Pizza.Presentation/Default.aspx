<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pizza.Presentation.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-1">

                </div>
                <div class="col-md-10 text-center">
                    <h1 class="">Staffans Pizzeria!</h1>
                </div>
                <div class="col-md-1">

                </div>
            </div>
            <div class="row">
                <div class="col-md-3">

                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="sizesDropDownList" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:DropDownList ID="crustDropDownList" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:CheckBoxList ID="ingredientsCheckBox" AutoPostBack="true" runat="server"></asp:CheckBoxList>
                     <asp:Label ID="resultLabel" runat="server"></asp:Label><br />
                    <asp:Button ID="orderButton" runat="server" Text="Order" CssClass="btn btn-info btn-block" OnClick="orderButton_Click" />
                </div>
                <div class="col-md-3">

                </div>
            </div>
            <div class="row">
                <div class="col-md-2">

                </div>
                <div class="col-md-8">
                    <h2 class="text-center">Add new customer</h2>
                    Name: <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />
                    Address: <asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />
                    Postal Code: <asp:TextBox ID="postalTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />
                    Phone: <asp:TextBox ID="phoneTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />
                    <asp:Button ID="addCustomer" runat="server" Text="Add customer" CssClass="btn btn-block btn-primary" OnClick="addCustomer_Click" /><br />
                    <asp:Label ID="customerLabel" runat="server"></asp:Label>
                </div>
                <div class="col-md-2">

                </div>
            </div>
            <div class="row">
                
                <div class="col-md-2">

                </div>
                <div class="col-md-8">
                    <h2 class="text-center">Current Customers</h2>
                    <asp:DropDownList ID="customerDropDown" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-2">

                </div>
            </div>
        </div>
    </form>
</body>
</html>
