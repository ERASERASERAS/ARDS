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
        private bool draggedSignPictureBoxIsClicked = false;
        Point startPoint = new Point();
        
        PictureBox topDraggedTrafficLightPictureBox = new PictureBox();
        PictureBox bottomTrafficLightPictureBox = new PictureBox();
        private LinkedList<SignDrawing> signDrawings = new LinkedList<SignDrawing>();

        private LinkedList<PictureBox> signsPictureBoxes = new LinkedList<PictureBox>();
        private SignDrawing signDrawing = new SignDrawing();

        public Form1()
        {
            InitializeComponent();
            chooseRoadTypeComboBox.Items.Add("Тоннель");
            chooseRoadTypeComboBox.Items.Add("Магистраль");
            chooseRoadTypeComboBox.Items.Add("Загородная дорога");
            chooseRoadTypeComboBox.Items.Add("Городская дорога");
            chooseRoadTypeComboBox.SelectedIndex = 1;
            chooseCountWayComboBox.Items.Add("Однонаправленная");
            chooseCountWayComboBox.Items.Add("Двунаправленная");
            chooseCountWayComboBox.SelectedIndex = 1;
            chooseTimeTypeComboBox.Items.Add("Детерминированный");
            chooseTimeTypeComboBox.Items.Add("Случайный");
            //chooseTimeTypeComboBox.SelectedIndex = 1;
            chooseSpeedTypeComboBox.Items.Add("Детерминированный");
            chooseSpeedTypeComboBox.Items.Add("Случайный");
            //chooseSpeedTypeComboBox.SelectedIndex = 1;
            //chooseSpeedTypeComboBox.SelectedItem = chooseSpeedTypeComboBox.Items[0];
            chooseTimeDistributionLawComboBox.Items.Add("Нормальный");
            chooseTimeDistributionLawComboBox.Items.Add("Показательный");
            chooseTimeDistributionLawComboBox.Items.Add("Равномерный");
            //chooseTimeDistributionLawComboBox.SelectedIndex = 1;
            chooseSpeedDistributionLawComboBox.Items.Add("Нормальный");
            chooseSpeedDistributionLawComboBox.Items.Add("Показательный");
            chooseSpeedDistributionLawComboBox.Items.Add("Равномерный");
            //chooseSpeedDistributionLawComboBox.SelectedIndex = 0;
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
            if (checkTimeParamsForException() && checkSpeedParamsForExceptions())
            {
                stopButton.Enabled = true;
                stopButton.Visible = true;
                switch (chooseTimeTypeComboBox.SelectedItem.ToString())
                {
                    case ("Детерминированный"):
                        GeneratorsHolder.getGeneratorsHolder().TIMESGENERATOR = new DeterministicTimeGenerator(Double.Parse(timeTextBox.Text));
                        break;

                    case ("Случайный"):
                        if (chooseTimeDistributionLawComboBox.SelectedItem.ToString().Equals("Показательный"))
                        {
                            GeneratorsHolder.getGeneratorsHolder().TIMESGENERATOR = new RandomTimeGenerator(new ExponentialDistribution(Double.Parse(timesFirstParTextBox.Text)));
                        }
                        else if (chooseTimeDistributionLawComboBox.SelectedItem.ToString().Equals("Равномерный"))
                        {
                            GeneratorsHolder.getGeneratorsHolder().TIMESGENERATOR = new RandomTimeGenerator(new UniformDistribution(Double.Parse(timesFirstParTextBox.Text), Double.Parse(timesSecondParTextBox.Text)));
                        }
                        else if (chooseTimeDistributionLawComboBox.SelectedItem.ToString().Equals("Нормальный"))
                        {
                            GeneratorsHolder.getGeneratorsHolder().TIMESGENERATOR = new RandomTimeGenerator(new NormalDistribution(Double.Parse(timesFirstParTextBox.Text), Double.Parse(timesSecondParTextBox.Text)));
                        }
                        break;

                    default:
                        break;
                }

                switch (chooseSpeedTypeComboBox.SelectedItem.ToString())
                {
                    case ("Детерминированный"):
                        GeneratorsHolder.getGeneratorsHolder().SPEEDSGENERATOR = new DeterministicSpeedGenerator(Double.Parse(speedTextBox.Text));
                        break;

                    case ("Случайный"):
                        if (chooseSpeedDistributionLawComboBox.SelectedItem.ToString().Equals("Показательный"))
                        {
                            GeneratorsHolder.getGeneratorsHolder().SPEEDSGENERATOR = new RandomSpeedGenerator(new ExponentialDistribution(Double.Parse(speedsFirstParTextBox.Text)));
                        }
                        else if (chooseSpeedDistributionLawComboBox.SelectedItem.ToString().Equals("Равномерный"))
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
                    if (Road.getRoad().COUNTOFWAYS == 2)
                    {
                        bottomTrafficLightPictureBox.Image = TrafficLightDrawing.getTrafficLightDrawing().REDSTATEBOTTOM;
                    }
                    tl.REDLIGHT = false;
                    trafficLightTimer.Start();
                }
                generateCarTimer.Interval = (int)(GeneratorsHolder.getGeneratorsHolder().TIMESGENERATOR.getTime() * 1000);
                generateCarTimer.Start();
                animationTimer.Start();
            }
        }



        

        private void trafficLightPictureBox_Click(object sender, EventArgs e)
        {
            initTopDraggedTrafficLightPictureBox();         
        }

        private void checkForExceptions()
        {
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
            if (Road.getRoad().COUNTOFWAYS > 1)//нарисована ли уже  дорога ?
            {
                RoadDrawing.getRoadDrawing().clearRoadDrawing(mainPictureBox.CreateGraphics());
                Road.getRoad().clearRoad();
            }                           
            Road.getRoad().COUNTOFSTRIPES = (int)chooseStripesCountNumericUpDown.Value;
            switch (chooseCountWayComboBox.SelectedItem.ToString())
            {            
                case ("Однонаправленная"):
                    Road.getRoad().COUNTOFWAYS = 1;
                    Way way = new Way("LEFT");
                    for (int i = 0; i < Road.getRoad().COUNTOFSTRIPES; i++)
                    {
                        way.addStripe(new Stripe());
                    }
                    Road.getRoad().WAYS.AddLast(way);
                    break;
                case ("Двунаправленная"):
                    Road.getRoad().COUNTOFWAYS = 2;
                    Way leftWay = new Way("LEFT");
                    Way rightWay = new Way("RIGHT");
                    LinkedList<Way> ways = new LinkedList<Way>();
                    ways.AddLast(leftWay);
                    ways.AddLast(rightWay);
                    foreach (Way someWay in ways)
                    {
                        for (int i = 0; i < Road.getRoad().COUNTOFSTRIPES; i++)
                        {
                            someWay.stripes.AddLast(new Stripe());
                        }
                    }
                    Road.getRoad().WAYS = ways;
                    
                    break;
                default:
                    break;

            }

            Road r = Road.getRoad();
            Road.getRoad().ROADTYPE = chooseRoadTypeComboBox.SelectedItem.ToString();
            ConstrainsInstaller.setConstrains(chooseRoadTypeComboBox.SelectedItem.ToString());
            //new RoadDrawing(mainPictureBox.CreateGraphics(), mainPictureBox.Width, mainPictureBox.Height).drawRoad();
            RoadDrawing.getRoadDrawing().drawRoad(mainPictureBox.CreateGraphics(), mainPictureBox.Width, mainPictureBox.Height);
        }

       

        private void mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //getRoadDrawing().drawRoad(mainPictureBox.CreateGraphics(), mainPictureBox.Width, mainPictureBox.Height);
            RoadDrawing.getRoadDrawing().drawRoad(e.Graphics, mainPictureBox.Width, mainPictureBox.Height);
            LinkedList<StripeDrawing> stripeDrawings = RoadDrawing.getRoadDrawing().STRIPEDRAWINGS;

            foreach (StripeDrawing sd in stripeDrawings)
            {
                foreach (CarDrawing cd in sd.carsDrawings)
                {
                    cd.drawCar(e.Graphics);
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (trafficLightPictureBoxIsCLicked)
            {
                topDraggedTrafficLightPictureBox.Location = e.Location;              
            }
            if (signPictureBoxIsClicked)
            {
                newSignPictureBoxMain.Location = e.Location;
            }
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (signPictureBoxIsClicked)
            {
                newSignPictureBoxMain.Location = new Point(e.X + mainPictureBox.Location.X, e.Y + mainPictureBox.Location.Y);
            }
            else
            {
                if (draggedSignPictureBoxIsClicked)
                {

                    newSignPictureBoxMain.Location = new Point(e.X + mainPictureBox.Location.X, newSignPictureBoxMain.Location.Y);
                    if (newSignPictureBoxMain.Location.X + newSignPictureBoxMain.Width / 10 > mainPictureBox.Width + mainPictureBox.Location.X)
                    {
                        SignDrawing removableSignDrawing = null;
                        foreach (SignDrawing sg in RoadDrawing.getRoadDrawing().signDrawings)
                        {
                            if (sg.COORDINATS.X == previousCoordinats.X && sg.COORDINATS.Y == previousCoordinats.Y)
                            {
                                removableSignDrawing = sg;
                            }
                        }
                        RoadDrawing.getRoadDrawing().signDrawings.Remove(removableSignDrawing);
                        if (RoadDrawing.getRoadDrawing().signDrawings.Count == 3)
                        {
                            signPictureBox.Enabled = true;
                            signPictureBox.Image = Image.FromFile("..\\..\\images\\sign_icon.png"); 
                        }
                        this.Controls.Remove(newSignPictureBoxMain);
                        signsPictureBoxes.Remove(newSignPictureBoxMain);
                        draggedSignPictureBoxIsClicked = false;
                    }
                }
            }
            if (trafficLightPictureBoxIsCLicked)
            {
                topDraggedTrafficLightPictureBox.Location = new Point(e.X + mainPictureBox.Location.X, e.Y + mainPictureBox.Location.Y);
            }
            else
            {
                if (draggedTrafficLightPictureBoxIsClicked)
                {
                    
                    topDraggedTrafficLightPictureBox.Location = new Point(e.X + mainPictureBox.Location.X, topDraggedTrafficLightPictureBox.Location.Y);
                    if (Road.getRoad().COUNTOFWAYS == 2)
                    {
                        bottomTrafficLightPictureBox.Location = new Point(e.X + mainPictureBox.Location.X, bottomTrafficLightPictureBox.Location.Y);
                    }
                    if (topDraggedTrafficLightPictureBox.Location.X + topDraggedTrafficLightPictureBox.Width / 10 > mainPictureBox.Width + mainPictureBox.Location.X)
                    {                      
                        if (Road.getRoad().COUNTOFWAYS == 2)
                        { 
                            this.Controls.Remove(bottomTrafficLightPictureBox);
                        }
                        this.Controls.Remove(topDraggedTrafficLightPictureBox);
                        TrafficLightDrawing.getTrafficLightDrawing().COORDINATS.Clear();
                        Road.getRoad().TRAFFICLIGHTS.Clear();
                        trafficLightTimer.Stop();
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
                RoadDrawing.getRoadDrawing().resumeCarsTraffic();
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
            initTopDraggedSignPictureBox();
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
                    if (Road.getRoad().COUNTOFWAYS == 2)
                    {
                        bottomTrafficLightPictureBox.Image = TrafficLightDrawing.getTrafficLightDrawing().DEFAULTSTATEBOTTOM;
                        bottomTrafficLightPictureBox.Size = new Size(topDraggedTrafficLightPictureBox.Width * 2, mainPictureBox.Height / 14);
                        bottomTrafficLightPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        bottomTrafficLightPictureBox.Location = new Point(topDraggedTrafficLightPictureBox.Location.X, mainPictureBox.Height - topDraggedTrafficLightPictureBox.Location.Y + bottomTrafficLightPictureBox.Height);
                        this.Controls.Add(bottomTrafficLightPictureBox);
                        bottomTrafficLightPictureBox.BringToFront();
                    }
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
                draggedTrafficLightPictureBoxIsClicked = false;
                SetTrafficLightForm ssf = new SetTrafficLightForm(false);
                ssf.ShowDialog();
            };
            this.Controls.Add(topDraggedTrafficLightPictureBox);
            topDraggedTrafficLightPictureBox.BringToFront();
        }

        PictureBox newSignPictureBoxMain = new PictureBox();
        Point previousCoordinats = new Point();
        private void initTopDraggedSignPictureBox() //args PictureBox...?????
        {
            startPoint = signPictureBox.Location;
            PictureBox newSignPictureBox = new PictureBox();
            signPictureBoxIsClicked = true;
            newSignPictureBox.Image = signPictureBox.Image;
            newSignPictureBox.Size = signPictureBox.Size;
            newSignPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newSignPictureBox.Location = signPictureBox.Location;
            newSignPictureBox.BackColor = Color.WhiteSmoke;
           
            newSignPictureBox.MouseMove += (s, arg) =>
            {
                if (signPictureBoxIsClicked)
                {
                    newSignPictureBox.Left += signPictureBox.Location.X - startPoint.X;
                    newSignPictureBox.Top += signPictureBox.Location.Y - startPoint.Y;
                }
            };
            newSignPictureBox.MouseClick += (s, arg) =>
            {
                if (signPictureBoxIsClicked)
                {
                    //if чтобы положить его сожно только в mainPB

                    
                    signPictureBoxIsClicked = false;
                    newSignPictureBox.Height = mainPictureBox.Height / 14;
                    newSignPictureBox.Width = newSignPictureBox.Height;
                    SignDrawing addedSignDrawing = new SignDrawing();
                    addedSignDrawing.COORDINATS = newSignPictureBox.Location;
                    //signDrawings.AddLast(addedSignDrawing);
                    RoadDrawing.getRoadDrawing().signDrawings.AddLast(addedSignDrawing);
                    if (RoadDrawing.getRoadDrawing().signDrawings.Count == 4)
                    {
                        signPictureBox.Enabled = false;
                        signPictureBox.Image = Image.FromFile("..\\..\\images\\not_enabled_sign_icon.png");
                    }
                    SetSignForm setSignForm = new SetSignForm(addedSignDrawing);
                    setSignForm.ShowDialog();
                    Road.getRoad().SIGNS.AddLast(addedSignDrawing.SIGN);
                    addedSignDrawing.getSignGraphic(Graphics.FromImage(newSignPictureBox.Image));
                    signsPictureBoxes.AddLast(newSignPictureBox);
                    newSignPictureBox.Invalidate(); newSignPictureBox.Invalidate(); newSignPictureBox.Invalidate();
                }
                else
                {
                    if (draggedSignPictureBoxIsClicked)
                    { 
                        draggedSignPictureBoxIsClicked = false;
                        PictureBox pb = (PictureBox) s;
                        foreach (SignDrawing sd in RoadDrawing.getRoadDrawing().signDrawings)
                        {
                            if ((sd.COORDINATS.X == previousCoordinats.X) && (sd.COORDINATS.Y == previousCoordinats.Y))
                            {                                
                                sd.COORDINATS = pb.Location;
                            }
                        }
                       
                    }
                    else
                    {
                        draggedSignPictureBoxIsClicked = true;
                        newSignPictureBoxMain = signsPictureBoxes.Find((PictureBox)s).Value;
                        previousCoordinats = newSignPictureBoxMain.Location;
                    }
                }
            };
            newSignPictureBox.DoubleClick += (s, arg) =>
            {
                draggedSignPictureBoxIsClicked = false; 
                PictureBox pb = (PictureBox)s;
                foreach (SignDrawing sg in RoadDrawing.getRoadDrawing().signDrawings)
                {
                    if (sg.COORDINATS == pb.Location)
                    {
                        SetSignForm ssf = new SetSignForm(sg);
                        ssf.ShowDialog();
                        sg.getSignGraphic(Graphics.FromImage(pb.Image));
                        pb.Invalidate();
                   }
                }
                pb.Invalidate(); pb.Invalidate();
                newSignPictureBox.Invalidate(); newSignPictureBox.Invalidate(); newSignPictureBox.Invalidate();
            };

            newSignPictureBox.Paint += (s, arg) =>
            {
                PictureBox pb = (PictureBox)s;

                foreach (SignDrawing sg in RoadDrawing.getRoadDrawing().signDrawings)
                {
                    if (sg.COORDINATS.X == pb.Location.X && sg.COORDINATS.Y == pb.Location.Y)
                    {
                        sg.getSignGraphic(Graphics.FromImage(pb.Image));
                    }                   
                }
            };


            this.Controls.Add(newSignPictureBox);
            newSignPictureBoxMain = newSignPictureBox;
            signPictureBox.Image = Image.FromFile("..\\..\\images\\sign_icon.png");
            newSignPictureBox.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            LinkedList<StripeDrawing> stripeDrawings = RoadDrawing.getRoadDrawing().STRIPEDRAWINGS;
            if (Road.getRoad().TRAFFICLIGHTS.First != null)
            {
                if (!Road.getRoad().TRAFFICLIGHTS.First.Value.REDLIGHT)
                {
                    RoadDrawing.getRoadDrawing().stopCars(topDraggedTrafficLightPictureBox.Width, mainPictureBox.Location.X);
                }
            }
            foreach (StripeDrawing sd in stripeDrawings)
            {

                LinkedList<CarDrawing> carDrawings = sd.carsDrawings;
                if (carDrawings.Count > 0)
                {
                    if (carDrawings.First.Value.car.speed < 0)
                    {
                        if (sd.firstCarIsLeaved(mainPictureBox.Width))
                        {
                            sd.stripe.CARS.Remove(sd.carsDrawings.First.Value.car);
                            sd.carsDrawings.RemoveFirst();
                            //sd.stripe.CARS.RemoveFirst(); 
                            
                        }
                    }
                    else
                    {
                        if (sd.firstCarIsLeaved(0))
                        {                           
                            sd.carsDrawings.RemoveFirst();
                            sd.stripe.CARS.RemoveFirst();
                            
                           
                        }
                    }
                }
                sd.correctSpeeds();
                sd.overtaking();
                foreach (CarDrawing cd in carDrawings) //void move() 
                {
                    
                    cd.X -= cd.car.speed;
                }
               // Road r = Road.getRoad();
                if (Road.getRoad().SIGNS.Count > 0)
                {
                    if (Road.getRoad().COUNTOFWAYS == 2)
                    {
                        RoadDrawing.getRoadDrawing().correctSpeedBySigns(mainPictureBox.Height / 2, mainPictureBox.Location.X);
                    }
                    else
                    {
                        RoadDrawing.getRoadDrawing().correctSpeedBySigns(mainPictureBox.Location.X);
                    }
                }
                
            }
            mainPictureBox.Invalidate();
        }
        Random rnd = new Random();

        private void generateCarTimer_Tick(object sender, EventArgs e)
        {
            Car newCar = new Car((int) GeneratorsHolder.getGeneratorsHolder().SPEEDSGENERATOR.getSpeed());
            CarDrawing newCarDrawing = new CarDrawing("..\\..\\images\\cars\\car" + rnd.Next(1,5).ToString() + ".png", newCar);
            newCarDrawing.car = newCar;
            Stripe randomStripe = new Stripe(); ;
            Way randomWay = new Way();
            //int i = 0;
            //while (i < Road.getRoad().COUNTOFSTRIPES) 
            //{
                 int randowWayNumber = rnd.Next(0, Road.getRoad().COUNTOFWAYS);
                 randomWay = Road.getRoad().WAYS.ElementAt(randowWayNumber);
                 int randomStripeNumber = rnd.Next(0, randomWay.stripes.Count);
                 randomStripe = randomWay.stripes.ElementAt(randomStripeNumber);
                 foreach (StripeDrawing sd in RoadDrawing.getRoadDrawing().STRIPEDRAWINGS)
                 {
                     if (randomStripe.Equals(sd.stripe))
                     {
                         if(sd.canGenerateNewCar(randomWay.way.Equals("LEFT") ? mainPictureBox.Width : 0, randomWay.way.Equals("LEFT") ? -1 : 1))
                         {
                            sd.carsDrawings.AddLast(newCarDrawing);
                            if (randomWay.way.Equals("RIGHT"))
                            {
                                newCar.speed *= -1;
                                newCar.initialSpeed = newCar.speed;
                                newCarDrawing.carImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                newCarDrawing.X = sd.X;
                                newCarDrawing.Y = sd.Y + mainPictureBox.Height / 14;
                            }
                            else
                            {
                                newCarDrawing.X = sd.X + mainPictureBox.Width;
                                newCarDrawing.Y = sd.Y + mainPictureBox.Height / 14;
                            }
                            mainPictureBox.Invalidate();
                         }
                     }
                 }
                 //++i;
            //}
        
            randomStripe.addCar(newCar);
            generateCarTimer.Interval = (int) (GeneratorsHolder.getGeneratorsHolder().TIMESGENERATOR.getTime() * 1000);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
            generateCarTimer.Stop();
            trafficLightTimer.Stop();
            resumeButton.Enabled = true;
            resumeButton.Visible = true;
            stopButton.Enabled = false;
            stopButton.Visible = false;
            resetButton.Enabled = true;
            resetButton.Visible = true;
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            animationTimer.Start();
            if (Road.getRoad().TRAFFICLIGHTS.Count > 0)
            {
                trafficLightTimer.Start();
            }
            generateCarTimer.Start();
            resumeButton.Enabled = false;
            resumeButton.Visible = false;
            stopButton.Enabled = true;
            stopButton.Visible = true;
            resetButton.Enabled = false;
            resetButton.Visible = false;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (Road.getRoad().TRAFFICLIGHTS.Count > 0)
            {
                this.Controls.Remove(topDraggedTrafficLightPictureBox);
                if (Road.getRoad().COUNTOFWAYS == 2)
                {
                    this.Controls.Remove(bottomTrafficLightPictureBox);
                }
                trafficLightPictureBox.Enabled = true;
                trafficLightPictureBox.Image = Image.FromFile("..\\..\\images\\traffic_light_icon.jpg");
            }
            foreach (PictureBox pb in signsPictureBoxes)
            {
                this.Controls.Remove(pb);
            }
            //Road.getRoad().clearRoad();
            RoadDrawing.getRoadDrawing().clearRoadDrawing(mainPictureBox.CreateGraphics());
            resetButton.Enabled = false;
            resetButton.Visible = false;
            stopButton.Enabled = false;
            stopButton.Visible = false;
            resumeButton.Enabled = false;
            resumeButton.Visible = false;
            
            
        }

        private bool checkTimeParamsForException()
        {
            bool result = true;
            int outer = 5;
            double outerD = 1.5;
            if (chooseTimeTypeComboBox.SelectedIndex == 0)
            {
                if (!Int32.TryParse(timeTextBox.Text, out outer))
                {
                    MessageBox.Show("В параметр времени нужно ввести целое числовое значение");
                    result = false;
                }
                else
                {
                    if (Int32.Parse(timeTextBox.Text) > ConstrainsHolder.getConstrainsHolder().MAXTIME ||
                             Int32.Parse(timeTextBox.Text) < ConstrainsHolder.getConstrainsHolder().MINTIME)
                    {
                        MessageBox.Show("Детерминированное время машин должно быть от 1 до 10");
                        result = false;
                    }
                }
            }
            else if (chooseTimeTypeComboBox.SelectedIndex == 1)
            {
                if (chooseTimeDistributionLawComboBox.SelectedIndex == 0)
                {
                    if (!Double.TryParse(timesFirstParTextBox.Text, out outerD))
                    {
                        result = false;
                        MessageBox.Show("Значение математического ожидания для нормального распределения времени машин имеет недопустимое значение");
                    }
                    else if (!Double.TryParse(timesSecondParTextBox.Text, out outerD))
                    {
                        result = false;
                        MessageBox.Show("Значение дисперсии для нормального распределения времени появления машин имеет недопустимое значение");
                    }
                }
                else if (chooseTimeDistributionLawComboBox.SelectedIndex == 1)
                {
                    if (!Double.TryParse(timesFirstParTextBox.Text, out outerD))
                    {
                        MessageBox.Show("Недопустимое значение параметра показательного распределения для времени");
                        result = false;
                    }
                    else
                    {
                        if (Double.Parse(timesFirstParTextBox.Text) > ConstrainsHolder.getConstrainsHolder().MAXEXPPARTOFTIME ||
                               Double.Parse(timesFirstParTextBox.Text) < ConstrainsHolder.getConstrainsHolder().MINEXPPARFORTIME)
                        {
                            result = false;
                            MessageBox.Show("Значения параметра показательного распределения для времени должны находиться в интвервале [0,1;1]");
                        }
                    }
                }
                else if (chooseTimeDistributionLawComboBox.SelectedIndex == 2)
                {
                    if (!Int32.TryParse(timesFirstParTextBox.Text, out outer))
                    {
                        result = false;
                        MessageBox.Show("Недопустимое значения для параметра а равномерного распределения времени появления машин.");
                    }
                    else if (!Int32.TryParse(timesSecondParTextBox.Text, out outer))
                    {
                        result = false;
                        MessageBox.Show("Недопустимое значения для параметра b равномерного распределения времени появления машин.");
                    }
                    else if (Int32.Parse(timesFirstParTextBox.Text) < ConstrainsHolder.getConstrainsHolder().AFORTIME ||
                                Int32.Parse(timesSecondParTextBox.Text) > ConstrainsHolder.getConstrainsHolder().BFORTIME)
                    {
                        result = false;
                        MessageBox.Show("Значения параметров для равномерного распредлеения времени появления машин не могут быть меньше 1 или больше 10");
                    }
                    else if (Int32.Parse(timesFirstParTextBox.Text) >= Int32.Parse(timesSecondParTextBox.Text))
                    {
                        result = false;
                        MessageBox.Show("Значение параметра а для равномерного распределения времени появления машин всегда должно быть меньше параметра b");
                    }
                }
            }
            else
            {
                result = false;
                MessageBox.Show("Необходимо установить время появления машин");
            }

            return result;
        }

        private bool checkSpeedParamsForExceptions()
        {
            bool result = true;
            int outer = 5;
            double outerD = 1.5;
            if (chooseSpeedTypeComboBox.SelectedIndex == 0)
            {
                if (!Int32.TryParse(speedTextBox.Text, out outer))
                {
                    MessageBox.Show("В скорости появления машин нужно ввести целое числовое значение");
                    result = false;
                }
                else if (Int32.Parse(speedTextBox.Text) > ConstrainsHolder.getConstrainsHolder().MAXSPEED ||
                            Int32.Parse(speedTextBox.Text) < ConstrainsHolder.getConstrainsHolder().MINSPEED)
                {
                    result = false;
                    MessageBox.Show("При данном типе дороги скорость должна быть от " + ConstrainsHolder.getConstrainsHolder().MINSPEED 
                                        + " до " + ConstrainsHolder.getConstrainsHolder().MAXSPEED);
                }
            }
            else if (chooseSpeedTypeComboBox.SelectedIndex == 1)
            {
                if (chooseSpeedDistributionLawComboBox.SelectedIndex == 0)
                {
                    if (!Double.TryParse(speedsFirstParTextBox.Text, out outerD))
                    {
                        result = false;
                        MessageBox.Show("Математическое ожидание для нормального распределения скоростей было задано неверно");
                    }
                    else if (!Double.TryParse(speedsSecondParTextBox.Text, out outerD))
                    {
                        result = false;
                        MessageBox.Show("Дисперсия для нормального распределения скоростей была задана неверно");
                    }
                }
                else if (chooseSpeedDistributionLawComboBox.SelectedIndex == 1)
                {
                    if (!Double.TryParse(speedsFirstParTextBox.Text, out outerD))
                    {
                        result = false;
                        MessageBox.Show("Входная строка для параметра показательного распределения скоростей имела неверный формат");
                    }
                    else if (Double.Parse(speedsFirstParTextBox.Text) > ConstrainsHolder.getConstrainsHolder().MAXEXPPAROFSPEED ||
                                Double.Parse(speedsFirstParTextBox.Text) < ConstrainsHolder.getConstrainsHolder().MINEXPPAROFSPEED)
                    {
                        result = false;
                        MessageBox.Show("Параметр показательного распределения скоростей должен находиться в интервале [0.01;0.04]");
                    }
                }
                else if (chooseSpeedDistributionLawComboBox.SelectedIndex == 2)
                {
                    if (!Int32.TryParse(speedsFirstParTextBox.Text, out outer))
                    {
                        result = false;
                        MessageBox.Show("Входная строка для левой границы равномерного распределения имеет неверный формат");
                    }
                    else if (!Int32.TryParse(speedsSecondParTextBox.Text, out outer))
                    {
                        result = false;
                        MessageBox.Show("Входная строка для правой границы равномерного распределения имеет неверный формат");
                    }
                    else if (Int32.Parse(speedsFirstParTextBox.Text) < ConstrainsHolder.getConstrainsHolder().AFORSPEED ||
                                Int32.Parse(speedsSecondParTextBox.Text) > ConstrainsHolder.getConstrainsHolder().BFORSPEED)
                    {
                        result = false;
                        MessageBox.Show("Левая граница равномерного распределения скоростей должна быть не меньше " + 
                                            ConstrainsHolder.getConstrainsHolder().AFORSPEED + " , а правая не больше " + 
                                                ConstrainsHolder.getConstrainsHolder().BFORSPEED);
                    }
                    else if (Int32.Parse(speedsFirstParTextBox.Text) > Int32.Parse(speedsSecondParTextBox.Text))
                    {
                        result = false;
                        MessageBox.Show("Левая граница равномерного распределения скоростей не должна быть большей правой");
                    }
                }
            }
            else
            {
                result = false;
                MessageBox.Show("Необходимо установить параметры скорости машин");
            }
            return result;
        }
     
    }
}
