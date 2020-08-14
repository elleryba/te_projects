using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class TransferSqlDAO : ITransferDAO
    {
        private readonly string connectionString;
        private readonly string SQL_SelectTransfer = "SELECT transfer_id, transfer_type_id, transfer_status_id, amount, " +
                                                        "aFrom.account_id as 'fromAcct', aFrom.user_id as 'fromUser', uFrom.username as 'fromName', aFrom.balance as 'fromBal', " +
                                                        "aTo.account_id as 'toAcct', aTo.user_id as 'toUser', uTo.username as 'toName', aTo.balance as 'toBal' " +
                                                        "FROM transfers " +
                                                        "INNER JOIN accounts aFrom on account_from = aFrom.account_id " +
                                                        "INNER JOIN users uFrom on uFrom.user_id = aFrom.user_id " +
                                                        "INNER JOIN accounts aTo on account_to = aTo.account_id " +
                                                        "INNER JOIN users uTo on uTo.user_id = aTo.user_id ";

        public TransferSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Transfer GetTransferById(int transferId)
        {
            Transfer returnTransfer = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SelectTransfer + "WHERE transfer_id = @transferId", conn);
                    cmd.Parameters.AddWithValue("@transferId", transferId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnTransfer = GetTransferFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnTransfer;
        }

        public Transfer AddTransfer(NewTransfer transfer, int fromAcctId, int toAcctId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO transfers (transfer_type_id, transfer_status_id, account_from, account_to, amount) VALUES (@transferType, @transferStatus, @accountFrom, @accountTo, @amount)", conn);
                    cmd.Parameters.AddWithValue("@transferType", transfer.TransferType);
                    cmd.Parameters.AddWithValue("@transferStatus",
                                        transfer.TransferType == TransferType.Request ?
                                        TransferStatus.Pending : TransferStatus.Approved); //pending if request, approved if send
                    cmd.Parameters.AddWithValue("@accountFrom", fromAcctId);
                    cmd.Parameters.AddWithValue("@accountTo", toAcctId);
                    cmd.Parameters.AddWithValue("@amount", transfer.Amount);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT @@IDENTITY", conn);
                    int newId = Convert.ToInt32(cmd.ExecuteScalar());

                    if (transfer.TransferType == TransferType.Send) //sending doesn't need approval, just do it
                    {
                         TransferMoney(transfer.Amount, fromAcctId, toAcctId);
                    }

                    return GetTransferById(newId);
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public List<Transfer> GetTransfersForUser(int userId)
        {
            List<Transfer> returnTransfers = new List<Transfer>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = SQL_SelectTransfer + "WHERE (account_from IN (SELECT account_id FROM accounts WHERE user_id = @userId) OR account_to IN (SELECT account_id FROM accounts WHERE user_id = @userId))";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Transfer t = GetTransferFromReader(reader);
                            returnTransfers.Add(t);
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnTransfers;
        }

        public List<Transfer> GetPendingTransfersForUser(int userId)
        {
            List<Transfer> returnTransfers = new List<Transfer>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = SQL_SelectTransfer + "WHERE transfer_status_id = 1 AND account_from IN (SELECT account_id FROM accounts WHERE user_id = @userId)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Transfer t = GetTransferFromReader(reader);
                            returnTransfers.Add(t);
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnTransfers;
        }

        public bool ApproveTransfer(int transferId)
        {
            if (ChangeTransferStatus(transferId, TransferStatus.Approved))
            {
                Transfer t = GetTransferById(transferId);

                return TransferMoney(t.Amount, t.AccountFrom.AccountId, t.AccountTo.AccountId);
            }
            return false;
        }
        public bool RejectTransfer(int transferId)
        {
            return ChangeTransferStatus(transferId, TransferStatus.Rejected);
        }
        private bool ChangeTransferStatus(int transferId, TransferStatus status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE transfers SET transfer_status_id = @transferStatus WHERE transfer_id = @transferId", conn);
                    cmd.Parameters.AddWithValue("@transferStatus", (int)status);
                    cmd.Parameters.AddWithValue("@transferId", transferId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        private bool TransferMoney(decimal amount, int acctFrom, int acctTo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE accounts SET balance = (balance - @amount) WHERE account_id = @accountFrom; UPDATE accounts SET balance = (balance + @amount) WHERE account_id = @accountTo", conn);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@accountFrom", acctFrom);
                    cmd.Parameters.AddWithValue("@accountTo", acctTo);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        private Transfer GetTransferFromReader(SqlDataReader reader)
        {
            Transfer t = new Transfer()
            {
                TransferId = Convert.ToInt32(reader["transfer_id"]),
                TransferType = (TransferType)Convert.ToInt32(reader["transfer_type_id"]),
                TransferStatus = (TransferStatus)Convert.ToInt32(reader["transfer_status_id"]),
                Amount = Convert.ToDecimal(reader["amount"]),
                AccountFrom = new Account()
                {
                    AccountId = Convert.ToInt32(reader["fromAcct"]),
                    UserId = Convert.ToInt32(reader["fromUser"]),
                    Username = Convert.ToString(reader["fromName"]),
                    Balance = Convert.ToInt32(reader["fromBal"]),
                },
                AccountTo = new Account()
                {
                    AccountId = Convert.ToInt32(reader["toAcct"]),
                    UserId = Convert.ToInt32(reader["toUser"]),
                    Username = Convert.ToString(reader["toName"]),
                    Balance = Convert.ToInt32(reader["toBal"]),
                },
            };

            return t;
        }
    }
}
