using weka.classifiers;
using weka.core;

namespace ProbabilityPredictor
{
    public class J48Predictor
    {
        private Classifier cl;

        private Instances header;

        public J48Predictor()
        {
            init();
        }

        /// <summary>
        /// 初始化分类器
        /// </summary>
        private void init()
        {
            object[] arr = SerializationHelper.readAll("Resources/j48.save");
            cl = (Classifier)arr[0];
            header = (Instances)arr[1];
        }

        /// <summary>
        /// 获取概率
        /// </summary>
        /// <param name="age">年龄</param>
        /// <param name="gender">性别</param>
        /// <param name="isOut">是否有过海外求学经历</param>
        /// <param name="isMBA">是否读过MBA</param>
        /// <param name="school">学校</param>
        /// <param name="degree">学历</param>
        /// <param name="major">专业</param>
        /// <param name="address">地址</param>
        /// <returns></returns>
        public double[] getProbabilities(double age,
            double gender,
            double isOut,
            double isMBA,
            double school,
            double degree,
            double major,
            double address)
        {
            Instance inst = new DenseInstance(header.numAttributes());
            inst.setDataset(header);
            inst.setValue(0, age);
            inst.setValue(1, gender);
            inst.setValue(2, isOut);
            inst.setValue(3, isMBA);
            inst.setValue(4, school);
            inst.setValue(5, degree);
            inst.setValue(6, major);
            inst.setValue(7, address);
            inst.setValue(8, 0);
            return cl.distributionForInstance(inst);
        }
    }
}
