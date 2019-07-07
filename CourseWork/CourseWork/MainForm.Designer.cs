namespace CourseWork
{
    partial class MainCameraForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainCameraForm));
            this.connectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.moveRightButton = new System.Windows.Forms.Button();
            this.moveLeftButton = new System.Windows.Forms.Button();
            this.takePictureButton = new System.Windows.Forms.Button();
            this.stopMDButton = new System.Windows.Forms.Button();
            this.startMDButton = new System.Windows.Forms.Button();
            this.stopRecordingButton = new System.Windows.Forms.Button();
            this.startRecordingButton = new System.Windows.Forms.Button();
            this.stopCameraButton = new System.Windows.Forms.Button();
            this.startCameraButton = new System.Windows.Forms.Button();
            this.cameraPictureBox = new System.Windows.Forms.PictureBox();
            this.cameraPictureTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTurningButton = new System.Windows.Forms.Button();
            this.startTurningButton = new System.Windows.Forms.Button();
            this.turningTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(251, 336);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 35;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Move the camera";
            // 
            // moveRightButton
            // 
            this.moveRightButton.Location = new System.Drawing.Point(618, 296);
            this.moveRightButton.Name = "moveRightButton";
            this.moveRightButton.Size = new System.Drawing.Size(50, 34);
            this.moveRightButton.TabIndex = 33;
            this.moveRightButton.Text = "-->";
            this.moveRightButton.UseVisualStyleBackColor = true;
            this.moveRightButton.Click += new System.EventHandler(this.moveRightButton_Click);
            // 
            // moveLeftButton
            // 
            this.moveLeftButton.Location = new System.Drawing.Point(551, 296);
            this.moveLeftButton.Name = "moveLeftButton";
            this.moveLeftButton.Size = new System.Drawing.Size(50, 34);
            this.moveLeftButton.TabIndex = 32;
            this.moveLeftButton.Text = "<--";
            this.moveLeftButton.UseVisualStyleBackColor = true;
            this.moveLeftButton.Click += new System.EventHandler(this.moveLeftButton_Click);
            // 
            // takePictureButton
            // 
            this.takePictureButton.Location = new System.Drawing.Point(551, 212);
            this.takePictureButton.Name = "takePictureButton";
            this.takePictureButton.Size = new System.Drawing.Size(117, 34);
            this.takePictureButton.TabIndex = 31;
            this.takePictureButton.Text = "Take Picture";
            this.takePictureButton.UseVisualStyleBackColor = true;
            this.takePictureButton.Click += new System.EventHandler(this.takePictureButton_Click);
            // 
            // stopMDButton
            // 
            this.stopMDButton.Location = new System.Drawing.Point(551, 157);
            this.stopMDButton.Name = "stopMDButton";
            this.stopMDButton.Size = new System.Drawing.Size(117, 34);
            this.stopMDButton.TabIndex = 30;
            this.stopMDButton.Text = "Stop Motion Detection";
            this.stopMDButton.UseVisualStyleBackColor = true;
            this.stopMDButton.Visible = false;
            this.stopMDButton.Click += new System.EventHandler(this.stopMDButton_Click);
            // 
            // startMDButton
            // 
            this.startMDButton.Location = new System.Drawing.Point(551, 157);
            this.startMDButton.Name = "startMDButton";
            this.startMDButton.Size = new System.Drawing.Size(117, 34);
            this.startMDButton.TabIndex = 29;
            this.startMDButton.Text = "Start Motion Detection";
            this.startMDButton.UseVisualStyleBackColor = true;
            this.startMDButton.Click += new System.EventHandler(this.startMDButton_Click);
            // 
            // stopRecordingButton
            // 
            this.stopRecordingButton.Location = new System.Drawing.Point(551, 99);
            this.stopRecordingButton.Name = "stopRecordingButton";
            this.stopRecordingButton.Size = new System.Drawing.Size(117, 34);
            this.stopRecordingButton.TabIndex = 28;
            this.stopRecordingButton.Text = "Stop Recording";
            this.stopRecordingButton.UseVisualStyleBackColor = true;
            this.stopRecordingButton.Visible = false;
            this.stopRecordingButton.Click += new System.EventHandler(this.stopRecordingButton_Click);
            // 
            // startRecordingButton
            // 
            this.startRecordingButton.Location = new System.Drawing.Point(551, 99);
            this.startRecordingButton.Name = "startRecordingButton";
            this.startRecordingButton.Size = new System.Drawing.Size(117, 34);
            this.startRecordingButton.TabIndex = 27;
            this.startRecordingButton.Text = "Start Recording";
            this.startRecordingButton.UseVisualStyleBackColor = true;
            this.startRecordingButton.Click += new System.EventHandler(this.startRecordingButton_Click);
            // 
            // stopCameraButton
            // 
            this.stopCameraButton.Location = new System.Drawing.Point(551, 42);
            this.stopCameraButton.Name = "stopCameraButton";
            this.stopCameraButton.Size = new System.Drawing.Size(117, 34);
            this.stopCameraButton.TabIndex = 26;
            this.stopCameraButton.Text = "Stop Camera";
            this.stopCameraButton.UseVisualStyleBackColor = true;
            this.stopCameraButton.Click += new System.EventHandler(this.stopCameraButton_Click);
            // 
            // startCameraButton
            // 
            this.startCameraButton.Location = new System.Drawing.Point(551, 42);
            this.startCameraButton.Name = "startCameraButton";
            this.startCameraButton.Size = new System.Drawing.Size(117, 34);
            this.startCameraButton.TabIndex = 25;
            this.startCameraButton.Text = "Start Camera";
            this.startCameraButton.UseVisualStyleBackColor = true;
            this.startCameraButton.Visible = false;
            this.startCameraButton.Click += new System.EventHandler(this.startCameraButton_Click);
            // 
            // cameraPictureBox
            // 
            this.cameraPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cameraPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("cameraPictureBox.Image")));
            this.cameraPictureBox.Location = new System.Drawing.Point(12, 42);
            this.cameraPictureBox.Name = "cameraPictureBox";
            this.cameraPictureBox.Size = new System.Drawing.Size(512, 288);
            this.cameraPictureBox.TabIndex = 24;
            this.cameraPictureBox.TabStop = false;
            // 
            // cameraPictureTimer
            // 
            this.cameraPictureTimer.Interval = 30;
            this.cameraPictureTimer.Tick += new System.EventHandler(this.cameraPictureTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.menuToolStripMenuItem.Text = "Camera Menu";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.filesToolStripMenuItem.Text = "Files";
            this.filesToolStripMenuItem.Click += new System.EventHandler(this.filesToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.informationToolStripMenuItem.Text = "Information";
            this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // stopTurningButton
            // 
            this.stopTurningButton.Location = new System.Drawing.Point(551, 345);
            this.stopTurningButton.Name = "stopTurningButton";
            this.stopTurningButton.Size = new System.Drawing.Size(117, 26);
            this.stopTurningButton.TabIndex = 37;
            this.stopTurningButton.Text = "Stop turning";
            this.stopTurningButton.UseVisualStyleBackColor = true;
            this.stopTurningButton.Click += new System.EventHandler(this.stopTurningButton_Click);
            // 
            // startTurningButton
            // 
            this.startTurningButton.Location = new System.Drawing.Point(551, 345);
            this.startTurningButton.Name = "startTurningButton";
            this.startTurningButton.Size = new System.Drawing.Size(117, 26);
            this.startTurningButton.TabIndex = 38;
            this.startTurningButton.Text = "Start turning";
            this.startTurningButton.UseVisualStyleBackColor = true;
            this.startTurningButton.Click += new System.EventHandler(this.StartTurningButton_Click);
            // 
            // turningTimer
            // 
            this.turningTimer.Interval = 10000;
            this.turningTimer.Tick += new System.EventHandler(this.turningTimer_Tick);
            // 
            // MainCameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startTurningButton);
            this.Controls.Add(this.stopTurningButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moveRightButton);
            this.Controls.Add(this.moveLeftButton);
            this.Controls.Add(this.takePictureButton);
            this.Controls.Add(this.stopMDButton);
            this.Controls.Add(this.startMDButton);
            this.Controls.Add(this.stopRecordingButton);
            this.Controls.Add(this.startRecordingButton);
            this.Controls.Add(this.stopCameraButton);
            this.Controls.Add(this.startCameraButton);
            this.Controls.Add(this.cameraPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainCameraForm";
            this.Text = "Camera";
            this.Load += new System.EventHandler(this.MainCameraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button moveRightButton;
        private System.Windows.Forms.Button moveLeftButton;
        private System.Windows.Forms.Button takePictureButton;
        private System.Windows.Forms.Button stopMDButton;
        private System.Windows.Forms.Button startMDButton;
        private System.Windows.Forms.Button stopRecordingButton;
        private System.Windows.Forms.Button startRecordingButton;
        private System.Windows.Forms.Button stopCameraButton;
        private System.Windows.Forms.Button startCameraButton;
        private System.Windows.Forms.PictureBox cameraPictureBox;
        private System.Windows.Forms.Timer cameraPictureTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.Button stopTurningButton;
        private System.Windows.Forms.Button startTurningButton;
        private System.Windows.Forms.Timer turningTimer;
    }
}

