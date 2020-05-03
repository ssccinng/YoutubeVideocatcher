namespace YoutubeVideocatcher
{
    partial class YoutubeCatcher
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YoutubeCatcher));
            this.VideoId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PageURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Videos = new System.Windows.Forms.TextBox();
            this.Catch1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Catch2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.is720 = new System.Windows.Forms.CheckBox();
            this.is1080 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.is480 = new System.Windows.Forms.CheckBox();
            this.clartext = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VideoId
            // 
            this.VideoId.Location = new System.Drawing.Point(152, 31);
            this.VideoId.Name = "VideoId";
            this.VideoId.Size = new System.Drawing.Size(100, 21);
            this.VideoId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "视频链接或Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "频道视频页面链接";
            // 
            // PageURL
            // 
            this.PageURL.Location = new System.Drawing.Point(152, 103);
            this.PageURL.Name = "PageURL";
            this.PageURL.Size = new System.Drawing.Size(100, 21);
            this.PageURL.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "下载前n个视频";
            // 
            // Videos
            // 
            this.Videos.Location = new System.Drawing.Point(370, 103);
            this.Videos.Name = "Videos";
            this.Videos.Size = new System.Drawing.Size(39, 21);
            this.Videos.TabIndex = 0;
            this.Videos.Text = "1";
            // 
            // Catch1
            // 
            this.Catch1.Location = new System.Drawing.Point(458, 29);
            this.Catch1.Name = "Catch1";
            this.Catch1.Size = new System.Drawing.Size(75, 23);
            this.Catch1.TabIndex = 2;
            this.Catch1.Text = "抓取!";
            this.Catch1.UseVisualStyleBackColor = true;
            this.Catch1.Click += new System.EventHandler(this.oneVideo_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label4.Location = new System.Drawing.Point(0, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(584, 10);
            this.label4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label5.Location = new System.Drawing.Point(0, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(584, 10);
            this.label5.TabIndex = 3;
            // 
            // Catch2
            // 
            this.Catch2.Location = new System.Drawing.Point(458, 101);
            this.Catch2.Name = "Catch2";
            this.Catch2.Size = new System.Drawing.Size(75, 23);
            this.Catch2.TabIndex = 2;
            this.Catch2.Text = "抓取!";
            this.Catch2.UseVisualStyleBackColor = true;
            this.Catch2.Click += new System.EventHandler(this.PageVideo_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label6.Location = new System.Drawing.Point(0, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(584, 10);
            this.label6.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label7.Location = new System.Drawing.Point(0, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(584, 10);
            this.label7.TabIndex = 3;
            // 
            // is720
            // 
            this.is720.AutoSize = true;
            this.is720.Checked = true;
            this.is720.CheckState = System.Windows.Forms.CheckState.Checked;
            this.is720.Location = new System.Drawing.Point(152, 187);
            this.is720.Name = "is720";
            this.is720.Size = new System.Drawing.Size(48, 16);
            this.is720.TabIndex = 4;
            this.is720.Text = "720p";
            this.is720.UseVisualStyleBackColor = true;
            // 
            // is1080
            // 
            this.is1080.AutoSize = true;
            this.is1080.Location = new System.Drawing.Point(236, 188);
            this.is1080.Name = "is1080";
            this.is1080.Size = new System.Drawing.Size(54, 16);
            this.is1080.TabIndex = 4;
            this.is1080.Text = "1080p";
            this.is1080.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "清晰度选择";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(424, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "Creat by ssmoob";
            // 
            // is480
            // 
            this.is480.AutoSize = true;
            this.is480.Location = new System.Drawing.Point(310, 187);
            this.is480.Name = "is480";
            this.is480.Size = new System.Drawing.Size(84, 16);
            this.is480.TabIndex = 4;
            this.is480.Text = "with audio";
            this.is480.UseVisualStyleBackColor = true;
            // 
            // clartext
            // 
            this.clartext.Location = new System.Drawing.Point(152, 209);
            this.clartext.Name = "clartext";
            this.clartext.Size = new System.Drawing.Size(48, 21);
            this.clartext.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "其他自定义清晰度";
            // 
            // YoutubeCatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 246);
            this.Controls.Add(this.clartext);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.is480);
            this.Controls.Add(this.is1080);
            this.Controls.Add(this.is720);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Catch2);
            this.Controls.Add(this.Catch1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Videos);
            this.Controls.Add(this.PageURL);
            this.Controls.Add(this.VideoId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YoutubeCatcher";
            this.Text = "Youtube视频抓取";
            this.Load += new System.EventHandler(this.YoutubeCatcher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox VideoId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PageURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Videos;
        private System.Windows.Forms.Button Catch1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Catch2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox is720;
        private System.Windows.Forms.CheckBox is1080;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox is480;
        private System.Windows.Forms.TextBox clartext;
        private System.Windows.Forms.Label label10;
    }
}

