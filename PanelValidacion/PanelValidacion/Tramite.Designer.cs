namespace PanelValidacion
{
    partial class Tramite
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
            this.tramitedll1 = new TramiteDll.tramitedll();
            this.SuspendLayout();
            // 
            // tramitedll1
            // 
            this.tramitedll1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tramitedll1.Location = new System.Drawing.Point(0, 0);
            this.tramitedll1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tramitedll1.Name = "tramitedll1";
            this.tramitedll1.Size = new System.Drawing.Size(800, 450);
            this.tramitedll1.TabIndex = 0;
            this.tramitedll1.Load += new System.EventHandler(this.Tramitedll1_Load);
            // 
            // Tramite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tramitedll1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Tramite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tramite";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tramite_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private TramiteDll.tramitedll tramitedll1;
    }
}