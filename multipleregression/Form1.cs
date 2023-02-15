using Accord.Statistics.Models.Regression.Linear;
using Accord.Statistics.Models.Regression.Fitting;
using Accord.Statistics.Testing;
using Microsoft.VisualBasic.FileIO;


namespace multipleregression
{
    public partial class Form1 : Form
    {
        private MultipleLinearRegression _regression;

        public Form1()
        {
            InitializeComponent();

            /* var hoursStudied = new[] { 2.0, 4.0, 5.0, 6.0, 3.0 };
             var coursesTaken = new[] { 3.0, 4.0, 2.0, 5.0, 2.0 };
             var marks = new[] { 60.0, 80.0, 70.0, 90.0, 65.0 };*/

            

            // ...

            string path = @"C:\Users\Lenovo\Downloads\Student_Marks.csv";
            List<double> hoursStudied = new List<double>();
            List<double> coursesTaken = new List<double>();
            List<double> marks = new List<double>();

            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    double hours, courses, mark;

                    if (double.TryParse(fields[0], out hours) &&
                        double.TryParse(fields[1], out courses) &&
                        double.TryParse(fields[2], out mark))
                    {
                        hoursStudied.Add(hours);
                        coursesTaken.Add(courses);
                        marks.Add(mark);
                    }
                }
            }
            double[] hours_final = hoursStudied.ToArray();
            double[] courses_final = coursesTaken.ToArray();
            double[] marks_final = marks.ToArray();

            // Now you can use the hoursStudied, coursesTaken, and marks lists
            // to train your machine learning model or perform other data analysis.


            var learner = new OrdinaryLeastSquares();
            _regression = learner.Learn(hours_final.Zip(courses_final, (x, y) => new[] { x, y }).ToArray(), marks_final);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the input data from the form
            var hoursStudied = double.Parse(hoursTextBox.Text);
            var coursesTaken = double.Parse(courses.Text);

            // Make a prediction using the multiple linear regression model
            var prediction = _regression.Transform(new[] { hoursStudied, coursesTaken });

            // Update the output label
            output.Text = prediction.ToString("F2");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}