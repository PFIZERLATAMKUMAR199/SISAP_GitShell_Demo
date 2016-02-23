<%@ Page Language="C#"  AutoEventWireup="true" Inherits="Login" Codebehind="Login.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Inicio de Sesión</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="Panel1" runat="server" Height="80%" Width="100%" HorizontalAlign=Center >
    <table Height="75" cellpadding=0 cellspacing=0 border=0 style="font-family:Verdana; font-size:small  ; background-color: white; width: 80%;">
    <tr>
    <td align=center style="height: 74px" >
        <img src="images/banner.png"  /></td>
    </tr>
</table>
     <table Height="40px" cellpadding=0 cellspacing=0 border=0 style="font-family:Verdana; font-size:small  ; background-color: white; width: 400px;">
        <tr>
        <td align=left style=" font-weight: bold; width: 300; color: Black; height: 40px; vertical-align: bottom; border-bottom: thin solid;"  >&nbsp;Inicio de Sesión&nbsp;</td>
        </tr>
    </table>
    <table Height="55px" cellpadding=0 cellspacing=0 border=0 style="font-family:Verdana; font-size:small  ; background-color: white; width: 400px;">
      
       <tr  Height="24px">
                <td align=left  style=" width: 200px;  color: #000099; height: 24px;">
                    &nbsp;Nombre de Usuario:</td>
                <td align=center  style="width: 200px; text-align: center; height: 24px;">                  
                    <asp:TextBox ID="txtUsuario" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                       Width="143px" MaxLength="20" BorderColor="SteelBlue" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>&nbsp;</td>    
       </tr>              
       <tr Height="24px" >
                <td align=left  style=" width: 200px;  color: #000099; height: 24px;">
                    &nbsp;Contraseña:</td>
                <td align=left  style="width: 200px; text-align: center; height: 24px;">                  
                    <asp:TextBox ID="txtClave" runat="server" Font-Names="Verdana" Font-Size="X-Small" Width="143px" MaxLength="25" TextMode="Password" BorderColor="SteelBlue" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>&nbsp;<a href="javascript:OpenCalendar('Calendario.aspx','txtFechaD', '201','177')"></a></td>
       </tr>
      </table>
      <table Height="40px" cellpadding=0 cellspacing=0 border=0 style="font-family:Verdana; font-size:small  ; background-color: white; width: 400px;">
        <tr>
        <td align=center style=" width: 50%;"  >
            &nbsp;</td>
        <td align=center style="width: 50%"  > <asp:ImageButton ID="ibtnLogin" runat="server" ImageUrl="Images\Login.png" OnClick="ibtnLogin_Click" /></td>
        </tr>
    </table>
        <asp:Label ID="lblError" runat="server" Font-Bold="False" Font-Names="Verdana" Font-Size="Small"
            ForeColor="Red"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario"
            Display="None" ErrorMessage="El Nombre de Usuario es requerido"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtClave"
            Display="None" ErrorMessage="La Contraseña es requerida"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
    </asp:Panel>
    </div>
    </form>
  
</body>
</html>
