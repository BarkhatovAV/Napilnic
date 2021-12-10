using System;
using System.Data;
using System.IO;
using System.Reflection;

namespace ConsoleApp9
{
    class Program
    {
		private void checkButton_Click()
		{
			if (this.passportTextbox.Text.Trim() == "")
			{
				int num1 = (int)MessageBox.Show("Введите серию и номер паспорта");
			}
			else
			{
				HandleInput();
			}
		}

		private void HandleInput()
		{
			string rawData = this.passportTextbox.Text.Trim().Replace(" ", string.Empty);
			if (rawData.Length < 10)
			{
				this.textResult.Text = "Неверный формат серии или номера паспорта";
			}
			else
			{
				TryConnect(rawData);
			}
		}

		private void TryConnect(string rawData)
		{
			string commandText = string.Format("select * from passports where num='{0}' limit 1;", (object)Form1.ComputeSha256Hash(rawData));
			string connectionString = string.Format("Data Source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\db.sqlite");
			try
			{
				Connect(commandText, connectionString);
			}
			catch (SQLiteException ex)
			{
				if (ex.ErrorCode != 1)
					return;
				int num2 = (int)MessageBox.Show("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");
			}
		}

		private void Connect(string commandText, string connectionString)
		{
			SQLiteConnection connection = new SQLiteConnection(connectionString);
			connection.Open();
			SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(new SQLiteCommand(commandText, connection));
			DataTable dataTable1 = new DataTable();
			DataTable dataTable2 = dataTable1;
			sqLiteDataAdapter.Fill(dataTable2);
			VerifyDataTableRows(dataTable1);
		}

		private void VerifyDataTableRows(DataTable dataTable)
		{
			if (dataTable.Rows.Count > 0)
			{
				ShowMessage(dataTable);
			}
			else
				this.textResult.Text = "Паспорт «" + this.passportTextbox.Text + "» в списке участников дистанционного голосования НЕ НАЙДЕН";
		}

		private void ShowMessage(DataTable dataTable)
		{
			if (Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]))
				this.textResult.Text = "По паспорту «" + this.passportTextbox.Text + "» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
			else
				this.textResult.Text = "По паспорту «" + this.passportTextbox.Text + "» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
		}
	}
}
