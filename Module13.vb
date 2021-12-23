Imports System
Imports System.Runtime.Remoting
Module Module13

    Public Sub Main()
        Dim loformu As System.Windows.Forms.Form = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("sigafyc.frmFLoginAcceso")
        loformu.ShowDialog()
    End Sub

End Module
