VERSION 5.00
Object = "{34E74120-6D1A-4E42-A3DB-DD24B676A5DF}#1.0#0"; "mscoree.dll"
Begin VB.Form Form1 
   Caption         =   "vb6 binding js"
   ClientHeight    =   8076
   ClientLeft      =   108
   ClientTop       =   432
   ClientWidth     =   12456
   LinkTopic       =   "Form1"
   ScaleHeight     =   8076
   ScaleWidth      =   12456
   StartUpPosition =   3  'Windows Default
   Begin CefInteropControlCtl.CefUserControl CefUserControl1 
      Height          =   6852
      Left            =   360
      TabIndex        =   0
      Top             =   960
      Width           =   7212
      Object.Visible         =   "True"
      Enabled         =   "True"
      ForegroundColor =   "-2147483630"
      BackgroundColor =   "-2147483633"
      InitialZoomPercentage=   "100"
      ShowLoadingControl=   "True"
      BackColor       =   "Control"
      ForeColor       =   "ControlText"
      Location        =   "30, 80"
      Margin          =   "4, 4, 4, 4"
      Name            =   "CefUserControl"
      Size            =   "601, 571"
      Object.TabIndex        =   "0"
   End
   Begin VB.CommandButton btnNavigate 
      Caption         =   "Navigate"
      Height          =   372
      Left            =   6120
      TabIndex        =   6
      Top             =   240
      Width           =   972
   End
   Begin VB.TextBox TxtUrl 
      Height          =   408
      Left            =   240
      TabIndex        =   5
      Text            =   "https://cefsharp.github.io/"
      Top             =   240
      Width           =   5772
   End
   Begin VB.TextBox txtEventLog 
      Enabled         =   0   'False
      Height          =   3732
      Left            =   7800
      MultiLine       =   -1  'True
      TabIndex        =   4
      Top             =   4080
      Width           =   4452
   End
   Begin VB.Label Label3 
      Caption         =   "Event Log"
      Height          =   252
      Left            =   7800
      TabIndex        =   3
      Top             =   3720
      Width           =   4332
   End
   Begin VB.Label Label2 
      Caption         =   "Selected Text"
      Height          =   252
      Left            =   7680
      TabIndex        =   2
      Top             =   120
      Width           =   4572
   End
   Begin VB.Label Label1 
      Height          =   2892
      Left            =   7800
      TabIndex        =   1
      Top             =   480
      Width           =   4332
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub btnNavigate_Click()
    Me.CefUserControl1.Navigate (TxtUrl.text)
End Sub

Private Sub CefUserControl1_AddressChangedEvent(ByVal address As String)
    Rem MsgBox ("Address changed" & address)
    LogEvent "AddressChangedEvent", address
End Sub

Private Sub CefUserControl1_FrameLoadEndEvent()
    Rem MsgBox ("Main frame loadEndEvent")
    LogEvent "FrameLoadEndEvent", ""
End Sub

Private Sub CefUserControl1_JavascriptMessageReceivedEvent(ByVal message As String)
    Me.Label1.Caption = message
    LogEvent "JavascriptMessageReceivedEvent", ""
End Sub

Rem Por Sugerencia de CefSharp este evento es mas seguro de que se haya cargado el frame
Private Sub CefUserControl1_LoadingStateChangedEvent()
    LogEvent "LoadingStateChangedEvent", ""
    Me.CefUserControl1.ExecuteScript ("document.body.onmouseup = function(){" & vbCrLf & _
        "// se llama al evento de CefSharp que bindea con el metodo javascriptreceived " & vbCrLf & _
        "CefSharp.PostMessage(window.getSelection().toString());}")
End Sub

Private Sub Form_Load()
    Me.CefUserControl1.Navigate (TxtUrl.text)
End Sub

Private Sub LogEvent(event1 As String, text As String)
    If text = "" Then
        Me.txtEventLog.text = event1 & vbCrLf & Me.txtEventLog.text
    Else
        Me.txtEventLog.text = event1 & " -> " & text & vbCrLf & Me.txtEventLog.text
    End If
End Sub

