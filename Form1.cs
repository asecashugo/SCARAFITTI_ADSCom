using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TwinCAT;
using TwinCAT.Ads;
using TwinCAT.TypeSystem;
using System.IO;

namespace Sample01
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnYplus;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int hVar, hVarX, hVarY, auxX, auxY;
        private Button btnYminus;
        private Button btnXplus;
        private Button btnXminus;
        private Label labelY;
        private Label labelX;
        private TcAdsClient tcClient;
	
		public Form1()
		{
			InitializeComponent();		
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnYplus = new System.Windows.Forms.Button();
            this.btnYminus = new System.Windows.Forms.Button();
            this.btnXplus = new System.Windows.Forms.Button();
            this.btnXminus = new System.Windows.Forms.Button();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnYplus
            // 
            this.btnYplus.Location = new System.Drawing.Point(56, 12);
            this.btnYplus.Name = "btnYplus";
            this.btnYplus.Size = new System.Drawing.Size(54, 23);
            this.btnYplus.TabIndex = 1;
            this.btnYplus.Text = "Y+";
            this.btnYplus.Click += new System.EventHandler(this.Yplus_Click);
            // 
            // btnYminus
            // 
            this.btnYminus.Location = new System.Drawing.Point(56, 84);
            this.btnYminus.Name = "btnYminus";
            this.btnYminus.Size = new System.Drawing.Size(54, 23);
            this.btnYminus.TabIndex = 2;
            this.btnYminus.Text = "Y-";
            this.btnYminus.Click += new System.EventHandler(this.Yminus_Click);
            // 
            // btnXplus
            // 
            this.btnXplus.Location = new System.Drawing.Point(110, 46);
            this.btnXplus.Name = "btnXplus";
            this.btnXplus.Size = new System.Drawing.Size(54, 23);
            this.btnXplus.TabIndex = 1;
            this.btnXplus.Text = "X+";
            this.btnXplus.Click += new System.EventHandler(this.Xplus_Click);
            // 
            // btnXminus
            // 
            this.btnXminus.Location = new System.Drawing.Point(7, 46);
            this.btnXminus.Name = "btnXminus";
            this.btnXminus.Size = new System.Drawing.Size(54, 23);
            this.btnXminus.TabIndex = 1;
            this.btnXminus.Text = "X-";
            this.btnXminus.Click += new System.EventHandler(this.Xminus_Click);
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(12, 149);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(36, 13);
            this.labelY.TabIndex = 4;
            this.labelY.Text = "labelY";
            this.labelY.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(12, 127);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(36, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "labelX";
            this.labelX.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(176, 269);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.btnYminus);
            this.Controls.Add(this.btnXminus);
            this.Controls.Add(this.btnXplus);
            this.Controls.Add(this.btnYplus);
            this.Name = "Form1";
            this.Text = "Sample01";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			tcClient = new TcAdsClient();
			tcClient.Connect("5.72.137.238.1.1",851);
			
			try
			{
				hVarX = tcClient.CreateVariableHandle("MAIN.Xc_test");
				hVarY = tcClient.CreateVariableHandle("MAIN.Yc_test");
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

        private void lbArray_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Yplus_Click(object sender, System.EventArgs e)
		{
			try
			{
				AdsStream dataStream = new AdsStream(100 * 4);
				BinaryReader binRead = new BinaryReader(dataStream);
			


				auxY = auxY + 100;
			
				tcClient.WriteAny(hVarY, auxY);

				//Leer y mostrar Y			
				tcClient.Read(hVarY, dataStream);
				dataStream.Position = 0;
				labelY.Text = "Y=" + binRead.ReadInt32().ToString();
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Yminus_Click(object sender, System.EventArgs e)
		{
			try
			{
				AdsStream dataStream = new AdsStream(100 * 4);
				BinaryReader binRead = new BinaryReader(dataStream);



				auxY = auxY - 100;

				tcClient.WriteAny(hVarY, auxY);

				//Leer y mostrar Y			
				tcClient.Read(hVarY,dataStream);
				dataStream.Position = 0;
				labelY.Text = "Y=" + binRead.ReadInt32().ToString();

			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void Xplus_Click(object sender, System.EventArgs e)
		{
			try
			{
				AdsStream dataStream = new AdsStream(100 * 4);
				BinaryReader binRead = new BinaryReader(dataStream);



				auxX = auxX + 100;

				tcClient.WriteAny(hVarX, auxX);

				//Leer y mostrar X			
				tcClient.Read(hVarX, dataStream);
				dataStream.Position = 0;
				labelX.Text = "X=" + binRead.ReadInt32().ToString();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void Xminus_Click(object sender, System.EventArgs e)
		{
			try
			{
				AdsStream dataStream = new AdsStream(100 * 4);
				BinaryReader binRead = new BinaryReader(dataStream);



				auxX = auxX - 100;

				tcClient.WriteAny(hVarX, auxX);

				//Leer y mostrar X			
				tcClient.Read(hVarX, dataStream);
				dataStream.Position = 0;
				labelX.Text = "X=" + binRead.ReadInt32().ToString();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Resourcen wieder freigeben
			try
			{
				tcClient.DeleteVariableHandle(hVarX);
				tcClient.DeleteVariableHandle(hVarY);
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
			tcClient.Dispose();				
		}		
	}
}
