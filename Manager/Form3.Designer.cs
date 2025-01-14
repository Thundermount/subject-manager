﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Manager
{
    partial class Form3
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(42, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(722, 372);
            this.listBox1.TabIndex = 0;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(785, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 58);
            this.button2.TabIndex = 2;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(785, 104);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 58);
            this.button3.TabIndex = 3;
            this.button3.Text = "Обновить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(275, 412);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 58);
            this.button4.TabIndex = 4;
            this.button4.Text = "Изменить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(496, 412);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 58);
            this.button5.TabIndex = 5;
            this.button5.Text = "Открыть папку с файлами";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 536);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Shown += new System.EventHandler(this.Form3_Shown);
            this.ResumeLayout(false);

        }
        void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;

            Graphics g = e.Graphics;
            Dictionary<string, object> props = (this.listBox1.Items[e.Index] as Dictionary<string, object>);
            SolidBrush backgroundBrush = new SolidBrush(props.ContainsKey("BackColor") ? (Color)props["BackColor"] : e.BackColor);
            SolidBrush foregroundBrush = new SolidBrush(props.ContainsKey("ForeColor") ? (Color)props["ForeColor"] : e.ForeColor);
            Font textFont = props.ContainsKey("Font") ? (Font)props["Font"] : e.Font;
            string text = props.ContainsKey("Text") ? (string)props["Text"] : string.Empty;
            RectangleF rectangle = new RectangleF(new PointF(e.Bounds.X, e.Bounds.Y), new SizeF(e.Bounds.Width, g.MeasureString(text, textFont).Height));

            g.FillRectangle(backgroundBrush, rectangle);
            g.DrawString(text, textFont, foregroundBrush, rectangle);

            backgroundBrush.Dispose();
            foregroundBrush.Dispose();
            g.Dispose();
        }
        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}