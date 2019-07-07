using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class SettingsForm : Form
    {
        public SettingsClass settings;

        public SettingsForm()
        {
            InitializeComponent();
        }

        #region Buttons Click

        /// <summary>
        /// Обработчик события нажатия на кнопку "Import"
        /// </summary>
        /// <remarks>
        /// Импортирует настройки из выбранного файла
        /// </remarks>
        private void ImportButton_Click(object sender, EventArgs e)
        {
            var dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.Abort || dialogResult == DialogResult.Cancel)
                return;

            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(SettingsClass));
            SettingsClass settings = null;

            using(FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
            {
                try
                {
                    settings = (SettingsClass)formatter.ReadObject(fs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Import Error");
                    return;
                }
            }

            MessageBox.Show("Import completed successfully.", "Completed");
            delayTextBox.Text = settings.Delay.ToString();
            ipTextBox.Text = settings.Ip;
            servoTextBox.Text = settings.FinalPosition.ToString();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Export"
        /// </summary>
        /// <remarks>
        /// Экспортирует настройки в выбранный файл
        /// </remarks>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            SettingsClass exportSettings = null;
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(SettingsClass));

            try
            {
                exportSettings = new SettingsClass(ipTextBox.Text, delayTextBox.Text, servoTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Error.");
                return;
            }

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))
            {
                try
                {
                    formatter.WriteObject(fs, exportSettings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return;
                }
            }

            MessageBox.Show("Export completed successfully.", "Completed");
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Apply"
        /// </summary>
        /// <remarks>
        /// Инициализирует объект класса SettingsClass, возвращает OK в качестве DialogResult и закрывает форму
        /// </remarks>
        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                settings = new SettingsClass("http://" + ipTextBox.Text + "/", delayTextBox.Text, servoTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion
    }
}
