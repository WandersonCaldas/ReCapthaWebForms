
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub


    Protected Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        If (capValidate()) Then
            ClientScript.RegisterStartupScript(Me.GetType, "erro", "<script language='javascript'>alert('SUCESSO');</script>")
        Else
            ClientScript.RegisterStartupScript(Me.GetType, "erro", "<script language='javascript'>alert('FALHA');</script>")
        End If
    End Sub

    Public Function capValidate() As Boolean
        Dim Response As String = Request("g-recaptcha-response")
        Dim Valid As Boolean = False
        Dim req As HttpWebRequest = DirectCast(WebRequest.Create(Convert.ToString("https://www.google.com/recaptcha/api/siteverify?secret=CHAVE_SECRETA&response=") & Response), HttpWebRequest)
        Try
            Using wResponse As WebResponse = req.GetResponse()

                Using readStream As New StreamReader(wResponse.GetResponseStream())
                    Dim jsonResponse As String = readStream.ReadToEnd()
                    Dim js As New JavaScriptSerializer()
                    Dim data As MyObject = js.Deserialize(Of MyObject)(jsonResponse)

                    Valid = Convert.ToBoolean(data.success)
                    Return Valid
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class

Public Class MyObject
    Public Property success() As String
        Get
            Return m_success
        End Get
        Set(value As String)
            m_success = value
        End Set
    End Property
    Private m_success As String

End Class
