VERSION 5.00
Object = "{34E74120-6D1A-4E42-A3DB-DD24B676A5DF}#1.0#0"; "CefInteropControl.tlb"
Begin VB.Form Form1 
   Caption         =   "vb6 binding js"
   ClientHeight    =   5136
   ClientLeft      =   108
   ClientTop       =   432
   ClientWidth     =   8880
   LinkTopic       =   "Form1"
   ScaleHeight     =   5136
   ScaleWidth      =   8880
   StartUpPosition =   3  'Windows Default
   Begin CefInteropControlCtl.CefUserControl CefUserControl1 
      Height          =   4692
      Left            =   360
      TabIndex        =   0
      Top             =   240
      Width           =   6132
      Object.Visible         =   "True"
      Enabled         =   "True"
      ForegroundColor =   "-2147483630"
      BackgroundColor =   "-2147483633"
      BackColor       =   "Control"
      ForeColor       =   "ControlText"
      Location        =   "30, 20"
      Margin          =   "4, 4, 4, 4"
      Name            =   "CefUserControl"
      Size            =   "511, 391"
      Object.TabIndex        =   "0"
   End
   Begin VB.Label Label2 
      Caption         =   "Selected Text"
      Height          =   492
      Left            =   6720
      TabIndex        =   2
      Top             =   120
      Width           =   1932
   End
   Begin VB.Label Label1 
      Height          =   2412
      Left            =   6720
      TabIndex        =   1
      Top             =   720
      Width           =   1932
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Private Sub CefUserControl1_FrameLoadEndEvent()
    MsgBox ("Main frame loaded")
    Me.CefUserControl1.ExecuteScript ("document.body.onmouseup = function(){" & vbCrLf & _
        "// se llama al evento de CefSharp que bindea con el metodo javascriptreceived " & vbCrLf & _
        "CefSharp.PostMessage(window.getSelection().toString());}")
End Sub

Private Sub CefUserControl1_JavascriptMessageReceivedEvent(ByVal message As String)
    Me.Label1.Caption = message
End Sub

Private Sub Form_Load()
    Me.CefUserControl1.Navigate ("https://ubuntu.com")
End Sub
