<%@ Page Language="C#" MasterPageFile="~/prove.master" AutoEventWireup="true" Inherits="Perfiles" Title="Administrar Perfiles" Codebehind="Perfiles.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <table width="100%" cellspacing="2">
        <tr>
            <td colspan="3" style="background-color: #e0e0e0;" align="center">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium"
                    ForeColor="Black" Text="Administración de Perfiles"></asp:Label></td>
        </tr>
       <tr>
            <td colspan="2" style="font-weight: bold; font-size: 8pt; font-family: Verdana; text-align: right; vertical-align: bottom; height: 19px;">
                Perfil:
                <asp:TextBox ID="txtPerfil" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                    Width="240px"></asp:TextBox>
                <asp:ImageButton ID="ibtnAgregarPerfil" runat="server" ImageUrl="~/images/Agregar.png" ToolTip="Agregar Perfil" Width="16px" OnClick="ibtnAgregarPerfil_Click" /></td>
            
            <td style="vertical-align: bottom; font-weight: bold; font-size: 8pt; font-family: Verdana; height: 19px;">
                <br />
                Menu:
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SDSddlMenu" DataTextField="Descripcion"
                    DataValueField="MenuId" Width="230px" Height="57px" Font-Names="Verdana" Font-Size="X-Small">
                </asp:DropDownList>
                <asp:ImageButton ID="ibtnAgregarMenu" runat="server" ImageUrl="~/images/Agregar.png" OnClick="ibtnAgregarMenu_Click" ToolTip="Agregar Menu" Width="16px" /></td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; text-align: right;" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="COD_PERFIL" DataSourceID="SDSPerfil" ForeColor="#333333" GridLines="None" Font-Names="Verdana" Font-Size="X-Small" Width="70%">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="COD_PERFIL" HeaderText="COD_PERFIL" ReadOnly="True" SortExpression="COD_PERFIL"
                            Visible="False" />
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="Perfil" SortExpression="DESCRIPCION" >
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" SelectImageUrl="~/images/Select.png" ButtonType="Image" />
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            
            <td style="vertical-align: top; width: 50%;">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="COD_PERFIL,MenuId" DataSourceID="SDSMenu" ForeColor="#333333" GridLines="None" Font-Names="Verdana" Font-Size="X-Small" Width="295px">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="COD_PERFIL" HeaderText="COD_PERFIL" SortExpression="COD_PERFIL" Visible="False" />
                        <asp:BoundField DataField="MenuId" HeaderText="MenuId" InsertVisible="False" ReadOnly="True"
                            SortExpression="MenuId" Visible="False" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Men&#250;" SortExpression="Descripcion" >
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PadreId" HeaderText="PadreId" SortExpression="PadreId" Visible="False" />
                        <asp:BoundField DataField="Posicion" HeaderText="Posicion" SortExpression="Posicion" Visible="False" />
                        <asp:BoundField DataField="Icono" HeaderText="Icono" SortExpression="Icono" Visible="False" />
                        <asp:CheckBoxField DataField="Habilitado" HeaderText="Habilitado" SortExpression="Habilitado" Visible="False" />
                        <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url" Visible="False" />
                        <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" ButtonType="Image" DeleteImageUrl="~/images/Delete.png" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:CommandField>
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            
            <td></td>
        </tr>
    </table>
     <asp:SqlDataSource ID="SDSPerfil" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
        SelectCommand="SELECT [COD_PERFIL], [DESCRIPCION] FROM [PERFIL] ORDER BY [DESCRIPCION]">
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SDSMenu" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
        SelectCommand="SELECT     MENU_PERFIL.COD_PERFIL AS COD_PERFIL, MENU.*&#13;&#10;FROM         MENU_PERFIL INNER JOIN&#13;&#10;                      MENU ON MENU_PERFIL.MenuId = MENU.MenuId&#13;&#10;WHERE COD_PERFIL=@COD_PERFIL&#13;&#10;ORDER BY MENU.Posicion" DeleteCommand="DELETE MENU_PERFIL WHERE COD_PERFIL=@COD_PERFIL AND MenuId=@MenuId">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="COD_PERFIL" PropertyName="SelectedValue" />
        </SelectParameters>
                    <DeleteParameters>
                        <asp:ControlParameter ControlID="GridView2" Name="COD_PERFIL" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="GridView2" Name="MenuId" PropertyName="SelectedValue" />
                    </DeleteParameters>
    </asp:SqlDataSource>
    &nbsp; &nbsp;
    <asp:SqlDataSource ID="SDSddlMenu" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
        SelectCommand="SELECT [MenuId], [Descripcion] FROM [MENU] ORDER BY [Descripcion]">
    </asp:SqlDataSource>
   
</asp:Content>

