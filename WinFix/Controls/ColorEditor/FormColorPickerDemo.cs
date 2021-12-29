using System;
using System.Drawing;
using System.Windows.Forms;
using MechanikaDesign.WinForms.UI.ColorPicker;
namespace ColorHexagon.Demo
{
    public partial class FormColorPickerDemo : Form
    {
        #region Fields

        private HslColor colorHsl = HslColor.FromAhsl(0xff);
        private ColorModes colorMode = ColorModes.Hue;
		public Color colorRgb = Color.Empty;
        private bool lockUpdates = false;
		private int cbox = 1;
        #endregion

        public FormColorPickerDemo()
        {
            InitializeComponent();
            this.colorBox2D.ColorMode = this.colorMode;
            this.colorSlider.ColorMode = this.colorMode;
        }
		public FormColorPickerDemo(Color ms)
		{
			colorRgb = ms;
			InitializeComponent();
			this.colorBox2D.ColorMode = this.colorMode;
			this.colorSlider.ColorMode = this.colorMode;
		}
        private void colorHexagon_ColorChanged(object sender, ColorChangedEventArgs args)
        {
            labelCurrentColor.BackColor = colorHexagon.SelectedColor;
		//	Dragon.ColorEd.NsQ=colorHexagon.SelectedColor;
	//		Console.WriteLine (colorHexagon.SelectedColor.R+" "+colorHexagon.SelectedColor.G+" "+colorHexagon.SelectedColor.B);
            textboxHexColor.Text = ColorTranslator.ToHtml(colorHexagon.SelectedColor);
        }

        private void colorWheel_ColorChanged(object sender, EventArgs e)
        {
            labelCurrentColor.BackColor = colorWheel.Color;
//			Dragon.ColorEd.NsQ=colorWheel.Color;
            textboxHexColor.Text = ColorTranslator.ToHtml(colorWheel.Color);
        }

        private void colorSlider_ColorChanged(object sender, ColorChangedEventArgs args)
        {
            if (!this.lockUpdates)
            {
                HslColor colorHSL = this.colorSlider.ColorHSL;
                this.colorHsl = colorHSL;
                this.colorRgb = this.colorHsl.RgbValue;
                this.lockUpdates = true;
                this.colorBox2D.ColorHSL = this.colorHsl;
                this.lockUpdates = false;
                labelCurrentColor.BackColor = this.colorRgb;
                textboxHexColor.Text = ColorTranslator.ToHtml(this.colorRgb);
//				Dragon.ColorEd.NsQ=colorRgb;
                UpdateColorFields();
            }  
        }

        private void colorBox2D_ColorChanged(object sender, ColorChangedEventArgs args)
        {
            if (!this.lockUpdates)
            {
                HslColor colorHSL = this.colorBox2D.ColorHSL;
                this.colorHsl = colorHSL;
                this.colorRgb = this.colorHsl.RgbValue;
                this.lockUpdates = true;
                this.colorSlider.ColorHSL = this.colorHsl;
                this.lockUpdates = false;
                labelCurrentColor.BackColor = this.colorRgb;
                textboxHexColor.Text = ColorTranslator.ToHtml(this.colorRgb);
                UpdateColorFields();
            }    
        }

        private void ColorModeChangedHandler(object sender, EventArgs e)
        {
            if (sender == this.radioRed)
            {
                this.colorMode = ColorModes.Red;
            }
            else if (sender == this.radioGreen)
            {
                this.colorMode = ColorModes.Green;
            }
            else if (sender == this.radioBlue)
            {
                this.colorMode = ColorModes.Blue;
            }
            else if (sender == this.radioHue)
            {
                this.colorMode = ColorModes.Hue;
            }
            else if (sender == this.radioSaturation)
            {
                this.colorMode = ColorModes.Saturation;
            }
            else if (sender == this.radioLuminance)
            {
                this.colorMode = ColorModes.Luminance;
            }
            this.colorSlider.ColorMode = this.colorMode;
            this.colorBox2D.ColorMode = this.colorMode;        
        }

        private void UpdateColorFields()
        {
            this.lockUpdates = true;
            this.numRed.Value = this.colorRgb.R;
            this.numGreen.Value = this.colorRgb.G;
            this.numBlue.Value = this.colorRgb.B;
			int val = (int)(((decimal)this.colorHsl.H) * 360M);
			if (val >= 360) {
				val = 359;
			}
			if (val < 0) {
				val = 0;
			}
			this.numHue.Value = val;
            this.numSaturation.Value = (int)(((decimal)this.colorHsl.S) * 100M);
            this.numLuminance.Value = (int)(((decimal)this.colorHsl.L) * 100M);
            this.lockUpdates = false;
        }

        private void UpdateRgbFields(Color newColor)
        {
            this.colorHsl = HslColor.FromColor(newColor);
            this.colorRgb = newColor;
            this.lockUpdates = true;
            this.numHue.Value = (int)(((decimal)this.colorHsl.H) * 360M);
            this.numSaturation.Value = (int)(((decimal)this.colorHsl.S) * 100M);
            this.numLuminance.Value = (int)(((decimal)this.colorHsl.L) * 100M);
            this.lockUpdates = false;
            this.colorSlider.ColorHSL = this.colorHsl;
            this.colorBox2D.ColorHSL = this.colorHsl;
			textboxHexColor.Text = ColorTranslator.ToHtml(this.colorRgb);
			labelCurrentColor.BackColor = colorRgb;
//			Dragon.ColorEd.NsQ=colorRgb;
        }

        private void UpdateHslFields(HslColor newColor)
        {
            this.colorHsl = newColor;
            this.colorRgb = newColor.RgbValue;
            this.lockUpdates = true;
            this.numRed.Value = this.colorRgb.R;
            this.numGreen.Value = this.colorRgb.G;
            this.numBlue.Value = this.colorRgb.B;
            this.lockUpdates = false;
            this.colorSlider.ColorHSL = this.colorHsl;
            this.colorBox2D.ColorHSL = this.colorHsl;
			textboxHexColor.Text = ColorTranslator.ToHtml(this.colorRgb);
			labelCurrentColor.BackColor = colorRgb;
//			Dragon.ColorEd.NsQ=colorRgb;
		//	UpdateRgbFields (colorRgb);
        }

        private void numRed_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
                UpdateRgbFields(Color.FromArgb((int)this.numRed.Value, (int)this.numGreen.Value, (int)this.numBlue.Value));

            }
        }

        private void numGreen_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
                UpdateRgbFields(Color.FromArgb((int)this.numRed.Value, (int)this.numGreen.Value, (int)this.numBlue.Value));
            }
        }

        private void numBlue_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
                UpdateRgbFields(Color.FromArgb((int)this.numRed.Value, (int)this.numGreen.Value, (int)this.numBlue.Value));
            }
        }

        private void numHue_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
                HslColor newColor = HslColor.FromAhsl((double)(((float)((int)this.numHue.Value)) / 360f), this.colorHsl.S, this.colorHsl.L);
                this.UpdateHslFields(newColor);
            }
        }

        private void numSaturation_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
				HslColor newColor = HslColor.FromAhsl(this.colorHsl.A, this.colorHsl.H, (double)(((float)((int)this.numSaturation.Value)) / 100f), (double)(((float)((int)this.numLuminance.Value)) / 100f));
                this.UpdateHslFields(newColor);
            }
            
        }
		//																									this.colorHsl.S,			this.colorHsl.L
        private void numLuminance_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
				HslColor newColor = HslColor.FromAhsl(this.colorHsl.A, this.colorHsl.H, (double)(((float)((int)this.numSaturation.Value)) / 100f), (double)(((float)((int)this.numLuminance.Value)) / 100f));
                this.UpdateHslFields(newColor);
            }
        }

		private void hexSet(object sender, EventArgs e)
		{
			try {
				string s = textboxHexColor.Text;
				string h = "";
				if (s.StartsWith ("hex:")) {
					h = s.Substring (4);
					if (h.Length < 7) {
						for (int i = h.Length; i < 7; i++) {
							h += "0";

						}
					}
				} else {
					if (s.StartsWith ("#")) {
						h = s;
						if (h.Length < 7) {
							for (int i = h.Length; i < 7; i++) {
								h += "0";
							}
						}
					} else if (s.Contains ("#")) {
						if (s.IndexOf ("#") < 5) {
							h = s.Substring (s.IndexOf ("#"));
							if (h.Length < 7) {
								for (int i = h.Length; i < 7; i++) {
									h += "0";
								}
							}
						}
					} else {
						if (!s.Contains ("h") && !s.Contains ("x") && !s.Contains (":")) {
							h = "#" + s;
							if (h.Length < 7) {
								for (int i = h.Length; i < 7; i++) {
									h += "0";
								}
							}
						} 
					}
				}
				if (h.Length > 3) {
					Color rgb = ColorTranslator.FromHtml (h.ToUpper ());
					//		UpdateRGB (new RGB (rgb.R, rgb.G, rgb.B));
					if(cbox==3){
					UpdateRgbFields (rgb);
					}
					else if(cbox==2) {
						colorWheel.HslColor= rgb;
					}
					else if(cbox==1){
						labelCurrentColor.BackColor=rgb;
					}
				}
			} catch {

			}
		}

		private void KeyPress(object sender,KeyPressEventArgs k)
		{
			if (k.KeyChar == (char)Keys.Return) {
				k.Handled = true;
				textboxHexColor.Hide ();
				textboxHexColor.Show ();
				Focus();
			}
		}

		private void color_Wheel_ColorChanged(object sender, EventArgs e)
		{
			labelCurrentColor.BackColor = colorWheel.Color;
			textboxHexColor.Text = ColorTranslator.ToHtml(colorWheel.Color);
		}

		public void ReIN(Color nw){
			colorRgb = nw;
			labelCurrentColor.BackColor = colorRgb;

			tabControlMain.SelectedIndex = 0;
		}

		public void UpdateText(int lang)
		{
			Text = "Color Switcher";
		}

		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.labelCurrent = new Label();
			this.labelCurrentColor = new Label();
			this.labelHex = new Label();
			this.textboxHexColor = new TextBox();
			this.tabControlMain = new TabControl();
			this.tabHexagon = new TabPage();
			this.colorHexagon = new MechanikaDesign.WinForms.UI.ColorPicker.ColorHexagon();
			this.tabWheel = new TabPage();
			//      this.colorWheel = new MechanikaDesign.WinForms.UI.ColorPicker.ColorWheel();
			this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
			this.tabColorBox = new TabPage();
			this.numLuminance = new NumericUpDown();
			this.radioLuminance = new RadioButton();
			this.numSaturation = new NumericUpDown();
			this.radioSaturation = new RadioButton();
			this.numHue = new NumericUpDown();
			this.radioHue = new RadioButton();
			this.numBlue = new NumericUpDown();
			this.radioBlue = new RadioButton();
			this.numGreen = new NumericUpDown();
			this.radioGreen = new RadioButton();
			this.numRed = new NumericUpDown();
			this.radioRed = new RadioButton();
			OKBTN = new Button ();
			CNBTN = new Button ();
			this.colorSlider = new MechanikaDesign.WinForms.UI.ColorPicker.ColorSliderVertical();
			this.colorBox2D = new MechanikaDesign.WinForms.UI.ColorPicker.ColorBox2D();
			this.tabControlMain.SuspendLayout();
			this.tabHexagon.SuspendLayout();
			this.tabWheel.SuspendLayout();
			this.tabColorBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numLuminance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSaturation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBlue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numGreen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRed)).BeginInit();
			this.SuspendLayout();
			// 
			// labelCurrent
			// 
			this.labelCurrent.AutoSize = true;
			this.labelCurrent.Location = new Point(448, 22);
			this.labelCurrent.Name = "labelCurrent";
			this.labelCurrent.Size = new Size(41, 13);
			this.labelCurrent.TabIndex = 1;
			this.labelCurrent.Text = "Current";
			// 
			// labelCurrentColor
			// 
			if (colorRgb != Color.Empty) {
				this.labelCurrentColor.BackColor = colorRgb;
			} else {
				this.labelCurrentColor.BackColor = Color.White;
			}
			this.labelCurrentColor.BorderStyle = BorderStyle.FixedSingle;
			this.labelCurrentColor.Location = new Point(451, 39);
			this.labelCurrentColor.Name = "labelCurrentColor";
			this.labelCurrentColor.Size = new Size(68, 32);
			this.labelCurrentColor.TabIndex = 2;
			// 
			// labelHex
			// 
			this.labelHex.AutoSize = true;
			this.labelHex.Location = new Point(448, 98);
			this.labelHex.Name = "labelHex";
			this.labelHex.Size = new Size(26, 13);
			this.labelHex.TabIndex = 3;
			this.labelHex.Text = "Hex";
			// 
			// textboxHexColor
			// 
			this.textboxHexColor.Location = new Point(451, 114);
			this.textboxHexColor.Name = "textboxHexColor";
			//        this.textboxHexColor.ReadOnly = true;
			this.textboxHexColor.Size = new Size(68, 20);
			textboxHexColor.MaxLength = 11;
			this.textboxHexColor.Font = new Font ("Times New Roman",10);
			this.textboxHexColor.TabIndex = 4;
			this.textboxHexColor.Text = "FFFFFF";
			textboxHexColor.KeyPress += KeyPress;
			textboxHexColor.Leave += hexSet;
			// 
			// tabControlMain
			// 
			this.tabControlMain.Controls.Add(this.tabHexagon);
			this.tabControlMain.Controls.Add(this.tabWheel);
			this.tabControlMain.Controls.Add(this.tabColorBox);
			this.tabControlMain.Dock = DockStyle.Left;
			this.tabControlMain.Location = new Point(0, 0);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new Size(427, 370);
			this.tabControlMain.TabIndex = 5;
			// 
			// tabHexagon
			// 
			this.tabHexagon.Controls.Add(this.colorHexagon);
			this.tabHexagon.Location = new Point(4, 22);
			this.tabHexagon.Name = "tabHexagon";
			this.tabHexagon.Padding = new Padding(3);
			this.tabHexagon.Size = new Size(419, 344);
			this.tabHexagon.TabIndex = 0;
			this.tabHexagon.Text = "Color Hexagon";
			this.tabHexagon.UseVisualStyleBackColor = true;
			tabHexagon.Enter+= (object sender, System.EventArgs e) => {
				cbox=1;
			};
			// 
			// colorHexagon
			// 
			this.colorHexagon.Dock = DockStyle.Fill;
			this.colorHexagon.Location = new Point(3, 3);
			this.colorHexagon.Name = "colorHexagon";
			this.colorHexagon.Size = new Size(413, 338);
			this.colorHexagon.TabIndex = 1;
			this.colorHexagon.ColorChanged += new MechanikaDesign.WinForms.UI.ColorPicker.ColorHexagon.ColorChangedEventHandler(this.colorHexagon_ColorChanged);
			// 
			// tabWheel
			// 
			this.tabWheel.Controls.Add(this.colorWheel);
			this.tabWheel.Location = new Point(4, 22);
			this.tabWheel.Name = "tabWheel";
			this.tabWheel.Padding = new Padding(3);
			this.tabWheel.Size = new Size(419, 344);
			this.tabWheel.TabIndex = 1;
			this.tabWheel.Text = "Color Wheel";
			this.tabWheel.UseVisualStyleBackColor = true;
			tabWheel.Enter+= (object sender, System.EventArgs e) => {
				colorWheel.HslColor=labelCurrentColor.BackColor;
				cbox=2;
			};
			// 
			// colorWheel
			// 
			/*      this.colorWheel.Color = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.colorWheel.Dock = DockStyle.Fill;
            this.colorWheel.Location = new Point(3, 3);
            this.colorWheel.Name = "colorWheel";
            this.colorWheel.Size = new Size(413, 338);
            this.colorWheel.TabIndex = 0;
            this.colorWheel.ColorChanged += new System.EventHandler(this.colorWheel_ColorChanged);
        */

			this.colorWheel.Color = Color.FromArgb(255, 255, 255);
			this.colorWheel.Dock = DockStyle.Fill;
			this.colorWheel.Location = new Point(3, 3);
			this.colorWheel.Name = "colorWheel";
			this.colorWheel.Size = new Size(413, 338);
			this.colorWheel.TabIndex = 0;
			this.colorWheel.ColorChanged += new System.EventHandler(this.colorWheel_ColorChanged);
			// 
			// optionsSplitContainer
			// 

			// 
			// tabColorBox
			// 
			this.tabColorBox.Controls.Add(this.numLuminance);
			this.tabColorBox.Controls.Add(this.radioLuminance);
			this.tabColorBox.Controls.Add(this.numSaturation);
			this.tabColorBox.Controls.Add(this.radioSaturation);
			this.tabColorBox.Controls.Add(this.numHue);
			this.tabColorBox.Controls.Add(this.radioHue);
			this.tabColorBox.Controls.Add(this.numBlue);
			this.tabColorBox.Controls.Add(this.radioBlue);
			this.tabColorBox.Controls.Add(this.numGreen);
			this.tabColorBox.Controls.Add(this.radioGreen);
			this.tabColorBox.Controls.Add(this.numRed);
			this.tabColorBox.Controls.Add(this.radioRed);
			this.tabColorBox.Controls.Add(this.colorSlider);
			this.tabColorBox.Controls.Add(this.colorBox2D);
			this.tabColorBox.Location = new Point(4, 22);
			this.tabColorBox.Name = "tabColorBox";
			this.tabColorBox.Padding = new Padding(3);
			this.tabColorBox.Size = new Size(419, 344);
			this.tabColorBox.TabIndex = 2;
			this.tabColorBox.Text = "Color Box & Slider";
			this.tabColorBox.UseVisualStyleBackColor = true;
			tabColorBox.Enter+= (object sender, System.EventArgs e) => {
				UpdateRgbFields(labelCurrentColor.BackColor);
				cbox=3;
			};
			// 
			// numLuminance
			// 
			this.numLuminance.Location = new Point(349, 165);
			this.numLuminance.Name = "numLuminance";
			this.numLuminance.Size = new Size(54, 20);
			this.numLuminance.TabIndex = 13;
			this.numLuminance.Value = new decimal(new int[] {
				100,
				0,
				0,
				0});
			this.numLuminance.ValueChanged += new System.EventHandler(this.numLuminance_ValueChanged);
			// 
			// radioLuminance
			// 
			this.radioLuminance.AutoSize = true;
			this.radioLuminance.Location = new Point(306, 165);
			this.radioLuminance.Name = "radioLuminance";
			this.radioLuminance.Size = new Size(34, 17);
			this.radioLuminance.TabIndex = 12;
			this.radioLuminance.Text = "L:";
			this.radioLuminance.UseVisualStyleBackColor = true;
			this.radioLuminance.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
			// 
			// numSaturation
			// 
			this.numSaturation.Location = new Point(349, 139);
			this.numSaturation.Name = "numSaturation";
			this.numSaturation.Size = new Size(54, 20);
			this.numSaturation.TabIndex = 11;
			this.numSaturation.Value = new decimal(new int[] {
				100,
				0,
				0,
				0});
			this.numSaturation.ValueChanged += new System.EventHandler(this.numSaturation_ValueChanged);
			// 
			// radioSaturation
			// 
			this.radioSaturation.AutoSize = true;
			this.radioSaturation.Location = new Point(306, 139);
			this.radioSaturation.Name = "radioSaturation";
			this.radioSaturation.Size = new Size(35, 17);
			this.radioSaturation.TabIndex = 10;
			this.radioSaturation.Text = "S:";
			this.radioSaturation.UseVisualStyleBackColor = true;
			this.radioSaturation.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
			// 
			// numHue
			// 
			this.numHue.Location = new Point(349, 113);
			this.numHue.Maximum = new decimal(new int[] {
				359,
				0,
				0,
				0});
			this.numHue.Name = "numHue";
			this.numHue.Size = new Size(54, 20);
			this.numHue.TabIndex = 9;
			this.numHue.ValueChanged += new System.EventHandler(this.numHue_ValueChanged);
			// 
			// radioHue
			// 
			this.radioHue.AutoSize = true;
			this.radioHue.Checked = true;
			this.radioHue.Location = new Point(306, 113);
			this.radioHue.Name = "radioHue";
			this.radioHue.Size = new Size(36, 17);
			this.radioHue.TabIndex = 8;
			this.radioHue.TabStop = true;
			this.radioHue.Text = "H:";
			this.radioHue.UseVisualStyleBackColor = true;
			this.radioHue.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
			// 
			// numBlue
			// 
			this.numBlue.Location = new Point(349, 69);
			this.numBlue.Maximum = new decimal(new int[] {
				255,
				0,
				0,
				0});
			this.numBlue.Name = "numBlue";
			this.numBlue.Size = new Size(54, 20);
			this.numBlue.TabIndex = 7;
			this.numBlue.ValueChanged += new System.EventHandler(this.numBlue_ValueChanged);
			// 
			// radioBlue
			// 
			this.radioBlue.AutoSize = true;
			this.radioBlue.Location = new Point(306, 69);
			this.radioBlue.Name = "radioBlue";
			this.radioBlue.Size = new Size(35, 17);
			this.radioBlue.TabIndex = 6;
			this.radioBlue.Text = "B:";
			this.radioBlue.UseVisualStyleBackColor = true;
			this.radioBlue.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
			// 
			// numGreen
			// 
			this.numGreen.Location = new Point(349, 43);
			this.numGreen.Maximum = new decimal(new int[] {
				255,
				0,
				0,
				0});
			this.numGreen.Name = "numGreen";
			this.numGreen.Size = new Size(54, 20);
			this.numGreen.TabIndex = 5;
			this.numGreen.ValueChanged += new System.EventHandler(this.numGreen_ValueChanged);
			// 
			// radioGreen
			// 
			this.radioGreen.AutoSize = true;
			this.radioGreen.Location = new Point(306, 43);
			this.radioGreen.Name = "radioGreen";
			this.radioGreen.Size = new Size(36, 17);
			this.radioGreen.TabIndex = 4;
			this.radioGreen.Text = "G:";
			this.radioGreen.UseVisualStyleBackColor = true;
			this.radioGreen.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
			// 
			// numRed
			// 
			this.numRed.Location = new Point(349, 17);
			this.numRed.Maximum = new decimal(new int[] {
				255,
				0,
				0,
				0});
			this.numRed.Name = "numRed";
			this.numRed.Size = new Size(54, 20);
			this.numRed.TabIndex = 3;
			this.numRed.Value = new decimal(new int[] {
				255,
				0,
				0,
				0});
			this.numRed.ValueChanged += new System.EventHandler(this.numRed_ValueChanged);
			// 
			// radioRed
			// 
			this.radioRed.AutoSize = true;
			this.radioRed.Location = new Point(306, 17);
			this.radioRed.Name = "radioRed";
			this.radioRed.Size = new Size(36, 17);
			this.radioRed.TabIndex = 2;
			this.radioRed.Text = "R:";
			this.radioRed.UseVisualStyleBackColor = true;
			this.radioRed.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
			// 
			// colorSlider
			// 
			this.colorSlider.ColorMode = MechanikaDesign.WinForms.UI.ColorPicker.ColorModes.Hue;
			this.colorSlider.ColorRGB = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.colorSlider.Location = new Point(259, 8);
			this.colorSlider.Name = "colorSlider";
			this.colorSlider.NubColor = Color.White;
			this.colorSlider.Position = 142;
			this.colorSlider.Size = new Size(40, 252);
			this.colorSlider.TabIndex = 1;
			this.colorSlider.ColorChanged += new MechanikaDesign.WinForms.UI.ColorPicker.ColorSliderVertical.ColorChangedEventHandler(this.colorSlider_ColorChanged);
			// 
			// colorBox2D
			// 
			this.colorBox2D.ColorMode = MechanikaDesign.WinForms.UI.ColorPicker.ColorModes.Hue;
			this.colorBox2D.ColorRGB = Color.Red;
			this.colorBox2D.Location = new Point(8, 8);
			this.colorBox2D.Name = "colorBox2D";
			this.colorBox2D.Size = new Size(245, 252);
			this.colorBox2D.TabIndex = 0;
			this.colorBox2D.ColorChanged += new MechanikaDesign.WinForms.UI.ColorPicker.ColorBox2D.ColorChangedEventHandler(this.colorBox2D_ColorChanged);
			// 
			// FormColorPickerDemo
			// 

			OKBTN.Location = new Point (455, 150);
			OKBTN.Text="OK";
			OKBTN.Size = new Size (60, 20);
			OKBTN.Click += (object sender, System.EventArgs e) => {
				//			Dragon.ColorEd.NsQ=labelCurrentColor.BackColor;
				DialogResult=DialogResult.OK;	
			};
			OKBTN.FlatStyle = FlatStyle.Flat;
			OKBTN.FlatAppearance.BorderSize = 0;
			OKBTN.BackColor = Color.FromArgb (18, 19, 22);

			CNBTN.Location = new Point (455, 180);
			CNBTN.Text="Cancel";
			CNBTN.Size = new Size (60, 20);
			CNBTN.Click += (object sender, System.EventArgs e) => {
				DialogResult=DialogResult.Cancel;	
			};
			CNBTN.BackColor = Color.FromArgb (18, 19, 22);
			CNBTN.FlatStyle = FlatStyle.Flat;
			CNBTN.FlatAppearance.BorderSize = 0;

	//		textboxHexColor.BorderStyle = BorderStyle.None;

			tabHexagon.BackColor = Color.FromArgb (34, 37, 50);
			tabWheel.BackColor = Color.FromArgb (34, 37, 50);
			tabColorBox.BackColor = Color.FromArgb (34, 37, 50);

			this.AutoScaleDimensions = new SizeF(6F, 13F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.ClientSize = new Size(535, 350);
			BackColor  = Color.FromArgb (25, 27, 35);
			textboxHexColor.BackColor = Color.FromArgb (34, 37, 50);
			textboxHexColor.ForeColor = Color.Gold;
			//			BackColor = Color.FromArgb (20, 20, 180);
			//			tabColorBox.BackColor=Color.FromArgb (200, 0, 180);
			//			tabHexagon.BackColor=Color.FromArgb (225, 0, 255);
			//			tabWheel.BackColor=Color.FromArgb (255, 250, 5);
			Controls.Add(OKBTN);
			Controls.Add(CNBTN);

//			labelHex.ForeColor = Color.FromArgb (180, 184, 195);
			labelHex.ForeColor = Color.FromArgb (180, 186, 208);
			labelCurrent.ForeColor = Color.FromArgb (180, 186, 208);
			OKBTN.ForeColor = Color.FromArgb (180, 186, 208);
			CNBTN.ForeColor = Color.FromArgb (180, 186, 208);
//			labelHex.ForeColor = Color.FromArgb (255, 255, 255);
			this.Controls.Add(this.tabControlMain);
			this.Controls.Add(this.textboxHexColor);
			this.Controls.Add(this.labelHex);
			this.Controls.Add(this.labelCurrentColor);
			this.Controls.Add(this.labelCurrent);
			this.ForeColor = Color.FromArgb (180, 184, 195);
			this.MaximizeBox = false;
			this.Name = "FormColorPickerDemo";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Color Picker UI Control Demo";
			this.tabControlMain.ResumeLayout(false);
			this.tabHexagon.ResumeLayout(false);
			this.tabWheel.ResumeLayout(false);
			this.tabColorBox.ResumeLayout(false);
			this.tabColorBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numLuminance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSaturation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBlue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numGreen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRed)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private Button OKBTN;
		private Button CNBTN;

		private Label labelCurrent;
		public Label labelCurrentColor;
		private Label labelHex;
		private TextBox textboxHexColor;
		private TabControl tabControlMain;
		private TabPage tabHexagon;
		private MechanikaDesign.WinForms.UI.ColorPicker.ColorHexagon colorHexagon;
		private TabPage tabWheel;
		//    private MechanikaDesign.WinForms.UI.ColorPicker.ColorWheel colorWheel;
		private Cyotek.Windows.Forms.ColorWheel colorWheel;
		private TabPage tabColorBox;
		private MechanikaDesign.WinForms.UI.ColorPicker.ColorBox2D colorBox2D;
		private MechanikaDesign.WinForms.UI.ColorPicker.ColorSliderVertical colorSlider;
		private NumericUpDown numBlue;
		private RadioButton radioBlue;
		private NumericUpDown numGreen;
		private RadioButton radioGreen;
		private NumericUpDown numRed;
		private RadioButton radioRed;
		private NumericUpDown numLuminance;
		private RadioButton radioLuminance;
		private NumericUpDown numSaturation;
		private RadioButton radioSaturation;
		private NumericUpDown numHue;
		private RadioButton radioHue;




    }
}
