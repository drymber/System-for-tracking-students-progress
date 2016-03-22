namespace StudentsProgressManager
{
    partial class DeleteData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteData));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxYearDeleteStudent = new System.Windows.Forms.ComboBox();
            this.comboBoxGroupDeleteStudent = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDeleteStudent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxStudentDeleteStudent = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteGroup = new System.Windows.Forms.Button();
            this.comboBoxYearDeleteGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxGroupDeleteGroup = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteTopic = new System.Windows.Forms.Button();
            this.comboBoxTopicDeleteTopic = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxYearDeleteStudent);
            this.groupBox1.Controls.Add(this.comboBoxGroupDeleteStudent);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonDeleteStudent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxStudentDeleteStudent);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delete student";
            // 
            // comboBoxYearDeleteStudent
            // 
            this.comboBoxYearDeleteStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxYearDeleteStudent.FormattingEnabled = true;
            this.comboBoxYearDeleteStudent.Location = new System.Drawing.Point(420, 32);
            this.comboBoxYearDeleteStudent.Name = "comboBoxYearDeleteStudent";
            this.comboBoxYearDeleteStudent.Size = new System.Drawing.Size(61, 23);
            this.comboBoxYearDeleteStudent.TabIndex = 10;
            this.comboBoxYearDeleteStudent.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearDeleteStudent_SelectedIndexChanged);
            // 
            // comboBoxGroupDeleteStudent
            // 
            this.comboBoxGroupDeleteStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxGroupDeleteStudent.FormattingEnabled = true;
            this.comboBoxGroupDeleteStudent.Location = new System.Drawing.Point(341, 32);
            this.comboBoxGroupDeleteStudent.Name = "comboBoxGroupDeleteStudent";
            this.comboBoxGroupDeleteStudent.Size = new System.Drawing.Size(61, 23);
            this.comboBoxGroupDeleteStudent.TabIndex = 9;
            this.comboBoxGroupDeleteStudent.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupDeleteStudent_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Group:";
            // 
            // buttonDeleteStudent
            // 
            this.buttonDeleteStudent.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDeleteStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteStudent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDeleteStudent.Location = new System.Drawing.Point(541, 30);
            this.buttonDeleteStudent.Name = "buttonDeleteStudent";
            this.buttonDeleteStudent.Size = new System.Drawing.Size(75, 24);
            this.buttonDeleteStudent.TabIndex = 8;
            this.buttonDeleteStudent.Text = "Delete";
            this.buttonDeleteStudent.UseVisualStyleBackColor = false;
            this.buttonDeleteStudent.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Student:";
            // 
            // comboBoxStudentDeleteStudent
            // 
            this.comboBoxStudentDeleteStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxStudentDeleteStudent.FormattingEnabled = true;
            this.comboBoxStudentDeleteStudent.Location = new System.Drawing.Point(79, 32);
            this.comboBoxStudentDeleteStudent.Name = "comboBoxStudentDeleteStudent";
            this.comboBoxStudentDeleteStudent.Size = new System.Drawing.Size(140, 23);
            this.comboBoxStudentDeleteStudent.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDeleteGroup);
            this.groupBox2.Controls.Add(this.comboBoxYearDeleteGroup);
            this.groupBox2.Controls.Add(this.comboBoxGroupDeleteGroup);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(15, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 81);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete group";
            // 
            // buttonDeleteGroup
            // 
            this.buttonDeleteGroup.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDeleteGroup.Location = new System.Drawing.Point(541, 30);
            this.buttonDeleteGroup.Name = "buttonDeleteGroup";
            this.buttonDeleteGroup.Size = new System.Drawing.Size(75, 24);
            this.buttonDeleteGroup.TabIndex = 8;
            this.buttonDeleteGroup.Text = "Delete";
            this.buttonDeleteGroup.UseVisualStyleBackColor = false;
            this.buttonDeleteGroup.Click += new System.EventHandler(this.buttonDeleteGroup_Click);
            // 
            // comboBoxYearDeleteGroup
            // 
            this.comboBoxYearDeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxYearDeleteGroup.FormattingEnabled = true;
            this.comboBoxYearDeleteGroup.Location = new System.Drawing.Point(158, 32);
            this.comboBoxYearDeleteGroup.Name = "comboBoxYearDeleteGroup";
            this.comboBoxYearDeleteGroup.Size = new System.Drawing.Size(61, 23);
            this.comboBoxYearDeleteGroup.TabIndex = 7;
            this.comboBoxYearDeleteGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearDeleteGroup_SelectedIndexChanged);
            // 
            // comboBoxGroupDeleteGroup
            // 
            this.comboBoxGroupDeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxGroupDeleteGroup.FormattingEnabled = true;
            this.comboBoxGroupDeleteGroup.Location = new System.Drawing.Point(79, 32);
            this.comboBoxGroupDeleteGroup.Name = "comboBoxGroupDeleteGroup";
            this.comboBoxGroupDeleteGroup.Size = new System.Drawing.Size(61, 23);
            this.comboBoxGroupDeleteGroup.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Group:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonDeleteTopic);
            this.groupBox4.Controls.Add(this.comboBoxTopicDeleteTopic);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Location = new System.Drawing.Point(15, 189);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(631, 81);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Delete topic";
            // 
            // buttonDeleteTopic
            // 
            this.buttonDeleteTopic.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDeleteTopic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteTopic.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDeleteTopic.Location = new System.Drawing.Point(541, 30);
            this.buttonDeleteTopic.Name = "buttonDeleteTopic";
            this.buttonDeleteTopic.Size = new System.Drawing.Size(75, 24);
            this.buttonDeleteTopic.TabIndex = 8;
            this.buttonDeleteTopic.Text = "Delete";
            this.buttonDeleteTopic.UseVisualStyleBackColor = false;
            this.buttonDeleteTopic.Click += new System.EventHandler(this.buttonDeleteTopic_Click);
            // 
            // comboBoxTopicDeleteTopic
            // 
            this.comboBoxTopicDeleteTopic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxTopicDeleteTopic.FormattingEnabled = true;
            this.comboBoxTopicDeleteTopic.Location = new System.Drawing.Point(79, 32);
            this.comboBoxTopicDeleteTopic.Name = "comboBoxTopicDeleteTopic";
            this.comboBoxTopicDeleteTopic.Size = new System.Drawing.Size(140, 23);
            this.comboBoxTopicDeleteTopic.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Topic:";
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOK.Location = new System.Drawing.Point(571, 293);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.Location = new System.Drawing.Point(15, 293);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // DeleteData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(660, 331);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteData";
            this.Text = "Deleting data";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxYearDeleteStudent;
        private System.Windows.Forms.ComboBox comboBoxGroupDeleteStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDeleteStudent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxStudentDeleteStudent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDeleteGroup;
        private System.Windows.Forms.ComboBox comboBoxYearDeleteGroup;
        private System.Windows.Forms.ComboBox comboBoxGroupDeleteGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonDeleteTopic;
        private System.Windows.Forms.ComboBox comboBoxTopicDeleteTopic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}