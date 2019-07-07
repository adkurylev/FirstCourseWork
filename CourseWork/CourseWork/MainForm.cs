#define connection
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class MainCameraForm : Form
    {
        public MainCameraForm()
        {
            InitializeComponent();
        }
        #region Fields
        /// <summary>
        /// Массивы кнопок для удобного к ним доступа
        /// </summary>
        Button[] buttons, cameraButtons;

        /// <summary>
        /// Адрес Raspberry Pi
        /// </summary>
        public static string uri = "http://192.168.0.101/";

        /// <summary>
        /// Адресс для FilesForm
        /// </summary>
        string fw = uri;

        /// <summary>
        /// Экземпляр класс HttpClient для связи с сервером и отправки GET запросов
        /// </summary>
        HttpClient client = new HttpClient();

        /// <summary>
        /// Счетчик для поворота сервомотора
        /// </summary>
        int flag = 1;

        /// <summary>
        /// Конечная позиция сервомотора
        /// </summary>
        public static int finalPosition = 250;

        /// <summary>
        /// Количество поворотов сервомотора в одну сторону до достижения конечной позиции
        /// </summary>
        int turnValue = (finalPosition - 50) / 25 - 1;

        /// <summary>
        /// Задержка между поворотами сервомотора в миллисекундах
        /// </summary>
        public static int turningTimerDelay = 10000;
        #endregion

        /// <summary>
        /// Обработчик события загрузки формы
        /// </summary>
        /// <remarks>
        /// Отвечает за начальное состояние кнопок и установку интервала таймера
        /// </remarks>
        private void MainCameraForm_Load(object sender, EventArgs e)
        {
            buttons = new Button[] { startCameraButton, stopCameraButton, startRecordingButton,
                stopRecordingButton, startMDButton, stopMDButton, takePictureButton, moveLeftButton, moveRightButton, startTurningButton };

            cameraButtons = new Button[] { startRecordingButton,
                stopRecordingButton, startMDButton, stopMDButton, takePictureButton, moveLeftButton, moveRightButton, startTurningButton };

            Array.ForEach(buttons, 
                x => { x.Enabled = false;
                    x.TabStop = false; });

            turningTimer.Interval = turningTimerDelay;
        }
        #region Buttons Click
        /// <summary>
        /// Обработчик события нажатия на кнопку "Connect"
        /// </summary>
        /// <remarks>
        /// Делает кнопки активными и запускает таймер обновления изображения
        /// </remarks>
        private void connectButton_Click(object sender, EventArgs e)
        {
            Array.ForEach(buttons, x => x.Enabled = !x.Enabled);
            connectButton.Visible = !connectButton.Visible;
            cameraPictureTimer.Enabled = !cameraPictureTimer.Enabled;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Stop Camera"
        /// </summary>
        /// <remarks>
        /// Меняет состояния кнопок и посылает запрос об остановке камеры на сервер
        /// </remarks>
        private async void stopCameraButton_Click(object sender, EventArgs e)
        {
            stopCameraButton.Enabled = false;
#if connection
            await client.GetAsync(uri + "html/cmd_pipe.php?cmd=ru%200");
#endif
            stopCameraButton.Enabled = true;
            Array.ForEach(cameraButtons, x => x.Enabled = !x.Enabled);
            stopCameraButton.Visible = false;
            startCameraButton.Visible = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Start Camera"
        /// </summary>
        /// <remarks>
        /// Меняет состояния кнопок и посылает запрос о запуске камеры на сервер
        /// </remarks>
        private async void startCameraButton_Click(object sender, EventArgs e)
        {
            startCameraButton.Enabled = false;
#if connection
            await client.GetAsync(uri + "html/cmd_pipe.php?cmd=ru%201");
#endif
            startCameraButton.Enabled = true;
            Array.ForEach(cameraButtons, x => x.Enabled = !x.Enabled);
            startCameraButton.Visible = false;
            stopCameraButton.Visible = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Stop Recording"
        /// </summary>
        /// <remarks>
        /// Меняет состояния кнопок и посылает запрос об остановке записи на сервер
        /// </remarks>
        private async void stopRecordingButton_Click(object sender, EventArgs e)
        {
            stopRecordingButton.Enabled = false;
#if connection
            await client.GetAsync(uri + "html/cmd_pipe.php?cmd=ca%200");
#endif
            stopRecordingButton.Enabled = true;
            startMDButton.Enabled = true;
            stopCameraButton.Enabled = true;
            stopRecordingButton.Visible = false;
            startRecordingButton.Visible = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Start Recording"
        /// </summary>
        /// <remarks>
        /// Меняет состояния кнопок и посылает запрос о начале записи на сервер
        /// </remarks>
        private async void startRecordingButton_Click(object sender, EventArgs e)
        {
            startRecordingButton.Enabled = false;
#if connection
            await client.GetAsync(uri + "html/cmd_pipe.php?cmd=ca%201");
#endif
            startRecordingButton.Enabled = true;
            startMDButton.Enabled = false;
            stopCameraButton.Enabled = false;
            startRecordingButton.Visible = false;
            stopRecordingButton.Visible = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Stop Motion Detection"
        /// </summary>
        /// <remarks>
        /// Меняет состояния кнопок и посылает запрос об остановке режима Motion Detection на сервер
        /// </remarks>
        private async void stopMDButton_Click(object sender, EventArgs e)
        {
            stopMDButton.Enabled = false;
#if connection
            await client.GetAsync(uri + "html/cmd_pipe.php?cmd=md%200");
#endif
            stopMDButton.Enabled = true;
            startRecordingButton.Enabled = true;
            stopCameraButton.Enabled = true;
            stopMDButton.Visible = false;
            startMDButton.Visible = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Start Motion Detection"
        /// </summary>
        /// <remarks>
        /// Меняет состояния кнопок и посылает запрос о запуске режима Motion Detection на сервер
        /// </remarks>
        private async void startMDButton_Click(object sender, EventArgs e)
        {
            startMDButton.Enabled = false;
#if connection
            await client.GetAsync(uri + "html/cmd_pipe.php?cmd=md%201");
#endif
            startMDButton.Enabled = true;
            startRecordingButton.Enabled = false;
            stopCameraButton.Enabled = false;
            startMDButton.Visible = false;
            stopMDButton.Visible = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Taje Picture"
        /// </summary>
        /// <remarks>
        /// Посылает запрос о съемки фотографии на сервер
        /// </remarks>
        private async void takePictureButton_Click(object sender, EventArgs e)
        {
            takePictureButton.Enabled = false;
#if connection
            await client.GetAsync(uri + "html/cmd_pipe.php?cmd=im");
#endif
            takePictureButton.Enabled = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Move Left Button"
        /// </summary>
        /// <remarks>
        /// Посылает запрос о смене состояния сервомотора на сервер
        /// </remarks>
        private async void moveLeftButton_Click(object sender, EventArgs e)
        {
            moveLeftButton.Enabled = false;
#if connection
            await client.GetAsync(uri + "servo/turnleft.php");
#endif
            moveLeftButton.Enabled = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Move Right Button"
        /// </summary>
        /// <remarks>
        /// Посылает запрос о смене состояния сервомотора на сервер
        /// </remarks>
        private async void moveRightButton_Click(object sender, EventArgs e)
        {
            moveRightButton.Enabled = false;
#if connection
            await client.GetAsync(uri + "servo/turnright.php");
#endif
            moveRightButton.Enabled = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Start Turning"
        /// </summary>
        /// <remarks>
        /// Меняет интервал таймера и состояние кнопок, отправляет запрос на сервер об изменении положения сервомотора, запускает таймер
        /// </remarks>
        private async void StartTurningButton_Click(object sender, EventArgs e)
        {
            turningTimer.Interval = turningTimerDelay;
            startTurningButton.Enabled = false;
#if connection
            await client.GetAsync(uri + "servo/initialposition.php");
#endif
            startTurningButton.Enabled = true;
            startTurningButton.Visible = false;
            turningTimer.Enabled = true;
            stopTurningButton.Visible = true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Stop Turning"
        /// </summary>
        /// <remarks>
        /// Останавливает таймер и меняет состояние кнопок
        /// </remarks>
        private void stopTurningButton_Click(object sender, EventArgs e)
        {
            stopTurningButton.Visible = false;
            turningTimer.Enabled = false;
            startTurningButton.Visible = true;
        }
        #endregion
        #region Menu Items Click
        /// <summary>
        /// Обработчик события нажатия на элемент "Settings" меню
        /// </summary>
        /// <remarks>
        /// Открывает форму SettingsForm и меняет некоторые настройки, если была нажата кнопка "Apply"
        /// </remarks>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                uri = settingsForm.settings.Ip;
                turningTimerDelay = settingsForm.settings.Delay;
                finalPosition = settingsForm.settings.FinalPosition;
                fw = settingsForm.settings.Ip;
            }
        }

        /// <summary>
        /// Обработчик события нажатия на элемент "Files" меню
        /// </summary>
        /// <remarks>
        /// Открывает форму FilesForm
        /// </remarks>
        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FilesForm filesForm = new FilesForm();
                filesForm.uri = fw;
                filesForm.url = fw + "html/preview.php";
                filesForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Обработчик события нажатия на элемент "About" меню
        /// </summary>
        /// <remarks>
        /// Открывает форму AboutForm
        /// </remarks>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Обработчик события нажатия на элемент "Information" меню
        /// </summary>
        /// <remarks>
        /// Открывает форму AboutForm
        /// </remarks>
        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
#endregion
        #region Timer Ticks
        /// <summary>
        /// Обработчик события тика таймера
        /// </summary>
        /// <remarks>
        /// Пробует загрузить изображение с камеры, если не удается, деактивирует кнопки и уведомляет пользователя
        /// </remarks>
        private void cameraPictureTimer_Tick(object sender, EventArgs e)
        {
            try
            {
#if connection
                cameraPictureBox.Load(uri + "html/cam_pic.php");
#endif
            }
            catch (Exception)
            {
                Array.ForEach(buttons, x => x.Enabled = !x.Enabled);
                connectButton.Visible = !connectButton.Visible;
                cameraPictureTimer.Enabled = !cameraPictureTimer.Enabled;
                MessageBox.Show("Can't connect to the server.", "Error");
            }
        }

        /// <summary>
        /// Обработчик события тика таймера
        /// </summary>
        /// <remarks>
        /// Отслеживает количество поворотов, отправляется запросы на сервер о повороте сервомотора, меняет направление поворота
        /// </remarks>
        private async void turningTimer_Tick(object sender, EventArgs e)
        {
#if connection
            if(flag == turnValue + 1)
            {
                flag = -1;
            }

            if(flag == -(turnValue + 1))
            {
                flag = 1;
            }

            if(flag > 0)
            {
                await client.GetAsync(uri + "servo/turnright.php");
                flag++;
            }

            if(flag < 0)
            {
                await client.GetAsync(uri + "servo/turnleft.php");
                flag--;
            }
#endif
        }
        #endregion
    }
}
