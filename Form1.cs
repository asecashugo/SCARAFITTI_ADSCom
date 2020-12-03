using System;
using System.Text;
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
        private int hVarX, hVarY, auxX, auxY, hVarRealX, hVarRealY, hVarSimX, hVarSimY, hVarVelocidad, hVarTolerancia;
        private int hVarSimulacion, hVarParada, hVarEnObjetivo, hVarError, hVarAlfa, hVarBeta,hVarRegimen;
        private bool auxError;
        private int hVarStringCommand, hVarStringFeedback;
        private Label objetivoY;
        private Label objetivoX;
        private Label label3;
        private Label label4;
        private Label realX;
        private Label realY;
        private Label labelAlfa;
        private Label labelBeta;
        private Timer timer1;
        private GroupBox groupBox1;
        private Button btnYplus;
        private Button btnXplus;
        private Button btnXminus;
        private Button btnYminus;
        private GroupBox groupBox2;
        private CheckBox chb_simulacion;
        private Label LabelError;
        private Label Velocidad;
        private Label EnObjetivo;
        private Label tolerancia;
        private TextBox textBoxVelocidad;
        private GroupBox groupBox3;
        private TextBox CommandBox;
        private Label LabelGFeedback;
        private Button mandarComando;
        private Button BotonParada;
        private Button BotonArranque;
        private Button BotonReset;
        private TextBox textBoxTolerancia;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label labelRegimen;
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.realX = new System.Windows.Forms.Label();
            this.realY = new System.Windows.Forms.Label();
            this.labelAlfa = new System.Windows.Forms.Label();
            this.labelBeta = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BotonReset = new System.Windows.Forms.Button();
            this.btnYminus = new System.Windows.Forms.Button();
            this.btnYplus = new System.Windows.Forms.Button();
            this.btnXminus = new System.Windows.Forms.Button();
            this.btnXplus = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelRegimen = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTolerancia = new System.Windows.Forms.TextBox();
            this.textBoxVelocidad = new System.Windows.Forms.TextBox();
            this.EnObjetivo = new System.Windows.Forms.Label();
            this.LabelError = new System.Windows.Forms.Label();
            this.chb_simulacion = new System.Windows.Forms.CheckBox();
            this.tolerancia = new System.Windows.Forms.Label();
            this.Velocidad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mandarComando = new System.Windows.Forms.Button();
            this.CommandBox = new System.Windows.Forms.TextBox();
            this.LabelGFeedback = new System.Windows.Forms.Label();
            this.BotonParada = new System.Windows.Forms.Button();
            this.BotonArranque = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // objetivoY
            // 
            this.objetivoY.AutoSize = true;
            this.objetivoY.Location = new System.Drawing.Point(31, 95);
            this.objetivoY.Name = "objetivoY";
            this.objetivoY.Size = new System.Drawing.Size(36, 13);
            this.objetivoY.TabIndex = 4;
            this.objetivoY.Text = "labelY";
            this.objetivoY.Click += new System.EventHandler(this.label1_Click);
            // 
            // objetivoX
            // 
            this.objetivoX.AutoSize = true;
            this.objetivoX.Location = new System.Drawing.Point(31, 60);
            this.objetivoX.Name = "objetivoX";
            this.objetivoX.Size = new System.Drawing.Size(36, 13);
            this.objetivoX.TabIndex = 4;
            this.objetivoX.Text = "labelX";
            this.objetivoX.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 29);
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
            this.label4.Location = new System.Drawing.Point(98, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Real";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // realX
            // 
            this.realX.AutoSize = true;
            this.realX.Location = new System.Drawing.Point(98, 60);
            this.realX.Name = "realX";
            this.realX.Size = new System.Drawing.Size(31, 13);
            this.realX.TabIndex = 4;
            this.realX.Text = "realX";
            this.realX.Click += new System.EventHandler(this.label1_Click);
            // 
            // realY
            // 
            this.realY.AutoSize = true;
            this.realY.Location = new System.Drawing.Point(98, 95);
            this.realY.Name = "realY";
            this.realY.Size = new System.Drawing.Size(29, 13);
            this.realY.TabIndex = 4;
            this.realY.Text = "realy";
            this.realY.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelAlfa
            // 
            this.labelAlfa.AutoSize = true;
            this.labelAlfa.Location = new System.Drawing.Point(152, 60);
            this.labelAlfa.Name = "labelAlfa";
            this.labelAlfa.Size = new System.Drawing.Size(24, 13);
            this.labelAlfa.TabIndex = 4;
            this.labelAlfa.Text = "alfa";
            this.labelAlfa.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.Location = new System.Drawing.Point(152, 95);
            this.labelBeta.Name = "labelBeta";
            this.labelBeta.Size = new System.Drawing.Size(28, 13);
            this.labelBeta.TabIndex = 4;
            this.labelBeta.Text = "beta";
            this.labelBeta.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BotonReset);
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
            // BotonReset
            // 
            this.BotonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BotonReset.Location = new System.Drawing.Point(72, 50);
            this.BotonReset.Name = "BotonReset";
            this.BotonReset.Size = new System.Drawing.Size(54, 32);
            this.BotonReset.TabIndex = 3;
            this.BotonReset.Text = "Reset";
            this.BotonReset.UseVisualStyleBackColor = false;
            this.BotonReset.Click += new System.EventHandler(this.BotonReset_Click);
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
            this.btnXminus.Location = new System.Drawing.Point(23, 54);
            this.btnXminus.Name = "btnXminus";
            this.btnXminus.Size = new System.Drawing.Size(39, 23);
            this.btnXminus.TabIndex = 1;
            this.btnXminus.Text = "X-";
            this.btnXminus.Click += new System.EventHandler(this.Xminus_Click);
            // 
            // btnXplus
            // 
            this.btnXplus.Location = new System.Drawing.Point(138, 54);
            this.btnXplus.Name = "btnXplus";
            this.btnXplus.Size = new System.Drawing.Size(37, 23);
            this.btnXplus.TabIndex = 1;
            this.btnXplus.Text = "X+";
            this.btnXplus.Click += new System.EventHandler(this.Xplus_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelRegimen);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxTolerancia);
            this.groupBox2.Controls.Add(this.textBoxVelocidad);
            this.groupBox2.Controls.Add(this.EnObjetivo);
            this.groupBox2.Controls.Add(this.LabelError);
            this.groupBox2.Controls.Add(this.chb_simulacion);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tolerancia);
            this.groupBox2.Controls.Add(this.Velocidad);
            this.groupBox2.Controls.Add(this.labelBeta);
            this.groupBox2.Controls.Add(this.realX);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.objetivoX);
            this.groupBox2.Controls.Add(this.labelAlfa);
            this.groupBox2.Controls.Add(this.realY);
            this.groupBox2.Controls.Add(this.objetivoY);
            this.groupBox2.Location = new System.Drawing.Point(15, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 203);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Posición";
            // 
            // labelRegimen
            // 
            this.labelRegimen.AutoSize = true;
            this.labelRegimen.Location = new System.Drawing.Point(212, 176);
            this.labelRegimen.Name = "labelRegimen";
            this.labelRegimen.Size = new System.Drawing.Size(66, 13);
            this.labelRegimen.TabIndex = 16;
            this.labelRegimen.Text = "Regimen [%]";
            this.labelRegimen.Click += new System.EventHandler(this.labelRegimen_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Regimen [%]";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBoxTolerancia
            // 
            this.textBoxTolerancia.Location = new System.Drawing.Point(96, 169);
            this.textBoxTolerancia.Name = "textBoxTolerancia";
            this.textBoxTolerancia.Size = new System.Drawing.Size(54, 20);
            this.textBoxTolerancia.TabIndex = 14;
            this.textBoxTolerancia.TextChanged += new System.EventHandler(this.textBox1_TextChanged_2);
            // 
            // textBoxVelocidad
            // 
            this.textBoxVelocidad.Location = new System.Drawing.Point(155, 169);
            this.textBoxVelocidad.Name = "textBoxVelocidad";
            this.textBoxVelocidad.Size = new System.Drawing.Size(51, 20);
            this.textBoxVelocidad.TabIndex = 9;
            this.textBoxVelocidad.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // EnObjetivo
            // 
            this.EnObjetivo.AutoSize = true;
            this.EnObjetivo.Location = new System.Drawing.Point(31, 152);
            this.EnObjetivo.Name = "EnObjetivo";
            this.EnObjetivo.Size = new System.Drawing.Size(59, 13);
            this.EnObjetivo.TabIndex = 8;
            this.EnObjetivo.Text = "EnObjetivo";
            this.EnObjetivo.Click += new System.EventHandler(this.label6_Click);
            // 
            // LabelError
            // 
            this.LabelError.AutoSize = true;
            this.LabelError.Location = new System.Drawing.Point(31, 127);
            this.LabelError.Name = "LabelError";
            this.LabelError.Size = new System.Drawing.Size(29, 13);
            this.LabelError.TabIndex = 8;
            this.LabelError.Text = "Error";
            this.LabelError.Click += new System.EventHandler(this.Error_Click);
            // 
            // chb_simulacion
            // 
            this.chb_simulacion.AutoSize = true;
            this.chb_simulacion.Location = new System.Drawing.Point(155, 127);
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
            this.tolerancia.Location = new System.Drawing.Point(93, 152);
            this.tolerancia.Name = "tolerancia";
            this.tolerancia.Size = new System.Drawing.Size(57, 13);
            this.tolerancia.TabIndex = 4;
            this.tolerancia.Text = "Tolerancia";
            this.tolerancia.Click += new System.EventHandler(this.label1_Click);
            // 
            // Velocidad
            // 
            this.Velocidad.AutoSize = true;
            this.Velocidad.Location = new System.Drawing.Point(152, 152);
            this.Velocidad.Name = "Velocidad";
            this.Velocidad.Size = new System.Drawing.Size(54, 13);
            this.Velocidad.TabIndex = 4;
            this.Velocidad.Text = "Velocidad";
            this.Velocidad.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mandarComando);
            this.groupBox3.Controls.Add(this.CommandBox);
            this.groupBox3.Controls.Add(this.LabelGFeedback);
            this.groupBox3.Location = new System.Drawing.Point(15, 363);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 100);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "G-Code";
            // 
            // mandarComando
            // 
            this.mandarComando.Location = new System.Drawing.Point(206, 71);
            this.mandarComando.Name = "mandarComando";
            this.mandarComando.Size = new System.Drawing.Size(53, 20);
            this.mandarComando.TabIndex = 13;
            this.mandarComando.Text = "Send";
            this.mandarComando.UseVisualStyleBackColor = true;
            this.mandarComando.Click += new System.EventHandler(this.button1_Click);
            // 
            // CommandBox
            // 
            this.CommandBox.Location = new System.Drawing.Point(10, 71);
            this.CommandBox.Name = "CommandBox";
            this.CommandBox.Size = new System.Drawing.Size(190, 20);
            this.CommandBox.TabIndex = 12;
            this.CommandBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // LabelGFeedback
            // 
            this.LabelGFeedback.AutoSize = true;
            this.LabelGFeedback.Location = new System.Drawing.Point(7, 27);
            this.LabelGFeedback.Name = "LabelGFeedback";
            this.LabelGFeedback.Size = new System.Drawing.Size(55, 13);
            this.LabelGFeedback.TabIndex = 8;
            this.LabelGFeedback.Text = "Feedback";
            this.LabelGFeedback.Click += new System.EventHandler(this.label6_Click);
            // 
            // BotonParada
            // 
            this.BotonParada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BotonParada.Location = new System.Drawing.Point(221, 83);
            this.BotonParada.Name = "BotonParada";
            this.BotonParada.Size = new System.Drawing.Size(67, 62);
            this.BotonParada.TabIndex = 12;
            this.BotonParada.Text = "Parada";
            this.BotonParada.UseVisualStyleBackColor = false;
            this.BotonParada.Click += new System.EventHandler(this.BotonParada_Click);
            // 
            // BotonArranque
            // 
            this.BotonArranque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BotonArranque.Location = new System.Drawing.Point(221, 15);
            this.BotonArranque.Name = "BotonArranque";
            this.BotonArranque.Size = new System.Drawing.Size(67, 62);
            this.BotonArranque.TabIndex = 12;
            this.BotonArranque.Text = "Arranque";
            this.BotonArranque.UseVisualStyleBackColor = false;
            this.BotonArranque.Click += new System.EventHandler(this.BotonArranque_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(367, 466);
            this.Controls.Add(this.BotonArranque);
            this.Controls.Add(this.BotonParada);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "SCARAFITTI CONTROL";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
				hVarX = tcClient.CreateVariableHandle("GVL.Xc_sp");
				hVarY = tcClient.CreateVariableHandle("GVL.Yc_sp");
                hVarRealX = tcClient.CreateVariableHandle("GVL.Xc");
                hVarRealY = tcClient.CreateVariableHandle("GVL.Yc");
                hVarSimX = tcClient.CreateVariableHandle("GVL.Xc");
                hVarSimY = tcClient.CreateVariableHandle("GVL.Yc");
                hVarVelocidad = tcClient.CreateVariableHandle("Simulacion.vel");
                hVarTolerancia = tcClient.CreateVariableHandle("GVL.deadband_angulo");
                hVarSimulacion = tcClient.CreateVariableHandle("GVL.simulacion");
                hVarParada = tcClient.CreateVariableHandle("GVL.parada");
                hVarEnObjetivo = tcClient.CreateVariableHandle("GVL.en_objetivo");
                hVarError = tcClient.CreateVariableHandle("GVL.error");
                hVarAlfa = tcClient.CreateVariableHandle("IO.alfa_deg");
                hVarBeta = tcClient.CreateVariableHandle("IO.beta_deg");
                hVarStringCommand = tcClient.CreateVariableHandle("IO.string_in");
                hVarStringFeedback = tcClient.CreateVariableHandle("IO.string_out");
                hVarRegimen = tcClient.CreateVariableHandle("GVL.regimen_maximo");

            }
            catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}



        private void button1_Click(object sender, EventArgs e)
        {
            tcClient.WriteAnyString(hVarStringCommand, CommandBox.Text, 80, System.Text.Encoding.Default);
        }

        private void BotonParada_Click(object sender, EventArgs e)
        {
            tcClient.WriteAny(hVarParada, true);
        }
        private void BotonArranque_Click(object sender, EventArgs e)
        {
            tcClient.WriteAny(hVarParada, false);
        }

        private void BotonReset_Click(object sender, EventArgs e)
        {
            tcClient.WriteAnyString(hVarStringCommand, "reset", 80, System.Text.Encoding.Default);
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            tcClient.WriteAny(hVarTolerancia, Convert.ToSingle(textBoxTolerancia.Text));
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_3(object sender, EventArgs e)
        {

        }

        private void labelRegimen_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void chb_simulacion_CheckedChanged(object sender, EventArgs e)
        {
            tcClient.WriteAny(hVarSimulacion, chb_simulacion.Checked);

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            tcClient.WriteAny(hVarVelocidad, Convert.ToSingle(textBoxVelocidad.Text));
        }

        private void Error_Click(object sender, EventArgs e)
        {

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

            //mostrar realX
            tcClient.Read(hVarRealX, dataStream);
            dataStream.Position = 0;
            realX.Text = binRead.ReadSingle().ToString("0.0") + " mm";
            //mostrar realY
            tcClient.Read(hVarRealY, dataStream);
            dataStream.Position = 0;
            realY.Text = binRead.ReadSingle().ToString("0.0") + " mm";

            //mostrar Xsp
            tcClient.Read(hVarX, dataStream);
            dataStream.Position = 0;
            objetivoX.Text = binRead.ReadSingle().ToString("0.0") + " mm";
            //mostrar Ysp
            tcClient.Read(hVarY, dataStream);
            dataStream.Position = 0;
            objetivoY.Text = binRead.ReadSingle().ToString("0.0") + " mm";

            //mostrar alfa
            tcClient.Read(hVarAlfa, dataStream);
            dataStream.Position = 0;
            labelAlfa.Text = "alfa = " + binRead.ReadSingle().ToString("0.00") + "deg";
            //mostrar beta
            tcClient.Read(hVarBeta, dataStream);
            dataStream.Position = 0;
            labelBeta.Text = "beta = " + binRead.ReadSingle().ToString("0.00") + "deg";
            //mostrar regimen
            tcClient.Read(hVarRegimen, dataStream);
            dataStream.Position = 0;
            labelRegimen.Text = binRead.ReadInt32().ToString();

            //mostrar ERROR
            tcClient.Read(hVarError, dataStream);
            dataStream.Position = 0;
            if ((binRead.ReadInt32().Equals(1078460417)))
                { LabelError.Text = "Error";
                LabelError.BackColor = Color.Red;

            }
            else
            {
                LabelError.Text = "No Error";
                LabelError.BackColor = Color.Green;
            }
                
            LabelError.Text = Convert.ToString(binRead.ReadInt32().Equals(1078460417));

            LabelError.Refresh();

            //GCode listen
            string str = tcClient.ReadAnyString(hVarStringFeedback, 80, Encoding.Default);
            LabelGFeedback.Text = str;
            LabelGFeedback.Refresh();

            EnObjetivo.Text = Convert.ToString(hVarEnObjetivo);




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
                tcClient.DeleteVariableHandle(hVarRealX);
                tcClient.DeleteVariableHandle(hVarRealY);
                tcClient.DeleteVariableHandle(hVarSimX );
                tcClient.DeleteVariableHandle(hVarSimY);
                tcClient.DeleteVariableHandle(hVarVelocidad );
                tcClient.DeleteVariableHandle(hVarTolerancia);
                tcClient.DeleteVariableHandle(hVarSimulacion);
                tcClient.DeleteVariableHandle(hVarParada );
                tcClient.DeleteVariableHandle(hVarEnObjetivo);
                tcClient.DeleteVariableHandle(hVarError );
                tcClient.DeleteVariableHandle(hVarAlfa );
                tcClient.DeleteVariableHandle(hVarBeta );
                tcClient.DeleteVariableHandle(hVarStringCommand);
                tcClient.DeleteVariableHandle(hVarStringFeedback);
                tcClient.DeleteVariableHandle(hVarRegimen);
                

            }
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
			tcClient.Dispose();				
		}		
	}
}
