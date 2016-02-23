Imports proveedor
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Partial Class prove


    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DT As System.Data.DataTable
        Dim Rw As DataRow

        If Not IsPostBack Then
            Dim tabla As New Procesar_proveedor(System.Configuration.ConfigurationManager.AppSettings("ConnectionString"))

            Try
                'DT = tabla.TraerTabla("sp_ObtenerOpcionesMenu '" & Session("Usuario") & "'")
                DT = tabla.TraerTabla("sp_ObtenerOpcionesMenu '" & Session("ADGroup") & "'")
                Session("TBMenu") = DT

                For Each Rw In DT.Rows
                    If Rw("MenuId").Equals(Rw("PadreId")) Then
                        If (Not (Rw("MenuId") = 5) And Not (Rw("MenuId") = 4)) Then
                            Dim mnuItem As New MenuItem
                            mnuItem.Value = Rw("MenuId").ToString()
                            mnuItem.Text = Rw("Descripcion").ToString()
                            mnuItem.NavigateUrl = Rw("Url").ToString()
                            mnuItem.ImageUrl = Rw("Icono").ToString()
                            Menu_Principal.Items.Add(mnuItem)
                            AddMenuItem(mnuItem, DT)
                        End If
                    End If
                Next

            Catch ex As Exception

            End Try


        End If


    End Sub

    Protected Sub AddMenuItem(ByVal mnuItem As MenuItem, ByVal DTMenuItem As DataTable)
        Dim Rw As DataRow

        For Each Rw In DTMenuItem.Rows
            If Rw("PadreId").ToString().Equals(mnuItem.Value) And Rw("MenuId").ToString().Equals(Rw("PadreId").ToString()) = False Then

                Dim mnuItemNew As New MenuItem

                mnuItemNew.Value = Rw("MenuId").ToString()
                mnuItemNew.Text = Rw("Descripcion").ToString()
                mnuItemNew.ImageUrl = Rw("Icono").ToString()
                mnuItemNew.NavigateUrl = Rw("Url").ToString()
                mnuItem.ChildItems.Add(mnuItemNew)

                AddMenuItem(mnuItemNew, DTMenuItem)

            End If
        Next


    End Sub
End Class

