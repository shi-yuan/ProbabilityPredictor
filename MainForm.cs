using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;

namespace ProbabilityPredictor
{
    public partial class MainForm : XtraForm
    {
        private J48Predictor predicator;

        private Dictionary<string, int> schools = new Dictionary<string, int>();
        private Dictionary<string, int> degrees = new Dictionary<string, int>();
        private Dictionary<string, int> majors = new Dictionary<string, int>();
        private Dictionary<string, int> addresses = new Dictionary<string, int>();

        public MainForm(J48Predictor predicator)
        {
            InitializeComponent();
            this.predicator = predicator;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 学校
            schools.Add("TOP2", 1);
            schools.Add("985", 2);
            schools.Add("211", 3);
            schools.Add("海外", 4);
            schools.Add("其他", 5);
            comboBox_school.Properties.Items.AddRange(schools.Keys);

            // 学历
            degrees.Add("博士", 1);
            degrees.Add("硕士", 2);
            degrees.Add("MBA/EMBA", 2);
            degrees.Add("本科", 3);
            degrees.Add("专科", 4);
            degrees.Add("其他", 4);
            comboBox_degree.Properties.Items.AddRange(degrees.Keys);

            // 专业
            majors.Add("经济管理类", 1);
            majors.Add("计算机通信电子类", 2);
            majors.Add("理科基础学科类", 3);
            majors.Add("其他", 4);
            comboBox_major.Properties.Items.AddRange(majors.Keys);

            // 地区
            addresses.Add("浙江", 1);
            addresses.Add("广东", 2);
            addresses.Add("北京", 3);
            addresses.Add("安徽", 4);
            addresses.Add("湖北", 4);
            addresses.Add("陕西", 4);
            addresses.Add("福建", 5);
            addresses.Add("湖南", 5);
            addresses.Add("江苏", 5);
            addresses.Add("其他", 6);
            comboBox_addr.Properties.Items.AddRange(addresses.Keys);
        }

        private void btn_predicate_Click(object sender, EventArgs e)
        {
            // 年龄
            double age = Convert.ToDouble(spinEdit_age.EditValue);

            // 性别
            double gender = "男".CompareTo(comboBox_gender.EditValue) == 0 ? 1 : 0;

            // 是否海外求学
            double isOut = "有".CompareTo(comboBox_out.EditValue) == 0 ? 1 : 0;

            // 是否读MBA
            double isMBA = "有".CompareTo(comboBox_mba.EditValue) == 0 ? 1 : 0;

            // 学校
            string v = comboBox_school.EditValue as string;
            int school;
            schools.TryGetValue(v, out school);

            // 学历
            v = comboBox_degree.EditValue as string;
            int degree;
            degrees.TryGetValue(v, out degree);

            // 专业
            v = comboBox_major.EditValue as string;
            int major;
            majors.TryGetValue(v, out major);

            // 地址
            v = comboBox_addr.EditValue as string;
            int addr;
            addresses.TryGetValue(v, out addr);

            double[] arr = predicator.getProbabilities(
                    age,
                    gender,
                    isOut,
                    isMBA,
                    school,
                    degree,
                    major,
                    addr
                );
            memoEdit_probability.Text = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}\r\n{8}, {9}",
                age, gender, isOut, isMBA, school, degree, major, addr, arr[0], arr[1]);
        }
    }
}
