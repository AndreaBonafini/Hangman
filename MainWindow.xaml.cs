﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        string RightAnswer;
        Random random = new Random();
      //Random random = new Random((int)DateTime.Now.Ticks);
        string DiscoveredAnswer;
        string[] incorrectGuessed = new string[7];
        string[] easy = new string[10];
        string[] medium = new string[10];
        string[] hard = new string[10];
        List<string> ImageList = new List<string>();
        //bool GameOver;
        int counter = 7;
        string lblWrong = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            int randomnumber = random.Next(1, 10);
            lblOutput.Text = "";
            //Radio Button to decide the difficulty of the game
            //and pick a random word from list/textfile
            if ((bool)rbEasy.IsChecked)
            {
                System.IO.StreamReader easyread = new System.IO.StreamReader("Easy.txt");
                while (!easyread.EndOfStream)
                {
                    if (count == randomnumber)
                    {
                        easy[randomnumber] = easyread.ReadLine();
                    }
                    else
                    {
                        easyread.ReadLine();
                    }
                    RightAnswer = easy[randomnumber];
                    count++;
                }
                easyread.Close();
                for (int i = 0; i < RightAnswer.Length; i++)
                {
                    lblOutput.Text += "_" + " ";
                }
            }
                if ((bool)rbMedium.IsChecked)
                {
                    count = 0;
                    System.IO.StreamReader mediumLevel = new System.IO.StreamReader("Medium.txt");
                    while (!mediumLevel.EndOfStream)
                    {
                        if (count == randomnumber)
                        {
                            medium[randomnumber] = mediumLevel.ReadLine();
                        }
                        else
                        {
                            mediumLevel.ReadLine();
                        }
                        RightAnswer = medium[randomnumber];
                        count++;
                    }
                    mediumLevel.Close();
                    for (int i = 0; i < RightAnswer.Length; i++)
                    {
                        lblOutput.Text += "_" + " ";
                    }
                }
                if ((bool)rbHard.IsChecked)
                {
                    count = 0;
                    System.IO.StreamReader HardLevel = new System.IO.StreamReader("Hard.txt");
                    while (!HardLevel.EndOfStream)
                    {
                        if (count == randomnumber)
                        {
                            hard[randomnumber] = HardLevel.ReadLine();
                        }
                        else
                        {
                            HardLevel.ReadLine();
                        }
                        RightAnswer = hard[randomnumber];
                        count++;
                    }
                    HardLevel.Close();
                    for (int i = 0; i < RightAnswer.Length; i++)
                    {
                        lblOutput.Text += "_" + " ";
                    }
                }
            MessageBox.Show("To input a new letter,please delete the previous one");
        }

        private void BtnLetterCheck_Click(object sender, RoutedEventArgs e)
        {
            //replace the letter of the input if right
            DiscoveredAnswer = lblOutput.Text.ToString();
            if (RightAnswer == null)
            {
                MessageBox.Show("Please select a difficulty and restart the game");
                RightAnswer = " ";
            }
            else
            { 
            for (int i = 0; i < RightAnswer.Length; i++)
            {
            char lettersingle = RightAnswer[i];
            if (lettersingle.ToString() == txtLetterInput.Text)
                {
                    DiscoveredAnswer = DiscoveredAnswer.Remove(i * 2, 1);
                    DiscoveredAnswer = DiscoveredAnswer.Insert(i * 2, lettersingle.ToString());
                    lblOutput.Text = "";
                    lblOutput.Text += DiscoveredAnswer;
                }                
            else if (!RightAnswer.Contains(txtLetterInput.ToString()))
                    {
                        counter--;
                        incorrectGuessed[i] = txtLetterInput.Text;
                        lblWrong = lblWrong + incorrectGuessed[i] + " ";
                        lblWrongLetter.Content = lblWrong;
                        i = RightAnswer.Length;
                        if (counter != 0)
                        {
                            lblWrongLetter.Content = "Your guess:  " + "\"" + txtLetterInput.Text + "\"" + " was incorrect!";
                            lblLives.Content = Environment.NewLine + "Lives left:" + counter.ToString();
                        }

                        if (counter == 0)
                        {
                            lblOutput.Text = "You lose! The word you were looking for was: " + RightAnswer;
                        }
                    }
                }
                if (counter == 6)
                {
                    Ellipse head = new Ellipse();
                    head.Width = 60;
                    head.Height = 60;
                    head.Fill = Brushes.White;
                    head.Stroke = Brushes.White;
                    head.StrokeThickness = 5;
                    canvas.Children.Add(head);
                    Canvas.SetTop(head, 232);
                    Canvas.SetLeft(head, 408);
                }
                else if (counter == 5)
                {
                    Rectangle Body = new Rectangle();
                    Body.Width = 5;
                    Body.Height = 70;
                    Body.Fill = Brushes.White;
                    Body.Stroke = Brushes.White;
                    canvas.Children.Add(Body);
                    Canvas.SetTop(Body, 287);
                    Canvas.SetLeft(Body, 436);
                }
                else if (counter == 2)
                {
                    Line leg1 = new Line();
                    leg1.X1 = 438;
                    leg1.X2 = 460;
                    leg1.Y1 = 355;
                    leg1.Y2 = 400;
                    leg1.Stroke = Brushes.White;
                    leg1.StrokeThickness = 5;
                    leg1.HorizontalAlignment = HorizontalAlignment.Left;
                    leg1.VerticalAlignment = VerticalAlignment.Center;
                    canvas.Children.Add(leg1);
                }
                else if (counter == 1)
                {
                    Line leg2 = new Line();
                    leg2.X1 = 438;
                    leg2.X2 = 416;
                    leg2.Y1 = 295;
                    leg2.Y2 = 340;
                    leg2.Stroke = Brushes.White;
                    leg2.StrokeThickness = 5;
                    leg2.HorizontalAlignment = HorizontalAlignment.Left;
                    leg2.VerticalAlignment = VerticalAlignment.Center;
                    canvas.Children.Add(leg2);
                }
                else if (counter == 3)
                {
                    Line arm1 = new Line();
                    arm1.X1 = 438;
                    arm1.X2 = 460;
                    arm1.Y1 = 295;
                    arm1.Y2 = 340;
                    arm1.Stroke = Brushes.White;
                    arm1.StrokeThickness = 5;
                    arm1.HorizontalAlignment = HorizontalAlignment.Left;
                    arm1.VerticalAlignment = VerticalAlignment.Center;
                    canvas.Children.Add(arm1);
                }
                else if (counter == 4)
                {
                    Line arm2 = new Line();
                    arm2.X1 = 438;
                    arm2.X2 = 416;
                    arm2.Y1 = 355;
                    arm2.Y2 = 400;
                    arm2.Stroke = Brushes.White;
                    arm2.StrokeThickness = 5;
                    arm2.HorizontalAlignment = HorizontalAlignment.Left;
                    arm2.VerticalAlignment = VerticalAlignment.Center;
                    canvas.Children.Add(arm2);
                }
                                   /* lblWrongLetter.Content = "Letter Guessed:";
                                    lblWrongLetter.Content += " " + txtLetterInput.Text + ";";
                                    if (WinnerCheck == 0)
                                    {
                                        string wordarrays;
                                        char lettersingle = RightAnswer[i];
                                        wordarrays = lettersingle[0] 
                                    }*/
            }
            }           

        /*private bool startGame(bool test)
        {
            if (lblOutput.Text.ToString() == RightAnswer || GameOver == true)
            {
                count = 0;
                int randomnumber = random.Next(0, 10);
                lblOutput.Text = "";

                if ((bool)rbEasy.IsChecked)
                {
                    System.IO.StreamReader easyread = new System.IO.StreamReader("Easy.txt");
                    while (!easyread.EndOfStream)
                    {
                        if (count == randomnumber)
                        {
                            easy[randomnumber] = easyread.ReadLine();
                        }
                        else
                        {
                            easyread.ReadLine();
                        }
                        RightAnswer = easy[randomnumber];
                        count++;
                    }
                    easyread.Close();
                    for (int i = 0; i < RightAnswer.Length; i++)
                    {
                        lblOutput.Text += "_" + " ";
                    }

                    if ((bool)rbMedium.IsChecked)
                    {
                        count = 0;
                        System.IO.StreamReader mediumLevel = new System.IO.StreamReader("Medium.txt");
                        while (!mediumLevel.EndOfStream)
                        {
                            medium[count] = mediumLevel.ReadLine();
                            lblOutput.Text += medium[count] + Environment.NewLine;
                            count++;
                        }
                        mediumLevel.Close();
                    }
                    if ((bool)rbHard.IsChecked)
                    {
                        count = 0;
                        System.IO.StreamReader HardLevel = new System.IO.StreamReader("Hard.txt");
                        while (!HardLevel.EndOfStream)
                        {
                            hard[count] = HardLevel.ReadLine();
                            lblOutput.Text += hard[count] + Environment.NewLine;
                            count++;
                        }
                        HardLevel.Close();
                    }
                }

                lblOutput.Text = RightAnswer;
                lblOutput.Text += Environment.NewLine + "Lives left :" + lives;
                GameOver = false;
                return test = true;
            }
            else
            {
                return test = false;
            }
        }*/

        private void BtnReplay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
