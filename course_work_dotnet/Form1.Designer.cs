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
            SuspendLayout();
            // 
            // textBoxEdges
            // 
            textBoxEdges.Location = new Point(340, 524);
            textBoxEdges.Name = "textBoxEdges";
            textBoxEdges.Size = new Size(180, 23);
            textBoxEdges.TabIndex = 2;
            // 
            // textBoxPrufer
            // 
            textBoxPrufer.Location = new Point(631, 524);
            textBoxPrufer.Name = "textBoxPrufer";
            textBoxPrufer.Size = new Size(185, 23);
            textBoxPrufer.TabIndex = 3;
            // 
            // buttonEncode
            // 
            buttonEncode.Location = new Point(388, 553);
            buttonEncode.Name = "buttonEncode";
            buttonEncode.Size = new Size(100, 23);
            buttonEncode.TabIndex = 4;
            buttonEncode.Text = "Кодировать";
            buttonEncode.UseVisualStyleBackColor = true;
            buttonEncode.Click += buttonEncode_Click;
            // 
            // buttonDecode
            // 
            buttonDecode.Location = new Point(680, 553);
            buttonDecode.Name = "buttonDecode";
            buttonDecode.Size = new Size(98, 23);
            buttonDecode.TabIndex = 5;
            buttonDecode.Text = "Декодировать";
            buttonDecode.UseVisualStyleBackColor = true;
            buttonDecode.Click += buttonDecode_Click;
            // 
            // drawingPanel
            // 
            drawingPanel.Location = new Point(31, 12);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(1073, 466);
            drawingPanel.TabIndex = 6;
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
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxEdges;
        private TextBox textBoxPrufer;
        private Button buttonEncode;
        private Button buttonDecode;
        private Panel drawingPanel;
    }
}
