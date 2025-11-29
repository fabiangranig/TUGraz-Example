namespace INF_JG22_01_MorphingVonRechtecken
{
    public partial class MRechteck : Form
    {
        public MRechteck()
        {
            InitializeComponent();
        }

        private void MRechteck_Load(object sender, EventArgs e)
        {
            
        }

        private Rechteck[] RechteckMorphen(Rechteck rechteck_start, Rechteck rechteck_stop, int anzahl)
        {
            Rechteck[] rechteck = new Rechteck[anzahl + 2];
            rechteck[0] = rechteck_start;
            rechteck[rechteck.Length - 1] = rechteck_stop;
            int PunktZuPunkt_X = (rechteck_stop.X - rechteck_start.X) / (anzahl + 1);
            int PunktZuPunkt_Y = (rechteck_stop.Y - rechteck_start.Y) / (anzahl + 1);
            int SizeZuSizeX = (rechteck_stop.Breite - rechteck_start.Breite) / (anzahl + 1);
            int SizeZuSizeY = (rechteck_stop.Hoehe - rechteck_start.Hoehe) / (anzahl + 1);
            for (int i = 1; i < rechteck.Length - 1; i++)
            {
                rechteck[i] = new Rechteck(
                    rechteck[i - 1].X + PunktZuPunkt_X,
                    rechteck[i - 1].Y + PunktZuPunkt_Y,
                    rechteck[i - 1].Breite + SizeZuSizeX,
                    rechteck[i - 1].Hoehe + SizeZuSizeY);
            }
            return rechteck;
        }

        private void RechteckBewegen(Rechteck rechteck)
        {
            pictureBox_Rechteck.Location = new Point(rechteck.X, rechteck.Y);
            pictureBox_Rechteck.Size = new Size(rechteck.Breite, rechteck.Hoehe);
            Refresh();
        }

        private void button_Morphen_Click(object sender, EventArgs e)
        {
            Rechteck Rechteck_Stop = new Rechteck(
                Int32.Parse(textBox_X2.Text),
                Int32.Parse(textBox_Y2.Text),
                Int32.Parse(textBox_B2.Text),
                Int32.Parse(textBox_H2.Text));
            Rechteck Rechteck_Start = new Rechteck(
                Int32.Parse(textBox_X1.Text),
                Int32.Parse(textBox_Y1.Text),
                Int32.Parse(textBox_B1.Text),
                Int32.Parse(textBox_H1.Text));
            Rechteck[] Rechteck_Bewegen = RechteckMorphen(Rechteck_Start, Rechteck_Stop, Convert.ToInt32(numericUpDown_Anzahl.Value));

            for (int i = 0; i < Rechteck_Bewegen.Length; i++)
            {
                pictureBox_Rechteck.Visible = true;
                RechteckBewegen(Rechteck_Bewegen[i]);
                Thread.Sleep(2000);
            }
            Thread.Sleep(5000);
            pictureBox_Rechteck.Visible = false;
        }
    }

    class Rechteck
    {
        public int X;
        public int Y;
        public int Breite;
        public int Hoehe;

        public Rechteck(int X1, int Y1, int Breite1, int Hoehe1)
        {
            this.X = X1;
            this.Y = Y1;
            this.Breite = Breite1;
            this.Hoehe = Hoehe1;
        }
    }
}
