using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bresenham
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //用来存栅格的二维数组
        MyGrid[,] GridStore;

        //建立图层
        public Bitmap VectorMap;

        //栅格的大小为边长为len的正方形
        int len = 10;

        //三个bool值为了判断在画图时是否已经选择了起点或终点或圆心
        bool start=false, end=false, center=false;

        //用来判断选的是线还是圆
        bool line = false, arc = false;

        //三个点分别用来储存线的起点和终点和圆心,储存的是坐标变换之后的值
        Point start_point = new Point();
        Point end_point = new Point();
        Point center_point = new Point();

        //判断点击次数的变量
        int click_num = 0;

        //初始化界面，绘制栅格图形
        public void Start()
        {
            //确定图层的大小
            VectorMap = new Bitmap(PictureBox.Width, PictureBox.Height);

            //建立图层和画笔,用来绘制栅格
            PictureBox.Image = VectorMap;
            Graphics g = Graphics.FromImage(VectorMap);
            Pen mypen = new Pen(Color.FromArgb(255, 0, 0, 0));

            //开辟栅格数组
            //为了和栅格的顺序对上，加1，栅格数组下标从1开始
            GridStore = new MyGrid[(int)(PictureBox.Height / len+1 ), (int)(PictureBox.Width / len )+1];

            //把每一个栅格放到数组中
            int i, j;
            for (i = len; i < PictureBox.Height; i = i + len)
            {
                for (j = len; j < PictureBox.Width; j = j + len)
                {
                    //新建一个栅格类，为属性赋值然后添加到数组里
                    MyGrid onegride = new MyGrid();
                    onegride.AddX(j);
                    onegride.AddY(i);
                    onegride.AddWidth(len);
                    GridStore[(int)(i / len), (int)(j / len)] = onegride;

                    //绘制这个栅格的四条边
                    Point point1 = new Point(onegride.GetX(), onegride.GetY());
                    Point point2 = new Point(onegride.GetX() + len, onegride.GetY());
                    Point point3 = new Point(onegride.GetX() + len, onegride.GetY() + len);
                    Point point4 = new Point(onegride.GetX(), onegride.GetY() + len);
                    g.DrawLine(mypen, point1, point2);
                    g.DrawLine(mypen, point2, point3);
                    g.DrawLine(mypen, point3, point4);
                    g.DrawLine(mypen, point4, point1);
                }
            }
        }

        //加载栅格，但是不显示
        private void Form1_Load(object sender, EventArgs e)
        {

            this.StartPosition= FormStartPosition.Manual;
            this.Location = new Point(100, 100);

            //加载界面，除了工具栏外其它控件都不可见
            Start();
            PictureBox.Visible = false;
            start_button.Visible = false;
            end_button.Visible = false;
            draw_button.Visible = false;
            clean_button.Visible = false;
            center_button.Visible = false;
            radius_button.Visible = false;
            radius_box.Visible = false;
        }

        //选择画线
        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arc = false;
            line = true;
            //选择画线则将与线有关的所有控件可见
            PictureBox.Visible = true;
            start_button.Visible = true;
            end_button.Visible = true;
            draw_button.Visible = true;
            clean_button.Visible = true;

            //将画圆的控件隐藏
            center_button.Visible = false;
            radius_button.Visible = false;
            radius_box.Visible = false;

            //将圆的判断变为false
            center = false;
        }

        //选择画圆
        private void arcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arc = true;
            line = false;
            //选择画圆则将与圆有关的所有控件可见
            PictureBox.Visible = true;
            draw_button.Visible = true;
            clean_button.Visible = true;
            center_button.Visible = true;
            radius_button.Visible = true;
            radius_box.Visible = true;

            //将画线的控件隐藏
            start_button.Visible = false;
            end_button.Visible = false;

            //将线的判断变为false
            start = false;
            end = false;
        }

        //当点击了相应变量的按钮后将相应变量的判断条件变为true
        private void start_button_Click(object sender, EventArgs e)
        {
            start = true;
            if (click_num >= 1)
            {
                MessageBox.Show("请先选择终点");
                return;
            }
            click_num ++;
        }
        private void center_button_Click(object sender, EventArgs e)
        {
            center = true;
            click_num = 1;
        }
        private void end_button_Click(object sender, EventArgs e)
        {
            
            if (start==false)
            {
                MessageBox.Show("请先选择起点");
                return;
            }
            end = true;
            click_num ++;
        }

        //鼠标点击网格
        private void PictureBox_Click(object sender, EventArgs e)
        {          
            //获取鼠标点击的位置相对于picturebox左上角的坐标
            int x = MousePosition.X- PictureBox.Location.X-this.Location.X-20;
            int y = MousePosition.Y-PictureBox.Location.Y- this.Location.Y-40;

            //判断点击的位置是起点、终点、还是圆心
            //确定了之后将对应的栅格填充颜色
            if(start==true &&end==false &&center==false)
            {
                if(click_num==1)
                {
                    start_point.X = x/len +1;
                    start_point.Y = y/len+1;
                    draw_point(start_point);
                }
                else
                {
                    MessageBox.Show("请选择终点");
                    return;
                }
            }
            if (start == true && end == true && center == false)
            {
                if(click_num==2)
                {
                    end_point.X = x/len+1;
                    end_point.Y = y/len+1;
                    draw_point(end_point);
                }
                else if(click_num==1)
                {
                    MessageBox.Show("请选择终点");
                    return;
                }
                else
                {
                    MessageBox.Show("请画图");
                    return;
                }
            }
            if (start == false && end == true && center == false)
            {
                MessageBox.Show("请先选择起点");
                return;
            }
            if (start == false && end == false && center == true)
            {
                if(click_num==1)
                {
                    center_point.X = x/len+1;
                    center_point.Y = y/len+1;
                    draw_point(center_point);
                }
                else
                {
                    MessageBox.Show("请输入半径或画图");
                    return;
                }
            }
        }

        //将对应的点填充上颜色,传入的是除以len之后的坐标
        public void draw_point(Point a)
        {
            int x = a.X;
            int y = a.Y;
            GridStore[y, x].AddColor();
            PictureBox.Image = VectorMap;
            Graphics g = Graphics.FromImage(VectorMap);
            SolidBrush OneBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
            g.FillRectangle(OneBrush, GridStore[y, x].GetX(), GridStore[y, x].GetY(), GridStore[y, x].GetWidth(), GridStore[y, x].GetWidth());
        }

        //在网格上画图
        private void draw_button_Click(object sender, EventArgs e)
        {
            //排除没有起点，终点，圆心，半径的情况
            if (start == true && end == false && center == false)
            {
                MessageBox.Show("请选择终点");
                return;
            }
            else if (start == false && end == false && center == false&&arc==true)
            {
                MessageBox.Show("请选择圆心或输入半径");
                return;
            }
            else if (start == false && end == false && center == false&&line==true)
            {
                MessageBox.Show("请先选择起点");
                return;
            }
            else if (start == false && end == false && center == true&&radius_box.Text=="")
            {
                MessageBox.Show("请输入半径");
                return;
            }
            //排除所有意外后开始画图
            else
            {
                //画线
                if(line==true)
                {
                    //因为坐标不一样，pixturebox中y轴由上往下增大，所以deltay要变符号
                    int deltay = 0 -(end_point.Y - start_point.Y);
                    int deltax = end_point.X - start_point.X;

                    int x = start_point.X;
                    int y = start_point.Y;

                    //y方向变化大
                    if (Math.Abs(deltay) > Math.Abs(deltax))
                    {
                        //往上走，y坐标变小
                        if (deltay >= 0)
                        {
                            //往右走，x坐标变大
                            if (deltax >= 0)
                            {
                                //决策参数
                                int f = 2 * deltax - deltay;
                                for (int i = 0; i <= deltay; i++)
                                {
                                    Point one_point = new Point(x, y);
                                    draw_point(one_point);
                                    if (f >= 0)
                                    {
                                       x++;
                                        f = f - 2 * deltay;
                                    }

                                    //x坐标一直变大
                                    y--;
                                    f = f + 2 * deltax;
                                }
                            }

                            //往左走，x坐标变小
                            if (deltax < 0)
                            {
                                //决策参数
                                int f = -2 * deltax - deltay;
                                for (int i = 0; i <= deltay; i++)
                                {
                                    Point one_point = new Point(x, y);
                                    draw_point(one_point);
                                    if (f >= 0)
                                    {
                                       x--;
                                        f = f - 2 * deltay;
                                    }

                                    //y坐标一直变小
                                    y--;
                                    f = f - 2 * deltax;
                                }
                            }
                        }

                        //往下走，y坐标变大
                        if (deltay < 0)
                        {
                            //往右走，x坐标变大
                            if (deltax >= 0)
                            {
                                //决策参数
                                int f = 2 * deltax + deltay;
                                for (int i = 0; i <= -deltay; i++)
                                {
                                    Point one_point = new Point(x, y);
                                    draw_point(one_point);
                                    if (f >= 0)
                                    {
                                       x++;
                                        f = f + 2 * deltay;
                                    }

                                    //y坐标一直变大
                                   y++;
                                    f = f + 2 * deltax;
                                }
                            }

                            //往左走，x坐标变小
                            if (deltax < 0)
                            {
                                //决策参数
                                int f = -2 * deltax + deltay;
                                for (int i = 0; i <= -deltay; i++)
                                {
                                    Point one_point = new Point(x, y);
                                    draw_point(one_point);
                                    if (f >= 0)
                                    {
                                       x--;
                                        f = f + 2 * deltay;
                                    }

                                    //y坐标一直变大
                                    y++;
                                    f = f - 2 * deltax;
                                }
                            }
                        }
                    }

                    //x方向变化大
                    if (Math.Abs(deltax) >= Math.Abs(deltay))
                    {
                        //往右走,x变大
                        if (deltax >= 0)
                        {
                            //往上走，y坐标变小
                            if (deltay >= 0)
                            {
                                //决策参数
                                int f = 2 * deltay - deltax;
                                for (int i = 0; i <= deltax; i++)
                                {
                                    Point one_point = new Point(x, y);
                                    draw_point(one_point);
                                    if (f >= 0)
                                    {
                                        y--;
                                        f = f - 2 * deltax;
                                    }

                                    //x坐标一直变大
                                    x++;
                                    f = f + 2 * deltay;
                                }
                            }

                            //往下走,y变大
                            if (deltay < 0)
                            {
                                //决策参数
                                int f = -2 * deltay - deltax;
                                for (int i = 0; i <= deltax; i++)
                                {
                                    Point one_point = new Point(x, y);
                                    draw_point(one_point);
                                    if (f >= 0)
                                    {
                                        y++;
                                        f = f - 2 * deltax;
                                    }

                                    //x坐标一直变大
                                    x++;
                                    f = f - 2 * deltay;
                                }
                            }
                        }

                        //往左走，x变小
                        if (deltax < 0)
                        {
                            //往上走，y坐标变小
                            if (deltay >= 0)
                            {
                                //决策参数
                                int f = 2 * deltay + deltax;
                                for (int i = 0; i <= -deltax; i++)
                                {
                                    Point one_point = new Point(x, y);
                                    draw_point(one_point);
                                    if (f >= 0)
                                    {
                                        y--;
                                        f = f + 2 * deltax;
                                    }

                                    //x坐标一直变大
                                    x--;
                                    f = f + 2 * deltay;
                                }
                            }

                            //往下走，y变大
                            if (deltay < 0)
                            {
                                //决策参数
                                int f = -2 * deltay + deltax;
                                for (int i = 0; i <= -deltax; i++)
                                {
                                    Point one_point = new Point(x, y);
                                    draw_point(one_point);
                                    if (f >= 0)
                                    {
                                        y++;
                                        f = f + 2 * deltax;
                                    }

                                    //x坐标一直变小
                                    x--;
                                    f = f - 2 * deltay;
                                }
                            }
                        }
                    } 
                }

                //画圆
                if(arc==true)
                {
                    string num= radius_box.Text;
                    int r = int.Parse(num);
                    int x0 = center_point.X;
                    int x= center_point.X;
                    int y0 = center_point.Y;
                    int y = center_point.Y - r;

                    int max = Math.Min(PictureBox.Height / len-1-y0, PictureBox.Width / len-1-x0);
                    max = Math.Min(y0-1, max);
                    max = Math.Min(x0-1, max);
                    if (r>max)
                    {
                        string text = max.ToString();
                        MessageBox.Show("最大半径为" + text);
                        radius_box.Text = "";
                        return;
                    }
                    if(r<0)
                    {
                        MessageBox.Show("半径必须不小于0");
                        return;
                    }

                    //决策因子
                    int d = 3 - 2 *r;

                    while(x+y<x0+y0)
                    {
                        //对称的画8个点
                        Point onepoint = new Point(x, y);
                        draw_point(onepoint);

                        onepoint.X = x;
                        onepoint.Y = y0 * 2 - y;
                        draw_point(onepoint);

                        onepoint.X = y-y0+x0;
                        onepoint.Y = x0-x+y0;
                        draw_point(onepoint);

                        onepoint.X = y - y0 + x0;
                        onepoint.Y = y0-x0+x;
                        draw_point(onepoint);

                        onepoint.X = x0 * 2 - x;
                        onepoint.Y = y;
                        draw_point(onepoint);

                        onepoint.X =x0-y+y0;
                        onepoint.Y = y0-x0+x;
                        draw_point(onepoint);

                        onepoint.X = x0 - y + y0;
                        onepoint.Y = x0-x+y0;
                        draw_point(onepoint);

                        onepoint.X = x0*2-x;
                        onepoint.Y = y0 * 2 - y;
                        draw_point(onepoint);

                        if (d<0)
                        {
                            d = d + 4 * (x-x0) + 6;
                        }
                        else
                        {
                            //因为有坐标系的变化需要平移和对称
                            d = d + 4 * ((x-x0) - (y0-y)) + 10;
                            y = y + 1;
                        }
                        x = x + 1;
                    }
                    if((x+y)==(x0+y0))
                    {
                        Point onepoint = new Point(x, y);
                        draw_point(onepoint);

                        onepoint.X = x;
                        onepoint.Y = y0 * 2 - y;
                        draw_point(onepoint);

                        onepoint.X = y-y0+x0;
                        onepoint.Y = x0-x+y0;
                        draw_point(onepoint);

                        onepoint.X = y - y0 + x0;
                        onepoint.Y = y0-x0+x;
                        draw_point(onepoint);

                        onepoint.X = x0 * 2 - x;
                        onepoint.Y = y;
                        draw_point(onepoint);

                        onepoint.X =x0-y+y0;
                        onepoint.Y = y0-x0+x;
                        draw_point(onepoint);

                        onepoint.X = x0 - y + y0;
                        onepoint.Y = x0-x+y0;
                        draw_point(onepoint);

                        onepoint.X = x0*2-x;
                        onepoint.Y = y0 * 2 - y;
                        draw_point(onepoint);

                    }
                }

                //每画完一个图点击次数归零
                click_num = 0;

                //参数归零
                start = false;
                end = false;
                center = false;
                click_num = 0;
                radius_box.Text = "";
            }
        }

        //清空网格
        private void clean_button_Click(object sender, EventArgs e)
        {
            //将所有栅格的颜色填充为白色，并将颜色属性改为false
            PictureBox.Image = VectorMap;
            Graphics g = Graphics.FromImage(VectorMap);
            SolidBrush OneBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
            Pen mypen = new Pen(Color.FromArgb(255, 0, 0, 0));

            int i, j;
            for (i = len; i < PictureBox.Height; i = i + len)
            {
                for (j = len; j < PictureBox.Width; j = j + len)
                {
                    //用白色填充
                    GridStore[(int)(i / len), (int)(j / len)].CleanColor();
                    g.FillRectangle(OneBrush, GridStore[(int)(i / len), (int)(j / len)].GetX(), GridStore[(int)(i / len), (int)(j / len)].GetY(), GridStore[(int)(i / len), (int)(j / len)].GetWidth(), GridStore[(int)(i / len), (int)(j / len)].GetWidth());

                    //重新绘制一遍网格
                    Point point1 = new Point(GridStore[(int)(i / len), (int)(j / len)].GetX(), GridStore[(int)(i / len), (int)(j / len)].GetY());
                    Point point2 = new Point(GridStore[(int)(i / len), (int)(j / len)].GetX() + len, GridStore[(int)(i / len), (int)(j / len)].GetY());
                    Point point3 = new Point(GridStore[(int)(i / len), (int)(j / len)].GetX() + len, GridStore[(int)(i / len), (int)(j / len)].GetY() + len);
                    Point point4 = new Point(GridStore[(int)(i / len), (int)(j / len)].GetX(), GridStore[(int)(i / len), (int)(j / len)].GetY() + len);
                    g.DrawLine(mypen, point1, point2);
                    g.DrawLine(mypen, point2, point3);
                    g.DrawLine(mypen, point3, point4);
                    g.DrawLine(mypen, point4, point1);
                }
            }

            //参数归零
            start = false;
            end = false;
            center = false;
            click_num = 0;
        }
    }
}
