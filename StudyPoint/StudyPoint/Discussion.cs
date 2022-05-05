﻿using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyPoint
{
    internal class DISCUSSION
    {

        CONNECT_DISCUSSION connection = new CONNECT_DISCUSSION();
        //Crypting crypting = new Crypting();

        public bool AddHelper(int i)
        {


            //String encryptedPassword = crypting.Encrypt(password);
            MySqlCommand komento = new MySqlCommand();

            String lisays = "INSERT INTO topicnames " +
           "(topic) " +
           "VALUES (@txt); ";
            komento.CommandText = lisays;
            komento.Connection = connection.Connection();
            //@txt
            komento.Parameters.Add("@txt", MySqlDbType.Text).Value = "topic" + i;
            //komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
            //komento.Parameters.Add("@eml", MySqlDbType.VarChar).Value = email;
            //komento.Parameters.Add("@kid", MySqlDbType.UInt32).Value = userId;
            //komento.Parameters.Add("@pwd", MySqlDbType.VarChar).Value = encryptedPassword;
            //MessageBox.Show("Käyttäjätunnuksesi on " + email);

            connection.OpenConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.CloseConnection();
                return true;
            }
            else
            {
                connection.CloseConnection();
                return false;
            }
        }

        //lisää uuden käyttäjän
        public bool AddTopic(String topicName )
        {


            //String encryptedPassword = crypting.Encrypt(password);
            MySqlCommand komento = new MySqlCommand();
            String makeTopic = "CREATE TABLE " + topicName  +
                "(numb int NOT NULL AUTO_INCREMENT, " +
                "otsikko varchar (70), " +
                "teksti text(500), " +
                "PRIMARY KEY (numb))";            
             
            komento.CommandText = makeTopic;
            komento.Connection = connection.Connection();
            connection.OpenConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.CloseConnection();
                return true;
            }
            else
            {
                connection.CloseConnection();
                return false;
            }
        }

        public bool AddTopicText(String topicName, String teksti)
        {


            //String encryptedPassword = crypting.Encrypt(password);
            MySqlCommand komento = new MySqlCommand();

            String lisays = "INSERT INTO " + topicName +
           "(teksti) " +
           "VALUES (@txt); ";            
            komento.CommandText = lisays;
            komento.Connection = connection.Connection();
            //@txt
            komento.Parameters.Add("@txt", MySqlDbType.Text).Value = teksti;
            //komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
            //komento.Parameters.Add("@eml", MySqlDbType.VarChar).Value = email;
            //komento.Parameters.Add("@kid", MySqlDbType.UInt32).Value = userId;
            //komento.Parameters.Add("@pwd", MySqlDbType.VarChar).Value = encryptedPassword;
            //MessageBox.Show("Käyttäjätunnuksesi on " + email);

            connection.OpenConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.CloseConnection();
                return true;
            }
            else
            {
                connection.CloseConnection();
                return false;
            }
        }

        //tester
        public void test()
        {
            List<String> list = new List<String>();
            connection.OpenConnection();
            DataTable schema = connection.Connection().GetSchema("Tables");

            MessageBox.Show(schema.Rows[2][2].ToString());
            foreach (DataRow row in schema.Rows)
            {
                list.Add(row.ToString());
                MessageBox.Show(row[2].ToString());
            }

            
        }


        //hae oikeat topicit
        public List<string> MainTopic(int x)
        {
            List<String> list = new List<String>();
            connection.OpenConnection();
            DataTable schema = connection.Connection().GetSchema("Tables");
            for (int i = x; i < x+4; i++)
            {
                list.Add(schema.Rows[i][2].ToString());
            }
            return list;
            
        }


        // tester 2

        public bool tester()
        {


            MySqlCommand komento = new MySqlCommand();

            String lisays = "SHOW TABLE";
            komento.CommandText = lisays;
            komento.Connection = connection.Connection();
            //@txt
            //komento.Parameters.Add("@txt", MySqlDbType.Text).Value = teksti;
            //komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
            //komento.Parameters.Add("@eml", MySqlDbType.VarChar).Value = email;
            //komento.Parameters.Add("@kid", MySqlDbType.UInt32).Value = userId;
            //komento.Parameters.Add("@pwd", MySqlDbType.VarChar).Value = encryptedPassword;
            //MessageBox.Show("Käyttäjätunnuksesi on " + email);

            connection.OpenConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.CloseConnection();
                return true;
            }
            else
            {
                connection.CloseConnection();
                return false;
            }
        }


        /*
        //tarkistetaan käyttäjä ja salasana
        public string CheckPassword(string email, string password)
        {
            password = password.Trim();
            password = crypting.Encrypt(password);
            connection.OpenConnection();
            MySqlCommand komento = new MySqlCommand("SELECT salasana FROM kayttajat WHERE sahkoposti = '" + email + "'", connection.Connection());

            var sana = (string)komento.ExecuteScalar();
            connection.CloseConnection();

            if (sana == password)
            {
                return email;
            }
            else
            {
                return "";
            }


        }
        */
        //tarkistaa onko jo käyttäjä olemassa

        /*
        public bool GetTopics()
        {

            connection.OpenConnection();
            MySqlCommand komento = new MySqlCommand("SELECT FROM kayttajat WHERE sahkoposti = '" + email + "'", connection.Connection());
            
            var sana = (string)komento.ExecuteScalar();
            connection.CloseConnection();

            if (sana == email)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        */
        /*
        //tarkistaa onko käyttäjä admin
        public bool checkAdmin(string email)
        {

            connection.OpenConnection();
            MySqlCommand komento = new MySqlCommand("SELECT admin FROM kayttajat WHERE sahkoposti = '" + email + "'", connection.Connection());

            var status = (int)komento.ExecuteScalar();
            connection.CloseConnection();

            if (status == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }



        /* Tätä pitää muokata sen mukaan mihin laitetaan ja miten laitetaan tietojen muokkaus*/
        // Luodaan funktio käyttäjän tietojen muokkaamiseksi

        /*
        public bool EditUser(String enimi, String snimi, String email, int UserId)
        {
            MySqlCommand komento = new MySqlCommand();
            String paivityskysely = "UPDATE `kayttajat` SET `etunimi`= @enm," +
                "`sukunimi`= @snm,`sahkoposti`= @eml" +
                " WHERE userid = @uid";
            komento.CommandText = paivityskysely;
            komento.Connection = connection.Connection();
            //@enm, @snm, @eml, @uid
            komento.Parameters.Add("@enm", MySqlDbType.VarChar).Value = enimi;
            komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
            komento.Parameters.Add("@eml", MySqlDbType.VarChar).Value = email;
            //komento.Parameters.Add("@uid", MySqlDbType.UInt32).Value = UserId;


            connection.OpenConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.CloseConnection();
                return true;
            }
            else
            {
                connection.CloseConnection();
                return false;
            }
        }

        // Luodaan funktio käyttäjän tietojen poistamiseen
        // tähän tarvitaan vain käyttäjätunnus
        public bool DeleteUser(int userId)
        {
            MySqlCommand komento = new MySqlCommand();
            String poistokysely = "DELETE FROM yhteystiedot WHERE userid = @uid";
            komento.CommandText = poistokysely;
            komento.Connection = connection.Connection();
            //@oid
            komento.Parameters.Add("@uid", MySqlDbType.UInt32).Value = userId;

            connection.OpenConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.CloseConnection();
                return true;
            }
            else
            {
                connection.CloseConnection();
                return false;
            }
        }
        */
        /*
        public String salasana()
        {
            char[] jono = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            String ssana = "";
            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                ssana += jono[rnd.Next(0, 61)];
            }
            return ssana;
        }
        

        public bool ChangePassword(String password, int UserId)
        {
            MySqlCommand komento = new MySqlCommand();
            String paivityskysely = "UPDATE `yhteystiedot` SET `password`= @pwd," +
                " WHERE userid = @uid";
            komento.CommandText = paivityskysely;
            komento.Connection = connection.Connection();
            //@pwd
            komento.Parameters.Add("@pwd", MySqlDbType.UInt32).Value = password;



            connection.OpenConnection();
            if (komento.ExecuteNonQuery() == 1)
            {
                connection.CloseConnection();
                return true;
            }
            else
            {
                connection.CloseConnection();
                return false;
            }
        }
        */

    }
}
