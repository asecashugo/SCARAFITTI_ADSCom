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
		private System.Windows.Forms.ListBox lbArray;
        private Button btnYminus;
        private Button btnXplus;
        private Button btnXminus;
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
            this.lbArray = new System.Windows.Forms.ListBox();
            this.btnYplus = new System.Windows.Forms.Button();
            this.btnYminus = new System.Windows.Forms.Button();
            this.btnXplus = new System.Windows.Forms.Button();
            this.btnXminus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbArray
            // 
            this.lbArray.Location = new System.Drawing.Point(12, 125);
            this.lbArray.Name = "lbArray";
            this.lbArray.Size = new System.Drawing.Size(144, 69);
            this.lbArray.TabIndex = 0;
            this.lbArray.SelectedIndexChanged += new System.EventHandler(this.lbArray_SelectedIndexChanged);
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
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(176, 269);
            this.Controls.Add(this.btnYminus);
            this.Controls.Add(this.btnXminus);
            this.Controls.Add(this.btnXplus);
            this.Controls.Add(this.btnYplus);
            this.Controls.Add(this.lbArray);
            this.Name = "Form1";
            this.Text = "Sample01";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

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

				//Array komplett auslesen			
				tcClient.Read(hVarY, dataStream);

				lbArray.Items.Clear();
				dataStream.Position = 0;			
				for(int i=0; i<100; i++)
				{
					lbArray.Items.Add(binRead.ReadInt32().ToString());
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void Yminus_Click(object sender, System.EventArgs e)
		{
			try
			{
				AdsStream dataStream = new AdsStream(100 * 4);
				BinaryReader binRead = new BinaryReader(dataStream);



				auxY = auxY - 100;

				tcClient.WriteAny(hVarY, auxY);

				//Array komplett auslesen			
				tcClient.Read(hVarY, dataStream);

				lbArray.Items.Clear();
				dataStream.Position = 0;
				for (int i = 0; i < 100; i++)
				{
					lbArray.Items.Add(binRead.ReadInt32().ToString());
				}
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

				//Array komplett auslesen			
				tcClient.Read(hVarX, dataStream);

				lbArray.Items.Clear();
				dataStream.Position = 0;
				for (int i = 0; i < 100; i++)
				{
					lbArray.Items.Add(binRead.ReadInt32().ToString());
				}
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

				//Array komplett auslesen			
				tcClient.Read(hVarX, dataStream);

				lbArray.Items.Clear();
				dataStream.Position = 0;
				for (int i = 0; i < 100; i++)
				{
					lbArray.Items.Add(binRead.ReadInt32().ToString());
				}
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
				tcClient.DeleteVariableHandle(hVar);					
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
			tcClient.Dispose();				
		}		
	}
}
