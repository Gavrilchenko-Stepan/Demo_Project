using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace DemoLib.Models.Clients
{
    public class MySQLClientsModel : IClientsModel
    {
        private const string connStr = "server=localhost;user=root;database=clients_db;password=12345678;port=3306;";

        public void AddClient(Client client)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    string sql = @"INSERT INTO clientsinfo (clientName, phone, mail, description, imagePath) 
                                  VALUES (@name, @phone, @mail, @description, @imagePath)";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@name", client.Name);
                    command.Parameters.AddWithValue("@phone", client.Phone);
                    command.Parameters.AddWithValue("@mail", client.Mail);
                    command.Parameters.AddWithValue("@description", client.Description);
                    command.Parameters.AddWithValue("@imagePath", client.ImagePath);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddOrderRecord(int clientId, OrderRecord record)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    string sql = @"INSERT INTO orders (idclient, article, date, price, count) 
                                  VALUES (@idclient, @article, @date, @price, @count)";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@idclient", clientId);
                    command.Parameters.AddWithValue("@article", record.NameProduct);
                    command.Parameters.AddWithValue("@date", record.SaleDate);
                    command.Parameters.AddWithValue("@price", record.Price);
                    command.Parameters.AddWithValue("@count", record.Count);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при добавлении заказа: {ex.Message}", ex);
            }
        }

        public int GetClientsCount()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    string sql = "SELECT COUNT(id) FROM clientsinfo";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    int result = Convert.ToInt32(command.ExecuteScalar().ToString());

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Client> ReadAllClients()
        {
            List<Client> clients = new List<Client>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    string sql = "SELECT id, clientName, phone, mail, description, imagePath FROM clientsinfo";
                    MySqlCommand command = new MySqlCommand(sql, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Client client = new Client(reader.GetInt32(0));

                            client.Name = reader.GetString(1);
                            client.Phone = reader.GetString(2);
                            client.Mail = reader.GetString(3);
                            client.Description = reader.GetString(4);
                            client.ImagePath = reader.GetString(5);

                            clients.Add(client);
                        }
                    }

                    foreach (Client client in clients)
                    {
                        string orderQuery = "SELECT article, date, price, count FROM orders WHERE idclient = " + client.ID;
                        MySqlCommand orderCommand = new MySqlCommand(orderQuery, connection);
                        using (MySqlDataReader orderReader = orderCommand.ExecuteReader())
                        {
                            while (orderReader.Read())
                            {
                                OrderRecord orderRecord = new OrderRecord();
                                orderRecord.NameProduct = orderReader.GetString(0);
                                orderRecord.SaleDate = orderReader.GetDateTime(1);
                                orderRecord.Price = orderReader.GetDouble(2);
                                orderRecord.Count = orderReader.GetInt32(3);

                                client.order.AddRecord(orderRecord);
                            }
                        }
                    }

                    return clients;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveClient(int clientId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    // Сначала удаляем связанные заказы
                    string deleteOrdersSql = "DELETE FROM orders WHERE idclient = @id";
                    MySqlCommand deleteOrdersCommand = new MySqlCommand(deleteOrdersSql, connection);
                    deleteOrdersCommand.Parameters.AddWithValue("@id", clientId);
                    deleteOrdersCommand.ExecuteNonQuery();

                    // Затем удаляем клиента
                    string deleteClientSql = "DELETE FROM clientsinfo WHERE id = @id";
                    MySqlCommand deleteClientCommand = new MySqlCommand(deleteClientSql, connection);
                    deleteClientCommand.Parameters.AddWithValue("@id", clientId);

                    int rowsAffected = deleteClientCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveOrderRecord(int clientId, OrderRecord record)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    string sql = @"DELETE FROM orders 
                                  WHERE idclient = @idclient 
                                  AND article = @article 
                                  AND date = @date 
                                  AND price = @price 
                                  AND count = @count";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@idclient", clientId);
                    command.Parameters.AddWithValue("@article", record.NameProduct);
                    command.Parameters.AddWithValue("@date", record.SaleDate);
                    command.Parameters.AddWithValue("@price", record.Price);
                    command.Parameters.AddWithValue("@count", record.Count);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении заказа: {ex.Message}", ex);
            }
        }

        public void UpdateClient(Client client)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    string sql = @"UPDATE clientsinfo 
                                  SET clientName = @name, phone = @phone, mail = @mail, 
                                      description = @description, imagePath = @imagePath 
                                  WHERE id = @id";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@name", client.Name);
                    command.Parameters.AddWithValue("@phone", client.Phone);
                    command.Parameters.AddWithValue("@mail", client.Mail);
                    command.Parameters.AddWithValue("@description", client.Description);
                    command.Parameters.AddWithValue("@imagePath", client.ImagePath);
                    command.Parameters.AddWithValue("@id", client.ID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateOrderRecord(int clientId, OrderRecord oldRecord, OrderRecord newRecord)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    string sql = @"UPDATE orders 
                                  SET article = @new_article, date = @new_date, 
                                      price = @new_price, count = @new_count
                                  WHERE idclient = @idclient 
                                  AND article = @old_article 
                                  AND date = @old_date 
                                  AND price = @old_price 
                                  AND count = @old_count";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@idclient", clientId);

                    // Новые значения
                    command.Parameters.AddWithValue("@new_article", newRecord.NameProduct);
                    command.Parameters.AddWithValue("@new_date", newRecord.SaleDate);
                    command.Parameters.AddWithValue("@new_price", newRecord.Price);
                    command.Parameters.AddWithValue("@new_count", newRecord.Count);

                    // Старые значения для идентификации записи
                    command.Parameters.AddWithValue("@old_article", oldRecord.NameProduct);
                    command.Parameters.AddWithValue("@old_date", oldRecord.SaleDate);
                    command.Parameters.AddWithValue("@old_price", oldRecord.Price);
                    command.Parameters.AddWithValue("@old_count", oldRecord.Count);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении заказа: {ex.Message}", ex);
            }
        }
    }
}
