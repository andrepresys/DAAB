Option Explicit On 
Option Strict On

' Data Access Application Block Quick Start Samples.
' Please run CreateStoredProcedures.sql in SQL Query Analyzer
' to create database objects used by these examples.
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Text

Public Class FormDbHelper
    Inherits System.Windows.Forms.Form

    Private m_dbHelper As IDBHelper

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdSample6 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConnectionString As System.Windows.Forms.TextBox
    Friend WithEvents cmdSample5 As System.Windows.Forms.Button
    Friend WithEvents cmdSample4 As System.Windows.Forms.Button
    Friend WithEvents cmdSample3 As System.Windows.Forms.Button
    Friend WithEvents cmdSample2 As System.Windows.Forms.Button
    Friend WithEvents cmdClearResults As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtResults As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdSample1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents optSqlClient As System.Windows.Forms.RadioButton
    Friend WithEvents optOLEDB As System.Windows.Forms.RadioButton
    Friend WithEvents optODBC As System.Windows.Forms.RadioButton
    Friend WithEvents cmdDatsetUpdateCommandBuilder As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateNoCommandBuilder As System.Windows.Forms.Button
    Friend WithEvents cmdNoCommandBuilderTransaction As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateCommandBuilderTransaction As System.Windows.Forms.Button
    Friend WithEvents cmdNoCommandBuilderSP As System.Windows.Forms.Button
    Friend WithEvents cmdNoCommandBuilderSPTrans As System.Windows.Forms.Button
    Friend WithEvents cmdTestOracle As System.Windows.Forms.Button
    Private m_UseStoredPorcedure As Boolean = False

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.cmdSample6 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtConnectionString = New System.Windows.Forms.TextBox
        Me.cmdSample5 = New System.Windows.Forms.Button
        Me.cmdSample4 = New System.Windows.Forms.Button
        Me.cmdSample3 = New System.Windows.Forms.Button
        Me.cmdSample2 = New System.Windows.Forms.Button
        Me.cmdClearResults = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtResults = New System.Windows.Forms.RichTextBox
        Me.cmdSample1 = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.optSqlClient = New System.Windows.Forms.RadioButton
        Me.optOLEDB = New System.Windows.Forms.RadioButton
        Me.optODBC = New System.Windows.Forms.RadioButton
        Me.cmdDatsetUpdateCommandBuilder = New System.Windows.Forms.Button
        Me.cmdUpdateNoCommandBuilder = New System.Windows.Forms.Button
        Me.cmdNoCommandBuilderTransaction = New System.Windows.Forms.Button
        Me.cmdUpdateCommandBuilderTransaction = New System.Windows.Forms.Button
        Me.cmdNoCommandBuilderSP = New System.Windows.Forms.Button
        Me.cmdNoCommandBuilderSPTrans = New System.Windows.Forms.Button
        Me.cmdTestOracle = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdSample6
        '
        Me.cmdSample6.Location = New System.Drawing.Point(16, 264)
        Me.cmdSample6.Name = "cmdSample6"
        Me.cmdSample6.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample6.TabIndex = 32
        Me.cmdSample6.Text = "Retrieve XML Data"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(272, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Connection String"
        '
        'txtConnectionString
        '
        Me.txtConnectionString.Location = New System.Drawing.Point(272, 32)
        Me.txtConnectionString.Name = "txtConnectionString"
        Me.txtConnectionString.Size = New System.Drawing.Size(480, 20)
        Me.txtConnectionString.TabIndex = 30
        Me.txtConnectionString.Text = "Server=(local);Database=Northwind;User ID=sa;Password=;"
        '
        'cmdSample5
        '
        Me.cmdSample5.Location = New System.Drawing.Point(16, 216)
        Me.cmdSample5.Name = "cmdSample5"
        Me.cmdSample5.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample5.TabIndex = 29
        Me.cmdSample5.Text = "Perform Transactional Update"
        '
        'cmdSample4
        '
        Me.cmdSample4.Location = New System.Drawing.Point(16, 168)
        Me.cmdSample4.Name = "cmdSample4"
        Me.cmdSample4.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample4.TabIndex = 28
        Me.cmdSample4.Text = "Look Up Single Item"
        '
        'cmdSample3
        '
        Me.cmdSample3.Location = New System.Drawing.Point(16, 120)
        Me.cmdSample3.Name = "cmdSample3"
        Me.cmdSample3.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample3.TabIndex = 27
        Me.cmdSample3.Text = "Retrieve Single Row"
        '
        'cmdSample2
        '
        Me.cmdSample2.Location = New System.Drawing.Point(16, 72)
        Me.cmdSample2.Name = "cmdSample2"
        Me.cmdSample2.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample2.TabIndex = 26
        Me.cmdSample2.Text = "Retrieve Multiple Rows using DataSet"
        '
        'cmdClearResults
        '
        Me.cmdClearResults.Location = New System.Drawing.Point(16, 312)
        Me.cmdClearResults.Name = "cmdClearResults"
        Me.cmdClearResults.Size = New System.Drawing.Size(224, 32)
        Me.cmdClearResults.TabIndex = 25
        Me.cmdClearResults.Text = "Clear Results"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(272, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Results"
        '
        'txtResults
        '
        Me.txtResults.Location = New System.Drawing.Point(272, 112)
        Me.txtResults.Name = "txtResults"
        Me.txtResults.Size = New System.Drawing.Size(480, 256)
        Me.txtResults.TabIndex = 23
        Me.txtResults.Text = ""
        '
        'cmdSample1
        '
        Me.cmdSample1.Location = New System.Drawing.Point(16, 24)
        Me.cmdSample1.Name = "cmdSample1"
        Me.cmdSample1.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample1.TabIndex = 22
        Me.cmdSample1.Text = "Retrieve Multiple Rows using DataReader"
        '
        'optSqlClient
        '
        Me.optSqlClient.Checked = True
        Me.optSqlClient.Location = New System.Drawing.Point(272, 64)
        Me.optSqlClient.Name = "optSqlClient"
        Me.optSqlClient.Size = New System.Drawing.Size(104, 16)
        Me.optSqlClient.TabIndex = 33
        Me.optSqlClient.TabStop = True
        Me.optSqlClient.Text = "SQLClient"
        '
        'optOLEDB
        '
        Me.optOLEDB.Location = New System.Drawing.Point(384, 64)
        Me.optOLEDB.Name = "optOLEDB"
        Me.optOLEDB.Size = New System.Drawing.Size(104, 16)
        Me.optOLEDB.TabIndex = 34
        Me.optOLEDB.Text = "OLE_DB"
        '
        'optODBC
        '
        Me.optODBC.Location = New System.Drawing.Point(496, 64)
        Me.optODBC.Name = "optODBC"
        Me.optODBC.Size = New System.Drawing.Size(104, 16)
        Me.optODBC.TabIndex = 35
        Me.optODBC.Text = "ODBC"
        '
        'cmdDatsetUpdateCommandBuilder
        '
        Me.cmdDatsetUpdateCommandBuilder.Location = New System.Drawing.Point(16, 368)
        Me.cmdDatsetUpdateCommandBuilder.Name = "cmdDatsetUpdateCommandBuilder"
        Me.cmdDatsetUpdateCommandBuilder.Size = New System.Drawing.Size(224, 24)
        Me.cmdDatsetUpdateCommandBuilder.TabIndex = 36
        Me.cmdDatsetUpdateCommandBuilder.Text = "Dataset Update CommandBuilder"
        '
        'cmdUpdateNoCommandBuilder
        '
        Me.cmdUpdateNoCommandBuilder.Location = New System.Drawing.Point(16, 432)
        Me.cmdUpdateNoCommandBuilder.Name = "cmdUpdateNoCommandBuilder"
        Me.cmdUpdateNoCommandBuilder.Size = New System.Drawing.Size(224, 24)
        Me.cmdUpdateNoCommandBuilder.TabIndex = 37
        Me.cmdUpdateNoCommandBuilder.Text = "Dataset Update No CommandBuilder"
        '
        'cmdNoCommandBuilderTransaction
        '
        Me.cmdNoCommandBuilderTransaction.Location = New System.Drawing.Point(272, 376)
        Me.cmdNoCommandBuilderTransaction.Name = "cmdNoCommandBuilderTransaction"
        Me.cmdNoCommandBuilderTransaction.Size = New System.Drawing.Size(296, 24)
        Me.cmdNoCommandBuilderTransaction.TabIndex = 38
        Me.cmdNoCommandBuilderTransaction.Text = "Dataset Update No CommandBuilder Transactional"
        '
        'cmdUpdateCommandBuilderTransaction
        '
        Me.cmdUpdateCommandBuilderTransaction.Location = New System.Drawing.Point(16, 400)
        Me.cmdUpdateCommandBuilderTransaction.Name = "cmdUpdateCommandBuilderTransaction"
        Me.cmdUpdateCommandBuilderTransaction.Size = New System.Drawing.Size(224, 24)
        Me.cmdUpdateCommandBuilderTransaction.TabIndex = 39
        Me.cmdUpdateCommandBuilderTransaction.Text = "Dataset Update CommandBuilder Trans."
        '
        'cmdNoCommandBuilderSP
        '
        Me.cmdNoCommandBuilderSP.Location = New System.Drawing.Point(272, 404)
        Me.cmdNoCommandBuilderSP.Name = "cmdNoCommandBuilderSP"
        Me.cmdNoCommandBuilderSP.Size = New System.Drawing.Size(296, 24)
        Me.cmdNoCommandBuilderSP.TabIndex = 40
        Me.cmdNoCommandBuilderSP.Text = "Dataset Update No CommandBuilder Stored Procedure"
        '
        'cmdNoCommandBuilderSPTrans
        '
        Me.cmdNoCommandBuilderSPTrans.Location = New System.Drawing.Point(272, 432)
        Me.cmdNoCommandBuilderSPTrans.Name = "cmdNoCommandBuilderSPTrans"
        Me.cmdNoCommandBuilderSPTrans.Size = New System.Drawing.Size(296, 24)
        Me.cmdNoCommandBuilderSPTrans.TabIndex = 41
        Me.cmdNoCommandBuilderSPTrans.Text = "Dataset Update No CommandBuilder SP Trans"
        '
        'cmdTestOracle
        '
        Me.cmdTestOracle.Location = New System.Drawing.Point(616, 64)
        Me.cmdTestOracle.Name = "cmdTestOracle"
        Me.cmdTestOracle.Size = New System.Drawing.Size(136, 24)
        Me.cmdTestOracle.TabIndex = 42
        Me.cmdTestOracle.Text = "Teste Oracle"
        '
        'FormDbHelper
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(776, 461)
        Me.Controls.Add(Me.cmdTestOracle)
        Me.Controls.Add(Me.cmdNoCommandBuilderSPTrans)
        Me.Controls.Add(Me.cmdNoCommandBuilderSP)
        Me.Controls.Add(Me.cmdUpdateCommandBuilderTransaction)
        Me.Controls.Add(Me.cmdNoCommandBuilderTransaction)
        Me.Controls.Add(Me.cmdUpdateNoCommandBuilder)
        Me.Controls.Add(Me.cmdDatsetUpdateCommandBuilder)
        Me.Controls.Add(Me.optODBC)
        Me.Controls.Add(Me.optOLEDB)
        Me.Controls.Add(Me.optSqlClient)
        Me.Controls.Add(Me.cmdSample6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtConnectionString)
        Me.Controls.Add(Me.cmdSample5)
        Me.Controls.Add(Me.cmdSample4)
        Me.Controls.Add(Me.cmdSample3)
        Me.Controls.Add(Me.cmdSample2)
        Me.Controls.Add(Me.cmdClearResults)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtResults)
        Me.Controls.Add(Me.cmdSample1)
        Me.Name = "FormDbHelper"
        Me.Text = "Data Access Application Block for .NET QuickStart Samples (VB)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Add tooltips to command buttons
        ToolTip.SetToolTip(cmdSample1, "Retrieving Multiple Rows Using a SqlDataReader")
        ToolTip.SetToolTip(cmdSample2, "Retrieving Multiple Rows Using a DataSet")
        ToolTip.SetToolTip(cmdSample3, "Retrieving a Single Row")
        ToolTip.SetToolTip(cmdSample4, "Looking Up a Single Item")
        ToolTip.SetToolTip(cmdSample5, "Performing Transactional Updates")
        ToolTip.SetToolTip(cmdSample6, "Retrieving XML Data")

        m_dbHelper = New SqlDbHelper()

        optOLEDB.Checked = True
        optOLEDB.PerformClick()

    End Sub

    Private Sub cmdClearResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearResults.Click
        txtResults.Clear()
    End Sub

    Private Sub cmdSample1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample1.Click
        ' SqlDataReader that will hold the returned results		
        Dim dr As IDataReader

        ' Call ExecuteReader static method of SqlHelper class that returns a SqlDataReader
        ' We pass in database connection string, stored procedure name and value of categoryID parameterand, and a "1" for CategoryID value

        If m_UseStoredPorcedure Then
            dr = m_dbHelper.ExecuteReader(txtConnectionString.Text, "getProductsByCategory", 1)
        Else
            Dim sql As New StringBuilder

            sql.AppendLine("SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice")
            sql.AppendLine("FROM Products")
            sql.AppendLine("WHERE CategoryID = @CategoryID")
            Dim param = m_dbHelper.NewParameter("@CategoryID", 1)

            Dim connection = m_dbHelper.NewConnection(txtConnectionString.Text)

            dr = m_dbHelper.ExecuteReader(connection, CommandType.Text, sql.ToString(), param)

        End If




        ' display results in textbox on the form.
        txtResults.Clear()

        ' iterate through SqlDataReader
        While dr.Read()
            ' get the value of second column in the datareader (product description)
            txtResults.Text = txtResults.Text + CStr(dr.GetValue(1)) + Environment.NewLine
        End While
    End Sub

    Private Sub cmdSample2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample2.Click
        ' DataSet that will hold the returned results
        Dim ds As DataSet

        ' Call ExecuteDataset static method of SqlHelper class that returns a Dataset
        ' We pass in database connection string, command type, stored procedure name and a "1" for CategoryID SqlParameter value 
        If m_UseStoredPorcedure Then
            ds = m_dbHelper.ExecuteDataset(txtConnectionString.Text, CommandType.StoredProcedure, "getProductsByCategory", m_dbHelper.NewParameter("@CategoryID", 1))
        Else
            Dim sql As New StringBuilder

            sql.AppendLine("SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice")
            sql.AppendLine("FROM Products")
            sql.AppendLine("WHERE CategoryID = @CategoryID")
            Dim param = m_dbHelper.NewParameter("@CategoryID", 1)

            Dim connection = m_dbHelper.NewConnection(txtConnectionString.Text)
            connection.Open()

            ds = m_dbHelper.ExecuteDataset(connection, CommandType.Text, sql.ToString(), param)

        End If




        ' Get XML representation of the dataset and display results in text box
        txtResults.Clear()
        txtResults.Text = ds.GetXml()

    End Sub

    Private Sub cmdSample3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample3.Click

        ' Set up parameters (1 input and 3 output) 

        Dim arParms(3) As IDataParameter


        ' @ProductID Input Parameter 
        ' assign a "1" for ProductID parameter value
        arParms(0) = m_dbHelper.NewParameter("@ProductID", DbType.Int32)
        arParms(0).Value = 1

        ' @ProductName Output Parameter
        arParms(1) = m_dbHelper.NewParameter("@ProductName", DbType.String, 40)
        arParms(1).Direction = ParameterDirection.Output

        ' @UnitPrice Output Parameter
        arParms(2) = m_dbHelper.NewParameter("@UnitPrice", DbType.Currency)
        arParms(2).Direction = ParameterDirection.Output

        ' @QtyPerUnit Output Parameter
        arParms(3) = m_dbHelper.NewParameter("@QtyPerUnit", DbType.String, 20)
        arParms(3).Direction = ParameterDirection.Output

        Try
            ' Call ExecuteNonQuery static method of SqlHelper class
            ' We pass in database connection string, command type, stored procedure name and an array of SqlParameter object
            m_dbHelper.ExecuteNonQuery(txtConnectionString.Text, CommandType.StoredProcedure, "getProductDetails", arParms)

            ' Display results in text box using the values of output parameters	
            txtResults.Clear()
            txtResults.Text = CStr(arParms(1).Value) & ", " & CStr(arParms(2).Value) & ", " & CStr(arParms(3).Value)

        Catch ex As Exception
            ' throw an exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdSample4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample4.Click
        ' String variable that will hold the returned result
        Dim productName As String

        Try

            ' Call ExecuteScalar static method of SqlHelper class that returns an Object. Then cast the return value to string.
            ' We pass in database connection string, command type, stored procedure name, and a "1" as value for productID SqlParameter
            productName = CType(m_dbHelper.ExecuteScalar(txtConnectionString.Text, CommandType.StoredProcedure, "getProductName", m_dbHelper.NewParameter("@ProductID", 1)), String)

            ' Display results in text box
            txtResults.Text = productName

        Catch ex As Exception
            ' throw an exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdSample5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample5.Click

        Dim conn As IDbConnection = m_dbHelper.NewConnection(txtConnectionString.Text)

        conn.Open()

        Dim trans As IDbTransaction = conn.BeginTransaction()
        ' Establish command parameters

        ' @AccountNo (From Account)
        Dim paramFromAcc As IDataParameter = m_dbHelper.NewParameter("@AccountNo", DbType.AnsiString, 20)
        paramFromAcc.Value = "12345"

        ' @AccountNo (To Account)
        Dim paramToAcc As IDataParameter = m_dbHelper.NewParameter("@AccountNo", DbType.AnsiString, 20)
        paramToAcc.Value = "67890"

        ' @Money (Credit amount)
        Dim paramCreditAmount As IDataParameter = m_dbHelper.NewParameter("@Amount", DbType.Currency)
        paramCreditAmount.Value = 500

        ' @Money (Debit amount)
        Dim paramDebitAmount As IDataParameter = m_dbHelper.NewParameter("@Amount", DbType.Currency)
        paramDebitAmount.Value = 500

        Try
            ' Perform the debit operation
            m_dbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "Debit", paramFromAcc, paramDebitAmount)

            ' Perform the credit operation
            m_dbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "Credit", paramToAcc, paramCreditAmount)

            trans.Commit()
            ' If we got this far, transfer completed without errors being thrown
            txtResults.Text = "Transfer Completed"

        Catch ex As Exception
            ' throw an exception
            trans.Rollback()
            txtResults.Text = "Transfer Error"
            Throw ex
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub cmdSample6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample6.Click

        ' XmlReader that will hold the returned results
        Dim xreader As XmlReader

        Dim conn As IDbConnection = m_dbHelper.NewConnection(txtConnectionString.Text)
        conn.Open()

        ' Call ExecuteXmlReader static method of SqlHelper class that returns an XmlReader
        ' We pass in an open database connection object, command type, and command text
        xreader = CType(m_dbHelper, SqlDbHelper).ExecuteXmlReader(conn, CommandType.Text, "SELECT * FROM Products FOR XML AUTO")

        ' read the contents of xml reader and populate the results text box:
        txtResults.Clear()
        While (xreader.Read())
            txtResults.Text = txtResults.Text + xreader.ReadOuterXml() + Environment.NewLine
        End While

        ' close XmlReader and connection objects
        xreader.Close()
        conn.Close()

    End Sub

    Private Sub optSqlClient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSqlClient.Click
        Me.txtConnectionString.Text = "Server=(local);Database=Northwind;User ID=sa;Password=;"
        m_dbHelper = New SqlDbHelper()
    End Sub


    Private Sub optOLEDB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optOLEDB.Click
        Dim sConnectionString As String

        sConnectionString = "Provider=sqloledb;" & _
           "Data Source=(local);" & _
           "Initial Catalog=Northwind;" & _
           "User ID=sa;" & _
           "Password="

        sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=P:\vnetprojects2008\datalayer1.1\Sample\Nwind.mdb;Persist Security Info=False;Jet OLEDB:Database Password=98750"
        Me.txtConnectionString.Text = sConnectionString
        m_dbHelper = New OleDBDbHelper()

    End Sub

    Private Sub optODBC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optODBC.Click
        Dim sConnectionString As String
        sConnectionString = "Driver={SQL Server};Server=(local);UID=sa;PWD=;Database=Northwind;"
        Me.txtConnectionString.Text = sConnectionString

        m_dbHelper = New ODBCDBHelper()

    End Sub




    Private Sub cmdDatsetUpdateCommandBuilder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDatsetUpdateCommandBuilder.Click

        Dim conn As IDbConnection = m_dbHelper.NewConnection(txtConnectionString.Text)


        conn.Open()

        Dim ds As DataSet
        Dim sSQL As String

        sSQL = " SELECT CustomerID, CompanyName, ContactName , Region , @Test As Test  "
        sSQL &= " FROM Customers"
        sSQL &= " WHERE ContactName LIKE @ContactName "

        Dim paramContact(1) As IDataParameter

        paramContact(0) = m_dbHelper.NewParameter("@Test", DbType.AnsiString)
        paramContact(0).Value = "Teste"

        paramContact(1) = m_dbHelper.NewParameter("@ContactName", DbType.AnsiString)
        paramContact(1).Value = "Maria%"

        Try
            ds = m_dbHelper.ExecuteDataset(conn, CommandType.Text, sSQL, paramContact)

            ds.Tables(0).TableName = "Customers"

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Exit Sub
        End Try

        txtResults.Text = ds.GetXml

        ds.Tables(0).Rows(0).Item("Region") = CStr(Now.Second)

        sSQL = " SELECT CustomerID, CompanyName, ContactName , Region  "
        sSQL &= " FROM Customers"

        Dim numberRowsAffected As Integer

        'numberRowsAffected = m_dbHelper.UpdateDataset(conn, sSQL, ds.Tables(0))
        numberRowsAffected = m_dbHelper.UpdateDataset(conn, sSQL, ds, ds.Tables(0).TableName)

        txtResults.Text &= " Update:" & CStr(numberRowsAffected)

        Dim keys() As DataColumn = {ds.Tables(0).Columns("CustomerID")}
        ds.Tables(0).PrimaryKey = keys

        'Test insert Row 
        Dim dr As DataRow = ds.Tables(0).NewRow()
        'Insert new  Row 
        dr("CustomerID") = "TSTNE"
        dr("CompanyName") = "Test New"
        ds.Tables(0).Rows.Add(dr)
        'numberRowsAffected = m_dbHelper.UpdateDataset(conn, sSQL, ds.Tables(0))
        numberRowsAffected = m_dbHelper.UpdateDataset(conn, sSQL, ds, ds.Tables(0).TableName)

        txtResults.Text &= " Insert:" & CStr(numberRowsAffected)

        'Delete new Row 
        dr = ds.Tables(0).Rows.Find("TSTNE")
        dr.Delete()
        'numberRowsAffected = m_dbHelper.UpdateDataset(conn, sSQL, ds.Tables(0))
        numberRowsAffected = m_dbHelper.UpdateDataset(conn, sSQL, ds, ds.Tables(0).TableName)

        txtResults.Text &= " Delete:" & CStr(numberRowsAffected)

        ds.Dispose()

        conn.Dispose()

    End Sub

    Private Sub cmdUpdateCommandBuilderTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateCommandBuilderTransaction.Click

        Dim conn As IDbConnection = m_dbHelper.NewConnection(txtConnectionString.Text)

        Dim trans As IDbTransaction

        conn.Open()


        Dim ds As DataSet
        Dim sSQL As String

        sSQL = " SELECT CustomerID, CompanyName, ContactName , Region , @Test As Test  "
        sSQL &= " FROM Customers"
        sSQL &= " WHERE ContactName LIKE @ContactName "

        Dim paramContact(1) As IDataParameter

        paramContact(0) = m_dbHelper.NewParameter("@Test", DbType.AnsiString)
        paramContact(0).Value = "Teste"

        paramContact(1) = m_dbHelper.NewParameter("@ContactName", DbType.AnsiString)
        paramContact(1).Value = "Maria%"



        Try
            ds = m_dbHelper.ExecuteDataset(conn, CommandType.Text, sSQL, paramContact)

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Exit Sub
        End Try

        txtResults.Text = ds.GetXml



        ds.Tables(0).Rows(0).Item("Region") = CStr(Now.Second)

        sSQL = " SELECT CustomerID, CompanyName, ContactName , Region  "
        sSQL &= " FROM Customers"

        Dim numberRowsAffected As Integer

        Try

            trans = conn.BeginTransaction
            numberRowsAffected = m_dbHelper.UpdateDataset(trans, sSQL, ds.Tables(0))

            txtResults.Text &= " Update:" & CStr(numberRowsAffected)

            Dim keys() As DataColumn = {ds.Tables(0).Columns("CustomerID")}
            ds.Tables(0).PrimaryKey = keys

            'Test insert Row 
            Dim dr As DataRow = ds.Tables(0).NewRow()
            'Insert new  Row 
            dr("CustomerID") = "TSTNE"
            dr("CompanyName") = "Test New"
            ds.Tables(0).Rows.Add(dr)
            numberRowsAffected = m_dbHelper.UpdateDataset(trans, sSQL, ds.Tables(0))

            txtResults.Text &= " Insert:" & CStr(numberRowsAffected)

            'Delete new Row 
            dr = ds.Tables(0).Rows.Find("TSTNE")
            dr.Delete()
            numberRowsAffected = m_dbHelper.UpdateDataset(trans, sSQL, ds.Tables(0))

            txtResults.Text &= " Delete:" & CStr(numberRowsAffected)

            trans.Commit()

        Catch ex As Exception
            If Not trans Is Nothing Then
                trans.Rollback()
            End If
            MsgBox(ex.ToString)
        Finally
            ds.Dispose()
            conn.Dispose()
        End Try
    End Sub

    Private Sub cmdUpdateNoCommandBuilder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateNoCommandBuilder.Click

        Dim conn As IDbConnection = m_dbHelper.NewConnection(txtConnectionString.Text)


        conn.Open()

        Dim ds As DataSet
        Dim sSQL As String

        sSQL = " SELECT CustomerID, CompanyName, ContactName , Region , @Test As Test  "
        sSQL &= " FROM Customers"
        sSQL &= " WHERE ContactName LIKE @ContactName "

        Dim paramContact(1) As IDataParameter

        paramContact(0) = m_dbHelper.NewParameter("@Test", DbType.AnsiString)
        paramContact(0).Value = "Teste"

        paramContact(1) = m_dbHelper.NewParameter("@ContactName", DbType.AnsiString)
        paramContact(1).Value = "%"


        Try
            ds = m_dbHelper.ExecuteDataset(conn, CommandType.Text, sSQL, paramContact)

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Exit Sub
        End Try

        txtResults.Text = ds.GetXml

        ds.Tables(0).Rows(0).Item("Region") = CStr(Now.Second)


        'update Parameters 
        Dim sSQLUpdate As String
        sSQLUpdate = "UPDATE Customers SET Region = @Region WHERE (CustomerID = @CustomerID)"

        ReDim paramContact(1)

        paramContact(0) = m_dbHelper.NewParameter("@Region", DbType.AnsiString)
        paramContact(0).SourceColumn = "Region"

        paramContact(1) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
        paramContact(1).SourceColumn = "CustomerID"
        paramContact(1).SourceVersion = DataRowVersion.Original

        'Insert Parameters 
        Dim paramInsert(1) As IDataParameter
        Dim sSQLInsert As String

        sSQLInsert = "INSERT INTO Customers( CustomerID , CompanyName) VALUES ( @CustomerID , @CompanyName)"
        paramInsert(0) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
        paramInsert(0).SourceColumn = "CustomerID"

        paramInsert(1) = m_dbHelper.NewParameter("@CompanyName", DbType.AnsiString)
        paramInsert(1).SourceColumn = "CompanyName"

        'Delete Parameters 
        Dim paramDelete(0) As IDataParameter
        Dim sSQLDelete As String

        sSQLDelete = "DELETE FROM  Customers WHERE (CustomerID = @CustomerID) "
        paramDelete(0) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
        paramDelete(0).SourceColumn = "CustomerID"
        paramDelete(0).SourceVersion = DataRowVersion.Original

        Dim numberRowsAffected As Integer

        numberRowsAffected = m_dbHelper.UpdateDataset(conn, ds.Tables(0), sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)

        txtResults.Text &= " Update:" & CStr(numberRowsAffected)

        Dim keys() As DataColumn = {ds.Tables(0).Columns("CustomerID")}
        ds.Tables(0).PrimaryKey = keys

        'Test insert Row 
        Dim dr As DataRow = ds.Tables(0).NewRow()
        'Insert new  Row 
        dr("CustomerID") = "TSTNE"
        dr("CompanyName") = "Test New"
        ds.Tables(0).Rows.Add(dr)
        numberRowsAffected = m_dbHelper.UpdateDataset(conn, ds.Tables(0), sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)

        txtResults.Text &= " Insert:" & CStr(numberRowsAffected)

        'Delete new Row 
        dr = ds.Tables(0).Rows.Find("TSTNE")
        dr.Delete()
        numberRowsAffected = m_dbHelper.UpdateDataset(conn, ds.Tables(0), sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)

        txtResults.Text &= " Delete:" & CStr(numberRowsAffected)

        ds.Dispose()
        conn.Dispose()

    End Sub

    Private Sub cmdNoCommandBuilderTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNoCommandBuilderTransaction.Click

        Dim conn As IDbConnection = m_dbHelper.NewConnection(txtConnectionString.Text)


        conn.Open()

        Dim ds As DataSet
        Dim sSQL As String

        sSQL = " SELECT CustomerID, CompanyName, ContactName , Region , @Test As Test  "
        sSQL &= " FROM Customers"
        sSQL &= " WHERE ContactName LIKE @ContactName "

        Dim paramContact(1) As IDataParameter

        paramContact(0) = m_dbHelper.NewParameter("@Test", DbType.AnsiString)
        paramContact(0).Value = "Teste"

        paramContact(1) = m_dbHelper.NewParameter("@ContactName", DbType.AnsiString)
        paramContact(1).Value = "%"


        Try
            ds = m_dbHelper.ExecuteDataset(conn, CommandType.Text, sSQL, paramContact)

            ds.Tables(0).TableName = "Customers"

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Exit Sub
        End Try

        txtResults.Text = ds.GetXml

        ds.Tables(0).Rows(0).Item("Region") = CStr(Now.Second)


        Dim trans As IDbTransaction

        Try

            trans = conn.BeginTransaction(IsolationLevel.ReadCommitted)


            'update Parameters 
            Dim sSQLUpdate As String
            sSQLUpdate = "UPDATE Customers SET Region = @Region WHERE (CustomerID = @CustomerID)"

            ReDim paramContact(1)

            paramContact(0) = m_dbHelper.NewParameter("@Region", DbType.AnsiString)
            paramContact(0).SourceColumn = "Region"

            paramContact(1) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
            paramContact(1).SourceColumn = "CustomerID"
            paramContact(1).SourceVersion = DataRowVersion.Original

            'Insert Parameters 
            Dim paramInsert(1) As IDataParameter
            Dim sSQLInsert As String

            sSQLInsert = "INSERT INTO Customers( CustomerID , CompanyName) VALUES ( @CustomerID , @CompanyName)"
            paramInsert(0) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
            paramInsert(0).SourceColumn = "CustomerID"

            paramInsert(1) = m_dbHelper.NewParameter("@CompanyName", DbType.AnsiString)
            paramInsert(1).SourceColumn = "CompanyName"

            'Delete Parameters 
            Dim paramDelete(0) As IDataParameter
            Dim sSQLDelete As String

            sSQLDelete = "DELETE FROM  Customers WHERE (CustomerID = @CustomerID) "
            paramDelete(0) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
            paramDelete(0).SourceColumn = "CustomerID"
            paramDelete(0).SourceVersion = DataRowVersion.Original

            Dim numberRowsAffected As Integer


            'numberRowsAffected = m_dbHelper.UpdateDataset(trans, ds.Tables(0), sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)
            numberRowsAffected = m_dbHelper.UpdateDataset(trans, ds, ds.Tables(0).TableName, sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)

            txtResults.Text &= " Update:" & CStr(numberRowsAffected)

            Dim keys() As DataColumn = {ds.Tables(0).Columns("CustomerID")}
            ds.Tables(0).PrimaryKey = keys

            'Test insert Row 
            Dim dr As DataRow = ds.Tables(0).NewRow()
            'Insert new  Row 
            dr("CustomerID") = "TSTNE"
            dr("CompanyName") = "Test New"
            ds.Tables(0).Rows.Add(dr)
            'numberRowsAffected = m_dbHelper.UpdateDataset(trans, ds.Tables(0), sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)
            numberRowsAffected = m_dbHelper.UpdateDataset(trans, ds, ds.Tables(0).TableName, sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)

            txtResults.Text &= " Insert:" & CStr(numberRowsAffected)

            'Delete new Row 
            dr = ds.Tables(0).Rows.Find("TSTNE")
            dr.Delete()
            'numberRowsAffected = m_dbHelper.UpdateDataset(trans, ds.Tables(0), sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)
            numberRowsAffected = m_dbHelper.UpdateDataset(trans, ds, ds.Tables(0).TableName, sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)

            txtResults.Text &= " Delete:" & CStr(numberRowsAffected)

            trans.Commit()
        Catch ex As Exception
            If Not trans Is Nothing Then
                trans.Rollback()
            End If
            MsgBox(ex.ToString)
        Finally
            ds.Dispose()
            conn.Dispose()
        End Try
    End Sub



    Private Sub cmdNoCommandBuilderSP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNoCommandBuilderSP.Click
        Dim conn As IDbConnection = m_dbHelper.NewConnection(txtConnectionString.Text)


        conn.Open()

        Dim ds As DataSet
        Dim sSQL As String
        Dim numberRowsAffected As Integer

        sSQL = " SELECT CustomerID, CompanyName, ContactName , Region , @Test As Test  "
        sSQL &= " FROM Customers"
        sSQL &= " WHERE ContactName LIKE @ContactName "

        Dim paramContact(1) As IDataParameter

        paramContact(0) = m_dbHelper.NewParameter("@Test", DbType.AnsiString)
        paramContact(0).Value = "Teste"

        paramContact(1) = m_dbHelper.NewParameter("@ContactName", DbType.AnsiString)
        paramContact(1).Value = "%"


        Try
            ds = m_dbHelper.ExecuteDataset(conn, CommandType.Text, sSQL, paramContact)

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Exit Sub
        End Try

        txtResults.Text = ds.GetXml

        ds.Tables(0).Rows(0).Item("Region") = CStr(Now.Second)

        'update Parameters 
        Dim sSQLUpdate As String
        sSQLUpdate = "CommandUpdateCustomer"

        ReDim paramContact(1)

        paramContact(0) = m_dbHelper.NewParameter("@Region", DbType.AnsiString)
        paramContact(0).SourceColumn = "Region"

        paramContact(1) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
        paramContact(1).SourceColumn = "CustomerID"
        paramContact(1).SourceVersion = DataRowVersion.Original

        'Insert Parameters 
        Dim paramInsert(1) As IDataParameter
        Dim sSQLInsert As String

        sSQLInsert = "CommandInsertCustomer"
        paramInsert(0) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
        paramInsert(0).SourceColumn = "CustomerID"

        paramInsert(1) = m_dbHelper.NewParameter("@CompanyName", DbType.AnsiString)
        paramInsert(1).SourceColumn = "CompanyName"

        'Delete Parameters 
        Dim paramDelete(0) As IDataParameter
        Dim sSQLDelete As String

        sSQLDelete = "CommandDeleteCustomer"
        paramDelete(0) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
        paramDelete(0).SourceColumn = "CustomerID"
        paramDelete(0).SourceVersion = DataRowVersion.Original



        numberRowsAffected = m_dbHelper.UpdateDataset(conn, ds.Tables(0), _
                                                        CommandType.StoredProcedure, _
                                                        CommandType.StoredProcedure, _
                                                        CommandType.StoredProcedure, _
                                                        sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)

        txtResults.Text &= " Update:" & CStr(numberRowsAffected)

        Dim keys() As DataColumn = {ds.Tables(0).Columns("CustomerID")}
        ds.Tables(0).PrimaryKey = keys

        'Test insert Row 
        Dim dr As DataRow = ds.Tables(0).NewRow()
        'Insert new  Row 
        dr("CustomerID") = "TSTNE"
        dr("CompanyName") = "Test New"
        ds.Tables(0).Rows.Add(dr)
        numberRowsAffected = m_dbHelper.UpdateDataset(conn, ds.Tables(0), _
                                                       CommandType.StoredProcedure, _
                                                       CommandType.StoredProcedure, _
                                                       CommandType.StoredProcedure, _
                                                       sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)


        txtResults.Text &= " Insert:" & CStr(numberRowsAffected)

        'Delete new Row 
        dr = ds.Tables(0).Rows.Find("TSTNE")
        dr.Delete()
        numberRowsAffected = m_dbHelper.UpdateDataset(conn, ds.Tables(0), _
                                                       CommandType.StoredProcedure, _
                                                       CommandType.StoredProcedure, _
                                                       CommandType.StoredProcedure, _
                                                       sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)


        txtResults.Text &= " Delete:" & CStr(numberRowsAffected)

        ds.Dispose()
        conn.Dispose()

    End Sub

    Private Sub cmdNoCommandBuilderSPTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNoCommandBuilderSPTrans.Click
        Dim conn As IDbConnection = m_dbHelper.NewConnection(txtConnectionString.Text)


        conn.Open()

        Dim ds As DataSet
        Dim sSQL As String
        Dim numberRowsAffected As Integer

        sSQL = " SELECT CustomerID, CompanyName, ContactName , Region , @Test As Test  "
        sSQL &= " FROM Customers"
        sSQL &= " WHERE ContactName LIKE @ContactName "

        Dim paramContact(1) As IDataParameter

        paramContact(0) = m_dbHelper.NewParameter("@Test", DbType.AnsiString)
        paramContact(0).Value = "Teste"

        paramContact(1) = m_dbHelper.NewParameter("@ContactName", DbType.AnsiString)
        paramContact(1).Value = "%"


        Try
            ds = m_dbHelper.ExecuteDataset(conn, CommandType.Text, sSQL, paramContact)

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Exit Sub
        End Try

        txtResults.Text = ds.GetXml

        ds.Tables(0).Rows(0).Item("Region") = CStr(Now.Second)

        'update Parameters 
        Dim sSQLUpdate As String
        sSQLUpdate = "CommandUpdateCustomer"

        ReDim paramContact(1)

        paramContact(0) = m_dbHelper.NewParameter("@Region", DbType.AnsiString)
        paramContact(0).SourceColumn = "Region"

        paramContact(1) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
        paramContact(1).SourceColumn = "CustomerID"
        paramContact(1).SourceVersion = DataRowVersion.Original

        'Insert Parameters 
        Dim paramInsert(1) As IDataParameter
        Dim sSQLInsert As String

        sSQLInsert = "CommandInsertCustomer"
        paramInsert(0) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
        paramInsert(0).SourceColumn = "CustomerID"

        paramInsert(1) = m_dbHelper.NewParameter("@CompanyName", DbType.AnsiString)
        paramInsert(1).SourceColumn = "CompanyName"

        'Delete Parameters 
        Dim paramDelete(0) As IDataParameter
        Dim sSQLDelete As String

        sSQLDelete = "CommandDeleteCustomer"
        paramDelete(0) = m_dbHelper.NewParameter("@CustomerID", DbType.AnsiString)
        paramDelete(0).SourceColumn = "CustomerID"
        paramDelete(0).SourceVersion = DataRowVersion.Original


        Dim trans As IDbTransaction

        Try

            trans = conn.BeginTransaction
            numberRowsAffected = m_dbHelper.UpdateDataset(trans, ds.Tables(0), _
                                                            CommandType.StoredProcedure, _
                                                            CommandType.StoredProcedure, _
                                                            CommandType.StoredProcedure, _
                                                            sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)

            txtResults.Text &= " Update:" & CStr(numberRowsAffected)

            Dim keys() As DataColumn = {ds.Tables(0).Columns("CustomerID")}
            ds.Tables(0).PrimaryKey = keys

            'Test insert Row 
            Dim dr As DataRow = ds.Tables(0).NewRow()
            'Insert new  Row 
            dr("CustomerID") = "TSTNE"
            dr("CompanyName") = "Test New"
            ds.Tables(0).Rows.Add(dr)
            numberRowsAffected = m_dbHelper.UpdateDataset(trans, ds.Tables(0), _
                                                           CommandType.StoredProcedure, _
                                                           CommandType.StoredProcedure, _
                                                           CommandType.StoredProcedure, _
                                                           sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)


            txtResults.Text &= " Insert:" & CStr(numberRowsAffected)

            'Delete new Row 
            dr = ds.Tables(0).Rows.Find("TSTNE")
            dr.Delete()
            numberRowsAffected = m_dbHelper.UpdateDataset(trans, ds.Tables(0), _
                                                           CommandType.StoredProcedure, _
                                                           CommandType.StoredProcedure, _
                                                           CommandType.StoredProcedure, _
                                                           sSQLUpdate, paramContact, sSQLInsert, paramInsert, sSQLDelete, paramDelete)


            txtResults.Text &= " Delete:" & CStr(numberRowsAffected)
            trans.Commit()
        Catch ex As Exception
            If Not trans Is Nothing Then
                trans.Rollback()
            End If
            MsgBox(ex.ToString)
        Finally
            ds.Dispose()
            conn.Dispose()
        End Try
    End Sub

    Private Sub cmdTestOracle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTestOracle.Click
        Dim dbHelper As New MSOracleDbHelper
        Dim cnnString As String
        Dim cnn As IDbConnection

        Try

            cnnString = "user id=hr;password=hr;data source=192.168.31.225:1521/XE"

            cnn = dbHelper.NewConnection(cnnString)

            cnn.Open()

            Dim ds As DataSet
            Dim param As IDataParameter
            Dim param2 As IDataParameter
            Dim sql As String


            sql = "select * from [EMPLOYEES] where [HIRE_DATE] >= @HIRE_DATE AND FIRST_NAME LIKE @FIRST_NAME "
            param = CType(dbHelper.NewParameter("@hire_date", DbType.DateTime, CObj(#1/1/1990#)), IDbDataParameter)
            param2 = CType(dbHelper.NewParameter("@first_name", DbType.String, CObj("%LLe%")), IDbDataParameter)
            ds = dbHelper.ExecuteDataset(cnn, CommandType.Text, sql, param, param2)

            sql = " UPDATE  " & vbCrLf
            sql &= " departments  " & vbCrLf
            sql &= " As     d"
            sql &= " SET d.[DEPARTMENT_NAME]  = @department_name"
            sql &= " WHERE d.[DEPARTMENT_ID]   = @department_id"

            param = CType(dbHelper.NewParameter("@department_name", DbType.String, CObj("Finan�as")), IDbDataParameter)
            param2 = CType(dbHelper.NewParameter("@department_id", DbType.Int32, CObj(100)), IDbDataParameter)

            Dim trans As IDbTransaction = cnn.BeginTransaction


            dbHelper.ExecuteNonQuery(trans, CommandType.Text, sql, param, param2)

            trans.Commit()

            cnn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub

    
    Private Sub optOLEDB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optOLEDB.CheckedChanged

    End Sub
End Class
