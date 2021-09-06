
namespace Minesweeper
{
    partial class Minesweeper
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beginner16x16With10BombsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advanced30x16With99MineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cheatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recursiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermidiate16x16With40MineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(437, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.controlsToolStripMenuItem,
            this.uIToolStripMenuItem,
            this.cheatsToolStripMenuItem,
            this.fillModeToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beginner16x16With10BombsToolStripMenuItem,
            this.intermidiate16x16With40MineToolStripMenuItem,
            this.advanced30x16With99MineToolStripMenuItem,
            this.customToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // beginner16x16With10BombsToolStripMenuItem
            // 
            this.beginner16x16With10BombsToolStripMenuItem.Name = "beginner16x16With10BombsToolStripMenuItem";
            this.beginner16x16With10BombsToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.beginner16x16With10BombsToolStripMenuItem.Text = "Beginner (8x8 with 10 mine)";
            this.beginner16x16With10BombsToolStripMenuItem.Click += new System.EventHandler(this.beginner16x16With10BombsToolStripMenuItem_Click);
            // 
            // advanced30x16With99MineToolStripMenuItem
            // 
            this.advanced30x16With99MineToolStripMenuItem.Name = "advanced30x16With99MineToolStripMenuItem";
            this.advanced30x16With99MineToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.advanced30x16With99MineToolStripMenuItem.Text = "Advanced (30x16 with 99 mine)";
            this.advanced30x16With99MineToolStripMenuItem.Click += new System.EventHandler(this.advanced30x16With99MineToolStripMenuItem_Click);
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.controlsToolStripMenuItem.Text = "Controls";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // uIToolStripMenuItem
            // 
            this.uIToolStripMenuItem.Name = "uIToolStripMenuItem";
            this.uIToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.uIToolStripMenuItem.Text = "UI";
            // 
            // cheatsToolStripMenuItem
            // 
            this.cheatsToolStripMenuItem.Name = "cheatsToolStripMenuItem";
            this.cheatsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cheatsToolStripMenuItem.Text = "Cheats";
            // 
            // fillModeToolStripMenuItem
            // 
            this.fillModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recursiveToolStripMenuItem});
            this.fillModeToolStripMenuItem.Name = "fillModeToolStripMenuItem";
            this.fillModeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.fillModeToolStripMenuItem.Text = "Fill mode";
            // 
            // recursiveToolStripMenuItem
            // 
            this.recursiveToolStripMenuItem.Name = "recursiveToolStripMenuItem";
            this.recursiveToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.recursiveToolStripMenuItem.Text = "Recursive";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wIPToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.customToolStripMenuItem.Text = "Custom";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // intermidiate16x16With40MineToolStripMenuItem
            // 
            this.intermidiate16x16With40MineToolStripMenuItem.Name = "intermidiate16x16With40MineToolStripMenuItem";
            this.intermidiate16x16With40MineToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.intermidiate16x16With40MineToolStripMenuItem.Text = "Intermidiate (16x16 with 40 mine)";
            this.intermidiate16x16With40MineToolStripMenuItem.Click += new System.EventHandler(this.intermidiate16x16With40MineToolStripMenuItem_Click);
            // 
            // wIPToolStripMenuItem
            // 
            this.wIPToolStripMenuItem.Name = "wIPToolStripMenuItem";
            this.wIPToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.wIPToolStripMenuItem.Text = "WIP";
            // 
            // Minesweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 416);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Minesweeper";
            this.Text = "initializing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beginner16x16With10BombsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cheatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recursiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advanced30x16With99MineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intermidiate16x16With40MineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wIPToolStripMenuItem;
    }
}

