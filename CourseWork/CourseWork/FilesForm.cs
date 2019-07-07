using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class FilesForm : Form
    {
        #region Fields
        HttpClient client = new HttpClient();
        public string uri = "http://192.168.0.101/";
        public string url = "http://192.168.0.101/html/preview.php";
        GroupBox[] gbArray;
        #endregion

        public FilesForm()
        {
            InitializeComponent();
        }
        #region Methods
        /// <summary>
        /// Метод загрузки медиа-файлов и заполнения ими flowLayoutPanel1
        /// </summary>
        /// <remarks>
        /// Получает элементы, содержащие данные о файлах, преобразует их в необходимые 
        /// поля даты, времени, превью и ссылки на файл, создает элементы GroupBox и добавляет их на flowLayoutPanel1
        /// </remarks>
        private async void FillThePanel()
        {
            HttpResponseMessage response = null;
            string pageSource = "";
            HtmlParser pageParser = new HtmlParser();
            IHtmlDocument htmlPage = null;

            try
            {
                response = await client.GetAsync(url);
                pageSource = await response.Content.ReadAsStringAsync();
                htmlPage = await pageParser.ParseDocumentAsync(pageSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                Close();
                return;
            }            

            Fieldset[] fieldsets = GetFieldsets(htmlPage);
            GroupBox[] groupBoxes = new GroupBox[fieldsets.Length];

            for (int i = 0; i < groupBoxes.Length; i++)
            {
                groupBoxes[i] = new GroupBox();
                groupBoxes[i].Margin = new Padding(10, 10, 10, 10);
                groupBoxes[i].Size = new Size(184, 131);
                groupBoxes[i].Text = $"   {fieldsets[i].Time}   {fieldsets[i].Date}   {fieldsets[i].Type}";
                groupBoxes[i].Controls.Add(new CheckBox() { Size = new Size(15,15)});
                PictureBox pictureBox = new PictureBox() { Location = new Point(2, 19), Size = new Size(180, 101), SizeMode = PictureBoxSizeMode.StretchImage };
                try
                {
                    pictureBox.Load(uri + fieldsets[i].Image);
                }
                catch
                {
                    pictureBox.Load("../../../camerapic.jpg");
                }

                groupBoxes[i].Controls.Add(pictureBox);
                flowLayoutPanel1.Controls.Add(groupBoxes[i]);
            }

            gbArray = flowLayoutPanel1.Controls.OfType<GroupBox>().ToArray();

            for (int i = 0; i < gbArray.Length - 1; i++)
            {
                gbArray[i] = gbArray[i + 1];
            }

            Array.Resize(ref gbArray, gbArray.Length - 1);

            if(gbArray.Length == 0)
            {
                flowLayoutPanel1.Controls.Add(new Label { Text = "No media to load." });
            }
        }

        /// <summary>
        /// Получает элементы Fieldset
        /// </summary>
        /// <param name="document">HTML документ</param>
        /// <returns>
        /// Массив элементов Fieldset
        /// </returns>
        private static Fieldset[] GetFieldsets(IHtmlDocument document)
        {
            List<Fieldset> list = new List<Fieldset>();
            IEnumerable<AngleSharp.Dom.IElement> items = null;

            try
            {
                items = document.QuerySelectorAll("fieldset");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            try
            {
                foreach (var item in items)
                {
                    list.Add(new Fieldset((IHtmlFieldSetElement)item));
                }
            }
            catch
            {
                MessageBox.Show("Try again later.", "Error");
            }

            return list.ToArray();
        }
        #endregion
        
        /// <summary>
        /// Обработчик события загрузки формы
        /// </summary>
        /// <remarks>
        /// Вызывает метод FillThePanel, заполняющий форму
        /// </remarks>
        private void FilesForm_Load(object sender, EventArgs e)
        {
            FillThePanel();
        }

        #region Buttons Click
        /// <summary>
        /// Обработчик события нажатия на кнопку "Select All"
        /// </summary>
        /// <remarks>
        /// Помечает свойство Checked всех элементов CheckBox как true
        /// </remarks>
        private void selectButton_Click(object sender, EventArgs e)
        {
            Array.ForEach(gbArray, x => x.Controls.OfType<CheckBox>().First().Checked = true);
            selectButton.Visible = false;
            deselectButton.Visible = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Deselect All"
        /// </summary>
        /// <remarks>
        /// Помечает свойство Checked всех элементов CheckBox как false
        /// </remarks>
        private void deselectButton_Click(object sender, EventArgs e)
        {
            Array.ForEach(gbArray, x => x.Controls.OfType<CheckBox>().First().Checked = false);
            deselectButton.Visible = false;
            selectButton.Visible = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку Download Selected"
        /// </summary>
        /// <remarks>
        /// Выполняет загрузку выбранных файлов в указанный каталог
        /// </remarks>
        private void downloadButton_Click(object sender, EventArgs e)
        {
            List<string> filesToDownload = new List<string>();

            try
            {
                for (int i = 0; i < gbArray.Length; i++)
                    if (gbArray[i].Controls.OfType<CheckBox>().First().Checked)
                    {
                        string downloadFileAdress = gbArray[i].Controls.OfType<PictureBox>().First().ImageLocation;
                        filesToDownload.Add(downloadFileAdress.Substring(0, downloadFileAdress.Length - 13));
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            if (!filesToDownload.Any())
            {
                MessageBox.Show("Files were not selected.", "Error");
                return;
            }

            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;

            WebClient wc = new WebClient();
            foreach (var i in filesToDownload)
            {
                try
                {
                    wc.DownloadFile(i, folderBrowserDialog1.SelectedPath + "/" + i.Split(new string[] { "/media/" }, StringSplitOptions.None)[1]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return;
                }    
            }

            MessageBox.Show("Download completed successfully.", "Completed");
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Delete All"
        /// </summary>
        /// <remarks>
        /// Отправляет POST запрос на сервер об удалении всех файлов и закрывает форму
        /// </remarks>
        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            if (gbArray.Length == 0)
                Close();

            WebRequest request = null;

            try
            {
                request = WebRequest.Create(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
            request.Method = "POST";
            string data = "action=deleteAll";
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                try
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return;
                }
            }

            Close();
        }
        #endregion
    }
}
