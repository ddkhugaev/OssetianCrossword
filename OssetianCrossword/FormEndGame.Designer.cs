
namespace OssetianCrossword
{
    partial class FormEndGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEndGame));
            this.buttonEndGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEndGame
            // 
            this.buttonEndGame.Location = new System.Drawing.Point(354, 283);
            this.buttonEndGame.Name = "buttonEndGame";
            this.buttonEndGame.Size = new System.Drawing.Size(168, 56);
            this.buttonEndGame.TabIndex = 1;
            this.buttonEndGame.Text = "Готово";
            this.buttonEndGame.UseVisualStyleBackColor = true;
            this.buttonEndGame.Click += new System.EventHandler(this.buttonEndGame_Click);
            // 
            // FormEndGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.buttonEndGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEndGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конец игры";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonEndGame;
    }
}