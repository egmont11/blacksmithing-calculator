﻿namespace BlacksmithingApp_WinForms;

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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(400, 200);
        
        // In Form1.Designer.cs, inside InitializeComponent()
        this.ClientSize = new System.Drawing.Size(800, 600);
        this.MinimumSize = new System.Drawing.Size(800, 600);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        Text = "Blacksmithing Calculator";
        ResumeLayout(false);
    }

    #endregion
}