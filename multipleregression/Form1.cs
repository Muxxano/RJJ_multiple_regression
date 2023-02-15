using Accord.Statistics.Models.Regression.Linear;
using Accord.Statistics.Models.Regression.Fitting;
using Accord.Statistics.Testing;

namespace multipleregression
{
    public partial class Form1 : Form
    {
        private MultipleLinearRegression _regression;

        public Form1()
        {
            InitializeComponent();

            var hoursStudied = new[] { 2.0, 4.0, 5.0, 6.0, 3.0 };
            var coursesTaken = new[] { 3.0, 4.0, 2.0, 5.0, 2.0 };
            var marks = new[] { 60.0, 80.0, 70.0, 90.0, 65.0 };

            var learner = new OrdinaryLeastSquares();
            _regression = learner.Learn(hoursStudied.Zip(coursesTaken, (x, y) => new[] { x, y }).ToArray(), marks);

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