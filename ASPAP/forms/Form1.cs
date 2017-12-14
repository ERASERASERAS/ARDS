using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASPAP.constrains;
using ASPAP.generators.distribution_for_generators;
using ASPAP.generators.speedgenerators;
using ASPAP.random_distributions;
using ASPAP.generators.timegenerators;
using ASPAP.drawingclasses;
using ASPAP.forms;
using System.Threading;
using System.Collections;


namespace ASPAP
{
    public partial class Form1 : Form
    {
        private bool trafficLightPictureBoxIsCLicked, signPictureBoxIsClicked = false;
        private bool draggedTrafficLightPictureBoxIsClicked = false;
        private bool draggeSignPictureBoxIsClicked = false;
        Point startPoint = new Point();
        PictureBox topDraggedTrafficLightPictureBox = new PictureBox();
        PictureBox bottomTrafficLightPictureBox = new PictureBox();

        private LinkedList<PictureBox> signsPictureBoxes = new LinkedList<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            chooseRoadTypeComboBox.Items.Add("Тоннель");
            chooseRoadTypeComboBox.Items.Add("Магистраль");
            chooseRoadTypeComboBox.Items.Add("Загородная дорога");
            chooseRoadTypeComboBox.Items.Add("Городская дорога");
            chooseCountWayComboBox.Items.Add("Однонаправленная");
            chooseCountWayComboBox.Items.Add("Двунаправленная");
            chooseTimeTypeComboBox.Items.Add("Детерминированный");
            chooseTimeTypeComboBox.Items.Add("Случайный");
            chooseSpeedTypeComboBox.Items.Add("Детерминированный");
            chooseSpeedTypeComboBox.Items.Add("Случайный");
            chooseTimeDistributionLawComboBox.Items.Add("Нормальный");
            chooseTimeDistributionLawComboBox.Items.Add("Показательный");
            chooseTimeDistributionLawComboBox.Items.Add("Равномерный");
            chooseSpeedDistributionLawComboBox.Items.Add("Нормальный");
            chooseSpeedDistributionLawComboBox.Items.Add("Показательный");
            chooseSpeedDistributionLawComboBox.Items.Add("Равномерный");
            timeTextBox.Enabled = false;
            chooseTimeDistributionLawComboBox.Enabled = false;
            speedTextBox.Enabled = false;
            chooseSpeedDistributionLawComboBox.Enabled = false;
            DoubleBuffered = true;
           

        }

        

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("АСПАП");
        }

        

        private void авторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Коржев Матвейкин");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chooseRoadTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chooseRoadTypeComboBox.SelectedIndex == 0)
            {
                chooseCountWayComboBox.SelectedIndex = 0;
                chooseCountWayComboBox.Enabled = false;
                chooseStripesCountNumericUpDown.Value = 1;
                chooseStripesCountNumericUpDown.Enabled = false;
                trafficLightPictureBox.Enabled = false;
                signPictureBox.Enabled = false;
                trafficLightPictureBox.Image = Image.FromFile("..\\..\\images\\not_enabled_traffic_light_icon.jpeg");
                signPictureBox.Image = Image.FromFile("..\\..\\images\\not_enabled_sign_icon.png");
            }
            else
            {
                chooseCountWayComboBox.Enabled = true;
                chooseStripesCountNumericUpDown.Enabled = true;          
                trafficLightPictureBox.Enabled = true;
                signPictureBox.Enabled = true;
                trafficLightPictureBox.Image = Image.FromFile("..\\..\\images\\traffic_light_icon.jpg");
                signPictureBox.Image = Image.FromFile("..\\..\\images\\sign_icon.png");
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            
            switch(chooseTimeTypeComboBox.SelectedItem.ToString())
            {
                case("Детерминированный"):
                    GeneratorsHolder.getGeneratorsHolder().TIMESGENERATOR = new DeterministicTimeGenerator(Double.Parse(timeTextBox.Text));
                    break;

                case("Случайный"):
                    if(chooseTimeDistributionLawComboBox.SelectedItem.ToString().Equals("Показательный"))
                    {
                        GeneratorsHolder.getGeneratorsHolder().TIMESGENERATOR = new RandomTimeGenerator(new ExponentialDistribution(Double.Parse(timesFirstParTextBox.Text)));
                    }
                    else if(chooseTimeDistributionLawComboBox.SelectedItem.ToString().Equals("Равномерный"))
                    {
                        GeneratorsHolder.getGeneratorsHolder().TIMESGENERATOR = new RandomTimeGenerator(new UniformDistribution(Double.Parse(timesFirstParTextBox.Text), Double.Parse(timesSecondParTextBox.Text)));
                    }
                    else if (chooseTimeDistributionLawComboBox.SelectedItem.ToString().Equals("Нормальный"))
                    {
                        GeneratorsHolder.getGeneratorsHolder().TIMESGENERATOR = new RandomTimeGenerator(new NormalDistribution(Double.Parse(timesFirstParTextBox.Text) , Double.Parse(timesSecondParTextBox.Text)));
                    }
                    break;

                default:
                    break;
            }

            switch (chooseSpeedTypeComboBox.SelectedItem.ToString())
            {
                case("Детерминированный"):
                    GeneratorsHolder.getGeneratorsHolder().SPEEDSGENERATOR = new DeterministicSpeedGenerator(Double.Parse(speedTextBox.Text));
                    break;

                case("Случайный"):
                    if(chooseSpeedDistributionLawComboBox.SelectedItem.ToString().Equals("Показательный"))
                    {
                        GeneratorsHolder.getGeneratorsHolder().SPEEDSGENERATOR = new RandomSpeedGenerator(new ExponentialDistribution(Double.Parse(speedsFirstParTextBox.Text)));
                    }
                    else if(chooseSpeedDistributionLawComboBox.SelectedItem.ToString().Equals("Равномерный"))
                    {
                        GeneratorsHolder.getGeneratorsHolder().SPEEDSGENERATOR = new RandomSpeedGenerator(new UniformDistribution(Double.Parse(speedsFirstParTextBox.Text), Double.Parse(speedsSecondParTextBox.Text)));
                    }
                    else if (chooseSpeedDistributionLawComboBox.SelectedItem.ToString().Equals("Нормальный"))
                    {
                        GeneratorsHolder.getGeneratorsHolder().SPEEDSGENERATOR = new RandomSpeedGenerator(new NormalDistribution(Double.Parse(speedsFirstParTextBox.Text), Double.Parse(speedsSecondParTextBox.Text)));
                    }
                    break;

                default:
                    break;

            }
            if (Road.getRoad().TRAFFICLIGHTS.Count > 0)
            {
                TrafficLight tl = Road.getRoad().TRAFFICLIGHTS.First.Value;
                trafficLightTimer.Interval = tl.REDLIGHTTIME * 1000;
                topDraggedTrafficLightPictureBox.Image = TrafficLightDrawing.getTrafficLightDrawing().REDSTATETOP;
                bottomTrafficLightPictureBox.Image = TrafficLightDrawing.getTrafficLightDrawing().REDSTATEBOTTOM;
                trafficLightTimer.Start();
            }   
        }



        

        private void trafficLightPictureBox_Click(object sender, EventArgs e)
        {
            initTopDraggedTrafficLightPictureBox();
           
        }

        
        

        private void chooseTimeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chooseTimeTypeComboBox.SelectedIndex == 0)
            {
                label7.Visible = false;
                label8.Visible = false;
                timesFirstParTextBox.Visible = false;
                timesSecondParTextBox.Visible = false;
                timeTextBox.Enabled = true;
                chooseTimeDistributionLawComboBox.Enabled = false;
            }
            else
            {
                chooseTimeDistributionLawComboBox.Enabled = true;
                timeTextBox.Enabled = false;
            }
        }

        private void chooseTimeDistributionLawComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Visible = true;
            label8.Visible = true;
            timesFirstParTextBox.Visible = true;
            timesSecondParTextBox.Visible = true;
            if (chooseTimeDistributionLawComboBox.SelectedIndex == 0)
            {
                label7.Text = "λ";
                label8.Text = "σ";
            }
            else if (chooseTimeDistributionLawComboBox.SelectedIndex == 1)
            {
                label8.Visible = false;
                label7.Text = "λ";
                timesSecondParTextBox.Visible = false;
            }
            else if (chooseTimeDistributionLawComboBox.SelectedIndex == 2)
            {
                label7.Text = "a";
                label8.Text = "b";
            }
        }

        private void chooseSpeedTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chooseSpeedTypeComboBox.SelectedIndex == 0)
            {
                
                speedTextBox.Enabled = true;
                chooseSpeedDistributionLawComboBox.Enabled = false;
                label12.Visible = false;
                label11.Visible = false;
                speedsFirstParTextBox.Visible = false;
                speedsSecondParTextBox.Visible = false;
            }
            else
            {                
                chooseSpeedDistributionLawComboBox.Enabled = true;
                speedTextBox.Enabled = false;
            }
        }

        private void chooseSpeedDistributionLawComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label12.Visible = true;
            label11.Visible = true;
            speedsFirstParTextBox.Visible = true;
            speedsSecondParTextBox.Visible = true;
            if (chooseSpeedDistributionLawComboBox.SelectedIndex == 0)
            {
                label12.Text = "λ";
                label11.Text = "σ";
            }
            else if (chooseSpeedDistributionLawComboBox.SelectedIndex == 1)
            {
                label11.Visible = false;
                label12.Text = "λ";
                speedsSecondParTextBox.Visible = false;
            }
            else if (chooseSpeedDistributionLawComboBox.SelectedIndex == 2)
            {
                label12.Text = "a";
                label11.Text = "b";
            }
        }

        private void drawRoadButton_Click(object sender, EventArgs e)
        {
            Road.getRoad().COUNTOFSTRIPES = (int)chooseStripesCountNumericUpDown.Value;
            switch (chooseCountWayComboBox.SelectedItem.ToString())
            {
                case ("Однонаправленная"):
                    Road.getRoad().COUNTOFWAYS = 1;
                    break;
                case ("Двунаправленная"):
                    Road.getRoad().COUNTOFWAYS = 2;
                    break;
                default:
                    break;
            }

            Road.getRoad().ROADTYPE = chooseRoadTypeComboBox.SelectedItem.ToString();
            ConstrainsInstaller.setConstrains(chooseRoadTypeComboBox.SelectedItem.ToString());
            new RoadDrawing(mainPictureBox.CreateGraphics(), mainPictureBox.Width, mainPictureBox.Height).draw();
        }

        private void mainPictureBox_DragEnter(object sender, DragEventArgs e)
        {
            signPictureBox.Visible = false ;
        }

        private void mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            new RoadDrawing(e.Graphics, mainPictureBox.Width, mainPictureBox.Height).draw();
          
        }

        
     
        

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (trafficLightPictureBoxIsCLicked)
            {
                topDraggedTrafficLightPictureBox.Location = e.Location;              
            }            
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (trafficLightPictureBoxIsCLicked)
            {
                topDraggedTrafficLightPictureBox.Location = new Point(e.X + mainPictureBox.Location.X, e.Y + mainPictureBox.Location.Y);
            }
            else
            {
                if (draggedTrafficLightPictureBoxIsClicked)
                {
                    
                    topDraggedTrafficLightPictureBox.Location = new Point(e.X + mainPictureBox.Location.X, topDraggedTrafficLightPictureBox.Location.Y);
                    bottomTrafficLightPictureBox.Location = new Point(e.X + mainPictureBox.Location.X, bottomTrafficLightPictureBox.Location.Y);
                    if (topDraggedTrafficLightPictureBox.Location.X + topDraggedTrafficLightPictureBox.Width / 10 > mainPictureBox.Width + mainPictureBox.Location.X)
                    {
                        this.Controls.Remove(bottomTrafficLightPictureBox);
                        this.Controls.Remove(topDraggedTrafficLightPictureBox);
                        trafficLightPictureBox.Enabled = true;
                        trafficLightPictureBox.Image = Image.FromFile("..\\..\\images\\traffic_light_icon.jpg");
                        draggedTrafficLightPictureBoxIsClicked = false;
                    }
                }
            }
        }

        

        
        
        private void trafficLightTimer_Tick(object sender, EventArgs e)
        {
            setTrafficLight();
        }

        private void setTrafficLight()
        {
            TrafficLightDrawing t = TrafficLightDrawing.getTrafficLightDrawing();
            TrafficLight tl = Road.getRoad().TRAFFICLIGHTS.First.Value;
            if (tl.REDLIGHT)
            {
                trafficLightTimer.Interval = tl.REDLIGHTTIME * 1000;
                topDraggedTrafficLightPictureBox.Image = t.REDSTATETOP;
                bottomTrafficLightPictureBox.Image = t.REDSTATEBOTTOM;
                tl.REDLIGHT = false;
                
            }
            else
            {
                trafficLightTimer.Interval = tl.GREENLIGHTTIME * 1000;
                topDraggedTrafficLightPictureBox.Image = t.GREENSTATETOP;
                bottomTrafficLightPictureBox.Image = t.GREENSTATEBOTTOM;
                tl.REDLIGHT = true;
            }
        }

        private void showSetTrafficLight()
        {
            
        }

        private void mainPictureBox_MouseLeave(object sender, EventArgs e)
        {
        }

        private void signPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void initTopDraggedTrafficLightPictureBox()
        {
            
            startPoint = trafficLightPictureBox.Location;
            trafficLightPictureBoxIsCLicked = true;
            topDraggedTrafficLightPictureBox.Image = trafficLightPictureBox.Image;
            topDraggedTrafficLightPictureBox.Size = trafficLightPictureBox.Size;
            topDraggedTrafficLightPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            topDraggedTrafficLightPictureBox.Location = trafficLightPictureBox.Location;
            topDraggedTrafficLightPictureBox.MouseMove += (s, arg) =>
            {
                if (trafficLightPictureBoxIsCLicked)
                {
                    topDraggedTrafficLightPictureBox.Left += trafficLightPictureBox.Location.X - startPoint.X;
                    topDraggedTrafficLightPictureBox.Top += trafficLightPictureBox.Location.Y - startPoint.Y;
                }
            };
            topDraggedTrafficLightPictureBox.MouseClick += (s, arg) =>
            {
                if (trafficLightPictureBoxIsCLicked)
                {
                    //if чтобы положить его сожно только в mainPB
                    bottomTrafficLightPictureBox.Image = TrafficLightDrawing.getTrafficLightDrawing().DEFAULTSTATEBOTTOM;
                    bottomTrafficLightPictureBox.Size = new Size(topDraggedTrafficLightPictureBox.Width * 2, mainPictureBox.Height / 14);
                    bottomTrafficLightPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    bottomTrafficLightPictureBox.Location = new Point(topDraggedTrafficLightPictureBox.Location.X, mainPictureBox.Height - topDraggedTrafficLightPictureBox.Location.Y + bottomTrafficLightPictureBox.Height);
                    this.Controls.Add(bottomTrafficLightPictureBox);
                    bottomTrafficLightPictureBox.BringToFront();
                    trafficLightPictureBoxIsCLicked = false;
                    trafficLightPictureBox.Enabled = false;
                    trafficLightPictureBox.Image = Image.FromFile("..\\..\\images\\not_enabled_traffic_light_icon.jpeg");
                    topDraggedTrafficLightPictureBox.Height = mainPictureBox.Height / 14;
                    topDraggedTrafficLightPictureBox.Width *= 2;
                    topDraggedTrafficLightPictureBox.Image = TrafficLightDrawing.getTrafficLightDrawing().DEFAULTSTATETOP;
                    SetTrafficLightForm setTrafficLightForm = new SetTrafficLightForm(true);
                    setTrafficLightForm.Visible = true;
                    LinkedList<TrafficLight> t = Road.getRoad().TRAFFICLIGHTS;
                    TrafficLightDrawing.getTrafficLightDrawing().COORDINATS.AddLast(new Point[]{topDraggedTrafficLightPictureBox.Location
                                                                                    , bottomTrafficLightPictureBox.Location});
                }
                else
                {
                    if (draggedTrafficLightPictureBoxIsClicked)
                    {
                        draggedTrafficLightPictureBoxIsClicked = false;
                        TrafficLightDrawing.getTrafficLightDrawing().COORDINATS.RemoveLast();
                        TrafficLightDrawing.getTrafficLightDrawing().COORDINATS.AddLast(new Point[]{topDraggedTrafficLightPictureBox.Location
                                                                                    , bottomTrafficLightPictureBox.Location});

                    }
                    else
                    {
                        draggedTrafficLightPictureBoxIsClicked = true;
                    }
                }
            };
            topDraggedTrafficLightPictureBox.DoubleClick += (s, arg) =>
            {
                new SetTrafficLightForm(false).Visible = true;
            };
            this.Controls.Add(topDraggedTrafficLightPictureBox);
            topDraggedTrafficLightPictureBox.BringToFront();
        }

        private void initTopDraggedSignPictureBox() //args PictureBox...
        {

        }
        


        

        

        

        




     
    }
}
