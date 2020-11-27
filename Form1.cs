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
        private IContainer components;
        private int hVar, hVarX, hVarY, auxX, auxY, hVarRealX, hVarRealY, hVarSimX, hVarSimY, hVarVelocidad, hVarTolerancia;
        private int hVarSimulacion, hVarParada, hVarEnObjetivo;
        private Label objetivoY;
        private Label objetivoX;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label realX;
        private Label realY;
        private Label simX;
        private Label simY;
        private Timer timer1;
        private GroupBox groupBox1;
        private Button btnYplus;
        private Button btnXplus;
        private Button btnXminus;
        private Button btnYminus;
        private GroupBox groupBox2;
        private CheckBox chb_simulacion;
        private CheckBox chb_parada;
        private Label Error;
        private Label Velocidad;
        private Label EnObjetivo;
        private Label tolerancia;
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
            this.components = new System.ComponentModel.Container();
            this.objetivoY = new System.Windows.Forms.Label();
            this.objetivoX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.realX = new System.Windows.Forms.Label();
            this.realY = new System.Windows.Forms.Label();
            this.simX = new System.Windows.Forms.Label();
            this.simY = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnYminus = new System.Windows.Forms.Button();
            this.btnYplus = new System.Windows.Forms.Button();
            this.btnXminus = new System.Windows.Forms.Button();
            this.btnXplus = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EnObjetivo = new System.Windows.Forms.Label();
            this.Error = new System.Windows.Forms.Label();
            this.chb_simulacion = new System.Windows.Forms.CheckBox();
            this.tolerancia = new System.Windows.Forms.Label();
            this.Velocidad = new System.Windows.Forms.Label();
            this.chb_parada = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // objetivoY
            // 
            this.objetivoY.AutoSize = true;
            this.objetivoY.Location = new System.Drawing.Point(59, 95);
            this.objetivoY.Name = "objetivoY";
            this.objetivoY.Size = new System.Drawing.Size(36, 13);
            this.objetivoY.TabIndex = 4;
            this.objetivoY.Text = "labelY";
            this.objetivoY.Click += new System.EventHandler(this.label1_Click);
            // 
            // objetivoX
            // 
            this.objetivoX.AutoSize = true;
            this.objetivoX.Location = new System.Drawing.Point(59, 60);
            this.objetivoX.Name = "objetivoX";
            this.objetivoX.Size = new System.Drawing.Size(36, 13);
            this.objetivoX.TabIndex = 4;
            this.objetivoX.Text = "labelX";
            this.objetivoX.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Objetivo";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Real";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(180, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Simulado";
            this.label5.Click += new System.EventHandler(this.label3_Click);
            // 
            // realX
            // 
            this.realX.AutoSize = true;
            this.realX.Location = new System.Drawing.Point(126, 60);
            this.realX.Name = "realX";
            this.realX.Size = new System.Drawing.Size(31, 13);
            this.realX.TabIndex = 4;
            this.realX.Text = "realX";
            this.realX.Click += new System.EventHandler(this.label1_Click);
            // 
            // realY
            // 
            this.realY.AutoSize = true;
            this.realY.Location = new System.Drawing.Point(126, 95);
            this.realY.Name = "realY";
            this.realY.Size = new System.Drawing.Size(29, 13);
            this.realY.TabIndex = 4;
            this.realY.Text = "realy";
            this.realY.Click += new System.EventHandler(this.label1_Click);
            // 
            // simX
            // 
            this.simX.AutoSize = true;
            this.simX.Location = new System.Drawing.Point(180, 60);
            this.simX.Name = "simX";
            this.simX.Size = new System.Drawing.Size(29, 13);
            this.simX.TabIndex = 4;
            this.simX.Text = "simX";
            this.simX.Click += new System.EventHandler(this.label1_Click);
            // 
            // simY
            // 
            this.simY.AutoSize = true;
            this.simY.Location = new System.Drawing.Point(180, 95);
            this.simY.Name = "simY";
            this.simY.Size = new System.Drawing.Size(29, 13);
            this.simY.TabIndex = 4;
            this.simY.Text = "simY";
            this.simY.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnYminus);
            this.groupBox1.Controls.Add(this.btnYplus);
            this.groupBox1.Controls.Add(this.btnXminus);
            this.groupBox1.Controls.Add(this.btnXplus);
            this.groupBox1.Location = new System.Drawing.Point(15, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 136);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // btnYminus
            // 
            this.btnYminus.Location = new System.Drawing.Point(72, 91);
            this.btnYminus.Name = "btnYminus";
            this.btnYminus.Size = new System.Drawing.Size(54, 23);
            this.btnYminus.TabIndex = 2;
            this.btnYminus.Text = "Y-";
            this.btnYminus.Click += new System.EventHandler(this.Yminus_Click);
            // 
            // btnYplus
            // 
            this.btnYplus.Location = new System.Drawing.Point(72, 19);
            this.btnYplus.Name = "btnYplus";
            this.btnYplus.Size = new System.Drawing.Size(54, 23);
            this.btnYplus.TabIndex = 1;
            this.btnYplus.Text = "Y+";
            this.btnYplus.Click += new System.EventHandler(this.Yplus_Click);
            // 
            // btnXminus
            // 
            this.btnXminus.Location = new System.Drawing.Point(23, 53);
            this.btnXminus.Name = "btnXminus";
            this.btnXminus.Size = new System.Drawing.Size(54, 23);
            this.btnXminus.TabIndex = 1;
            this.btnXminus.Text = "X-";
            this.btnXminus.Click += new System.EventHandler(this.Xminus_Click);
            // 
            // btnXplus
            // 
            this.btnXplus.Location = new System.Drawing.Point(124, 53);
            this.btnXplus.Name = "btnXplus";
            this.btnXplus.Size = new System.Drawing.Size(54, 23);
            this.btnXplus.TabIndex = 1;
            this.btnXplus.Text = "X+";
            this.btnXplus.Click += new System.EventHandler(this.Xplus_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EnObjetivo);
            this.groupBox2.Controls.Add(this.Error);
            this.groupBox2.Controls.Add(this.chb_simulacion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.simX);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tolerancia);
            this.groupBox2.Controls.Add(this.Velocidad);
            this.groupBox2.Controls.Add(this.simY);
            this.groupBox2.Controls.Add(this.realX);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.objetivoX);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.realY);
            this.groupBox2.Controls.Add(this.objetivoY);
            this.groupBox2.Location = new System.Drawing.Point(15, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 203);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Posición";
            // 
            // EnObjetivo
            // 
            this.EnObjetivo.AutoSize = true;
            this.EnObjetivo.Location = new System.Drawing.Point(59, 152);
            this.EnObjetivo.Name = "EnObjetivo";
            this.EnObjetivo.Size = new System.Drawing.Size(29, 13);
            this.EnObjetivo.TabIndex = 8;
            this.EnObjetivo.Text = "Error";
            this.EnObjetivo.Click += new System.EventHandler(this.label6_Click);
            // 
            // Error
            // 
            this.Error.AutoSize = true;
            this.Error.Location = new System.Drawing.Point(59, 127);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(29, 13);
            this.Error.TabIndex = 8;
            this.Error.Text = "Error";
            // 
            // chb_simulacion
            // 
            this.chb_simulacion.AutoSize = true;
            this.chb_simulacion.Location = new System.Drawing.Point(183, 127);
            this.chb_simulacion.Name = "chb_simulacion";
            this.chb_simulacion.Size = new System.Drawing.Size(77, 17);
            this.chb_simulacion.TabIndex = 7;
            this.chb_simulacion.Text = "Simulación";
            this.chb_simulacion.UseVisualStyleBackColor = true;
            this.chb_simulacion.CheckedChanged += new System.EventHandler(this.chb_simulacion_CheckedChanged);
            // 
            // tolerancia
            // 
            this.tolerancia.AutoSize = true;
            this.tolerancia.Location = new System.Drawing.Point(121, 127);
            this.tolerancia.Name = "tolerancia";
            this.tolerancia.Size = new System.Drawing.Size(53, 13);
            this.tolerancia.TabIndex = 4;
            this.tolerancia.Text = "tolerancia";
            this.tolerancia.Click += new System.EventHandler(this.label1_Click);
            // 
            // Velocidad
            // 
            this.Velocidad.AutoSize = true;
            this.Velocidad.Location = new System.Drawing.Point(180, 152);
            this.Velocidad.Name = "Velocidad";
            this.Velocidad.Size = new System.Drawing.Size(54, 13);
            this.Velocidad.TabIndex = 4;
            this.Velocidad.Text = "Velocidad";
            this.Velocidad.Click += new System.EventHandler(this.label1_Click);
            // 
            // chb_parada
            // 
            this.chb_parada.AutoSize = true;
            this.chb_parada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chb_parada.Checked = true;
            this.chb_parada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_parada.Cursor = System.Windows.Forms.Cursors.No;
            this.chb_parada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_parada.Location = new System.Drawing.Point(239, 34);
            this.chb_parada.Name = "chb_parada";
            this.chb_parada.Size = new System.Drawing.Size(60, 17);
            this.chb_parada.TabIndex = 7;
            this.chb_parada.Text = "Parada";
            this.chb_parada.UseVisualStyleBackColor = false;
            this.chb_parada.CheckedChanged += new System.EventHandler(this.chb_parada_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(443, 466);
            this.Controls.Add(this.chb_parada);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "SCARAFITTI CONTROL";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
                hVarRealX = tcClient.CreateVariableHandle("GVL.Xc");
                hVarRealY = tcClient.CreateVariableHandle("GVL.Yc");
                hVarSimX = tcClient.CreateVariableHandle("GVL.Xc");
                hVarSimY = tcClient.CreateVariableHandle("GVL.Yc");
                hVarVelocidad = tcClient.CreateVariableHandle("Simulacion.vel");
                hVarTolerancia = tcClient.CreateVariableHandle("GVL.deadband_angulo");
                hVarSimulacion = tcClient.CreateVariableHandle("GVL.simulacion");
                hVarParada = tcClient.CreateVariableHandle("GVL.parada");
                hVarEnObjetivo = tcClient.CreateVariableHandle("GVL.en_objetivo_alfa");

            }
            catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

        private void chb_parada_CheckedChanged(object sender, EventArgs e)
        {
            tcClient.WriteAny(hVarParada, chb_parada.Checked);
        }

        private void chb_simulacion_CheckedChanged(object sender, EventArgs e)
        {
            tcClient.WriteAny(hVarSimulacion, chb_simulacion.Checked);

        }

        private void lbArray_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Yplus_Click(object sender, System.EventArgs e)
		{
			try
			{
		


				auxY = auxY + 100;
			
				tcClient.WriteAny(hVarY, auxY);

			
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AdsStream dataStream = new AdsStream(100 * 4);
            BinaryReader binRead = new BinaryReader(dataStream);
            objetivoY.Text = auxY.ToString() + " mm";
            objetivoY.Refresh();
            objetivoX.Text = auxX + " mm";
            objetivoX.Refresh();
            tcClient.Read(hVarRealX, dataStream);
            dataStream.Position = 0;
            realX.Text = binRead.ReadInt32().ToString() + " mm";

        }

        private void label6_Click(object sender, EventArgs e)
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
				objetivoY.Text = binRead.ReadInt32().ToString() + " mm";

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

				auxX = auxX + 100;

				tcClient.WriteAny(hVarX, auxX);

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
				objetivoX.Text = binRead.ReadInt32().ToString() + " mm";
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
