using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace APProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer ClockTimer;
        public MainWindow()
        {
            InitializeComponent();
            #region Clock

            #region circle around the clock

            Ellipse aroundCircle = new Ellipse();
            SolidColorBrush mySolidColorBrushForAroundCirlce = new SolidColorBrush();
            mySolidColorBrushForAroundCirlce.Color = Color.FromArgb(255, 90, 90, 90);
            aroundCircle.Fill = mySolidColorBrushForAroundCirlce;
            aroundCircle.StrokeThickness = 2;
            aroundCircle.Stroke = Brushes.Black;
            aroundCircle.Width = 110;
            aroundCircle.Height = 110;
            Thickness around = aroundCircle.Margin;
            around.Top = -210;
            around.Left = 635;
            aroundCircle.Margin = around;
            this.MainGrid.Children.Add(aroundCircle);

            #endregion circle around the clock

            #region 12 circles for clock 
            double teta = 0;
            for (int i = 0; i < 12; i++)
            {
                Ellipse myEllipse1 = new Ellipse();
                SolidColorBrush mySolidColorBrush1 = new SolidColorBrush();

                mySolidColorBrush1.Color = Color.FromArgb(255, 0, 0, 0);
                myEllipse1.Fill = mySolidColorBrush1;
                myEllipse1.StrokeThickness = 2;
                myEllipse1.Stroke = Brushes.Black;

                if (i % 3 == 0)
                {
                    myEllipse1.Width = 7;
                    myEllipse1.Height = 7;
                }
                else
                {
                    myEllipse1.Width = 5;
                    myEllipse1.Height = 5;
                }

                Thickness n1 = myEllipse1.Margin;
                n1.Top = -210 + 100 * Math.Cos(teta);
                n1.Left = 635 + 100 * Math.Sin(teta);
                myEllipse1.Margin = n1;
                this.MainGrid.Children.Add(myEllipse1);
                teta += Math.PI / 6;
            }
            #endregion 12 circles for clock

            #region circle
            Ellipse myEllipse = new Ellipse();
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();

            mySolidColorBrush.Color = Color.FromArgb(255, 0, 0, 0);
            myEllipse.Fill = mySolidColorBrush;
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.Black;
            myEllipse.Width = 5;
            myEllipse.Height = 5;
            Thickness n = myEllipse.Margin;
            n.Top = -210;
            n.Left = 635;
            myEllipse.Margin = n;
            MainGrid.Children.Add(myEllipse);
            #endregion circle

            #region Lines For Hands
            Line secondLine = new Line();
            Line minuteLine = new Line();
            Line hourLine = new Line();
            secondLine.Stroke = Brushes.Red;
            secondLine.Fill = Brushes.Black;
            minuteLine.Stroke = Brushes.Black;
            minuteLine.Fill = Brushes.Black;
            hourLine.Stroke = Brushes.Black;
            hourLine.Fill = Brushes.Black;
            #endregion Lines For Hands

            Clock myclock = new Clock();
            myclock.CenterX = 710;
            myclock.CenterY = 100;
            secondLine.X1 = myclock.CenterX;
            secondLine.Y1 = myclock.CenterY;
            minuteLine.X1 = myclock.CenterX;
            minuteLine.Y1 = myclock.CenterY;
            hourLine.X1 = myclock.CenterX;
            hourLine.Y1 = myclock.CenterY;

            #region initialize properties and update
            myclock.SecondHand.Length = 45;
            myclock.MinuteHand.Length = 40;
            myclock.HourHand.Length = 30;
            myclock.SecondHand.Thickness = 1.2;
            myclock.MinuteHand.Thickness = 1.7;
            myclock.HourHand.Thickness = 3;

            secondLine.StrokeThickness = myclock.SecondHand.Thickness;
            minuteLine.StrokeThickness = myclock.MinuteHand.Thickness;
            hourLine.StrokeThickness = myclock.HourHand.Thickness;

            myclock.UpdateClock();
            secondLine.X2 = myclock.CenterX + myclock.SecondHand.Length * Math.Cos(myclock.SecondHand.Angle);
            secondLine.Y2 = myclock.CenterY + myclock.SecondHand.Length * Math.Sin(myclock.SecondHand.Angle);
            minuteLine.X2 = myclock.CenterX + myclock.MinuteHand.Length * Math.Cos(myclock.MinuteHand.Angle);
            minuteLine.Y2 = myclock.CenterY + myclock.MinuteHand.Length * Math.Sin(myclock.MinuteHand.Angle);
            hourLine.X2 = myclock.CenterX + myclock.HourHand.Length * Math.Cos(myclock.HourHand.Angle);
            hourLine.Y2 = myclock.CenterY + myclock.HourHand.Length * Math.Sin(myclock.HourHand.Angle);
            #endregion initialize properties and update

            ClockTimer = new Timer((a) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    MainGrid.Children.Remove(secondLine);
                    MainGrid.Children.Remove(minuteLine);
                    MainGrid.Children.Remove(hourLine);
                    myclock.UpdateClock();
                    secondLine.X2 = myclock.CenterX + myclock.SecondHand.Length * Math.Cos(myclock.SecondHand.Angle);
                    secondLine.Y2 = myclock.CenterY + myclock.SecondHand.Length * Math.Sin(myclock.SecondHand.Angle);
                    minuteLine.X2 = myclock.CenterX + myclock.MinuteHand.Length * Math.Cos(myclock.MinuteHand.Angle);
                    minuteLine.Y2 = myclock.CenterY + myclock.MinuteHand.Length * Math.Sin(myclock.MinuteHand.Angle);
                    hourLine.X2 = myclock.CenterX + myclock.HourHand.Length * Math.Cos(myclock.HourHand.Angle);
                    hourLine.Y2 = myclock.CenterY + myclock.HourHand.Length * Math.Sin(myclock.HourHand.Angle);

                    MainGrid.Children.Add(secondLine);
                    MainGrid.Children.Add(minuteLine);
                    MainGrid.Children.Add(hourLine);
                });

            }, null, 1000, 1000);

            #endregion Clock

        }
    

       
   

        private void SaveButtonFunc_Click(object sender, RoutedEventArgs e)
        {
            string[] InputStrings= File.ReadAllLines(@"../../Information.txt");
            
            List<Person> people = new List<Person>();
            for(int i=0;i<InputStrings.Length;i+=6)
            {
               
                people.Add(new Person(InputStrings[i], InputStrings[i + 1], InputStrings[i + 2],int.Parse( InputStrings[i + 3]), InputStrings[i + 4], InputStrings[i + 5]));
            }
            StreamWriter NoteFile = new StreamWriter(@"../../Information.txt",append:true);
            try
            {
                string[] inputtext = NoteText.Text.Split('\n');
                int i = 2;
                int n;
                while (!int.TryParse(inputtext[i], out n))
                {
                    i++;
                }
                List<string> equtions = new List<string>();
                int k = 0;
                for (int j = i + 1; j < inputtext.Length; j++)
                {
                    if (inputtext[j].Contains("=") && (inputtext[j].Contains("-") || inputtext[j].Contains("+"))) 
                    {
                        equtions.Add( inputtext[j]);
                        k++;
                    }
                    if(k>=2)
                    {
                        break;
                    }
                }
                Person p = new Person(inputtext[0], inputtext[1], inputtext[2], n, equtions[0], equtions[1]);
                if (!people.Contains(p))
                {
                    NoteFile.Write(p.FirstName);
                    NoteFile.Write(p.LastName);
                    NoteFile.Write(p.City);
                    NoteFile.WriteLine(p.Age);
                    NoteFile.Write(p.Equation1);
                    NoteFile.Write(p.Equation2);
                }

            }
            catch { }
            
           
            
            
            NoteFile.Close();
            NoteText.Clear();
        }

        private void ShowButtonFunc_Click(object sender, RoutedEventArgs e)
        {
            NoteText.Clear();
            string[] InputStrings = File.ReadAllLines(@"../../Information.txt");
            
            List<Person> people = new List<Person>();
            for (int i = 0; i < InputStrings.Length; i += 6)
            {
                people.Add(new Person(InputStrings[i], InputStrings[i + 1], InputStrings[i + 2], int.Parse(InputStrings[i + 3]), InputStrings[i + 4], InputStrings[i + 5]));
            }
            for(int i=0;i<people.Count;i++)
            {
                NoteText.Text += $"Person {i+1} :\n";
                NoteText.Text += $"  First Name : {people[i].FirstName}\n";
                NoteText.Text += $"  Last Name : { people[i].LastName}\n";
                NoteText.Text += $"  City : {people[i].City}\n";
                NoteText.Text += $"  Age : {people[i].Age}\n";
                NoteText.Text += $"  Equation 1 : {people[i].Equation1}\n";
                NoteText.Text += $"  Equation 2 : {people[i].Equation2}\n";
                NoteText.Text += $"  Answers : {people[i].Answers[0].ch} = {people[i].Answers[0].answer}" +
                    $" , {people[i].Answers[1].ch} = {people[i].Answers[1].answer}\n";
            }

        }

        private void ClearButtonFunc_Click(object sender, RoutedEventArgs e)
        {
            NoteText.Clear();
        }

        private void ClearFileButtonFunc_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter NoteFile = new StreamWriter(@"../../Information.txt");
            NoteFile.Flush();
            NoteFile.Close();

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            QueryText.Clear();
            string[] InputStrings = File.ReadAllLines(@"../../Information.txt");
            
            List<Person> people = new List<Person>();
            for (int i = 0; i < InputStrings.Length; i += 6)
            {
                people.Add(new Person(InputStrings[i], InputStrings[i + 1], InputStrings[i + 2], int.Parse(InputStrings[i + 3]), InputStrings[i + 4], InputStrings[i + 5]));
            }

            string firstname = FirstNameText.Text.ToLower();
            string lastname = LastNameText.Text.ToLower();
            string city = CityText.Text.ToLower();
            int overage;
            try
            {
                overage = int.Parse(OverAgeText.Text);

            }
            catch
            {
                overage = -1;
            }
            int lowerage;
            try
            {
                lowerage = int.Parse(LowerAgeText.Text);
            }
            catch
            {
                lowerage = -1;
            }
           
            string eqution1 = Equation1Text.Text.ToLower();
            string eqution2 = Equation2Text.Text.ToLower();
            string answers = AnswersText.Text.ToLower();
            List<Person> searched = people;

            if(firstname!="")
            {
                searched = searched.Where(d => d.FirstName == firstname).ToList();
            }
            if(lastname!="")
            {
                searched = searched.Where(d => d.LastName == lastname).ToList();
            }
            if(city!="")
            {
                searched = searched.Where(d => d.City == city).ToList();
            }
            if (overage != -1)
            {
                searched = searched.Where(d => d.Age > overage).ToList();
            }
            if (lowerage != -1)
            {
                searched = searched.Where(d => d.Age < lowerage).ToList();
            }
            if(eqution1!="")
            {
                if(eqution2!="")
                {
                    searched = searched.Where(d => (d.Equation1 == eqution1 && d.Equation2 == eqution2)||(d.Equation2 == eqution1 && d.Equation1 == eqution2)).ToList();
                }
                else
                {
                    searched = searched.Where(d => (d.Equation1 == eqution1) || (d.Equation2 == eqution1)).ToList();
                }
            }
            else
            {
                if(eqution2!="")
                {
                    searched = searched.Where(d => (d.Equation1 == eqution2) || (d.Equation2 == eqution2)).ToList();
                }
                
            }

            if(answers!="")
            {
                string[] s = answers.Split(',');
                double[] a = new double[2];
                a[0] = double.Parse(s[0]);
                a[1] = double.Parse(s[1]);
                Array.Sort(a);
                searched = searched.Where(d => d.Answers[0].answer == a[0] && d.Answers[1].answer == a[1]).ToList();

            }

            for (int i = 0; i < searched.Count; i++)
            {
                QueryText.Text += $"Person {i + 1} :\n";
                QueryText.Text += $"  First Name : {searched[i].FirstName}\n";
                QueryText.Text += $"  Last Name : { searched[i].LastName}\n";
                QueryText.Text += $"  City : {searched[i].City}\n";
                QueryText.Text += $"  Age : {searched[i].Age}\n";
                QueryText.Text += $"  Equation 1 : {searched[i].Equation1}\n";
                QueryText.Text += $"  Equation 2 : {searched[i].Equation2}\n";
            }




        }

        
    }


    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Equation1 { get; set; }
        public string Equation2 { get; set; }
        public Answer[] Answers { get; set; }


        

        public Person(string firstname,string lastname,string city,int age,string equation1,string equation2)
        {
            this.FirstName = firstname.ToLower();
            this.LastName = lastname.ToLower();
            this.City = city.ToLower();
            this.Age = age;
            this.Equation1 = equation1.ToLower();
            this.Equation2 = equation2.ToLower();
            this.Answers= this.EquationSolve();
            
            
        }

        private Answer[] EquationSolve()
        {
            double[] answers = new double[2];
            double[] a = new double[2];
            double[] b = new double[2];
            double[] c = new double[2];

          

            List<Var> varibales = new List<Var>();
            List<char> vars = new List<char>();


            foreach(char ch in this.Equation1)
            {
                if(char.IsLetter(ch) && !vars.Contains(ch))
                {
                    varibales.Add(new Var(ch));
                    vars.Add(ch);
                }
            }
            foreach (char ch in this.Equation2)
            {
                if (char.IsLetter(ch) && !vars.Contains(ch))
                {
                    varibales.Add(new Var(ch));
                }
            }
            string s1="";
            string s2="";
            int idx = Equation1.IndexOf('=');
            for(int i=idx+1;i<Equation1.Length;i++)
            {
                s1 += Equation1[i];
            }
            c[0] = double.Parse(s1);
            idx = Equation2.IndexOf('=');
            for (int i = idx + 1; i < Equation2.Length; i++)
            {
                s2 += Equation2[i];
            }
            c[1] = double.Parse(s2);
            idx = Equation1.IndexOf(varibales[0].ch);
            idx--;
            s1 = "";
            while (!char.IsLetter(Equation1[idx]))
            {
                s1 += Equation1[idx];
                idx--;
                if (idx < 0)
                    break;

            }
            char[] charArray = s1.ToArray();
            Array.Reverse(charArray);
            s1 = "";

            foreach(char ch in charArray)
            {
                s1 += ch;
            }
            varibales[0].Co1 = double.Parse(s1);
            idx = Equation2.IndexOf(varibales[0].ch);
            idx--;
            s1 = "";
            while (!char.IsLetter(Equation2[idx]))
            {
                s1 += Equation2[idx];
                idx--;
                if (idx < 0)
                    break;
            }
            charArray = s1.ToArray();
            Array.Reverse(charArray);
            s1 = "";
            foreach(char ch in charArray)
            {
                s1 += ch;
            }
            varibales[0].Co2 = double.Parse(s1);



            idx = Equation1.IndexOf(varibales[1].ch);
            idx--;
            s1 = "";
            while (!char.IsLetter(Equation1[idx]))
            {
                s1 += Equation1[idx];
                idx--;
                if (idx < 0)
                    break;

            }
            charArray = s1.ToArray();
            Array.Reverse(charArray);
            s1 = "";
            foreach(char ch in charArray)
            {
                s1 += ch;
            }
           
            varibales[1].Co1 = double.Parse(s1);
            idx = Equation2.IndexOf(varibales[1].ch);
            idx--;
            s1 = "";
            while (!char.IsLetter(Equation2[idx]))
            {
                s1 += Equation2[idx];
                idx--;
                if (idx < 0)
                    break;
            }
            charArray = s1.ToArray();
            Array.Reverse(charArray);
            s1 = "";
            foreach(char ch in charArray)
            {
                s1 += ch;
            }
            varibales[1].Co2 = double.Parse(s1);

            a[0] = varibales[0].Co1;
            a[1] = varibales[0].Co2;
            b[0] = varibales[1].Co1;
            b[1] = varibales[1].Co2;

            double det = a[0] * b[1] - a[1] * b[0];

            if (det == 0)
                throw new Exception();

            double det1 = c[0] * b[1] - c[1] * b[0];
            double det2 = a[0] * c[1] - a[1] * c[0];
            answers[0] = det1 / det;
            answers[1] = det2 / det;

            Answer[] ans = new Answer[2];

            ans[0] = new Answer(varibales[0].ch, answers[0]);
            ans[1] = new Answer(varibales[1].ch, answers[1]);

            

            return ans.ToList().OrderBy(d=>d.answer).ToArray();
        }
    

    }


    public class Answer
    {
        public char ch { get; set; }
        public double answer { get; set; }

        public Answer(char c, double ans)
        {
            this.ch = c;
            this.answer = ans;
        }
    }
    public class Var
    {
        public char ch { get; set; }
        public double  Co1 { get; set; }
        public double  Co2 { get; set; }

        public Var(char c)
        {
            this.ch = c;
            
        }

    }

    public class Clock
    {
        public int Second { get; set; }
        public int Minute { get; set; }
        public int Hour { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public Hand HourHand = new Hand();
        public Hand MinuteHand = new Hand();
        public Hand SecondHand = new Hand();

        public void UpdateClock()
        {
            UpdateMinuteHand();
            UpdateHourHand();
            UpdateSecondHand();
        }

        void UpdateMinuteHand()
        {
            //drawing last minutehand to hide
            this.Minute = DateTime.Now.Minute;
            MinuteHand.Angle = (this.Minute * 6 /*+ (int)(this.Second * 0.1)*/) * Math.PI / 180 - Math.PI / 2;
            //drawing new minutehand to update the clock
        }

        void UpdateHourHand()
        {
            //drawing last hourhand to hide
            this.Hour = DateTime.Now.Hour;
            HourHand.Angle = (((this.Hour % 12) * 30) + (int)(this.Minute * 0.5)) * Math.PI / 180 - Math.PI / 2;
            //drawing new hourhand to update the clock
        }

        void UpdateSecondHand()
        {
            //drawing last secondhand to hide
            this.Second = DateTime.Now.Second;
            SecondHand.Angle = (this.Second * 6) * Math.PI / 180 - Math.PI / 2;
            //drawing new secondhand to update the clock
        }

        public void ShowTime()
        {
            Console.Clear();
            Console.WriteLine($"{this.Hour} : {this.Minute} : {this.Second}");
            Console.WriteLine($"{this.HourHand.Angle} : {this.MinuteHand.Angle} : {this.SecondHand.Angle}");
        }
    }

    public class Hand
    {
        public int Length { get; set; }
        public double Thickness { get; set; }
        public double Angle { get; set; }
    }
}
