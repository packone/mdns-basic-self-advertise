﻿namespace mdns_basic_self_advertise;

partial class MainForm
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
        TextBoxDomain = new TextBox();
        CheckBoxSwitch = new CheckBox();
        LabelDomainName = new Label();
        flowLayoutPanel1 = new FlowLayoutPanel();
        groupBox1 = new GroupBox();
        flowLayoutPanel2 = new FlowLayoutPanel();
        CheckBoxLog = new CheckBox();
        CheckBoxLogAll = new CheckBox();
        CheckBoxKeepLog = new CheckBox();
        ButtonClearLog = new Button();
        dataGridViewMessageLog = new DataGridView();
        flowLayoutPanel1.SuspendLayout();
        groupBox1.SuspendLayout();
        flowLayoutPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewMessageLog).BeginInit();
        SuspendLayout();
        // 
        // TextBoxDomain
        // 
        TextBoxDomain.Dock = DockStyle.Fill;
        TextBoxDomain.Font = new Font("Segoe UI", 16F);
        TextBoxDomain.Location = new Point(307, 3);
        TextBoxDomain.Name = "TextBoxDomain";
        TextBoxDomain.Size = new Size(574, 64);
        TextBoxDomain.TabIndex = 0;
        TextBoxDomain.Text = "test123.local";
        // 
        // CheckBoxSwitch
        // 
        CheckBoxSwitch.Appearance = Appearance.Button;
        CheckBoxSwitch.AutoSize = true;
        CheckBoxSwitch.Dock = DockStyle.Fill;
        CheckBoxSwitch.Font = new Font("Segoe UI", 16F);
        CheckBoxSwitch.Location = new Point(887, 3);
        CheckBoxSwitch.Name = "CheckBoxSwitch";
        CheckBoxSwitch.Size = new Size(157, 69);
        CheckBoxSwitch.TabIndex = 1;
        CheckBoxSwitch.Text = "Switch";
        CheckBoxSwitch.TextAlign = ContentAlignment.MiddleCenter;
        CheckBoxSwitch.UseVisualStyleBackColor = true;
        CheckBoxSwitch.CheckedChanged += CheckBoxSwitch_CheckedChanged;
        // 
        // LabelDomainName
        // 
        LabelDomainName.AutoSize = true;
        LabelDomainName.Dock = DockStyle.Fill;
        LabelDomainName.Font = new Font("Segoe UI", 16F);
        LabelDomainName.Location = new Point(3, 0);
        LabelDomainName.Name = "LabelDomainName";
        LabelDomainName.Size = new Size(298, 75);
        LabelDomainName.TabIndex = 7;
        LabelDomainName.Text = "Domain Name";
        LabelDomainName.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.AutoSize = true;
        flowLayoutPanel1.Controls.Add(LabelDomainName);
        flowLayoutPanel1.Controls.Add(TextBoxDomain);
        flowLayoutPanel1.Controls.Add(CheckBoxSwitch);
        flowLayoutPanel1.Dock = DockStyle.Top;
        flowLayoutPanel1.Location = new Point(0, 0);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new Size(1774, 75);
        flowLayoutPanel1.TabIndex = 8;
        // 
        // groupBox1
        // 
        groupBox1.AutoSize = true;
        groupBox1.Controls.Add(flowLayoutPanel2);
        groupBox1.Dock = DockStyle.Top;
        groupBox1.Location = new Point(0, 75);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(1774, 86);
        groupBox1.TabIndex = 10;
        groupBox1.TabStop = false;
        groupBox1.Text = "Logging";
        // 
        // flowLayoutPanel2
        // 
        flowLayoutPanel2.AutoSize = true;
        flowLayoutPanel2.Controls.Add(CheckBoxLog);
        flowLayoutPanel2.Controls.Add(CheckBoxLogAll);
        flowLayoutPanel2.Controls.Add(CheckBoxKeepLog);
        flowLayoutPanel2.Controls.Add(ButtonClearLog);
        flowLayoutPanel2.Dock = DockStyle.Top;
        flowLayoutPanel2.Location = new Point(3, 35);
        flowLayoutPanel2.Name = "flowLayoutPanel2";
        flowLayoutPanel2.Size = new Size(1768, 48);
        flowLayoutPanel2.TabIndex = 10;
        // 
        // CheckBoxLog
        // 
        CheckBoxLog.Appearance = Appearance.Button;
        CheckBoxLog.AutoSize = true;
        CheckBoxLog.Dock = DockStyle.Fill;
        CheckBoxLog.Location = new Point(3, 3);
        CheckBoxLog.Name = "CheckBoxLog";
        CheckBoxLog.Size = new Size(63, 42);
        CheckBoxLog.TabIndex = 2;
        CheckBoxLog.Text = "Log";
        CheckBoxLog.UseVisualStyleBackColor = true;
        // 
        // CheckBoxLogAll
        // 
        CheckBoxLogAll.Appearance = Appearance.Button;
        CheckBoxLogAll.AutoSize = true;
        CheckBoxLogAll.Dock = DockStyle.Fill;
        CheckBoxLogAll.Location = new Point(72, 3);
        CheckBoxLogAll.Name = "CheckBoxLogAll";
        CheckBoxLogAll.Size = new Size(308, 42);
        CheckBoxLogAll.TabIndex = 3;
        CheckBoxLogAll.Text = "Log every mDNS Question";
        CheckBoxLogAll.UseVisualStyleBackColor = true;
        // 
        // CheckBoxKeepLog
        // 
        CheckBoxKeepLog.Appearance = Appearance.Button;
        CheckBoxKeepLog.AutoSize = true;
        CheckBoxKeepLog.Dock = DockStyle.Fill;
        CheckBoxKeepLog.Location = new Point(386, 3);
        CheckBoxKeepLog.Name = "CheckBoxKeepLog";
        CheckBoxKeepLog.Size = new Size(258, 42);
        CheckBoxKeepLog.TabIndex = 6;
        CheckBoxKeepLog.Text = "Log overwrite inactive";
        CheckBoxKeepLog.UseVisualStyleBackColor = true;
        // 
        // ButtonClearLog
        // 
        ButtonClearLog.Dock = DockStyle.Fill;
        ButtonClearLog.Location = new Point(650, 3);
        ButtonClearLog.Name = "ButtonClearLog";
        ButtonClearLog.Size = new Size(150, 42);
        ButtonClearLog.TabIndex = 7;
        ButtonClearLog.Text = "Log clear";
        ButtonClearLog.UseVisualStyleBackColor = true;
        ButtonClearLog.Click += ButtonClearLog_Click_1;
        // 
        // dataGridViewMessageLog
        // 
        dataGridViewMessageLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewMessageLog.Dock = DockStyle.Fill;
        dataGridViewMessageLog.Location = new Point(0, 161);
        dataGridViewMessageLog.Name = "dataGridViewMessageLog";
        dataGridViewMessageLog.RowHeadersWidth = 82;
        dataGridViewMessageLog.Size = new Size(1774, 768);
        dataGridViewMessageLog.TabIndex = 11;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1774, 929);
        Controls.Add(dataGridViewMessageLog);
        Controls.Add(groupBox1);
        Controls.Add(flowLayoutPanel1);
        Name = "MainForm";
        Text = "mdns-basic-self-advertise";
        FormClosing += Form1_FormClosing;
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.PerformLayout();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        flowLayoutPanel2.ResumeLayout(false);
        flowLayoutPanel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewMessageLog).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox TextBoxDomain;
    private CheckBox CheckBoxSwitch;
    private Label LabelDomainName;
    private FlowLayoutPanel flowLayoutPanel1;
    private GroupBox groupBox1;
    private FlowLayoutPanel flowLayoutPanel2;
    private CheckBox CheckBoxLog;
    private CheckBox CheckBoxLogAll;
    private CheckBox CheckBoxKeepLog;
    private Button ButtonClearLog;
    private DataGridView dataGridViewMessageLog;
}
