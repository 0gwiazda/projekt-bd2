using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Diagnostics.Tracing;
using System.Transactions;

namespace Projekt
{
    public class Funkcje
    {
        [SqlFunction(DataAccess = DataAccessKind.Read)]
        public static int CheckClientAbility(int owner_id, int anim_danger)
        {
            using (SqlConnection conn = new SqlConnection("context connection=true"))
            {
                string[] dangers = { "safe", "medium", "dangerous", "deadly" };

                int danger_int = Array.IndexOf(dangers, anim_danger);

                conn.Open();

                if (anim_danger <= 3)
                {
                    return 1;
                }
                else
                {
                    SqlCommand query = new SqlCommand($"SELECT \"zwierzak\" as pet FROM \"Hodowla\" WHERE \"klient_id\" = {owner_id} AND \"zwierzak\".checkDanger({anim_danger}) >= 0", conn);
                    SqlDataReader data = query.ExecuteReader();

                    int i = 0;

                    while (data.Read())
                    {
                        i++;
                    }
                    data.Close();

                    if (i > 1)
                    {
                        return 1;
                    }
                    else
                    {
                        query = new SqlCommand($"SELECT \"zwierzak\" as pet FROM \"Hodowla\" WHERE \"klient_id\" = {owner_id} AND \"zwierzak\".checkDanger({anim_danger}) = -1", conn);
                        data = query.ExecuteReader();

                        i = 0;

                        while (data.Read()) 
                        {
                            i++;
                        }
                        data.Close();

                        if(i >= 3)
                        {
                            return 1;
                        }

                    }
                }
            }

            return 0; 
        }
    }
    public class Wyzwalacze 
    {
        [SqlTrigger(Target = "[dbo].[Hodowla]", Event = "FOR INSERT")]
        public static void ValidateAnimal()
        {
           
            using (SqlConnection conn = new SqlConnection("context connection = true"))
            {
     
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM inserted WHERE (\"zwierzak\".Endangered = 1 AND \"CITES\" IS NULL) OR (\"zwierzak\".Danger = 10 AND \"DangerDocument\" IS NULL)", conn);

                int num = (int)cmd.ExecuteScalar();

                if (num > 0)
                {
                        
                    SqlContext.Pipe.Send("Missing Documents for an animal!!");
                    Transaction.Current.Rollback();
                }
                
            }
        }
        [SqlTrigger(Target = "[dbo].[Przedmioty]", Event = "FOR INSERT")]
        public static void UpdateHodowla() 
        {
            using ( SqlConnection conn = new SqlConnection("context connection = true"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT z.\"data_otrzymania\" AS data FROM \"Zamówienie\" z JOIN INSERTED ON z.\"id\" = INSERTED.\"zamówienie_id\"", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                if (reader.HasRows && !reader.IsDBNull(reader.GetOrdinal("data")))
                {
                    string date = (string)reader["data"];
                    reader.Close();

                    cmd = new SqlCommand("SELECT z.\"zwierzak\" as pet FROM INSERTED JOIN \"Zwierzę\" z ON INSERTED.\"zwierze_id\" = z.\"id\"", conn);
                    reader = cmd.ExecuteReader();

                    reader.Read();
                    
                    if(reader.HasRows)
                    {
                        Animal animal = (Animal)reader["pet"];
                        reader.Close();
                        

                        cmd = new SqlCommand("SELECT k.\"id\" as owner_id, (k.\"imie\" + ' ' + k.\"nazwisko\") as owner FROM INSERTED JOIN \"Zamówienie\" z ON z.\"id\" = INSERTED.\"zamówienie_id\" JOIN \"Klient\" k ON k.\"id\" = z.\"klient_id\"", conn);
                        reader = cmd.ExecuteReader();

                        reader.Read();
                        string owner = (string)reader["owner"];
                        int owner_id = (int)reader["owner_id"];
                        reader.Close();

                        string animal_str = animal.Family + "," + animal.Species + "," + animal.Type + ","
                                          + animal.Gender + "," + animal.Maturity + "," + animal.NumOfChildren + ","
                                          + animal.Danger + "," + ((animal.Endangered) ? "true" : "false");

                        string danger_str = (animal.Danger == 10) ? owner + ";" + animal_str + ";" + date : "";
                        
                        string cites_str = (animal.Endangered) ? owner + ";" + animal_str + ";" + date : "";

                        cmd = new SqlCommand($"INSERT INTO \"Hodowla\"(\"klient_id\", \"zwierzak\", \"CITES\", \"DangerDocument\") VALUES ({owner_id},'{animal_str}','{cites_str}','{danger_str}')", conn);
                        cmd.ExecuteNonQuery();
                    }

                    if (!reader.IsClosed) reader.Close();
                }

                if(!reader.IsClosed) reader.Close();
            }
        }
        [SqlTrigger(Target = "[dbo].[Zamówienie]", Event = "FOR UPDATE")]
        public static void UpdateHodowlaDate()
        {
            using (SqlConnection conn = new SqlConnection("context connection = true"))
            {
               conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT d.\"data_otrzymania\" as before, i.\"data_otrzymania\" as after FROM INSERTED i JOIN DELETED d ON d.\"id\" = i.\"id\"", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                if (reader.HasRows)
                {
                    if (reader.IsDBNull(reader.GetOrdinal("before")) && !reader.IsDBNull(reader.GetOrdinal("after")))
                    {
                        string date = (string)reader["after"];
                        reader.Close();

                        cmd = new SqlCommand("SELECT z.\"zwierzak\" as pet FROM INSERTED JOIN \"Przedmioty\" p ON p.\"zamówienie_id\" = INSERTED.\"id\" JOIN \"Zwierzę\" z ON z.\"id\" = p.\"zwierze_id\"", conn);
                        reader = cmd.ExecuteReader();

                        reader.Read();

                        if(reader.HasRows && !reader.IsDBNull(reader.GetOrdinal("pet"))) 
                        {
                            Animal animal = (Animal)reader["pet"];
                            reader.Close();

                            cmd = new SqlCommand("SELECT k.\"id\" as owner_id, (k.\"imie\" + ' ' + k.\"nazwisko\") as owner FROM INSERTED JOIN \"Klient\" k ON k.\"id\" = INSERTED.\"klient_id\"", conn);
                            reader = cmd.ExecuteReader();

                            reader.Read();
                            int owner_id = (int)reader["owner_id"];
                            string owner = (string)reader["owner"];
                            reader.Close();

                            string animal_str = animal.Family + "," + animal.Species + "," + animal.Type + ","
                                          + animal.Gender + "," + animal.Maturity + "," + animal.NumOfChildren + ","
                                          + animal.Danger + "," + ((animal.Endangered) ? "true" : "false");

                            string danger_str = (animal.Danger == 10) ? owner + ";" + animal_str + ";" + date : "";

                            string cites_str = (animal.Endangered) ? owner + ";" + animal_str + ";" + date : "";

                            cmd = new SqlCommand($"INSERT INTO \"Hodowla\"(\"klient_id\", \"zwierzak\", \"CITES\", \"DangerDocument\") VALUES ({owner_id},'{animal_str}','{cites_str}','{danger_str}')", conn);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                if (!reader.IsClosed) reader.Close();
            }
        }
        [SqlTrigger(Target = "[dbo].[Przedmioty]", Event = "FOR INSERT")]
        public static void RemoveItem() 
        {
            using (SqlConnection conn = new SqlConnection("context connection = true"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT z.\"ilość\" as ilosc FROM INSERTED JOIN \"Zamówienie\" z ON INSERTED.\"zamówienie_id\" = z.\"id\"", conn);
                SqlDataReader reader = cmd.ExecuteReader(); 

                reader.Read();
                int quant = (int)reader["ilosc"];
                reader.Close();

                cmd = new SqlCommand("SELECT z.\"ilosc\" as q_z, z.\"id\" as z_id FROM INSERTED i JOIN \"Zwierzę\" z ON z.\"id\" = i.\"zwierze_id\"", conn);
                reader = cmd.ExecuteReader();

                reader.Read();
                int quant_z = (reader.HasRows && !reader.IsDBNull(0)) ? (int)reader["q_z"] : 0;
                int z_id = (reader.HasRows && !reader.IsDBNull(1)) ? (int)reader["z_id"] : 0;
                reader.Close();

                cmd = new SqlCommand("SELECT p.\"ilosc\" as q_p, p.\"id\" as p_id FROM INSERTED i JOIN \"Pojemnik\" p ON p.\"id\" = i.\"pojemnik_id\"", conn);
                reader = cmd.ExecuteReader();

                reader.Read();
                int quant_p = (reader.HasRows && !reader.IsDBNull(0)) ? (int)reader["q_p"] : 0;
                int p_id = (reader.HasRows && !reader.IsDBNull(1)) ? (int)reader["p_id"] : 0;
                reader.Close();

                cmd = new SqlCommand("SELECT n.\"ilosc\" as q_n, n.\"id\" as n_id FROM INSERTED i JOIN \"Narzędzie\" n ON n.\"id\" = i.\"narzedzie_id\"", conn);
                reader = cmd.ExecuteReader();

                reader.Read();
                int quant_n = (reader.HasRows && !reader.IsDBNull(0)) ? (int)reader["q_n"] : 0;
                int n_id = (reader.HasRows && !reader.IsDBNull(1)) ? (int)reader["n_id"] : 0;
                reader.Close();

                if (quant <= quant_z && z_id != 0)
                {
                    cmd = new SqlCommand($"UPDATE \"Zwierzę\" SET \"ilosc\" = {quant_z - quant} WHERE \"id\" = {z_id}", conn);
                    cmd.ExecuteNonQuery();  
                }
                if (z_id != 0 && quant > quant_z)
                {
                    SqlContext.Pipe.Send("Ordered more animals than available in store!");
                    Transaction.Current.Rollback();
                }

                if(quant <= quant_p && p_id != 0) 
                {
                    cmd = new SqlCommand($"UPDATE \"Pojemnik\" SET \"ilosc\" = {quant_p - quant} WHERE \"id\" = {p_id}", conn);
                    cmd.ExecuteNonQuery();
                }
                if(p_id != 0 && quant > quant_p)
                {
                    SqlContext.Pipe.Send("Ordered more enclosures than available in store!");
                    Transaction.Current.Rollback();
                }

                if(quant <= quant_n && n_id != 0)
                {
                    cmd = new SqlCommand($"UPDATE \"Narzędzie\" SET \"ilosc\" = {quant_n - quant} WHERE \"id\" = {n_id}", conn);
                    cmd.ExecuteNonQuery();
                }
                if(n_id != 0 && quant > quant_n)
                {
                    SqlContext.Pipe.Send("Ordered more tools than available in store!");
                    Transaction.Current.Rollback();
                }
            }
        }
    }
}
