namespace Wczytywanie_ZPliku
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnWybierz = new System.Windows.Forms.Button();
            this.tbScieszka = new System.Windows.Forms.TextBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.listaRegulTextBox = new System.Windows.Forms.TextBox();
            this.autorLabel = new System.Windows.Forms.Label();
            this.coveringRadioButton = new System.Windows.Forms.RadioButton();
            this.exhaustiveRadioButton = new System.Windows.Forms.RadioButton();
            this.lem2RadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnWybierz
            // 
            this.btnWybierz.Location = new System.Drawing.Point(382, 15);
            this.btnWybierz.Margin = new System.Windows.Forms.Padding(2);
            this.btnWybierz.Name = "btnWybierz";
            this.btnWybierz.Size = new System.Drawing.Size(31, 19);
            this.btnWybierz.TabIndex = 0;
            this.btnWybierz.Text = "...";
            this.btnWybierz.UseVisualStyleBackColor = true;
            this.btnWybierz.Click += new System.EventHandler(this.btnWybierz_Click);
            // 
            // tbScieszka
            // 
            this.tbScieszka.Location = new System.Drawing.Point(8, 16);
            this.tbScieszka.Margin = new System.Windows.Forms.Padding(2);
            this.tbScieszka.Name = "tbScieszka";
            this.tbScieszka.ReadOnly = true;
            this.tbScieszka.Size = new System.Drawing.Size(370, 20);
            this.tbScieszka.TabIndex = 1;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // listaRegulTextBox
            // 
            this.listaRegulTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listaRegulTextBox.Location = new System.Drawing.Point(8, 112);
            this.listaRegulTextBox.Multiline = true;
            this.listaRegulTextBox.Name = "listaRegulTextBox";
            this.listaRegulTextBox.ReadOnly = true;
            this.listaRegulTextBox.Size = new System.Drawing.Size(405, 351);
            this.listaRegulTextBox.TabIndex = 2;
            // 
            // autorLabel
            // 
            this.autorLabel.AutoSize = true;
            this.autorLabel.Location = new System.Drawing.Point(172, 466);
            this.autorLabel.Name = "autorLabel";
            this.autorLabel.Size = new System.Drawing.Size(241, 13);
            this.autorLabel.TabIndex = 3;
            this.autorLabel.Text = "Krzysztof Biernacki ISI III gr.1,1 02.06.2016 ver. 1";
            // 
            // coveringRadioButton
            // 
            this.coveringRadioButton.AutoSize = true;
            this.coveringRadioButton.Location = new System.Drawing.Point(13, 42);
            this.coveringRadioButton.Name = "coveringRadioButton";
            this.coveringRadioButton.Size = new System.Drawing.Size(354, 17);
            this.coveringRadioButton.TabIndex = 4;
            this.coveringRadioButton.TabStop = true;
            this.coveringRadioButton.Text = "Algorytm z rodziny sekwencyjnie pokrywajacych (sequential covering) ";
            this.coveringRadioButton.UseVisualStyleBackColor = true;
            this.coveringRadioButton.MouseCaptureChanged += new System.EventHandler(this.btnWybierz_Click);
            // 
            // exhaustiveRadioButton
            // 
            this.exhaustiveRadioButton.AutoSize = true;
            this.exhaustiveRadioButton.Location = new System.Drawing.Point(13, 65);
            this.exhaustiveRadioButton.Name = "exhaustiveRadioButton";
            this.exhaustiveRadioButton.Size = new System.Drawing.Size(385, 17);
            this.exhaustiveRadioButton.TabIndex = 5;
            this.exhaustiveRadioButton.TabStop = true;
            this.exhaustiveRadioButton.Text = "Reguły wyczerpujace (exhaustive) - z uzyciem mamacierzy nieodróznialnosci";
            this.exhaustiveRadioButton.UseVisualStyleBackColor = true;
            this.exhaustiveRadioButton.MouseCaptureChanged += new System.EventHandler(this.btnWybierz_Click);
            // 
            // lem2RadioButton
            // 
            this.lem2RadioButton.AutoSize = true;
            this.lem2RadioButton.Location = new System.Drawing.Point(13, 89);
            this.lem2RadioButton.Name = "lem2RadioButton";
            this.lem2RadioButton.Size = new System.Drawing.Size(296, 17);
            this.lem2RadioButton.TabIndex = 6;
            this.lem2RadioButton.TabStop = true;
            this.lem2RadioButton.Text = "wyliczanie reguł LEM2 (Learn from Examples by Modules)";
            this.lem2RadioButton.UseVisualStyleBackColor = true;
            this.lem2RadioButton.MouseCaptureChanged += new System.EventHandler(this.btnWybierz_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(431, 487);
            this.Controls.Add(this.lem2RadioButton);
            this.Controls.Add(this.exhaustiveRadioButton);
            this.Controls.Add(this.coveringRadioButton);
            this.Controls.Add(this.autorLabel);
            this.Controls.Add(this.listaRegulTextBox);
            this.Controls.Add(this.tbScieszka);
            this.Controls.Add(this.btnWybierz);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Wczytywanie z pliku";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWybierz;
        private System.Windows.Forms.TextBox tbScieszka;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.TextBox listaRegulTextBox;
        private System.Windows.Forms.Label autorLabel;
        private System.Windows.Forms.RadioButton coveringRadioButton;
        private System.Windows.Forms.RadioButton exhaustiveRadioButton;
        private System.Windows.Forms.RadioButton lem2RadioButton;
    }
}

