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
        private int hVarSimulacion_alfa, hVarSimulacion_beta, hVarParada, hVarEnObjetivo, hVarError, hVarAlfa, hVarBeta,hVarRegimenMax, hVarQuieto, hVarCommsStatus;
        private int hVarRegimenAlfa, hVarRegimenBeta, hVarTopeAlfa, hVarTopeBeta;
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
        private CheckBox chb_simulacion_alfa;
        private Label Velocidad;
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
        private Label labelParada;
        private Label labelComms;
        private CheckBox chb_simulacion_beta;
        private Label labelErrorObjetivo;
        private GroupBox groupBox4;
        private Label labelVelSim;
        private Label labelRegimenBeta;
        private Label label7;
        private Label labelRegimenAlfa;
        private Label label6;
        private Label labelTopeBeta;
        private Label labelTopeAlfa;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Label labelEnObjetivo;
        private CheckBox checkBoxTopeBeta;
        private CheckBox checkBoxTopeAlfa;
        private TextBox textBoxRegMax;
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
            this.label6 = new System.Windows.Forms.Label();
            this.labelRegimenBeta = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelRegimenAlfa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRegimen = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTolerancia = new System.Windows.Forms.TextBox();
            this.tolerancia = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBoxTopeBeta = new System.Windows.Forms.CheckBox();
            this.labelTopeBeta = new System.Windows.Forms.Label();
            this.checkBoxTopeAlfa = new System.Windows.Forms.CheckBox();
            this.labelTopeAlfa = new System.Windows.Forms.Label();
            this.textBoxVelocidad = new System.Windows.Forms.TextBox();
            this.chb_simulacion_alfa = new System.Windows.Forms.CheckBox();
            this.Velocidad = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mandarComando = new System.Windows.Forms.Button();
            this.CommandBox = new System.Windows.Forms.TextBox();
            this.labelComms = new System.Windows.Forms.Label();
            this.LabelGFeedback = new System.Windows.Forms.Label();
            this.BotonParada = new System.Windows.Forms.Button();
            this.BotonArranque = new System.Windows.Forms.Button();
            this.labelParada = new System.Windows.Forms.Label();
            this.chb_simulacion_beta = new System.Windows.Forms.CheckBox();
            this.labelErrorObjetivo = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelVelSim = new System.Windows.Forms.Label();
            this.labelEnObjetivo = new System.Windows.Forms.Label();
            this.textBoxRegMax = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.label4.Location = new System.Drawing.Point(93, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Real";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // realX
            // 
            this.realX.AutoSize = true;
            this.realX.Location = new System.Drawing.Point(93, 60);
            this.realX.Name = "realX";
            this.realX.Size = new System.Drawing.Size(31, 13);
            this.realX.TabIndex = 4;
            this.realX.Text = "realX";
            this.realX.Click += new System.EventHandler(this.label1_Click);
            // 
            // realY
            // 
            this.realY.AutoSize = true;
            this.realY.Location = new System.Drawing.Point(93, 95);
            this.realY.Name = "realY";
            this.realY.Size = new System.Drawing.Size(29, 13);
            this.realY.TabIndex = 4;
            this.realY.Text = "realy";
            this.realY.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelAlfa
            // 
            this.labelAlfa.AutoSize = true;
            this.labelAlfa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelAlfa.Location = new System.Drawing.Point(174, 60);
            this.labelAlfa.Name = "labelAlfa";
            this.labelAlfa.Size = new System.Drawing.Size(24, 13);
            this.labelAlfa.TabIndex = 4;
            this.labelAlfa.Text = "alfa";
            this.labelAlfa.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.Location = new System.Drawing.Point(174, 95);
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
            this.groupBox2.Controls.Add(this.textBoxRegMax);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.labelRegimenBeta);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.labelRegimenAlfa);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labelBeta);
            this.groupBox2.Controls.Add(this.realX);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.objetivoX);
            this.groupBox2.Controls.Add(this.labelAlfa);
            this.groupBox2.Controls.Add(this.realY);
            this.groupBox2.Controls.Add(this.objetivoY);
            this.groupBox2.Controls.Add(this.labelRegimen);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxTolerancia);
            this.groupBox2.Controls.Add(this.tolerancia);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Location = new System.Drawing.Point(15, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 203);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Posición";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(314, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tope";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // labelRegimenBeta
            // 
            this.labelRegimenBeta.AutoSize = true;
            this.labelRegimenBeta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelRegimenBeta.Location = new System.Drawing.Point(225, 95);
            this.labelRegimenBeta.Name = "labelRegimenBeta";
            this.labelRegimenBeta.Size = new System.Drawing.Size(65, 13);
            this.labelRegimenBeta.TabIndex = 19;
            this.labelRegimenBeta.Text = "regimenbeta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(225, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Regimen";
            // 
            // labelRegimenAlfa
            // 
            this.labelRegimenAlfa.AutoSize = true;
            this.labelRegimenAlfa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelRegimenAlfa.Location = new System.Drawing.Point(225, 60);
            this.labelRegimenAlfa.Name = "labelRegimenAlfa";
            this.labelRegimenAlfa.Size = new System.Drawing.Size(61, 13);
            this.labelRegimenAlfa.TabIndex = 17;
            this.labelRegimenAlfa.Text = "regimenalfa";
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
            // labelRegimen
            // 
            this.labelRegimen.AutoSize = true;
            this.labelRegimen.Location = new System.Drawing.Point(257, 152);
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
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Reg Max";
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
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(6, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(149, 123);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBoxTopeBeta);
            this.groupBox6.Controls.Add(this.labelTopeBeta);
            this.groupBox6.Controls.Add(this.checkBoxTopeAlfa);
            this.groupBox6.Controls.Add(this.labelTopeAlfa);
            this.groupBox6.Location = new System.Drawing.Point(161, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(270, 124);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            // 
            // checkBoxTopeBeta
            // 
            this.checkBoxTopeBeta.AutoSize = true;
            this.checkBoxTopeBeta.Location = new System.Drawing.Point(156, 83);
            this.checkBoxTopeBeta.Name = "checkBoxTopeBeta";
            this.checkBoxTopeBeta.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTopeBeta.TabIndex = 23;
            this.checkBoxTopeBeta.UseVisualStyleBackColor = true;
            this.checkBoxTopeBeta.CheckedChanged += new System.EventHandler(this.checkBoxTopeBeta_CheckedChanged);
            // 
            // labelTopeBeta
            // 
            this.labelTopeBeta.AutoSize = true;
            this.labelTopeBeta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTopeBeta.Location = new System.Drawing.Point(176, 83);
            this.labelTopeBeta.Name = "labelTopeBeta";
            this.labelTopeBeta.Size = new System.Drawing.Size(76, 13);
            this.labelTopeBeta.TabIndex = 22;
            this.labelTopeBeta.Text = "labelTopeBeta";
            // 
            // checkBoxTopeAlfa
            // 
            this.checkBoxTopeAlfa.AutoSize = true;
            this.checkBoxTopeAlfa.Location = new System.Drawing.Point(157, 51);
            this.checkBoxTopeAlfa.Name = "checkBoxTopeAlfa";
            this.checkBoxTopeAlfa.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTopeAlfa.TabIndex = 19;
            this.checkBoxTopeAlfa.UseVisualStyleBackColor = true;
            this.checkBoxTopeAlfa.CheckedChanged += new System.EventHandler(this.checkBoxTopeAlfa_CheckedChanged);
            // 
            // labelTopeAlfa
            // 
            this.labelTopeAlfa.AutoSize = true;
            this.labelTopeAlfa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTopeAlfa.Location = new System.Drawing.Point(180, 51);
            this.labelTopeAlfa.Name = "labelTopeAlfa";
            this.labelTopeAlfa.Size = new System.Drawing.Size(72, 13);
            this.labelTopeAlfa.TabIndex = 21;
            this.labelTopeAlfa.Text = "labelTopeAlfa";
            // 
            // textBoxVelocidad
            // 
            this.textBoxVelocidad.Location = new System.Drawing.Point(479, 210);
            this.textBoxVelocidad.Name = "textBoxVelocidad";
            this.textBoxVelocidad.Size = new System.Drawing.Size(77, 20);
            this.textBoxVelocidad.TabIndex = 9;
            this.textBoxVelocidad.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // chb_simulacion_alfa
            // 
            this.chb_simulacion_alfa.AutoSize = true;
            this.chb_simulacion_alfa.Location = new System.Drawing.Point(479, 174);
            this.chb_simulacion_alfa.Name = "chb_simulacion_alfa";
            this.chb_simulacion_alfa.Size = new System.Drawing.Size(44, 17);
            this.chb_simulacion_alfa.TabIndex = 7;
            this.chb_simulacion_alfa.Text = "Alfa";
            this.chb_simulacion_alfa.UseVisualStyleBackColor = true;
            this.chb_simulacion_alfa.CheckedChanged += new System.EventHandler(this.chb_simulacion_CheckedChanged);
            // 
            // Velocidad
            // 
            this.Velocidad.AutoSize = true;
            this.Velocidad.Location = new System.Drawing.Point(474, 194);
            this.Velocidad.Name = "Velocidad";
            this.Velocidad.Size = new System.Drawing.Size(54, 13);
            this.Velocidad.TabIndex = 4;
            this.Velocidad.Text = "Velocidad";
            this.Velocidad.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mandarComando);
            this.groupBox3.Controls.Add(this.CommandBox);
            this.groupBox3.Controls.Add(this.labelComms);
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
            // labelComms
            // 
            this.labelComms.Location = new System.Drawing.Point(7, 16);
            this.labelComms.Name = "labelComms";
            this.labelComms.Size = new System.Drawing.Size(174, 26);
            this.labelComms.TabIndex = 14;
            this.labelComms.Text = "labelComms";
            this.labelComms.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelGFeedback
            // 
            this.LabelGFeedback.Location = new System.Drawing.Point(7, 46);
            this.LabelGFeedback.Name = "LabelGFeedback";
            this.LabelGFeedback.Size = new System.Drawing.Size(174, 22);
            this.LabelGFeedback.TabIndex = 8;
            this.LabelGFeedback.Text = "Feedback";
            this.LabelGFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // labelParada
            // 
            this.labelParada.Location = new System.Drawing.Point(296, 15);
            this.labelParada.Name = "labelParada";
            this.labelParada.Size = new System.Drawing.Size(174, 26);
            this.labelParada.TabIndex = 13;
            this.labelParada.Text = "labelParada";
            this.labelParada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelParada.Click += new System.EventHandler(this.labelParada_Click);
            // 
            // chb_simulacion_beta
            // 
            this.chb_simulacion_beta.AutoSize = true;
            this.chb_simulacion_beta.Location = new System.Drawing.Point(529, 174);
            this.chb_simulacion_beta.Name = "chb_simulacion_beta";
            this.chb_simulacion_beta.Size = new System.Drawing.Size(48, 17);
            this.chb_simulacion_beta.TabIndex = 15;
            this.chb_simulacion_beta.Text = "Beta";
            this.chb_simulacion_beta.UseVisualStyleBackColor = true;
            this.chb_simulacion_beta.CheckedChanged += new System.EventHandler(this.chb_simulacion_beta_CheckedChanged);
            // 
            // labelErrorObjetivo
            // 
            this.labelErrorObjetivo.Location = new System.Drawing.Point(294, 101);
            this.labelErrorObjetivo.Name = "labelErrorObjetivo";
            this.labelErrorObjetivo.Size = new System.Drawing.Size(174, 26);
            this.labelErrorObjetivo.TabIndex = 16;
            this.labelErrorObjetivo.Text = "labelErrorObjetivo";
            this.labelErrorObjetivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelVelSim);
            this.groupBox4.Location = new System.Drawing.Point(460, 154);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(133, 203);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Simulacion";
            // 
            // labelVelSim
            // 
            this.labelVelSim.AutoSize = true;
            this.labelVelSim.Location = new System.Drawing.Point(68, 40);
            this.labelVelSim.Name = "labelVelSim";
            this.labelVelSim.Size = new System.Drawing.Size(74, 13);
            this.labelVelSim.TabIndex = 5;
            this.labelVelSim.Text = "Velocidad Sim";
            // 
            // labelEnObjetivo
            // 
            this.labelEnObjetivo.Location = new System.Drawing.Point(296, 43);
            this.labelEnObjetivo.Name = "labelEnObjetivo";
            this.labelEnObjetivo.Size = new System.Drawing.Size(174, 26);
            this.labelEnObjetivo.TabIndex = 18;
            this.labelEnObjetivo.Text = "labelEnObjetivo";
            this.labelEnObjetivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxRegMax
            // 
            this.textBoxRegMax.Location = new System.Drawing.Point(212, 169);
            this.textBoxRegMax.Name = "textBoxRegMax";
            this.textBoxRegMax.Size = new System.Drawing.Size(77, 20);
            this.textBoxRegMax.TabIndex = 10;
            this.textBoxRegMax.TextChanged += new System.EventHandler(this.textBoxRegMax_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(660, 466);
            this.Controls.Add(this.labelEnObjetivo);
            this.Controls.Add(this.labelErrorObjetivo);
            this.Controls.Add(this.chb_simulacion_beta);
            this.Controls.Add(this.labelParada);
            this.Controls.Add(this.BotonArranque);
            this.Controls.Add(this.textBoxVelocidad);
            this.Controls.Add(this.BotonParada);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chb_simulacion_alfa);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Velocidad);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form1";
            this.Text = "SCARAFITTI CONTROL";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
				hVarX = tcClient.CreateVariableHandle("GVL.Xc_sp");
				hVarY = tcClient.CreateVariableHandle("GVL.Yc_sp");
                hVarRealX = tcClient.CreateVariableHandle("GVL.Xc");
                hVarRealY = tcClient.CreateVariableHandle("GVL.Yc");
                hVarSimX = tcClient.CreateVariableHandle("GVL.Xc");
                hVarSimY = tcClient.CreateVariableHandle("GVL.Yc");
                hVarVelocidad = tcClient.CreateVariableHandle("Simulacion.vel");
                hVarTolerancia = tcClient.CreateVariableHandle("GVL.deadband_angulo");
                hVarSimulacion_alfa = tcClient.CreateVariableHandle("GVL.Scarafitti.simulacion_alfa");
                hVarSimulacion_beta = tcClient.CreateVariableHandle("GVL.Scarafitti.simulacion_beta");
                hVarParada = tcClient.CreateVariableHandle("GVL.Scarafitti.parada");
                hVarEnObjetivo = tcClient.CreateVariableHandle("GVL.Scarafitti.en_objetivo");
                hVarQuieto = tcClient.CreateVariableHandle("GVL.Scarafitti.quieto");
                hVarError = tcClient.CreateVariableHandle("GVL.Scarafitti.error_objetivo");
                hVarAlfa = tcClient.CreateVariableHandle("IO.alfa_deg");
                hVarBeta = tcClient.CreateVariableHandle("IO.beta_deg");
                hVarStringCommand = tcClient.CreateVariableHandle("IO.string_in");
                hVarStringFeedback = tcClient.CreateVariableHandle("IO.string_out");
                hVarRegimenMax = tcClient.CreateVariableHandle("GVL.regimen_maximo");
                hVarCommsStatus = tcClient.CreateVariableHandle("GVL.Scarafitti.ADSCOM_ready");
                hVarRegimenAlfa = tcClient.CreateVariableHandle("GVL.Cilindro1.regimen");
                hVarRegimenBeta = tcClient.CreateVariableHandle("GVL.Cilindro2.regimen");
                hVarTopeAlfa = tcClient.CreateVariableHandle("IO.tope_alfa");
                hVarTopeBeta = tcClient.CreateVariableHandle("IO.tope_beta");




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

        private void checkBoxTopeBeta_CheckedChanged(object sender, EventArgs e)
        {
            tcClient.WriteAny(hVarTopeBeta, checkBoxTopeBeta.Checked);
        }

        private void textBoxRegMax_TextChanged(object sender, EventArgs e)
        {
            tcClient.WriteAny(hVarRegimenMax, Convert.ToSingle(textBoxRegMax.Text));
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBoxTopeAlfa_CheckedChanged(object sender, EventArgs e)
        {
            tcClient.WriteAny(hVarTopeAlfa, checkBoxTopeAlfa.Checked);
        }

        private void chb_simulacion_beta_CheckedChanged(object sender, EventArgs e)
        {
            tcClient.WriteAny(hVarSimulacion_beta, chb_simulacion_beta.Checked);
        }

        private void textBox1_TextChanged_3(object sender, EventArgs e)
        {

        }

        private void labelParada_Click(object sender, EventArgs e)
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
            tcClient.WriteAny(hVarSimulacion_alfa, chb_simulacion_alfa.Checked);

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
            labelAlfa.Text = binRead.ReadSingle().ToString("0.0") + "deg";
            //mostrar beta
            tcClient.Read(hVarBeta, dataStream);
            dataStream.Position = 0;
            labelBeta.Text = binRead.ReadSingle().ToString("0.0") + "deg";
            //mostrar regimen maximo
            tcClient.Read(hVarRegimenMax, dataStream);
            dataStream.Position = 0;
            labelRegimen.Text = binRead.ReadSingle().ToString("0") + "%";
            labelRegimen.Refresh();
            //mostrar velocidad sim
            tcClient.Read(hVarVelocidad, dataStream);
            dataStream.Position = 0;
            labelVelSim.Text = binRead.ReadSingle().ToString();
            labelVelSim.Refresh();
            //mostrar regimenalfa
            tcClient.Read(hVarRegimenAlfa, dataStream);
            dataStream.Position = 0;
            labelRegimenAlfa.Text = binRead.ReadSingle().ToString("0") + "%";
            labelRegimenAlfa.Refresh();
            //mostrar regimenbeta
            tcClient.Read(hVarRegimenBeta, dataStream);
            dataStream.Position = 0;
            labelRegimenBeta.Text = binRead.ReadSingle().ToString("0") + "%";



            //mostrar PARADA/MARCHA
            tcClient.Read(hVarParada, dataStream);
            dataStream.Position = 0;          
            if (binRead.ReadBoolean())
            {
                labelParada.Text = "PARO";
                labelParada.BackColor = Color.LightSalmon;

            }
            else
            {
                labelParada.Text = "MARCHA";
                labelParada.BackColor = Color.LightGreen;
            }
            labelParada.Refresh();

            //mostrar COMMS STATUS
            tcClient.Read(hVarCommsStatus, dataStream);
            dataStream.Position = 0;
            if (binRead.ReadBoolean())
            {
                labelComms.Text = "ADSCOM READY";
                labelComms.BackColor = Color.LightBlue;

            }
            else
            {
                labelComms.Text = "ADSCOM NOT READY";
                labelComms.BackColor = Color.LightGray;
            }
            labelComms.Refresh();

            //mostrar ERROR OBJETIVO
            tcClient.Read(hVarError, dataStream);
            dataStream.Position = 0;
            if (binRead.ReadBoolean())
            {
                labelErrorObjetivo.Text = "ERROR OBJETIVO";
                labelErrorObjetivo.BackColor = Color.LightSalmon;

            }
            else
            {
                labelErrorObjetivo.Text = "";
                labelErrorObjetivo.BackColor = Color.LightGray;
            }
            labelErrorObjetivo.Refresh();

            //mostrar EN OBJETIVO
            tcClient.Read(hVarEnObjetivo, dataStream);
            dataStream.Position = 0;
            if (binRead.ReadBoolean())
            {
                labelEnObjetivo.Text = "EN OBJETIVO";
                labelEnObjetivo.BackColor = Color.LightGreen;

            }
            else
            {
                labelEnObjetivo.Text = "MOVIENDO";
                labelEnObjetivo.BackColor = Color.LightGoldenrodYellow;
            }
            labelEnObjetivo.Refresh();


            //GCode listen
            string str = tcClient.ReadAnyString(hVarStringFeedback, 80, Encoding.Default);
            LabelGFeedback.Text = str;
            LabelGFeedback.Refresh();





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
                tcClient.DeleteVariableHandle(hVarSimulacion_alfa);
                tcClient.DeleteVariableHandle(hVarSimulacion_beta);
                tcClient.DeleteVariableHandle(hVarParada );
                tcClient.DeleteVariableHandle(hVarEnObjetivo);
                tcClient.DeleteVariableHandle(hVarError );
                tcClient.DeleteVariableHandle(hVarAlfa );
                tcClient.DeleteVariableHandle(hVarBeta );
                tcClient.DeleteVariableHandle(hVarStringCommand);
                tcClient.DeleteVariableHandle(hVarStringFeedback);
                tcClient.DeleteVariableHandle(hVarRegimenMax);
                

            }
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
			tcClient.Dispose();				
		}		
	}
}
