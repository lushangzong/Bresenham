using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bresenham
{
    class MyGrid
    {
        //左上角点的横坐标
        int x;

        //左上角点的纵坐标
        int y;

        //正方形的大小
        int width;

        //是否上色
        bool color = false;

        //添加属性
        public void AddX(int X)
        {
            x = X;
        }
        public void AddY(int Y)
        {
            y = Y;
        }
        public void AddWidth(int Width)
        {
            width = Width;
        }
        public void AddColor()
        {
            color=true;
        }
        public void CleanColor()
        {
            color = false;
        }

        //返回属性值
        public int GetWidth()
        {
            return width;
        }
        
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        
    }
}
