using DSkin.DirectUI;
using DSkin.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CPetMain.Sports
{
    public class Sport
    {
        //1.站立-静止-地面：1
        //2.走路-移动-地面：2-3-48-47
        //3.跑-移动-地面：49-50-51-52
        //4.坐-静止-地面：11
        //5.坐着抬头看-静止-地面：26
        //6.坐着抬头看鼠标-静止-地面：26，11
        //7.撒花：15-16-17-104-105-106-107-108-109-110-111-112
        //8.打枪：30-31-32-31
        //9.趴着：21
        //10.趴着拍打地面：20-21-20-94
        //11.抓住天花板-静止-顶部：23
        //12.顺着天花板-移动-顶部：25-25-23-24-24-24-23-25
        //13.靠墙-移动-左侧：14-14-12-13-13-13-12-14
        //14.带着IE掉下来-嵌入:36
        //15.带着IE走路-地面-嵌入：34-35-37-36
        //16.投IE-地面-嵌入：38
        //17.跳跃-嵌入：22
        //18.坠落-嵌入：4-53-4-54
        //19.坠落后撩头发：55-56-57-58-59-60-61-62-63
        //20.摔倒-固定-地面：19-18-19-18-21-21
        //21.拎起来后抵抗-嵌入：5-6-5-6-96-97-98-95-99-95-99-95-99-95-99-95-99-95-100-101-100-101-5-6-5-6-5-6-102-103
        //22.变身1-固定-地面：73-76-77-78-74-75-70-79-80
        //23.变身2-静止-地面：80
        //24.不要不要：66-71-66-72
        //25.抓住窗口：9-9-9
        string path = "img/pet/default/";

        private string format(int i=1)
        {
            return path+ "shime" + i+ ".png";
        }
        public Bitmap[] getDrop(int type = 1)
        {
            int[] i;
            switch (type)
            {
                case 1:
                    i = new int[] { 9, 7 };
                    break;
                case 3:
                    i = new int[] { 8,10 };
                    break;
                default:
                    i = new int[] { 69, 68, 69, 68, 69, 68 };
                    break;
            }
            return init(i);
        }
        public Bitmap[] getBmp(int type=1)
        {
            int[] i;
            switch (type)
            {
                case 2:
                    i = new int[] {2,3,48,47};
                    break;
                case 3:
                    i = new int[] { 49, 50, 51,52 };
                    break;
                case 4:
                    i = new int[] { 11 };
                    break;
                case 5:
                    i = new int[] { 26 };
                    break;
                case 6:
                    i = new int[] { 26,11 };
                    break;
                case 7:
                    i = new int[] { 15,16,17,104,105,106,107,108,109,110,111,112 };
                    break;
                case 8:
                    i = new int[] { 30,31,32,31 };
                    break;
                case 9:
                    i = new int[] { 21 };
                    break;
                case 10:
                    i = new int[] { 20 , 21 , 20 , 94 };
                    break;
                case 11:
                    i = new int[] { 23 };
                    break;
                case 12:
                    i = new int[] { 25 , 25 , 23 , 24 , 24 , 24 , 23 , 25 };
                    break;
                case 13:
                    i = new int[] { 14 , 14 , 12 , 13 , 13 , 13 , 12 , 14 };
                    break;
                case 14:
                    i = new int[] { 36 };
                    break;
                case 15:
                    i = new int[] { 34 , 35 , 37 , 36 };
                    break;
                case 16:
                    i = new int[] { 38 };
                    break;
                case 17:
                    i = new int[] { 22 };
                    break;
                case 18:
                    i = new int[] { 4 , 53 , 4 , 54 };
                    break;
                case 19:
                    i = new int[] { 55 , 56 , 57 , 58 , 59 , 60 , 61 , 62 , 63 };
                    break;
                case 20:
                    i = new int[] { 19 , 18 , 19 , 18 , 21 , 21 };
                    break;
                
                case 21:
                    i = new int[] { 5, 6 , 5 , 6 , 96, 97 ,98 , 95, 99 , 95, 99 , 95 , 99 , 95, 99 , 95, 99 , 95 , 100 , 101, 100 , 101, 5, 6, 5, 6 , 5 , 6, 102, 103 };
                    break;
                case 22:
                    i = new int[] { 73 , 76 , 77 , 78 , 74 , 75 , 70 , 79 , 80 };
                    break;
                case 23:
                    i = new int[] { 80 };
                    break;
                case 24:
                    i = new int[] { 66 , 71 ,66, 72 };
                    break;
                case 25:
                    i = new int[] { 9 , 9 , 9 };
                    break;
                default:
                    i = new int[]{1};
                    break;
            }
            return init(i);
        }

        private Bitmap[] init(int[] i)
        {
            Bitmap[] map = new Bitmap[i.Count()];
            for(int j=0;j<i.Count();j++)
            {
                map[j] = (Bitmap)Image.FromFile(format(i[j]));
            }
            return map;
        }
    }
}
