namespace course_work_dotnet
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxEdges = new TextBox();
            textBoxPrufer = new TextBox();
            buttonEncode = new Button();
            buttonDecode = new Button();
            drawingPanel = new Panel();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            рёбраToolStripMenuItem = new ToolStripMenuItem();
            кодToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxEdges
            // 
            textBoxEdges.Location = new Point(344, 562);
            textBoxEdges.Name = "textBoxEdges";
            textBoxEdges.Size = new Size(180, 23);
            textBoxEdges.TabIndex = 2;
            // 
            // textBoxPrufer
            // 
            textBoxPrufer.Location = new Point(635, 562);
            textBoxPrufer.Name = "textBoxPrufer";
            textBoxPrufer.Size = new Size(185, 23);
            textBoxPrufer.TabIndex = 3;
            // 
            // buttonEncode
            // 
            buttonEncode.Location = new Point(392, 591);
            buttonEncode.Name = "buttonEncode";
            buttonEncode.Size = new Size(100, 23);
            buttonEncode.TabIndex = 4;
            buttonEncode.Text = "Кодировать";
            buttonEncode.UseVisualStyleBackColor = true;
            buttonEncode.Click += buttonEncode_Click;
            // 
            // buttonDecode
            // 
            buttonDecode.Location = new Point(684, 591);
            buttonDecode.Name = "buttonDecode";
            buttonDecode.Size = new Size(98, 23);
            buttonDecode.TabIndex = 5;
            buttonDecode.Text = "Декодировать";
            buttonDecode.UseVisualStyleBackColor = true;
            buttonDecode.Click += buttonDecode_Click;
            // 
            // drawingPanel
            // 
            drawingPanel.Location = new Point(35, 50);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(1073, 466);
            drawingPanel.TabIndex = 6;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, оПрограммеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1130, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохранитьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { рёбраToolStripMenuItem, кодToolStripMenuItem });
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(234, 22);
            сохранитьToolStripMenuItem.Text = "Сохранить в текстовый файл";
            // 
            // рёбраToolStripMenuItem
            // 
            рёбраToolStripMenuItem.Name = "рёбраToolStripMenuItem";
            рёбраToolStripMenuItem.Size = new Size(180, 22);
            рёбраToolStripMenuItem.Text = "Рёбра";
            рёбраToolStripMenuItem.Click += рёбраToolStripMenuItem_Click;
            // 
            // кодToolStripMenuItem
            // 
            кодToolStripMenuItem.Name = "кодToolStripMenuItem";
            кодToolStripMenuItem.Size = new Size(180, 22);
            кодToolStripMenuItem.Text = "Код";
            кодToolStripMenuItem.Click += кодToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(94, 20);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 667);
            Controls.Add(drawingPanel);
            Controls.Add(buttonDecode);
            Controls.Add(buttonEncode);
            Controls.Add(textBoxPrufer);
            Controls.Add(textBoxEdges);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxEdges;
        private TextBox textBoxPrufer;
        private Button buttonEncode;
        private Button buttonDecode;
        private Panel drawingPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem рёбраToolStripMenuItem;
        private ToolStripMenuItem кодToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}
