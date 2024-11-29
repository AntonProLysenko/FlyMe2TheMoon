Module modDataBaseUtilities


    Public m_conAdministrator As OleDb.OleDbConnection

    Private m_strDatabaseConnectionStringSQLServer As String = "Provider=SQLOLEDB;" &
                                                            "Server=(Local);" &
                                                            "Database=dbFlyMe2theMoon;" &
                                                            "Connect Timeout=200;" &
                                                            "Integrated Security=SSPI;"

    Public Function OpenDatabaseConnectionSQLServer() As Boolean
        Dim blnResult As Boolean = False
        Dim frmLoading As New frmLoading


        frmLoading.Show()
        Try
            m_conAdministrator = New OleDb.OleDbConnection
            m_conAdministrator.ConnectionString = m_strDatabaseConnectionStringSQLServer
            m_conAdministrator.Open()

            blnResult = True
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & " Utils, openDb Func", vbCritical)
        End Try
        frmLoading.Close()


        Return blnResult
    End Function





    Public Function CloseDatabaseConnection() As Boolean

        Dim blnResult As Boolean = False

        Try
            If m_conAdministrator IsNot Nothing Then

                If m_conAdministrator.State <> ConnectionState.Closed Then
                    m_conAdministrator.Close()
                End If

                m_conAdministrator = Nothing
            End If

            blnResult = True

        Catch excError As Exception
            MessageBox.Show(excError.Message)
        End Try

        Return blnResult
    End Function


    Public Function CheckOpenDBConnection(form As Object)
        If OpenDatabaseConnectionSQLServer() = False Then

            MessageBox.Show(form, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                form.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            form.Close()
        Else

        End If
    End Function






    'This Function is abble to commit Insert, Delete And Update Transactions To the database
    Public Function ExecuteUltimateTransaction(strExecuteStatement As String, strRole As String, strName As String, strTransactionType As String)
        Dim intRowsAffected As Integer
        Dim cmdAdd As New OleDb.OleDbCommand()


        cmdAdd.CommandType = CommandType.StoredProcedure

        ' Call stored proc which will insert the record 
        cmdAdd = New OleDb.OleDbCommand(strExecuteStatement, m_conAdministrator)

        ' this return is the # of rows affected
        intRowsAffected = cmdAdd.ExecuteNonQuery()

        ' close database connection
        CloseDatabaseConnection()

        If intRowsAffected > 0 Then
            MessageBox.Show(strTransactionType & " successful! " & strRole & " " & strName & " has been " & strTransactionType.ToLower() & "ed")

        Else
            MessageBox.Show(strTransactionType & " failed")

        End If
    End Function






    'CREATE
    Public Function InsertData(strInsert As String)
        Dim intNextPrimaryKey As Integer

        Dim cmdInsert As New OleDb.OleDbCommand
        Dim intRowsAffected As Integer

        cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)


        intRowsAffected = cmdInsert.ExecuteNonQuery()


        If intRowsAffected > 0 Then
            MessageBox.Show("Added Successfully")
        End If

    End Function



    'READ
    Public Function GetDataTable(strSelect As String) As DataTable
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtRecievedData As DataTable = New DataTable

        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader
        dtRecievedData.Load(drSourceTable)

        drSourceTable.Close()

        Return dtRecievedData
    End Function

    Public Function ExecuteSelectProdcedure(strProdcedureName As String) As DataTable
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtRecievedData As DataTable = New DataTable

        cmdSelect = New OleDb.OleDbCommand(strProdcedureName, m_conAdministrator)
        cmdSelect.CommandType = CommandType.StoredProcedure

        drSourceTable = cmdSelect.ExecuteReader
        dtRecievedData.Load(drSourceTable)
        drSourceTable.Close()
        Return dtRecievedData
    End Function

    Public Function ExecuteSelectProdcedure(strProdcedureName As String, strParamName As String, intParamValue As Integer) As DataTable
        Dim cmdSelect As OleDb.OleDbCommand
        Dim objParam As OleDb.OleDbParameter
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtRecievedData As DataTable = New DataTable


        cmdSelect = New OleDb.OleDbCommand(strProdcedureName, m_conAdministrator)
        cmdSelect.CommandType = CommandType.StoredProcedure

        objParam = cmdSelect.Parameters.Add(strParamName, OleDb.OleDbType.Integer)
        objParam.Direction = ParameterDirection.Input
        objParam.Value = intParamValue

        drSourceTable = cmdSelect.ExecuteReader

        dtRecievedData.Load(drSourceTable)
        drSourceTable.Close()
        Return dtRecievedData
    End Function

    Public Function ExecuteSelectNextPK(strTableName As String, strColumnName As String) As DataTable
        Dim cmdSelect As OleDb.OleDbCommand
        Dim objParam As OleDb.OleDbParameter
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtRecievedData As DataTable = New DataTable


        cmdSelect = New OleDb.OleDbCommand("uspNextPK", m_conAdministrator)
        cmdSelect.CommandType = CommandType.StoredProcedure

        objParam = cmdSelect.Parameters.Add("@id_ColumnName", OleDb.OleDbType.VarChar)
        objParam.Direction = ParameterDirection.Input
        objParam.Value = strColumnName

        objParam = cmdSelect.Parameters.Add("@TableName", OleDb.OleDbType.VarChar)
        objParam.Direction = ParameterDirection.Input
        objParam.Value = strTableName

        drSourceTable = cmdSelect.ExecuteReader

        dtRecievedData.Load(drSourceTable)
        drSourceTable.Close()
        Return dtRecievedData
    End Function


    'UPDATE
    Public Function UpdateData(strUpdate)
        Dim cmdUpdate As New OleDb.OleDbCommand
        Dim intRowsAffected As Integer

        cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)
        intRowsAffected = cmdUpdate.ExecuteNonQuery()

        If intRowsAffected = 1 Then
            MessageBox.Show("Update successful")
        Else
            MessageBox.Show("Update failed")
        End If
    End Function

    'DELETE
    Public Function DeleteData(strDelete)
        Dim cmbDelete As OleDb.OleDbCommand
        Dim intRowsAffected As Integer

        cmbDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
        intRowsAffected = cmbDelete.ExecuteNonQuery()

        If intRowsAffected > 0 Then
            MessageBox.Show("Deleted Successfuly")
        Else
            MessageBox.Show("Ooops!" & vbNewLine & "Something Went Wrong!", "Unsuccess!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Function



End Module
